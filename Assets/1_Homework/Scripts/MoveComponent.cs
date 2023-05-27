using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _widthSide = 2f;

    public void MoveHorizonral(float dx) {
        transform.position += new Vector3(dx, 0f, 0f) * _widthSide;
    }

    public void MoveForward(float deltaTime) {
        transform.position += _speed * Vector3.forward * deltaTime;
    }
}
