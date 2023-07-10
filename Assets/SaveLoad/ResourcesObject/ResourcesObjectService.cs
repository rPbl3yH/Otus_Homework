using System.Collections.Generic;
using Homeworks.SaveLoad;
using SaveLoad.GameManagement;
using UnityEngine;

namespace SaveLoad.ResourcesObject
{
    public class ResourcesObjectService
    {
        private List<ResourceObject> _resourceObjects;

        public ResourcesObjectService(List<ResourceObject> resourceObjects)
        {
            _resourceObjects = resourceObjects;
            ServiceLocator.AddService(this);
        }

        public List<ResourceObject> GetResourceObjects()
        {
            return _resourceObjects;
        }
    }

    public class ResourcesObjectData
    {
        public int ResourceTypeIndex;
        public int RemainingCount;
        public float[] Position = new float[3];
    }
}