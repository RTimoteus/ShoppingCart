using System;
using System.Collections.Generic;
using System.Text;

namespace HF1Shopping
{
    class ComboDiscount : DiscountBase
    {
        private readonly double discountPrice;
        private readonly string inputString;
        private Dictionary<char, int> products;
        public ComboDiscount(string items, int discountPrice)
        {
            this.discountPrice = discountPrice;
            this.inputString = items;
            CountItems();
        }

        //count the different types of product
        private void CountItems()
        {
            products = new Dictionary<char, int>();

            foreach (Char item in inputString)
            {
                if (products.ContainsKey(item))
                {
                    products[item] += 1;
                }
                else
                {
                    products.Add(item, 0);
                }
            }
        }

        public override double CalculateDiscountedPrice(Dictionary<char, int> cart, Dictionary<char, Item> prod)
        {
            //min is the first element
            int min = cart[inputString[0]];

            //calculate full Price
            int fullPrice = FullPrice(cart, prod);

            //search for smaller min just if all the products are in cart
            if (IsCartContainsProducts(cart))
            {
                foreach (KeyValuePair<char, int> x in products)
                {
                    //Comparing min to the amount of the next product
                    if (min > cart[x.Key])
                    {
                        min = cart[x.Key];
                    }
                }
            }
            return fullPrice - (discountPrice * min);
        }

        private int FullPrice(Dictionary<char, int> cart, Dictionary<char, Item> prod)
        {
            int sum = 0;
            foreach (KeyValuePair<char, int> x in products)
            {
                sum += prod[x.Key].Price;
            }
            return sum;
        }

        //check if all the products are bought for this discount
        private bool IsCartContainsProducts(Dictionary<char, int> cart)
        {
            foreach (KeyValuePair<char, int> product in products)
            {
                if (!cart.ContainsKey(product.Key))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
