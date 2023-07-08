using AtomicHomework.Atomic.Custom;
using Declarative;
using Lessons.Gameplay.Atomic1;
using Sirenix.OdinInspector;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class RotateEngine : IUpdateListener
    {
        private Transform _transform;
        private IAtomicValue<float> _speed;
        private IAtomicValue<Vector3> _rotateDirection;

        private bool _isRotateRequired;
        
        public void Construct(Transform transform, IAtomicValue<float> speed, IAtomicValue<Vector3> rotateDirection)
        {
            _transform = transform;
            _speed = speed;
            _rotateDirection = rotateDirection;
        }

        public void Rotate()
        {
            _isRotateRequired = true;
        }

        public void Update(float deltaTime)
        {
            if (_isRotateRequired)
            {
                _transform.Rotate(_rotateDirection.Value * (_speed.Value * deltaTime));
                _isRotateRequired = false;
            }
        }
    }
    
    
    public class HeroModel : DeclarativeModel
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] public AtomicVariable<float> Speed;
        [SerializeField] public AtomicVariable<float> RotationSpeed;
        [SerializeField] public AtomicVariable<Vector3> RotateDirection;

        [SerializeField]
        public AtomicVariable<int> HitPoints ;
        [ShowInInspector]
        public AtomicEvent<int> OnTakeDamage = new();
        [ShowInInspector]
        public AtomicEvent OnDeath = new();
        
        public MoveEngine MoveEngine = new();
        public CameraMoveEngine CameraMoveEngine = new();
        public RotateEngine RotateEngine = new();

        public LateUpdateMechanics LateUpdateMechanics = new();
        public UpdateMechanics UpdateMechanics = new();
        
        [Construct]
        public void Init()
        {
            MoveEngine.Construct(_transform, Speed);
            CameraMoveEngine.Construct(_cameraTransform, transform);
            RotateEngine.Construct(_transform, RotationSpeed, RotateDirection);

            LateUpdateMechanics.OnUpdate(_ => CameraMoveEngine.Move());
            UpdateMechanics.OnUpdate(_ => RotateEngine.Rotate());
            
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
        }
    }
}
