using System;
using System.Collections.Generic;
using SaveLoad.GameManagment;
using UnityEngine;

namespace Game.App
{
    public sealed class ApplicationManager : MonoBehaviour
    {
        public event Action<float> OnUpdate;

        private readonly List<IGameUpdateListener> updateListeners = new();

        private void Update()
        {
            InvokeUpdate();
        }

        public void AddListener(object listener)
        {
            if (listener is IGameUpdateListener updateListener)
            {
                updateListeners.Add(updateListener);
            }

        }

        public void RemoveListener(object listener)
        {
            if (listener is IGameUpdateListener updateListener)
            {
                updateListeners.Remove(updateListener);
            }

        }

        private void InvokeUpdate()
        {
            var deltaTime = Time.deltaTime;
            foreach (var updateListener in updateListeners)
            {
                updateListener.OnUpdate(deltaTime);
            }

            OnUpdate?.Invoke(deltaTime);
        }
    }
}