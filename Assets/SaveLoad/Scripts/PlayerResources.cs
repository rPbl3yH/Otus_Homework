using System.Collections.Generic;
using Homeworks.SaveLoad;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SaveLoad.Scripts
{
    public sealed class PlayerResources : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        private Dictionary<ResourceType, int> _resources = new();

        public void SetResource(ResourceType resourceType, int resource)
        {
            _resources[resourceType] = resource;
        }
        
        public int GetResource(ResourceType resourceType)
        {
            return _resources[resourceType];
        }

        public Dictionary<ResourceType, int> GetResources()
        {
            return _resources;
        }

        [ShowInInspector]
        public void AddResources(ResourceType resourceType, int resource)
        {
            if (_resources.ContainsKey(resourceType))
            {
                _resources[resourceType] += resource;
            }
            else
            {
                _resources.Add(resourceType, resource);
            }
        }

        public void SetupResources(Dictionary<ResourceType,int> resources)
        {
            _resources = resources;
        }
    }
}