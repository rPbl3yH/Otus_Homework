using Homeworks.SaveLoad;
using SaveLoad.GameManagement;
using SaveLoad.GameManagement.Listeners;
using UnityEngine;

namespace SaveLoad.Units
{
    public class UnitsServiceInstaller : MonoBehaviour, IGameInitListener
    {
        [SerializeField] private UnitObject[] _unitObjects;

        private UnitsService _unitsService;

        public void InitGame()
        {
            _unitsService = new UnitsService(_unitObjects);
            
            GameContext.AddService(_unitsService);
        }
    }
}