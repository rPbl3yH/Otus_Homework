using System;
using System.Collections.Generic;
using Declarative;
using Lessons.StateMachines.States;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.StateMachines
{
    [Serializable]
    public sealed class StateMachine : IState, IStartListener
    {
        [SerializeField]
        private CharacterStateType currentStateType;

        [SerializeField]
        private bool enterOnStart = true;
        
        [ShowInInspector, ReadOnly]
        private IState _currentState;

        private List<(CharacterStateType, IState)> _states = new();

        public void Construct(params (CharacterStateType, IState)[] states)
        {
            _states = new List<(CharacterStateType, IState)>(states);
        }
        
        void IStartListener.Start()
        {
            if (enterOnStart)
            {
                Enter();
            }
        }
        
        public void Enter()
        {
            _currentState = FindState(currentStateType);
            _currentState?.Enter();
        }

        public void Exit()
        {
            _currentState?.Exit();
            _currentState = null;
        }

        public void SwitchState(CharacterStateType stateType)
        {
            Exit();
            currentStateType = stateType;
            Enter();
        }

        private IState FindState(CharacterStateType stateType)
        {
            foreach (var state in _states)
            {
                if (state.Item1 == stateType)
                {
                    return state.Item2;
                }
            }

            return null;
        }
    }
}