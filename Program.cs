using System;

namespace Shopping_Kata
{ 
class Program
{
    static void Main(string[] args)
    {
        Item[] items = {
        new Item("A", 100),
        new Item("B", 75),
        new Item("c", 50),
        new Item("D", 25),
        new Item("E", 15)
        };

        foreach (Item item in items)
        {
            Console.WriteLine("Item name: {0} and Item Price: {1}", item.Name, item.Price);
        }
        Console.ReadKey();
    }
}
     
}