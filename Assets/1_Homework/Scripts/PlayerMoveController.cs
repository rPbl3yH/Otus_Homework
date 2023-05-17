using UnityEngine;

public class PlayerMoveController : MonoBehaviour, IGameUpdateListener
{
    [SerializeField] private float _speed;

    public void Move(Vector3 direction) {
        transform.position += direction;
    }

    void IGameUpdateListener.OnUpdate(float deltaTime) {
        transform.position += _speed * Vector3.forward * deltaTime;
    }
}
