using System;
using AtomicHomework.Atomic.Enemy.Document;
using AtomicHomework.Enemy.Document;
using AtomicHomework.Entities.Components;
using AtomicHomework.Hero;
using Entities;
using UnityEngine;

namespace AtomicHomework.Atomic.Enemy.Entity
{
    public class EnemyEntity : MonoEntityBase
    {
        [SerializeField] private EnemyDocument _enemyDocument;
        
        private void Awake()
        {
            Add(new TakeBulletDamageComponent(_enemyDocument.Life.OnTakeDamage));
            Add(new FollowComponent(_enemyDocument.Follow.OnFollow));
        }
    }
}