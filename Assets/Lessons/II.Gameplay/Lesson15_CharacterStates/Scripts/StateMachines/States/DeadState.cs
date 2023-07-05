using System;
using Declarative;
using Lessons.Character.Model;

namespace Lessons.StateMachines.States
{
    [Serializable]
    public sealed class DeadState : CompositeState
    {
        public AnimatorState animatorState;

        [Construct]
        public void ConstructSelf()
        {
            SetStates(animatorState);
        }
        
        [Construct]
        public void ConstructSubStates(CharacterVisual visual)
        {
            animatorState.Construct(visual.animator);
        }
    }
}