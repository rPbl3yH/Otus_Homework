using System;
using Lessons.MetaGame.Lesson_Inventory;
using UnityEngine;

namespace Lessons.III.MetaGame.Lesson_Crafing
{
    [Serializable]
    public struct InventoryItemIngredient
    {
        [SerializeField]
        public InventoryItemConfig itemInfo;

        [SerializeField]
        public int requiredCount;
    }
}