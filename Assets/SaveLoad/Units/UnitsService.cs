using System.Collections.Generic;
using Homeworks.SaveLoad;
using UnityEngine;

namespace SaveLoad.Units
{
    public class UnitsService
    {
        private UnitObject[] _units;

        public UnitsService(UnitObject[] units)
        {
            _units = units;
        }

        public UnitData[] GetUnitsData()
        {
            var list = new List<UnitData>();
            foreach (var unitObject in _units)
            {
                var unitPosition = unitObject.transform.position;
                
                list.Add(new UnitData()
                {
                    Position = new []
                    {
                        unitPosition.x,
                        unitPosition.y,
                        unitPosition.z,
                    },
                    Damage = unitObject.damage,
                    Speed = unitObject.speed,
                    HitPoints = unitObject.hitPoints,
                });
            }

            return list.ToArray();
        }

        public void SetupData(UnitData[] unitsData)
        {
            for (int i = 0; i < _units.Length; i++)
            {
                var data = unitsData[i];
                var unit = _units[i];
                unit.transform.position = new Vector3(data.Position[0], data.Position[1], data.Position[2]);
                unit.damage = data.Damage;
                unit.speed = data.Speed;
                unit.hitPoints = data.HitPoints;
            }
        }

        public void SetupDefault()
        {
            
        }
    }
}