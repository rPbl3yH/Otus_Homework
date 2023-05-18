using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour, IGameLateUpdateListener
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private Transform _target;

    void IGameLateUpdateListener.OnLateUpdate(float deltaTime) {
        transform.position = Vector3.Lerp(transform.position, _target.position, _speed * deltaTime);
    }
}
