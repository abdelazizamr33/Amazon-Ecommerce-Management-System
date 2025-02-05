using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonManagmentSystem.Users
{
    internal class Customer:User
    {
        public List<Product> Cart { get; set; }
        public double MoneySpent { get; set; }
        public void ViewCart()
        {
            foreach (Product product in Cart)
            {
                Console.WriteLine(product);
            }
        }
        public void AddToCart()
        {
            Product product = new Product();
            product.SetProductID(product);
            product.SetName(product);
            product.SetCategory(product);
            product.SetPrice(product);
            product.SetDescription(product);
            Cart.Add(product);
        }

        public void RemoveFromCart(Product product)
        {
            Cart.Remove(product);
        }
        public Customer(string email, string name, string phonenum, string visanum, string pass)
    : base(email, name, phonenum, visanum, pass)

        {
            Cart= new List<Product>();
            MoneySpent= 0;
        }
        public Customer()
        {
            Cart = new List<Product>();
            MoneySpent = 0;
        }
        public decimal TotalMoney()
        {
            decimal totalMoney = 0;
            foreach(Product product in Cart)
            {
                totalMoney += product.Price;
            }
            return totalMoney;
        }
        
    }
}
