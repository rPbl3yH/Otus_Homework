using Entities;
using Lessons.Character.Components;
using UnityEngine;

namespace Lessons.Character.Controllers
{
    public sealed class CharacterMovementController : MonoBehaviour
    {
        [SerializeField]
        private MovementInput movementInput;
         
        [SerializeField]
        private MonoEntity character;

        private MoveInDirectionComponent _moveInDirection;

        private void Start()
        {
            _moveInDirection = character.Get<MoveInDirectionComponent>();
        }

        private void OnEnable()
        {
            movementInput.MovementDirectionChanged += OnMovementDirectionChanged;
        }

        private void OnDisable()
        {
            movementInput.MovementDirectionChanged -= OnMovementDirectionChanged;
        }

        private void OnMovementDirectionChanged(Vector3 direction)
        {
            _moveInDirection.MoveInDirection(direction);
        }
    }
}