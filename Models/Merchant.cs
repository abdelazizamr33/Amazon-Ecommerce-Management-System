using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonManagmentSystem.Models.Users
{
    internal class Merchant : User
    {
        
        public List<Product> ProductSelling { get; set; }
        public List<Product> ProductSold { get; set; }
        public double Profit { get; set; }
        public void ListProduct()
        {

        }
        public void UnListProduct()
        {

        }
        public Merchant()
        {
            ProductSelling = new List<Product>();
            ProductSold = new List<Product>();
            Profit = 0;
        }
        public Merchant(string email, string name, string phonenum, string visanum, string pass)
    : base(email, name, phonenum, visanum, pass)

        {
            ProductSelling = new List<Product>();
            ProductSold = new List<Product>();
            Profit = 0;
            ProductSelling.Add(new Product(1, "Phone", "IPHONE 16 pro", "256 Gb", 120000, 4));
            ProductSelling.Add(new Product(2, "TV", "LG", "50 inch", 13000, 2));
            ProductSold.Add(new Product(1, "Laptop", "Hp victus", "256 Gb", 120000, 4));
            ProductSold.Add(new Product(2, "Home Appliances", "Fresh Blender", "make good foof", 900, 5));

        }
    }
}
