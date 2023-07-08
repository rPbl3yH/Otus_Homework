using System;
using AtomicHomework.Atomic.Custom;
using Declarative;
using UnityEngine;
using UnityEngine.Serialization;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class CameraDocument : DeclarativeModel
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Transform _cameraTransform;
        
        public CameraMoveEngine CameraMoveEngine = new();
        public LateUpdateMechanics LateUpdateMechanics = new();
        [Construct]
        public void Construct()
        {
            CameraMoveEngine.Construct(_cameraTransform, _targetTransform);

            LateUpdateMechanics.OnUpdate(_ => CameraMoveEngine.Move());
        }
    }
}