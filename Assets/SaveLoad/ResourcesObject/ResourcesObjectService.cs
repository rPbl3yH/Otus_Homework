using System.Collections.Generic;
using Homeworks.SaveLoad;
using SaveLoad.GameManagement;
using UnityEngine;

namespace SaveLoad.ResourcesObject
{
    public class ResourcesObjectService
    {
        private ResourceObject[] _resourceObjects;

        public ResourcesObjectService(ResourceObject[] resourceObjects)
        {
            _resourceObjects = resourceObjects;
            ServiceLocator.AddService(this);
        }

        public void SetupData(ResourcesObjectData[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                var resource = _resourceObjects[i];
                var resourceData = data[i];
                resource.resourceType = (ResourceType)resourceData.ResourceTypeIndex;
                resource.remainingCount = resourceData.RemainingCount;
                resource.transform.position = new Vector3(
                    resourceData.Position[0], 
                    resourceData.Position[1],
                    resourceData.Position[2]);
            }
        }

        public void SetupDefault()
        {
            
        }

        public ResourcesObjectData[] GetResourcesData()
        {
            var result = new List<ResourcesObjectData>();
            foreach (var resourceObject in _resourceObjects)
            {
                var position = resourceObject.transform.position;
                result.Add(new ResourcesObjectData()
                {
                    ResourceTypeIndex = (int)resourceObject.resourceType,
                    RemainingCount = resourceObject.remainingCount,
                    Position = new []
                    {
                      position.x,
                      position.y,
                      position.z
                    },
                });
            }

            return result.ToArray();
        } 
    }

    public class ResourcesObjectData
    {
        public int ResourceTypeIndex;
        public int RemainingCount;
        public float[] Position = new float[3];
    }
}