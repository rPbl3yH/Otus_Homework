using Lessons.Gameplay.Atomic1;

namespace AtomicHomework.Entities.Components
{
    class TakeBulletDamageComponent : ITakeBulletDamageComponent
    {
        private readonly IAtomicAction<int> _onTakeDamage;

        public TakeBulletDamageComponent(IAtomicAction<int> onTakeDamage)
        {
            _onTakeDamage = onTakeDamage;
        }

        public void TakeDamage(int value)
        {
            _onTakeDamage?.Invoke(value);    
        }
    }
}