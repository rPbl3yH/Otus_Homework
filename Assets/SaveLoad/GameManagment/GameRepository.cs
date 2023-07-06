using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveLoad.SaveSystem
{
    public class GameRepository
    {
        private const string GAME_PREFS = "GameState";
        private Dictionary<string, string> _gameState = new();


        public bool TryGetData(string key, out string data)
        {
            return _gameState.TryGetValue(key, out data);
        }

        public string GetData(string data)
        {
            return _gameState[data];
        }

        public void SetData(string key, string data)
        {
            _gameState[key] = data;
        } 

        public async Task LoadState()
        {
            
            Dictionary<string, string> localState = new();
            
            if (PlayerPrefs.HasKey(GAME_PREFS))
            {
                var localJson = PlayerPrefs.GetString(GAME_PREFS);
                localState = JsonConvert.DeserializeObject<Dictionary<string, string>>(localJson);
            }

            await Task.Delay(1000);
        }

        public void SaveState()
        {
            var json = JsonConvert.SerializeObject(_gameState);
            PlayerPrefs.SetString(GAME_PREFS, json);
        }
    }
}