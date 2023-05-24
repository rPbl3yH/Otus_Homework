using UnityEngine;

public class MoveComponent : MonoBehaviour, IGameUpdateListener
{
    [SerializeField] private float _speed;
    [SerializeField] private float _widthSide = 2f;

    public void Move(Vector3 direction) {
        transform.position += direction * _widthSide;
    }

    void IGameUpdateListener.OnUpdate(float deltaTime) {
        transform.position += _speed * Vector3.forward * deltaTime;
    }
}
