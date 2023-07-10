using System.Collections.Generic;
using Homeworks.SaveLoad;
using SaveLoad.GameManagement;
using UnityEngine;

namespace SaveLoad.Units
{
    public class UnitsService
    {
        private readonly List<UnitObject> _units;

        public UnitsService(List<UnitObject> units)
        {
            _units = units;
            GameContext.AddService(this);
        }
        
        public List<UnitObject> GetUnits()
        {
            return _units;
        }
    }
}