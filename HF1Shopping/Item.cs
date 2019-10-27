using System;
using System.Collections.Generic;
using System.Text;

namespace HF1Shopping
{
    public class Item
    {
        private readonly char name;
        public int Price { get; }

        public Item(char name, int price)
        {
            this.name = name;
            this.Price = price;
        }
    }
}
