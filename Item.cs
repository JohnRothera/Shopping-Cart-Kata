using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Kata

{
	public class Item
	{
		public string Name { get; set; }
		public int Price { get; set; }
		public Discounts? DiscountOffer { get; set; }


		public Item(string name, int price, string? discount = null)
		{
			this.Name = name;
			this.Price = price;
			if(discount != null)
			{
				try
				{
					Discounts validOffer = new Discounts(discount);
					this.DiscountOffer = validOffer;
				}
				catch (System.Exception)
				{
					System.Console.WriteLine("Invalid Offer");
				}
			}
		}
	}
}