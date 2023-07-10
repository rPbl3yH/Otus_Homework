using System.Collections.Generic;
using Homeworks.SaveLoad;
using SaveLoad.GameManagement;
using UnityEngine;

namespace SaveLoad.ResourcesObject.Mediator
{
    public class ResourcesObjectMediator : GameMediator<ResourcesObjectData[], ResourcesObjectService>
    {
        protected override void SetupFromData(ResourcesObjectService service, ResourcesObjectData[] data)
        {
            var resourceObjects = service.GetResourceObjects();
            
            for (int i = 0; i < data.Length; i++)
            {
                var resource = resourceObjects[i];
                var resourceData = data[i];
                resource.resourceType = (ResourceType)resourceData.ResourceTypeIndex;
                resource.remainingCount = resourceData.RemainingCount;
                resource.transform.position = new Vector3(
                    resourceData.Position[0], 
                    resourceData.Position[1],
                    resourceData.Position[2]);
            }
        }

        protected override void SetupByDefault(ResourcesObjectService service)
        {
            var objects = service.GetResourceObjects();
            objects = new List<ResourceObject>();
        }

        protected override ResourcesObjectData[] ConvertToData(ResourcesObjectService service)
        {
            var resourceObjects = service.GetResourceObjects();
            var resourcesObjectData = new ResourcesObjectData[resourceObjects.Count];

            for (int i = 0; i < resourceObjects.Count; i++)
            {
                var resourceObject = resourceObjects[i];
                var position = resourceObject.transform.position;

                resourcesObjectData[i] = new ResourcesObjectData()
                {
                    ResourceTypeIndex = (int)resourceObject.resourceType,
                    RemainingCount = resourceObject.remainingCount,
                    Position = new []
                    {
                        position.x,
                        position.y,
                        position.z
                    },
                };
            }

            return resourcesObjectData;
        }
    }
}