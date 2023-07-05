using Game.Meta;
using UnityEngine;

namespace Lessons.MetaGame.Upgrades
{
    [CreateAssetMenu(
        fileName = "DamageUpgradeConfig",
        menuName = "Lessons/New DamageUpgradeConfig"
    )]
    public sealed class DamageUpgradeConfig : UpgradeConfig
    {
        [SerializeField]
        public DamageUpgradeTable damageTable;
        
        public override Upgrade InstantiateUpgrade()
        {
            return new DamageUpgrade(this);
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            this.damageTable.OnValidate(this.maxLevel);
        }
    }
}