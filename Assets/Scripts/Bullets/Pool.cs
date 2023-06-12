using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Pool<T> where T : MonoBehaviour
    {
        public event Action<T> OnActiveItemAdded;
        public event Action<T> OnActiveItemRemoved;

        private readonly Transform _container;

        private readonly Queue<T> _itemsPool = new();
        private readonly HashSet<T> _activeItems = new();

        public Pool(Transform container) {
            _container = container;
        }

        public void Despawn(T item) {
            if (_activeItems.Remove(item)) {
                item.transform.SetParent(_container);
                _itemsPool.Enqueue(item);
                OnActiveItemRemoved?.Invoke(item);
            }
        }

        public void Add(T item) {
            _itemsPool.Enqueue(item);
        }

        public void AddToActiveItems(T item) {
            if (_activeItems.Add(item)) {
                OnActiveItemAdded?.Invoke(item);
            }
        }

        public bool TryDequeue(out T item) {
            var isSucces = _itemsPool.TryDequeue(out T result);
            item = result;
            return isSucces;
        }
    }
}
