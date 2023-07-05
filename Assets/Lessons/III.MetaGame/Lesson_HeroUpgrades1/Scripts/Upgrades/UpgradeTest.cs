using System.Collections.Generic;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.MetaGame.Upgrades
{
    public sealed class UpgradeTest : MonoBehaviour, IGameElementGroup
    {
        [SerializeField]
        private UpgradeConfig targetConfig;
    
        private Upgrade targetUpgrade;

        [Button]
        private void DoUpgrade()
        {
            if (!this.targetUpgrade.IsMaxLevel)
            {
                this.targetUpgrade.LevelUp();
                Debug.Log($"Level Up {this.targetUpgrade.Level}");
            }
        }

        private void Awake()
        {
            this.targetUpgrade = this.targetConfig.InstantiateUpgrade();
        }

        IEnumerable<IGameElement> IGameElementGroup.GetElements()
        {
            if (this.targetUpgrade is IGameElement gameUpgrade)
            {
                yield return gameUpgrade;
            }
        }
    }
}