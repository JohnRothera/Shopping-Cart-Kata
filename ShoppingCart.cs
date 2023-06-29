using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Kata

{
    public class shoppingCart
    {
        Dictionary<string, Item> scannedItems = new Dictionary<string, Item>(); 

        public void addItemToCart(Item item, string name) 
        {
            scannedItems.Add(name, item);
        }

        public void addItemsToCart(Item[] itemArray)
        {
            foreach (Item item in itemArray)
            {
                scannedItems.Add(item.Name, item);
            }
        }

        public Item? checkForScannedItem(string itemName)
        {
            Item? result = null;
            this.scannedItems.TryGetValue(itemName, out result);

            return result;
        }
    }

   


}