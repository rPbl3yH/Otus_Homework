using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class FireInput : MonoBehaviour
    {
        public event Action OnFired; 

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                OnFired?.Invoke();
            }
        }
    }
}
