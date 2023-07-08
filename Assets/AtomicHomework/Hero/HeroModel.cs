using Declarative;
using Lessons.Gameplay.Atomic1;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class HeroModel : DeclarativeModel
    {
        public AtomicEvent<Vector3> OnDirectionChanged;
        public AtomicEvent<Vector3> OnRotateDirectionChanged;

        [SerializeField]
        public AtomicVariable<int> HitPoints ;
        [ShowInInspector]
        public AtomicEvent<int> OnTakeDamage = new();
        [ShowInInspector]
        public AtomicEvent OnDeath = new();

        [Construct]
        public void Init()
        {
            OnTakeDamage += damage =>
            {
                HitPoints.Value -= damage;
            };

            HitPoints.OnChanged += hitPoints =>
            {
                if (hitPoints <= 0)
                {
                    OnDeath?.Invoke();
                }
            };

            OnDeath += () => Debug.Log("Death");
            
            
            // OnDirectionChanged += direction =>
            // {
            //     transform.Translate(direction);
            // };
            //
            // OnRotateDirectionChanged += direction =>
            // {
            //     transform.Rotate(direction);
            // };
        }
    }
}
