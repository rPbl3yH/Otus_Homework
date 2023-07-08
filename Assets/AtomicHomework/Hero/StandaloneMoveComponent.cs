using UnityEngine;

namespace AtomicHomework.Hero
{
    public class StandaloneMoveComponent
    {
        private InputSystem _inputSystem;
        private HeroModel _heroModel;
        public StandaloneMoveComponent(HeroModel heroModel, InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
            _heroModel = heroModel;
            _inputSystem.OnDirectionChanged += OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector3 direction)
        {
            //_heroModel.OnDirectionChanged?.Invoke(direction);
        }
    }
}