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

        shopCart.addItemsToCart(definedItems);

        // PROGRAM
        // Item? result = null;
        Item? result = shopCart.checkForScannedItem("A");

        if (result != null)
        {
            Console.WriteLine("Item {0} Item Value {1}", result.Name, result.Price);
        }
        else
        {
            Console.WriteLine("This did not work!");
        }

        Console.ReadKey();
    }
 
}
     
}