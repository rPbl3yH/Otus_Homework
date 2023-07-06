using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.SaveLoad
{
    public sealed class PlayerResources : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        private Dictionary<ResourceType, int> _resources = new();

        public void SetResource(ResourceType resourceType, int resource)
        {
            this._resources[resourceType] = resource;
        }
        
        public int GetResource(ResourceType resourceType)
        {
            return this._resources[resourceType];
        }

        public Dictionary<ResourceType, int> GetResources()
        {
            return _resources;
        }

        public void SetupResources(Dictionary<ResourceType,int> resources)
        {
            foreach (var resource in resources)
            {
                SetResource(resource.Key, resource.Value);
            }
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
    }
}