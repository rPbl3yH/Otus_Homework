using System.Collections.Generic;
using Homeworks.SaveLoad;
using SaveLoad.GameManagement;
using UnityEngine;

namespace SaveLoad.Units.Mediator
{
    public class UnitsMediator : GameMediator<UnitData[], UnitsService>
    {
        protected override void SetupFromData(UnitsService service, UnitData[] unitsData)
        {
            var units = service.GetUnits();
            for (int i = 0; i < unitsData.Length; i++)
            {
                var data = unitsData[i];
                var unit = units[i];
                unit.transform.position = new Vector3(data.Position[0], data.Position[1], data.Position[2]);
                unit.damage = data.Damage;
                unit.speed = data.Speed;
                unit.hitPoints = data.HitPoints;
            }
        }

        protected override void SetupByDefault(UnitsService service)
        {
            var unitsList = service.GetUnits();
            unitsList = new List<UnitObject>();
        }

        protected override UnitData[] ConvertToData(UnitsService service)
        {
            var units = service.GetUnits();
            var unitsData = new UnitData[units.Count];

            for (int i = 0; i < units.Count; i++)
            {
                var unitObject = units[i];

                var unitPosition = unitObject.transform.position;
                unitsData[i] = new UnitData()
                {
                    Position = new[]
                    {
                        unitPosition.x,
                        unitPosition.y,
                        unitPosition.z,
                    },
                    Damage = unitObject.damage,
                    Speed = unitObject.speed,
                    HitPoints = unitObject.hitPoints,
                };
            }

            return unitsData;
        }
    }
}