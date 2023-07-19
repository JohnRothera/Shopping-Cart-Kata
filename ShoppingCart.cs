using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Kata
{
    public class shoppingCart
    {
        Dictionary<string, Item> definedItems = new Dictionary<string, Item>();
        List<string> scannedItems = new List<string>();

        // this doesn't seem to be referenced anywhere? May be intended to be used in the main program?
        List<Discounts> appliedDiscounts = new List<Discounts>(); // Added a list to store applied discounts

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
            scannedItems.Add(itemName);
        }

        public int calculateTotal()
        {
            int total = 0;
            foreach (string item in scannedItems)
            {
                Item? result = checkItemIsValid(item);

                if (result != null)
                {
                    total += result.Price;
                }
            }
            return total;
        }


         // Helper method to apply the discount to a specific item
            private void ApplyDiscountToItem(Item item, Discounts discountOffer)
        {
            item.DiscountOffer = discountOffer;
        }

            public void ApplyDiscount(Discounts discountOffer)
        {
            string itemName = discountOffer.OfferName;
            Item? item = checkItemIsValid(itemName);
            if (item != null)
            {
                // Applying the discount to the specific item
                ApplyDiscountToItem(item, discountOffer);
            }
            else
            {
                throw new Exception("Invalid item name.");
            }
        }

        // Apply 'buyOneGetOne' offer to Item "E"
        public void ApplyBuyOneGetOneToE()
        {
            Discounts buyOneGetOne = new Discounts("buyOneGetOne");
            // I think there should be an if statement to clarify 
            ApplyDiscountToItem("E", buyOneGetOne);
        }

        // Apply 'buyTwoGet15PercentOff' offer to Item "B"
        public void ApplyBuyTwoGet15PercentOffToB()
        {
            Discounts buyTwoGet15PercentOff = new Discounts("buyTwoGet15PercentOff");
            ApplyDiscountToItem("B", buyTwoGet15PercentOff);
        }

        // Apply 'buyThreeGet20PercentOff' offer to Item "C" and "D"
        public void ApplyBuyThreeGet20PercentOffToCAndD()
        {
            Discounts buyThreeGet20PercentOff = new Discounts("buyThreeGet20PercentOff");
            ApplyDiscountToItem("C", buyThreeGet20PercentOff);
            ApplyDiscountToItem("D", buyThreeGet20PercentOff);
        }

            public double calculateDiscount()
        {
            double discount = 0.0;
            foreach (Discounts discountOffer in appliedDiscounts)
            {
                string itemName = discountOffer.OfferName;
                int qualifyingItemCount = discountOffer.QualifyingItemCount;
                int itemCount = scannedItems.Count(item => item == itemName);

                if (itemCount >= qualifyingItemCount)
                {
                    int totalItemsPrice = definedItems.Values.Where(item => item.Name == itemName)
                        .Sum(item => item.Price);
                    discount += discountOffer.CalculateDiscount(totalItemsPrice, itemCount);
                }
            }
            return discount;
        }

        public string getReceipt()
        {
            string receipt = "";
            foreach (string item in scannedItems)
            {
                Item? result = checkItemIsValid(item);

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