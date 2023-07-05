#if false

using System.Collections.Generic;
using Lessons.MetaGame.Lesson_Inventory;
using Lessons.MetaGame.Lesson_TDD;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public sealed class CraftingTests
{
    [Test]
    public void SuperBootsTest()
    {
        //{P}: Inventory
        //Boots - 1
        //Stone - 3

        //{Q}: Inventory
        //Boots - 0
        //Stone - 0
        //SuperBoots - 1

        //Arrange:
        var inventory = new Inventory();
        inventory.AddItem(new InventoryItem("Boots"));
        inventory.AddItem(new InventoryItem("Stone"));
        inventory.AddItem(new InventoryItem("Stone"));
        inventory.AddItem(new InventoryItem("Stone"));

        //Act: {S}
        //Crafting:
        var bootsCrafter = new Crafter();
        var receipt = new Receipt("SuperBoots", new Ingredient("Stone", 3), new Ingredient("Boots", 1));
        bootsCrafter.Craft(inventory, receipt);

        //Assert:
        Assert.True(inventory.CountItems("Boots") == 0);
        Assert.True(inventory.CountItems("Stone") == 0);
        Assert.True(inventory.CountItems("SuperBoots") == 1);
    }

    [Test]
    public void SwordTest()
    {
        //{P}: Inventory
        //Wood - 1
        //Steal - 3

        //{Q}: Inventory
        //Wood - 0
        //Steal - 0
        //Sword - 1

        //Arrange:
        var inventory = new Inventory();
        inventory.AddItem(new InventoryItem("Wood"));
        inventory.AddItem(new InventoryItem("Steal"));

        //Act: {S}
        //Crafting:
        var bootsCrafter = new Crafter();
        ;

        var receipt = new Receipt("Sword", new Ingredient("Wood", 1), new Ingredient("Steal", 1));
        var isSuccess = bootsCrafter.Craft(inventory, receipt);

        //Assert:
        Assert.True(isSuccess);
        Assert.True(inventory.CountItems("Wood") == 0);
        Assert.True(inventory.CountItems("Steal") == 0);
        Assert.True(inventory.CountItems("Sword") == 1);
    }
    
    [Test]
    public void IngedientsForSwordNotEnoughTest()
    {
        //{P}: Inventory
        //Wood - 1
        //Steal - 0

        //{Q}: Inventory
        //Wood - 1
        //Steal - 0
        //Sword - 0

        //Arrange:
        var inventory = new Inventory();
        inventory.AddItem(new InventoryItem("Wood"));

        //Act: {S}
        //Crafting:
        var bootsCrafter = new Crafter();
        var receipt = new Receipt("Sword", new Ingredient("Wood", 1), new Ingredient("Steal", 1));
        var isSuccess = bootsCrafter.Craft(inventory, receipt);

        //Assert:
        Assert.False(isSuccess);
        Assert.True(inventory.CountItems("Wood") == 1);
        Assert.True(inventory.CountItems("Sword") == 0);
    }
}
#endif
