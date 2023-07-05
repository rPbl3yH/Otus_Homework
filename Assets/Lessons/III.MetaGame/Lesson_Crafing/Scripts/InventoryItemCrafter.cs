using Lessons.MetaGame.Lesson_Inventory;

namespace Lessons.III.MetaGame.Lesson_Crafing
{
    public sealed class InventoryItemCrafter
    {
        public void Craft(Inventory inventory, InventoryItemReceipt receipt)
        {
            foreach (var ingredient in receipt.ingredients)
            {
                var itemName = ingredient.itemInfo.prototype.Name;
                var requiredCount = ingredient.requiredCount;
                if (inventory.CountItems(itemName) < requiredCount)
                {
                    return;
                }
            }

            foreach (var ingredient in receipt.ingredients)
            {
                var itemName = ingredient.itemInfo.prototype.Name;
                var requiredCount = ingredient.requiredCount;
                inventory.RemoveItems(itemName, requiredCount);
            }

            var resultItem = receipt.resultItemInfo.prototype.Clone();
            inventory.AddItem(resultItem);
        }
    }
}