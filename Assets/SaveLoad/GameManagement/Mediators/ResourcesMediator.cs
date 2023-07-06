using System;
using System.Collections.Generic;
using Homeworks.SaveLoad;
using SaveLoad.Scripts;

namespace SaveLoad.GameManagement
{
    public class ResourcesMediator : GameMediator<ResourcesData, PlayerResources>
    {
        protected override void SetupFromData(PlayerResources service, ResourcesData data)
        {
            service.SetupResources(data.Resources);
        }

        protected override void SetupByDefault(PlayerResources service)
        {
            service.SetupResources(new Dictionary<ResourceType, int>());
        }

        protected override ResourcesData ConvertToData(PlayerResources service)
        {
            return new ResourcesData()
            {
                Resources = service.GetResources()
            };
        }
    }

    [Serializable]
    public class ResourcesData
    {
        public Dictionary<ResourceType, int> Resources;
    }
}