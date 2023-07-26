using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Kata
{
    public class shoppingCart
    {
        Dictionary<string, Item> definedItems = new Dictionary<string, Item>();
        Dictionary<string, int> scannedItems = new Dictionary<string, int>();
        
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
            definedItems.TryGetValue(itemName, out result);

            return result;
        }

        public void scannedItem(string itemName)
        {
            // scannedItems.Add(itemName);

            if(scannedItems.ContainsKey(itemName))
            {
                scannedItems[itemName] += 1;
            }
            else
            {
                scannedItems.Add(itemName, 1);
            }
        }

        public int calculateTotal()
        {
            int total = 0;
            foreach (KeyValuePair<string, int> item in scannedItems)
            {
                Item? result = checkItemIsValid(item.Key);

                if (result != null)
                {
                    total += result.Price * item.Value;
                }
            }
            return total;
        }

        public double calculateDiscount()
        {
            double totalDiscount = 0;
                            //itemName itemQuantity
                            //index.key index.value
            foreach (KeyValuePair<string, int> index in scannedItems)
            {
                Item? item = checkItemIsValid(index.Key);
                int itemQuantity = index.Value;
                
                if (item != null && item.DiscountOffer != null)
                {
                    if (Math.Floor((double)itemQuantity / (double)item.DiscountOffer.QualifyingItemCount) >= 1)
                    {
                        double itemDiscount = (((item.Price * itemQuantity) * 100) * item.DiscountOffer.OfferMultiplier) / 100;
                        totalDiscount += itemDiscount;
                    }
                }
            }

            return totalDiscount;
        }

        public string getReceipt()
        {
            string receipt = "";
            foreach (KeyValuePair<string, int> item in scannedItems)
            {
                Item? result = checkItemIsValid(item.Key);

                if (result != null)
                {
                    receipt += result.Name + " " + result.Price + "\n";
                }
            }
            double discountAmount = calculateDiscount();
            int total = calculateTotal();
            receipt += "Total: " + (total - discountAmount);
            return receipt;
        }

    }
}