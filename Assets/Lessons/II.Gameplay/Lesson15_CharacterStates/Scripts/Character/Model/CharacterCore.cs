using System;
using Declarative;
using Lessons.Character.Engines;
using Lessons.StateMachines;
using Lessons.StateMachines.States;
using Lessons.Utils;
using UnityEngine;

namespace Lessons.Character.Model
{
    [Serializable]
    public sealed class CharacterCore
    {
        [Section]
        public CharacterLife life;

        [Section]
        public CharacterMovement movement;

        [Section]
        public CharacterStates states;
    }
    
    [Serializable]
    public sealed class CharacterLife
    {
        public AtomicVariable<bool> isAlive;
    }

    [Serializable]
    public sealed class CharacterMovement
    {
        public Transform transform;

        public AtomicVariable<float> movementSpeed = 6f;
        public AtomicVariable<float> rotationSpeed = 10f;
        public MovementDirectionVariable movementDirection;

        public MoveInDirectionEngine moveInDirectionEngine;
        public RotateInDirectionEngine rotateInDirectionEngine;

        [Construct]
        public void Construct()
        {
            moveInDirectionEngine.Construct(transform, movementSpeed);
            rotateInDirectionEngine.Construct(transform, rotationSpeed);
        }
    }

    [Serializable]
    public sealed class CharacterStates
    {
        public StateMachine stateMachine;

        [Section]
        public IdleState idleState;
        
        [Section]
        public RunState runState;

        [Section]
        public DeadState deadState;
        
        

        [Construct]
        public void Construct()
        {
            stateMachine.Construct(
                (CharacterStateType.Idle, idleState),
                (CharacterStateType.Run, runState),
                (CharacterStateType.Dead, deadState));
        }

        [Construct]
        public void ConstructTransitions(CharacterLife life, CharacterMovement movement)
        {
            life.isAlive.ValueChanged += isAlive =>
                stateMachine.SwitchState(isAlive ? CharacterStateType.Idle : CharacterStateType.Dead);
            
            movement.movementDirection.MovementStarted += () =>
            {
                if (life.isAlive)
                {
                    stateMachine.SwitchState(CharacterStateType.Run);
                }
            };
            
            movement.movementDirection.MovementFinished += () =>
            {
                if (life.isAlive)
                {
                    stateMachine.SwitchState(CharacterStateType.Idle);
                }
            };
        }
    }
}