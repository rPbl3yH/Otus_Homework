using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Lessons.MetaGame.Lesson_Inventory
{
    public sealed class Inventory
    {
        public event Action<InventoryItem> OnItemAdded;

        public event Action<InventoryItem> OnItemRemoved;

        [ReadOnly, ShowInInspector]
        private readonly List<InventoryItem> items;

        private readonly List<IInventoryItemObserver> observers;

        public Inventory()
        {
            this.items = new List<InventoryItem>();
            this.observers = new List<IInventoryItemObserver>();
        }

        public void AddListener(IInventoryItemObserver listener)
        {
            this.observers.Add(listener);
        }

        public void RemoveListener(IInventoryItemObserver listener)
        {
            this.observers.Remove(listener);
        }

        public void SetupItems(InventoryItem[] item)
        {
            this.items.Clear();
            this.items.AddRange(item);
        }

        public bool AddItem(InventoryItem item)
        {
            if (this.items.Contains(item))
            {
                return false;
            }
            
            this.items.Add(item);

            for (int i = 0, count = this.observers.Count; i < count; i++)
            {
                var observer = this.observers[i];
                observer.OnAddItem(item);
            }
            
            this.OnItemAdded?.Invoke(item);
            return true;
        }

        public bool RemoveItem(string itemName)
        {
            for (var i = this.items.Count - 1; i >= 0; i--)
            {
                var item = this.items[i];
                if (item.Name == itemName)
                {
                    return this.RemoveItem(item);
                }
            }

            return false;
        }

        public bool RemoveItem(InventoryItem item)
        {
            if (this.items.Remove(item))
            {
                for (int i = 0, count = this.observers.Count; i < count; i++)
                {
                    var observer = this.observers[i];
                    observer.OnRemoveItem(item);
                }
            
                this.OnItemRemoved?.Invoke(item);
                return true;
            }

            return false;
        }

        public bool IsItemExists(InventoryItem item)
        {
            return this.items.Contains(item);
        }

        public bool IsItemExists(string name)
        {
            return this.FindItemFirst(name, out _);
        }

        public bool IsEmpty()
        {
            return this.items.Count <= 0;
        }

        public InventoryItem[] GetAllItems()
        {
            return this.items.ToArray();
        }

        public List<InventoryItem> GetAllItemsUnsafe()
        {
            return this.items;
        }

        public bool FindItemFirst(InventoryItemFlags flags, out InventoryItem item)
        {
            for (int i = 0, count = this.items.Count; i < count; i++)
            {
                item = this.items[i];
                if ((item.Flags & flags) == flags)
                {
                    return true;
                }
            }

            item = default;
            return false;
        }

        public bool FindItemFirst(string name, out InventoryItem item)
        {
            for (int i = 0, count = this.items.Count; i < count; i++)
            {
                item = this.items[i];
                if (item.Name == name)
                {
                    return true;
                }
            }

            item = default;
            return false;
        }

        public bool FindItemLast(string name, out InventoryItem item)
        {
            for (var i = this.items.Count - 1; i >= 0; i--)
            {
                item = this.items[i];
                if (item.Name == name)
                {
                    return true;
                }
            }

            item = default;
            return false;
        }

        public bool FindItemFirst(out InventoryItem item, Func<InventoryItem, bool> predicate)
        {
            for (int i = 0, count = this.items.Count; i < count; i++)
            {
                item = this.items[i];
                if (predicate.Invoke(item))
                {
                    return true;
                }
            }

            item = default;
            return false;
        }

        public InventoryItem[] FindItems(InventoryItemFlags flags)
        {
            var result = new List<InventoryItem>();
            for (int i = 0, count = this.items.Count; i < count; i++)
            {
                var item = this.items[i];
                if ((item.Flags & flags) == flags)
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        public InventoryItem[] FindItems(string name)
        {
            var result = new List<InventoryItem>();
            for (int i = 0, count = this.items.Count; i < count; i++)
            {
                var item = this.items[i];
                if (item.Name == name)
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        public int CountItems(InventoryItemFlags flags)
        {
            var result = 0;
            for (int i = 0, count = this.items.Count; i < count; i++)
            {
                var item = this.items[i];
                if ((item.Flags & flags) == flags)
                {
                    result++;
                }
            }

            return result;
        }

        public int CountItems(string itemName)
        {
            var result = 0;
            for (int i = 0, count = this.items.Count; i < count; i++)
            {
                var item = this.items[i];
                if (item.Name == itemName)
                {
                    result++;
                }
            }

            return result;
        }

        public void RemoveItems(string itemName, int requiredCount)
        {
            while (requiredCount > 0 && this.RemoveItem(itemName))
            {
                requiredCount--;
            }
        }
    }
}