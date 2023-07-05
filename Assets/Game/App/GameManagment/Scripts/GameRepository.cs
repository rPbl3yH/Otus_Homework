using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Services;
using UnityEngine;

namespace Game.App
{
    public sealed class GameRepository
    {
        private static readonly DateTime originTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        private const string SAVE_TIME_KEY = "saveTime";

        private const string GAME_PREFS = "GameState";
        
        private GameClient client;
        
        private Dictionary<string, string> gameState;

        private bool isSaving;

        [ServiceInject]
        public void Construct(GameClient client)
        {
            this.client = client;
        }

        public bool TryGetData(string key, out string data)
        {
            return this.gameState.TryGetValue(key, out data);
        }

        public string GetData(string data)
        {
            return this.gameState[data];
        }

        public void SetData(string key, string data)
        {
            this.gameState[key] = data;
        } 

        public async Task LoadState()
        {
            //Load local game state:
            Dictionary<string, string> localState = new();
            long localSaveTime = -1; 
            if (PlayerPrefs.HasKey(GAME_PREFS))
            {
                var localJson = PlayerPrefs.GetString(GAME_PREFS);
                localState = JsonConvert.DeserializeObject<Dictionary<string, string>>(localJson);
                localSaveTime = long.Parse(localState[SAVE_TIME_KEY]);
            }

            //Load remote game state:
            Dictionary<string, string> remoteState = new();
            long remoteSaveTime = -1;
            
            var (success, remoteJson) = await this.client.DownloadState();
            if (success)
            {
                remoteState = JsonConvert.DeserializeObject<Dictionary<string, string>>(remoteJson);
                remoteSaveTime = long.Parse(remoteState[SAVE_TIME_KEY]);   
            }

            //Select recent game state:
            if (remoteSaveTime > localSaveTime)
            {
                this.gameState = remoteState;
            }
            else
            {
                this.gameState = localState;
            }
        }

        public async void SaveState()
        {
            if (this.isSaving)
            {
                return;
            }
            
            this.isSaving = true;
            
            //Update save time:
            var time = DateTime.Now.ToUniversalTime() - originTime;
            var saveTime = time.TotalSeconds.ToString("F0");
            this.gameState[SAVE_TIME_KEY] = saveTime;
            
            //Save game state:
            var json = JsonConvert.SerializeObject(this.gameState);
            PlayerPrefs.SetString(GAME_PREFS, json);
            await this.client.UploadState(json);
            
            this.isSaving = false;
        }
    }
}