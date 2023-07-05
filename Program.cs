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
            new Item("A", 100),
            new Item("B", 75),
            new Item("C", 50),
            new Item("D", 25),
            new Item("E", 15)
        };

        var shopCart = new shoppingCart();

        shopCart.addMultipleItemsDefinitions(definedItems);
        /* */

        
        List<string> scannedItems = new List<string>()
        {
            "A",
            "A",
            "A",
            "B",
            "B",
            "C",
            "D",
            "E"
        };

        foreach (string item in scannedItems)
        {
            shopCart.scannedItem(item);
        }

        System.Console.WriteLine(shopCart.getReceipt());

    }
 
}
     
}