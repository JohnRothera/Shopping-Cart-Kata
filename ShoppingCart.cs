using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Kata

{
    public class shoppingCart
    {
        Dictionary<string, Item> definedItems = new Dictionary<string, Item>(); 
        List<string> scannedItems = new List<string>();
        public void addItemDefinition(Item item, string name) 
        {
            definedItems.Add(name, item);
        }

        public void addMultipleItemsDefinitions(Item[] itemArray)
        {
            foreach (Item item in itemArray)
            {
                definedItems.Add(item.Name, item);
            }
        }

        public Item? checkItemIsValid(string itemName)
        {
            Item? result = null;
            this.definedItems.TryGetValue(itemName, out result);

            return result;
        }

        public void scannedItem (string itemName)
        {
            this.scannedItems.Add(itemName);
        }

        public int calculateTotal()
        {
            int total = 0;
            foreach (string item in this.scannedItems)
            {
                Item? result = this.checkItemIsValid(item);

                if (result != null)
                {
                    total += result.Price;
                }
            }
            return total;
        }

        public string getReceipt()
        {
            string receipt = "";
            foreach (string item in this.scannedItems)
            {
                Item? result = this.checkItemIsValid(item);

                if (result != null)
                {   
                    receipt += result.Name + " " + result.Price + "\n";
                }
            }
            receipt += "Total: " + this.calculateTotal();
            return receipt;
        }
    }

}