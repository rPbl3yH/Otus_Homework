using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour, IGameUpdateListener
{
    public delegate void InputSideDelegate(bool isLeft);
    public event InputSideDelegate OnInputSide;

    public void OnUpdate(float deltaTime) {
        if (Input.GetKeyDown(KeyCode.A)) {
            OnInputSide?.Invoke(true);
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            OnInputSide?.Invoke(false);
        }
    }
}
