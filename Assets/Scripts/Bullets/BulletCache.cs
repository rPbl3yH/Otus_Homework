using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
	public sealed class BulletCache : MonoBehaviour {

		private LevelBounds _levelBounds;

        private Pool<Bullet> _bulletPool;
		private readonly List<Bullet> _bulletCache = new();

		[Inject]
		public void Construct(Pool<Bullet> pool, LevelBounds levelBounds) {
			_bulletPool = pool;
			_levelBounds = levelBounds;
		}

		private void FixedUpdate() {
			_bulletCache.Clear();
			_bulletCache.AddRange(_bulletPool.GetAllPool());

			for (int i = 0, count = _bulletCache.Count; i < count; i++) {
				var bullet = _bulletCache[i];
				if (!_levelBounds.InBounds(bullet.transform.position)) {
					_bulletPool.Despawn(bullet);
				}
			}
		}
	}
}