
using System;
namespace Shopping_Kata

{
	public class Item
	{
		public string Name { get; set; }
		public int Price { get; set; }

		public Item(string name, int price)
		{
			this.Name = name;
			this.Price = price;
		}
	}
}