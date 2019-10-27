using System;
using System.Collections.Generic;
using System.Text;

namespace HF1Shopping
{
    class CountDiscount : DiscountBase
    {
        public char Name { get; set; }
        private readonly int buy;
        private readonly int get;
        public CountDiscount(char name, int buy, int get)
        {
            this.Name = name;
            this.buy = buy;
            this.get = get;
        }

        public override double CalculateDiscountedPrice(Dictionary<char, int> cart, Dictionary<char, Item> registeredProducts)
        {
            foreach (KeyValuePair<char, int> x in cart)
            {
                if (Name == x.Key)
                {
                    if (cart[Name] >= (buy + get))
                    {
                        double amount = cart[Name] / (buy + get);
                        return registeredProducts[Name].Price * amount * get;
                    }
                }
            }
            return 0;
        }
    }
}
