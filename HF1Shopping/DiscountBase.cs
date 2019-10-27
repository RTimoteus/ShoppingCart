using System;
using System.Collections.Generic;
using System.Text;

namespace HF1Shopping
{
    public abstract class DiscountBase
    {
        public abstract double CalculateDiscountedPrice(Dictionary<char, int> cart, Dictionary<char, Item> products);
    }
}
