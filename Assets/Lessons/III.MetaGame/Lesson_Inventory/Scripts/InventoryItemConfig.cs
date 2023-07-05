using UnityEngine;

namespace Lessons.MetaGame.Lesson_Inventory
{
    [CreateAssetMenu(
        fileName = "Inventory Item",
        menuName = "Lessons/New Inventory Item"
    )]
    public sealed class InventoryItemConfig : ScriptableObject
    {
        [SerializeField]
        public InventoryItem prototype;
    }
}