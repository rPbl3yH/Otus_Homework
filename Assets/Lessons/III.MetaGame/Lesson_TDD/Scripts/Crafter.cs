using Lessons.MetaGame.Lesson_Inventory;

namespace Lessons.MetaGame.Lesson_TDD
{
    public readonly struct Receipt
    {
        public readonly string itemName;

        public readonly Ingredient[] ingredients;

        public Receipt(string itemName, params Ingredient[] ingredients)
        {
            this.itemName = itemName;
            this.ingredients = ingredients;
        }
    }

    public readonly struct Ingredient
    {
        public readonly string itemName;

        public readonly int amount;

        public Ingredient(string itemName, int amount)
        {
            this.amount = amount;
            this.itemName = itemName;
        }
    }
    
    public sealed class Crafter
    {
        public bool CanCraft(Inventory inventory, Receipt receipt)
        {
            foreach (var ingredient in receipt.ingredients)
            {
                if (inventory.CountItems(ingredient.itemName) < ingredient.amount)
                {
                    return false;
                }
            }

            return true;
        }

        public bool Craft(Inventory inventory, Receipt receipt)
        {
            if (!this.CanCraft(inventory, receipt))
            {
                return false;
            }
            
            foreach (var ingredient in receipt.ingredients)
            {
                inventory.RemoveItems(ingredient.itemName, ingredient.amount);
            }

            inventory.AddItem(new InventoryItem(receipt.itemName));
            return true;
        }
    }
}
