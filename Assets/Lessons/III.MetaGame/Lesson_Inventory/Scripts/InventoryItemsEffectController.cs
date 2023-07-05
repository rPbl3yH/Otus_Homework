using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using UnityEngine;
using static Lessons.MetaGame.Lesson_Inventory.InventoryItemFlags;

namespace Lessons.MetaGame.Lesson_Inventory
{
    public sealed class InventoryItemsEffectController : IInventoryItemObserver
    {
        private IHeroService heroService;

        public void Construct(IHeroService heroService)
        {
            this.heroService = heroService;
        }

        public void OnAddItem(InventoryItem item)
        {
            if ((item.Flags & EFFECTIBLE) == EFFECTIBLE)
            {
                this.ActivateEffect(item);
            }
        }

        void IInventoryItemObserver.OnRemoveItem(InventoryItem item)
        {
            if ((item.Flags & EFFECTIBLE) == EFFECTIBLE)
            {
                this.DeactivateEffect(item);
            }
        }

        private void ActivateEffect(InventoryItem item)
        {
            Debug.Log($"Activate effect of item {item.Name}");
            var effect = item.GetComponent<IComponent_GetEffect>().Effect;
        
            var hero = this.heroService.GetHero();
            var heroComponent = hero.Get<IComponent_Effector>();
            heroComponent.Apply(effect);
        }

        private void DeactivateEffect(InventoryItem item)
        {
            Debug.Log($"Deactivate effect of item {item.Name}");
            var effect = item.GetComponent<IComponent_GetEffect>().Effect;
        
            var hero = this.heroService.GetHero();
            var heroComponent = hero.Get<IComponent_Effector>();
            heroComponent.Discard(effect);
        }
    }
}