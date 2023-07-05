using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.SaveLoad
{
    public sealed class PlayerResources : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        private Dictionary<ResourceType, int> resources = new();

        public void SetResource(ResourceType resourceType, int resource)
        {
            this.resources[resourceType] = resource;
        }
        
        public int GetResource(ResourceType resourceType)
        {
            return this.resources[resourceType];
        }

        public Dictionary<ResourceType, int> GetResources()
        {
            return resources;
        }

        [ShowInInspector]
        public void AddResources(ResourceType resourceType, int resource)
        {
            if (resources.ContainsKey(resourceType))
            {
                resources[resourceType] += resource;
            }
            else
            {
                resources.Add(resourceType, resource);
            }
        }
    }
}