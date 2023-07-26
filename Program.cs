using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Kata
{ 
class Program
{
    static void Main(string[] args)
    {   
        // CONFIG
        Item[] definedItems = {
            new Item("A", 100, "buyThreeGet20PercentOff"),
            new Item("B", 75, "poopoo"),
            new Item("C", 50),
            new Item("D", 25),
            new Item("E", 15, "buyOneGetOne"),
            new Item("Record", 50, "buyTwoGet15PercentOff")
        };

        Discounts[] definedDiscounts = {
            new Discounts("buyOneGetOne"),
            new Discounts("buyTwoGet15PercentOff"),
            new Discounts("buyThreeGet20PercentOff")
        };

        var shopCart = new shoppingCart();

        
        shopCart.addMultipleItemsDefinitions(definedItems);


        // PROGRAM

        

        
        List<string> scannedItems = new List<string>()
        {
            "A",
            "A",
            "A",
            "B",
            "B",
            "C",
            "D",
            "E",
            "E",
            "Record",
            "Record"
        };

        foreach (string item in scannedItems)
        {
            shopCart.scannedItem(item);
        }        

        System.Console.WriteLine(shopCart.getReceipt());        
    }
}
     
}