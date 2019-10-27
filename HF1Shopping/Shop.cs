using System;
using System.Collections.Generic;
using System.Text;

namespace HF1Shopping
{
    class Shop
    {
        private readonly Customer customer;
        private readonly Dictionary<char, Item> products;
        Discounts discounts;

        public Shop(Customer customer)
        {
            this.customer = customer;
            products = new Dictionary<char, Item>();
            discounts = new Discounts();
        }

        public void RegisterItem(char name, int price)
        {
            if (Char.IsUpper(name))
            {
                products.Add(name, new Item(name, price));
            }
        }

        //discounts
        public void RegisterAmountDiscount(Char name, int amount, double percentage)
        {
            discounts.AddAmountDiscount(name, amount, percentage);
        }
        public void RegisterComboDiscount(string items, int price)
        {
            discounts.AddComboDiscount(items, price);
        }
        public void RegisterCountDiscount(char name, int buy, int get)
        {
            discounts.AddCountDiscount(name, buy, get);
        }

        //Price calculation
        public double CalculatePrice()
        {
            double sum = 0;
            Dictionary<char, int> bought = customer.GetBoughtProducts();

            //calculate full price
            foreach (KeyValuePair<char, int> item in bought)
            {
                if (item.Key != 't' & Char.IsLetter(item.Key) & item.Key != 'p')
                {
                    sum += bought[item.Key] * products[item.Key].Price;
                }
            }

            sum -= CalculateDiscountPrice();

            //Check if Club member
            if (IsClubMember(customer.GetBoughtProducts()))
            {
                sum *= 0.9;
            }
            //pay by supershop points
            sum -= PayByPoints(customer.GetBoughtProducts(), sum);

            //get points from the discounted price
            GiveClubMemberPoints(sum);
            return sum;
        }

        //Discount Price calculation
        public double CalculateDiscountPrice()
        {
            discounts.RefreshData(customer.GetBoughtProducts(), products);
            return discounts.CalculatePrice(); ;
        }

        //If contains number give Club member points
        public bool IsClubMember(Dictionary<char, int> cart)
        {
            foreach (KeyValuePair<char, int> item in cart)
            {
                if (item.Key == 't')
                {
                    return true;
                }
            }
            return false;
        }

        //set id and points
        public void GiveClubMemberPoints(double price)
        {
            foreach (KeyValuePair<char, int> item in customer.GetBoughtProducts())
            {
                if (Char.IsNumber(item.Key))
                {
                    customer.ID = Convert.ToInt32(item.Key.ToString());
                    customer.ClubMemberPoints += price * 0.01;
                    break;
                }
            }
        }

        //If contains number give Club member points
        public double PayByPoints(Dictionary<char, int> cart, double sum)
        {
            foreach (KeyValuePair<char, int> item in cart)
            {
                if (item.Key == 'p')
                {
                    return sum * 0.01;
                }
            }
            return 0;
        }
    }
}
