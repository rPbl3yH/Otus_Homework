using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveLoad.GameManagement
{
    public class GameRepository
    {
        private const string GamePrefs = "GameState";
        private const string Password = "lksdfj2lafsd";
        private Dictionary<string, string> gameState = new Dictionary<string, string>();
        private ES3Settings _settings = new ES3Settings(ES3.EncryptionType.AES, Password);
        
        public bool TryGetData(string key, out string data)
        {
            return gameState.TryGetValue(key, out data);
        }

        public string GetData(string data)
        {
            return gameState[data];
        }

        public void SetData(string key, string data)
        {
            gameState[key] = data;
        } 

        public void LoadState()
        {
            Dictionary<string, string> localState = new();

            if (ES3.KeyExists(GamePrefs))
            {
                var localJson = ES3.Load<string>(GamePrefs);
                Debug.Log(localJson);
                localState = JsonConvert.DeserializeObject<Dictionary<string, string>>(localJson);
            }
        }

        public void SaveState()
        {
            var json = JsonConvert.SerializeObject(gameState);
            ES3.Save(GamePrefs, json);
            //PlayerPrefs.SetString(GamePrefs, json);
        }
    }
}