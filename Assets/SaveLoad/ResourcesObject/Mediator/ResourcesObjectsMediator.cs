using SaveLoad.GameManagement;

namespace SaveLoad.ResourcesObject.Mediator
{
    public class ResourcesObjectsMediator : GameMediator<ResourcesObjectData[], ResourcesObjectService>
    {
        protected override void SetupFromData(ResourcesObjectService service, ResourcesObjectData[] data)
        {
            service.SetupData(data);
        }

        protected override void SetupByDefault(ResourcesObjectService service)
        {
            service.SetupDefault();
        }

        protected override ResourcesObjectData[] ConvertToData(ResourcesObjectService service)
        {
            return service.GetResourcesData();
        }
    }
}