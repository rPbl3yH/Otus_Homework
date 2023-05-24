using System;
using UnityEngine;

public class MoveInput : MonoBehaviour, IGameUpdateListener
{
    public delegate void InputSideDelegate(InputDirection inputDirection);
    public event InputSideDelegate OnMove;

    public void OnUpdate(float deltaTime) {
        if (Input.GetKeyDown(KeyCode.A)) {
            OnMove?.Invoke(InputDirection.Left);
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            OnMove?.Invoke(InputDirection.Right);
        }
    }
}

public enum InputDirection
{
    Left,
    Right,
}
