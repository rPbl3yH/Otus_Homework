using AtomicHomework.Atomic.Custom;
using Declarative;
using Lessons.Gameplay.Atomic1;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class CameraMoveEngine: ILateUpdateListener
    {
        private Transform _target;
        private Transform _cameraTransform;
        private bool _isMoveRequired;
        
        public void Construct(Transform cameraTransform, Transform target)
        {
            _cameraTransform = cameraTransform;
            _target = target;
        }

        public void Move()
        {
            _isMoveRequired = true;
        }

        public void LateUpdate(float deltaTime)
        {
            if (_isMoveRequired)
            {
                _cameraTransform.position = _target.position;
            }
        }
    }
    
    public class HeroModel : DeclarativeModel
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] public AtomicVariable<float> Speed;
        
        public AtomicEvent<Vector3> OnDirectionChanged;
        public AtomicEvent<Vector3> OnRotateDirectionChanged;

        [SerializeField]
        public AtomicVariable<int> HitPoints ;
        [ShowInInspector]
        public AtomicEvent<int> OnTakeDamage = new();
        [ShowInInspector]
        public AtomicEvent OnDeath = new();
        
        public MoveEngine MoveEngine = new();
        public CameraMoveEngine CameraMoveEngine = new();

        public LateUpdateMechanics LateUpdateMechanics = new();
        
        [Construct]
        public void Init()
        {
            MoveEngine.Construct(_transform, Speed);
            CameraMoveEngine.Construct(_cameraTransform, transform);

            LateUpdateMechanics.OnUpdate(_ => CameraMoveEngine.Move());
            
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
