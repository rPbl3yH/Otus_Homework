using System;
using Lessons.Character.Model;
using UnityEngine;

namespace Lessons.StateMachines.States
{
    [Serializable]
    public sealed class AnimatorState : IState
    {
        [SerializeField]
        private AnimatorStateType stateType;

        [SerializeField]
        private string stateName = "State";

        private Animator _animator;
        private int _state;

        public void Construct(Animator animator)
        {
            _animator = animator;
            _state = Animator.StringToHash(stateName);
        }
        
        void IState.Enter()
        {
            _animator.SetInteger(_state, (int) stateType);
        }

        void IState.Exit()
        {
            
        }
    }
}