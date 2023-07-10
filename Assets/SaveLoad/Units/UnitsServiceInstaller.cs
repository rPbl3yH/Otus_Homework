using System.Collections.Generic;
using Homeworks.SaveLoad;
using UnityEngine;
using Zenject;

namespace SaveLoad.Units
{
    public class UnitsServiceInstaller : MonoInstaller<UnitsServiceInstaller>
    {
        [SerializeField] private List<UnitObject> _unitObjects;

        private UnitsService _unitsService;

        public override void InstallBindings()
        {
            Container.Bind<UnitsService>().FromNew().AsSingle().WithArguments(_unitObjects);
        }
    }
}