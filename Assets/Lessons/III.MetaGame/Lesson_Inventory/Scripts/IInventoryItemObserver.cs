namespace Lessons.MetaGame.Lesson_Inventory
{
    public interface IInventoryItemObserver
    {
        void OnAddItem(InventoryItem item);

        void OnRemoveItem(InventoryItem item);
    }
}