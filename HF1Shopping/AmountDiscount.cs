using System;
using System.Collections.Generic;
using System.Text;

namespace HF1Shopping
{
    class AmountDiscount : DiscountBase
    {
        private readonly char name;
        private readonly int amount;
        private readonly double percentage;
        public AmountDiscount(char name, int amount, double percentage)
        {
            this.name = name;
            this.amount = amount;
            this.percentage = percentage;
        }

        public override double CalculateDiscountedPrice(Dictionary<char, int> cart, Dictionary<char, Item> products)
        {
            foreach (KeyValuePair<char, int> x in cart)
            {
                if (x.Key == name && cart[name] >= amount)
                {
                    return products[name].Price * (1 - percentage) * cart[name];
                }
            }
            return 0;
        }
    }
}
