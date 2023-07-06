using System.Collections.Generic;
using Homeworks.SaveLoad;

namespace SaveLoad.SaveSystem.Mediators
{
    public class ResourcesMediator : GameMediator<PlayerResources, PlayerResources>
    {
        //TODO: create resourceData
        protected override void SetupFromData(PlayerResources service, PlayerResources data)
        {
            service.SetupResources(data.GetResources());
        }

        protected override void SetupByDefault(PlayerResources service)
        {
            service.SetupResources(new Dictionary<ResourceType, int>());
        }

        protected override PlayerResources ConvertToData(PlayerResources service)
        {
            return service;
        }
    }
}