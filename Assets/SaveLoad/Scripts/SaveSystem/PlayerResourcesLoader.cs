using System.IO;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.SaveLoad.SaveSystem
{
    public class PlayerResourcesLoader : MonoBehaviour
    {
        private const string ResourcesSaveKey = "KeyResources"; 
        
        [SerializeField]
        private PlayerResources _playerResources;
        
        [ShowInInspector]
        public void Save()
        {
            var resources = _playerResources.GetResources();
            var json = JsonConvert.SerializeObject(resources, Formatting.Indented);
            PlayerPrefs.SetString(ResourcesSaveKey, json);
            //File.WriteAllText();
            print("Save " + json);
        }

        [ShowInInspector]
        public PlayerResources Load()
        {
            var json = PlayerPrefs.GetString(ResourcesSaveKey);
            var resources = JsonConvert.DeserializeObject<PlayerResources>(json);
            print("Load " + json);
            return resources;
        }
    }
}