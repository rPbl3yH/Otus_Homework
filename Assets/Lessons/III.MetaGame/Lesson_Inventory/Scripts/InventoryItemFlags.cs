using System;

namespace Lessons.MetaGame.Lesson_Inventory
{
    [Flags]
    public enum InventoryItemFlags
    {
        NONE = 0, //0
        STACKABLE = 1, //01
        CONSUMABLE = 2, //10
        EQUPPABLE = 4, //100
        EFFECTIBLE = 8 //1000
    }
    
    // 0011 & 0110
}