#if false
using System.Collections.Generic;
using Game.Tutorial.UI;
using Lessons.III.MetaGame.Lesson_Crafing;
using Lessons.MetaGame.Lesson_Inventory;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public sealed class LessonCraftingTests
{
    [SetUp]
    public void Construct(){
    
    }
    
    [Test]
    public void CraftBootsTestSuccess()
    {
        //Inventory:
        
        //Input:
        //Boots - 1
        //Stones - 3
        //SuperBoots - 0

        //Output:
        //Boots - 0
        //Stones - 0
        //SuperBoots - 1
        
        //ARRANGE:

        var bootsItemConfig = ScriptableObject.CreateInstance<InventoryItemConfig>();
        bootsItemConfig.prototype = new InventoryItem("Boots", InventoryItemFlags.NONE, null);

        var stoneItemConfig = ScriptableObject.CreateInstance<InventoryItemConfig>();
        stoneItemConfig.prototype = new InventoryItem("Stone", InventoryItemFlags.NONE, null);
        
        var superBootsConfig = ScriptableObject.CreateInstance<InventoryItemConfig>();
        superBootsConfig.prototype = new InventoryItem("SuperBoots", InventoryItemFlags.NONE, null);

        var inventory = new Inventory();
        inventory.AddItem(bootsItemConfig.prototype.Clone());
        inventory.AddItem(stoneItemConfig.prototype.Clone());
        inventory.AddItem(stoneItemConfig.prototype.Clone());
        inventory.AddItem(stoneItemConfig.prototype.Clone());

        //ACT:
        //TODO: Crafting logic:

        var receipt = ScriptableObject.CreateInstance<InventoryItemReceipt>();
        receipt.resultItemInfo = superBootsConfig;
        receipt.ingredients = new InventoryItemIngredient[]
        {
            new()
            {
                itemInfo = bootsItemConfig,
                requiredCount = 1
            },
            new()
            {
                itemInfo = stoneItemConfig,
                requiredCount = 3
            }
        };

        var bootsCrafter = new InventoryItemCrafter();
        bootsCrafter.Craft(inventory, receipt);

        //ASSERT:
        Assert.True(inventory.IsItemExists(superBootsConfig.prototype.Name));
        Assert.False(inventory.IsItemExists(bootsItemConfig.prototype.Name));
        Assert.False(inventory.IsItemExists(stoneItemConfig.prototype.Name));
    }
    
    // [Test]
    // public void CraftBootsTestFail()
    // {
    //     //Inventory:
    //     
    //     //Input:
    //     //Boots - 1
    //     //Stones - 2
    //     //SuperBoots - 0
    //
    //     //Output:
    //     //Boots - 1
    //     //Stones - 2
    //     //SuperBoots - 0
    //     
    //     //ARRANGE:
    //     var bootsItem = new InventoryItem("Boots", InventoryItemFlags.NONE, null);
    //     var stoneItem1 = new InventoryItem("Stone", InventoryItemFlags.NONE, null);
    //     var stoneItem2 = new InventoryItem("Stone", InventoryItemFlags.NONE, null);
    //     
    //     var inventory = new Inventory();
    //     inventory.AddItem(bootsItem);
    //     inventory.AddItem(stoneItem1);
    //     inventory.AddItem(stoneItem2);
    //
    //     //ACT:
    //     //TODO: Crafting logic:
    //     var receipt = new InventoryItemReceipt
    //     {
    //         resultItemInfo = "SuperBoots",
    //         inputItems = new Dictionary<string, int>
    //         {
    //             {"Boots", 1},
    //             {"Stone", 3}
    //         }
    //     };
    //     
    //     var bootsCrafter = new InventoryItemCrafter();
    //     bootsCrafter.Craft(inventory, receipt);
    //
    //     //ASSERT:
    //     Assert.False(inventory.IsItemExists("SuperBoots"));
    //     Assert.True(inventory.CountItems("Boots") == 1);
    //     Assert.True(inventory.CountItems("Stone") == 2);
    // }
    //
    // [Test]
    // public void CraftAxeTest()
    // {
    //     //Inventory:
    //     
    //     //Input:
    //     //Tree - 2
    //     //Stones - 2
    //     //Axe - 0
    //
    //     //Output:
    //     //Tree - 1
    //     //Stones - 1
    //     //Axe - 1
    //     
    //     //ARRANGE:
    //     var treeItem1 = new InventoryItem("Tree", InventoryItemFlags.NONE, null);
    //     var treeItem2 = new InventoryItem("Tree", InventoryItemFlags.NONE, null);
    //     var stoneItem1 = new InventoryItem("Stone", InventoryItemFlags.NONE, null);
    //     var stoneItem2 = new InventoryItem("Stone", InventoryItemFlags.NONE, null);
    //     
    //     var inventory = new Inventory();
    //     inventory.AddItem(treeItem1);
    //     inventory.AddItem(treeItem2);
    //     inventory.AddItem(stoneItem1);
    //     inventory.AddItem(stoneItem2);
    //
    //     //ACT:
    //     //TODO: Crafting logic:
    //     var receipt = new InventoryItemReceipt
    //     {
    //         resultItemInfo = "Axe",
    //         inputItems = new Dictionary<string, int>
    //         {
    //             {"Tree", 1},
    //             {"Stone", 1}
    //         }
    //     };
    //
    //     var bootsCrafter = new InventoryItemCrafter();
    //     bootsCrafter.Craft(inventory, receipt);
    //
    //     //ASSERT:
    //     Assert.True(inventory.CountItems("Axe") == 1);
    //     Assert.True(inventory.CountItems("Tree") == 1);
    //     Assert.True(inventory.CountItems("Stone") == 1);
    // }
}
#endif