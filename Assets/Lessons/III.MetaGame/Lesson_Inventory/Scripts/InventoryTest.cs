using Game.Gameplay.Hero;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.MetaGame.Lesson_Inventory
{
    public sealed class InventoryTest : MonoBehaviour, IGameConstructElement
    {
        [ShowInInspector, ReadOnly]
        private readonly Inventory inventory = new();

        private readonly InventoryItemsEffectController effectController = new();
        
        [Button]
        public void AddItem(InventoryItemConfig itemConfig)
        {
            var item = itemConfig.prototype.Clone();
            this.inventory.AddItem(item);
        }

        [Button]
        public void RemoveItem(InventoryItemConfig itemConfig)
        {
            this.inventory.RemoveItem(itemConfig.prototype.Name);
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            var heroService = context.GetService<IHeroService>();
            this.effectController.Construct(heroService);
            this.inventory.AddListener(this.effectController);
        }
    }
}