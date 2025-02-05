using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonManagmentSystem.Users
{
    internal class Merchant:User
    {
        //List<Product> ProductSelling;
        //List<Product> ProductSold;
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
        }
    }
}
