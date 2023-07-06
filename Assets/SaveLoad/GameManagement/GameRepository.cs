using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveLoad.GameManagement
{
    public class GameRepository
    {
        private const string GAME_PREFS = "GameState";
        private Dictionary<string, string> gameState = new Dictionary<string, string>();

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

            if (PlayerPrefs.HasKey(GAME_PREFS))
            {
                var localJson = PlayerPrefs.GetString(GAME_PREFS);
                localState = JsonConvert.DeserializeObject<Dictionary<string, string>>(localJson);
            }
        }

        public void SaveState()
        {
            var json = JsonConvert.SerializeObject(gameState);
            PlayerPrefs.SetString(GAME_PREFS, json);
        }
    }
}