using Lessons.Gameplay.Atomic1;

namespace AtomicHomework.Entities.Components
{
    class TakeBulletDamageComponent : ITakeBulletDamageComponent
    {
        private readonly AtomicAction<int> _onTakeDamage;

        public TakeBulletDamageComponent(AtomicAction<int> onTakeDamage)
        {
            _onTakeDamage = onTakeDamage;
        }

        public void TakeDamage(int value)
        {
            _onTakeDamage?.Invoke(value);    
        }
    }
}