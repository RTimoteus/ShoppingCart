using System;
using System.Collections.Generic;
using System.Text;

namespace HF1Shopping
{
    class Discounts
    {
        List<DiscountBase> discounts;
        Dictionary<char, int> cart;
        Dictionary<char, Item> registeredProducts;

        public Discounts()
        {
            discounts = new List<DiscountBase>();
            cart = new Dictionary<char, int>();
            registeredProducts = new Dictionary<char, Item>();
        }

        //Adding discounts
        public void AddCountDiscount(char name, int buy, int get)
        {
            discounts.Add(new CountDiscount(name, buy, get));
        }
        public void AddAmountDiscount(char name, int amount, double percentage)
        {
            discounts.Add(new AmountDiscount(name, amount, percentage));
        }
        public void AddComboDiscount(string products, int price)
        {
            discounts.Add(new ComboDiscount(products, price));
        }


        public double CalculatePrice()
        {
            double sum = 0;
            foreach (DiscountBase disc in discounts)
            {
                sum += disc.CalculateDiscountedPrice(cart, registeredProducts);
            }
            return sum;
        }

        //starting dictionarys are differents after shopping 
        public void RefreshData(Dictionary<char, int> cart, Dictionary<char, Item> registeredProducts)
        {
            this.cart = cart;
            this.registeredProducts = registeredProducts;
        }

    }
}
