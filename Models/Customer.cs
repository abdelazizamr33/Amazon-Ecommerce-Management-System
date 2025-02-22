using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonManagmentSystem.Models.Users
{
    internal class Customer : User
    {
        public List<Product> Cart { get; set; }
        public List<Product> PurchasedProducts { get; set; }
        public double MoneySpent { get; set; }
        public void ViewCart(Customer customer)
        {
            foreach (var product in customer.Cart)
            {
                product.IsInCart = true;
                Console.WriteLine(product);
            }
        }
        public void AddToCart(List<Product> Products,int AddedProductId)
        {
            Product product = Products.FirstOrDefault(p => p.ProductID == AddedProductId);
            Cart.Add(product);
            Console.WriteLine("Added To Cart ✅");
        }

        public void RemoveFromCart(Product product)
        {
            Cart.Remove(product);
        }
        public Customer(string email, string name, string phonenum, string visanum, string pass)
    : base(email, name, phonenum, visanum, pass)

        {
            Cart = new List<Product>();
            PurchasedProducts = new List<Product>();
            MoneySpent = 0;
        }
        public Customer()
        {
        }
        
        static Customer()
        {

        }

        public void PurchaseProduct(Product product)
        {
            PurchasedProducts.Add(product);

        }

    }
}
