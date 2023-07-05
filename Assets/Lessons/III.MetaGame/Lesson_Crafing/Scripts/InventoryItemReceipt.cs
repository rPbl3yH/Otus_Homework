using Lessons.MetaGame.Lesson_Inventory;
using UnityEngine;

namespace Lessons.III.MetaGame.Lesson_Crafing
{
    [CreateAssetMenu(
        fileName = "InventoryItemReceipt",
        menuName = "Lessons/New InventoryItemReceipt"
    )]
    public sealed class InventoryItemReceipt : ScriptableObject
    {
        [SerializeField]
        public InventoryItemConfig resultItemInfo;

        [SerializeField]
        public InventoryItemIngredient[] ingredients;
    }
}