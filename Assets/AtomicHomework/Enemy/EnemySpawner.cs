using System.Collections;
using UnityEngine;

namespace AtomicHomework.Atomic.Enemy.Document
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyDocument _enemy;
        [SerializeField] private float _spawnTime = 2f;
        [SerializeField] private Transform[] _spawnPoints;

        public void Start()
        {
            StartCoroutine(StartSpawn());
        }

        private IEnumerator StartSpawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnTime);
                var spawnPoint = GetRandomPoint();
                var enemy = Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
                
            }
        }

        private Transform GetRandomPoint()
        {
            return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        }
    }
}