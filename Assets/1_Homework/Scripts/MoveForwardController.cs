using UnityEngine;

public class MoveForwardController : MonoBehaviour, IGameUpdateListener
{
    [SerializeField] private MoveComponent _moveComponent;

    void IGameUpdateListener.OnUpdate(float deltaTime) {
        _moveComponent.MoveForward(deltaTime);
    }
}
