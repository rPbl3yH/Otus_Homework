using System;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Lesson_Architecture2
{
    [Serializable]
    public sealed class EnemyConditon : IEntityCondition
    {
        [SerializeField]
        private string enemyName = "Dummy";
    
        public bool IsTrue(IEntity entity)
        {
            if (!entity.TryGet(out IComponent_GetName nameComponent) || nameComponent.Name != this.enemyName)
            {
                return false;
            }

            if (!entity.TryGet(out IComponent_IsAlive aliveComponent) || !aliveComponent.IsAlive)
            {
                return false;
            }
            
            return true;
        }
    }
}