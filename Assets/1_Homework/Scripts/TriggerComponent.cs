using System;
using UnityEngine;

public class TriggerComponent : MonoBehaviour
{
    public event Action<Collider> OnTriggerEntered;

    private void OnTriggerEnter(Collider collider) {
        OnTriggerEntered?.Invoke(collider);
    }
}
