using AtomicHomework.Atomic.Enemy.Document;
using AtomicHomework.Hero;
using Declarative;
using UnityEngine;

namespace AtomicHomework.Enemy.Document
{
    public class EnemyDocument : DeclarativeModel
    {
        public Transform Transform;
        
        [Section] 
        public Life Life;

        [Section]
        public Death Death;

        [Section]
        public Follow Follow;
    }
}