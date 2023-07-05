using System;
using Declarative;
using Lessons.Character.Model;

namespace Lessons.StateMachines.States
{
    [Serializable]
    public sealed class RunState : CompositeState
    {
        public AnimatorState animatorState;
        public MoveState moveState;
        
        [Construct]
        public void ConstructSelf()
        {
            SetStates(animatorState, moveState);
        }
        
        [Construct]
        public void ConstructSubStates(CharacterVisual visual, CharacterMovement movement)
        {
            animatorState.Construct(visual.animator);
            moveState.Construct(movement.movementDirection, movement.moveInDirectionEngine,
                movement.rotateInDirectionEngine);
        }
    }
}