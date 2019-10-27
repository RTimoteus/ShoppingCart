using System;
using System.Collections.Generic;
using System.Text;

namespace HF1Shopping
{
    class Customer
    {
        private readonly Dictionary<char, int> cart;
        public int ID { get; set; }
        public double ClubMemberPoints { get; set; }
        public Customer()
        {
            cart = new Dictionary<char, int>();
            ID = 0;
        }

        //Buy Item
        public void Buy(string x)
        {
            foreach (Char item in x)
            {
                AddItem(item);
            }
        }

        //Add new Item
        public void AddItem(char name)
        {
            if (IsAlreadyAdded(cart, name))
            {
                BuyMoreFromItem(name);
            }
            else
            {
                cart.Add(name, 1);
            }
        }

        //Add more to an existing Item
        public void BuyMoreFromItem(Char name)
        {
            cart[name] += 1;
        }

        public bool IsAlreadyAdded(Dictionary<char, int> boughtP, char name)
        {
            foreach (KeyValuePair<Char, int> item in boughtP)
            {
                if (item.Key == name)
                {
                    return true;
                }
            }
            return false;
        }

        public Dictionary<char, int> GetBoughtProducts()
        {
            return cart;
        }
    }
}
