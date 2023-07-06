using SaveLoad.GameManagement;

namespace SaveLoad.Units.Mediator
{
    public class UnitsMediator : GameMediator<UnitData[], UnitsService>
    {
        protected override void SetupFromData(UnitsService service, UnitData[] data)
        {
            service.SetupData(data);
        }

        protected override void SetupByDefault(UnitsService service)
        {
            service.SetupDefault();
        }

        protected override UnitData[] ConvertToData(UnitsService service)
        {
            return service.GetUnitsData();
        }
    }
}