using AtomicHomework.Input;
using UnityEngine;
using Zenject;

namespace AtomicHomework.Hero
{
    public class InputSystemInstaller : MonoInstaller<InputSystemInstaller>
    {
        [SerializeField] private InputSystem _inputSystem;
        
        public override void InstallBindings()
        {
            base.InstallBindings();
            Container.Bind<InputSystem>().FromInstance(_inputSystem).AsSingle();
        }
    }
}