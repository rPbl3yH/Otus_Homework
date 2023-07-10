using System;
using AtomicHomework.Enemy.Document;
using AtomicHomework.Hero;
using Declarative;
using UnityEngine;

namespace AtomicHomework.Atomic.Enemy.Document
{
    [Serializable]
    public class Death
    {
        [Construct]
        public void Construct(EnemyDocument enemyDocument, Life life)
        {
            life.OnDeath += () =>
            {
                GameObject.Destroy(enemyDocument.gameObject);
            };
        }
    }
}