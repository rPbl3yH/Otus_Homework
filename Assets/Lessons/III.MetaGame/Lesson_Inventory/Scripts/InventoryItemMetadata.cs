using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.MetaGame.Lesson_Inventory
{
    [Serializable]
    public sealed class InventoryItemMetadata
    {
        [SerializeField]
        public string title;

        [TextArea]
        [SerializeField]
        public string description;

        [PreviewField]
        [SerializeField]
        public Sprite icon;
    }
}