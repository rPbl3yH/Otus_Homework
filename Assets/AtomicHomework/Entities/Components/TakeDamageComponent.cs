using Lessons.Gameplay.Atomic1;

namespace AtomicHomework.Entities.Components
{
    class TakeDamageComponent : ITakeDamageComponent
    {
        private readonly IAtomicAction<int> _onTakeDamage;

        public TakeDamageComponent(IAtomicAction<int> onTakeDamage)
        {
            _onTakeDamage = onTakeDamage;
        }

        public void TakeDamage(int value)
        {
            _onTakeDamage?.Invoke(value);    
        }
    }
}