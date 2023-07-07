using Declarative;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class HeroModel : DeclarativeModel
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private float _speed;
        
        [Construct]
        public void Construct()
        {
            _inputSystem.OnDirectionChanged += direction =>
            {
                transform.Translate(direction * (_speed * Time.deltaTime));
            };
        }
    }
}
