using System;
using UnityEngine;

namespace Lessons.MetaGame.Lesson_Inventory
{
    [Serializable]
    public sealed class InventoryItem
    {
        public string Name
        {
            get { return this.name; }
        }

        public InventoryItemFlags Flags
        {
            get { return this.flags; }
        }

        public InventoryItemMetadata Metadata
        {
            get { return this.metadata; }
        }

        [SerializeField]
        private string name;

        [SerializeField]
        private InventoryItemFlags flags;

        [SerializeField]
        private InventoryItemMetadata metadata;

        [SerializeReference]
        private object[] components;

        public InventoryItem(string name)
        {
            this.name = name;
            this.flags = InventoryItemFlags.NONE;
            this.metadata = null;
            this.components = new object[0];
        }

        public InventoryItem(
            string name,
            InventoryItemFlags flags,
            InventoryItemMetadata metadata,
            params object[] components
        )
        {
            this.name = name;
            this.flags = flags;
            this.metadata = metadata;
            this.components = components;
        }

        public T GetComponent<T>()
        {
            for (int i = 0, count = this.components.Length; i < count; i++)
            {
                var component = this.components[i];
                if (component is T result)
                {
                    return result;
                }
            }

            throw new Exception($"Component of type {typeof(T)} is not found!");
        }

        public InventoryItem Clone()
        {
            return new InventoryItem(
                this.name,
                this.flags,
                this.metadata,
                this.CloneComponents()
            );
        }

        private object[] CloneComponents()
        {
            var count = this.components.Length;
            var result = new object[count];
            for (var i = 0; i < count; i++)
            {
                var component = this.components[i];
                if (component is ICloneable cloneable)
                {
                    component = cloneable.Clone();
                }

                result[i] = component;
            }

            return result;
        }
    }
}