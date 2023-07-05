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
            this.InvokeUpdate();
        }

        public void AddListener(object listener)
        {
            if (listener is IGameUpdateListener updateListener)
            {
                this.updateListeners.Add(updateListener);
            }

        }

        public void RemoveListener(object listener)
        {
            if (listener is IGameUpdateListener updateListener)
            {
                this.updateListeners.Remove(updateListener);
            }

        }

        private void InvokeUpdate()
        {
            var deltaTime = Time.deltaTime;
            for (int i = 0, count = this.updateListeners.Count; i < count; i++)
            {
                var listener = this.updateListeners[i];
                listener.OnUpdate(deltaTime);
            }

            this.OnUpdate?.Invoke(deltaTime);
        }
    }
}