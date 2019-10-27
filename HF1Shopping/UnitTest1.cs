using System;
using Xunit;

namespace HF1Shopping
{
    public class UnitTest1
    {

        [Fact]
        public void TestBuying()
        {
            Customer customer = new Customer();
            Shop shop = new Shop(customer);

            shop.RegisterItem('A', 300);
            shop.RegisterItem('B', 200);
            shop.RegisterItem('C', 100);
            customer.Buy("ABC");
            Assert.Equal(600, shop.CalculatePrice());
        }

        [Fact]
        public void CountDiscountTest()
        {
            Customer customer = new Customer();
            Shop shop = new Shop(customer);

            shop.RegisterItem('A', 300);
            shop.RegisterCountDiscount('A', 3,1);
            customer.Buy("AAAA");
            Assert.Equal(900, shop.CalculatePrice());
        }

        [Fact]
        public void AmountDiscountTest()
        {
            Customer customer = new Customer();
            Shop shop = new Shop(customer);

            shop.RegisterItem('A', 300);
            shop.RegisterAmountDiscount('A', 5, 0.9);
            customer.Buy("AAAAA");
            Assert.Equal(1350, shop.CalculatePrice());
        }

        [Fact]
        public void ComboDiscountTest()
        {
            Customer customer = new Customer();
            Shop shop = new Shop(customer);

            shop.RegisterItem('A', 300);
            shop.RegisterItem('B', 200);
            shop.RegisterItem('C', 100);
            shop.RegisterComboDiscount("ABC", 350);
            customer.Buy("BCA");
            Assert.Equal(350, shop.CalculatePrice());
        }

        [Fact]
        public void ClubMemberTest()
        {
            Customer customer = new Customer();
            Shop shop = new Shop(customer);

            shop.RegisterItem('B', 200);
            customer.Buy("BBBt");
            Assert.Equal(540, shop.CalculatePrice());
        }

        [Fact]
        public void ClubMemberIDTest()
        {
            Customer customer = new Customer();
            Shop shop = new Shop(customer);

            shop.RegisterItem('B', 400);
            customer.Buy("BBB3");
            double x = shop.CalculatePrice();
            Assert.Equal(3.0, customer.ID);
        }

        [Fact]
        public void ClubMemberpointsSavedTest()
        {
            Customer customer = new Customer();
            Shop shop = new Shop(customer);

            shop.RegisterItem('B', 200);
            customer.Buy("B9BtB");
            double x = shop.CalculatePrice();
            Assert.Equal(5.4, customer.ClubMemberPoints);
        }
        [Fact]
        public void PayBySupershopTest()
        {
            Customer customer = new Customer();
            Shop shop = new Shop(customer);

            shop.RegisterItem('B', 200);
            customer.Buy("Bp");
            Assert.Equal(198, shop.CalculatePrice());
        }
    }
}
