using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
	public sealed class Pool<T> where T : MonoBehaviour{
        public event Action<T> OnActiveBulletAdded;
        public event Action<T> OnActiveBulletRemoved;

        private readonly Transform _container;

        public Queue<T> GetAllPool() => _bulletPool;
        private readonly Queue<T> _bulletPool = new();
        private readonly HashSet<T> _activeBullets = new();

        public Pool(Transform container) {
            _container = container;
        }

        public void Despawn(T bullet) {
            if (_activeBullets.Remove(bullet)) {
				bullet.transform.SetParent(_container);
                _bulletPool.Enqueue(bullet);
                OnActiveBulletRemoved?.Invoke(bullet);
            }
        }

        public void Add(T bullet) {
            _bulletPool.Enqueue(bullet);
        }

		public void AddToActiveBullets(T bullet) {
            if (_activeBullets.Add(bullet)) {
                OnActiveBulletAdded?.Invoke(bullet);
            }
        }

		public bool TryDequeue(out T bullet)
		{
            var isSucces = _bulletPool.TryDequeue(out T result);
            bullet = result;
			return isSucces;
		}
	}
}