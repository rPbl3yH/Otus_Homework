using Game.GameEngine.Mechanics;
using GameSystem;
using Lessons.Meta.Upgrades;

namespace Lessons.MetaGame.Upgrades
{
    public sealed class DamageUpgrade : Upgrade, 
        IGameInitElement
    {
        private HeroService heroService;
        
        private readonly DamageUpgradeConfig config;

        public DamageUpgrade(DamageUpgradeConfig config) : base(config)
        {
            this.config = config;
        }

        protected override void OnUpgrade(int newLevel)
        {
            var damage = this.config.damageTable.GetDamage(newLevel);
            this.heroService.GetHero().Get<IComponent_SetMeleeDamage>().SetDamage(damage);
        }

        [GameInject]
        public void Construct(HeroService heroService)
        {
            this.heroService = heroService;
        }

        void IGameInitElement.InitGame()
        {
            var damage = this.config.damageTable.GetDamage(this.Level);
            this.heroService.GetHero().Get<IComponent_SetMeleeDamage>().SetDamage(damage);
        }
    }
}