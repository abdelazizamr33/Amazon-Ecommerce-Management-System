using AmazonManagmentSystem.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonManagmentSystem.Models
{
    internal class Product
    {
        public int ProductID { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int UnitInStock { get; set; }
        public int Quantity { get; set; }
        public bool IsInCart { get; set; } = false;
        public bool IsPurchased { get; set; } = false;

        public Product()
        {
            
        }

        static Product()
        {
            List<Product> Products = new List<Product>()
            {
                new Product(1,"Phone","IPHONE 16 pro","256 Gb",120000,5),
                new Product(2,"TV","LG","50 inch",13000,8),
                new Product(3,"Perfume","Jaguar","50ml ",700,10),
                new Product(4,"Phone","Samsung S25","128 Gb",70000,2),
            };
        }
        public Product(int ProductID, string Category, string Name, string Description, decimal Price,int UnitInStock)
        {
            this.ProductID = ProductID;
            this.Category = Category;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.UnitInStock = UnitInStock;

        }                      
        public void SetProductID(Product product)
        {
            bool flag = false;
            do
            {
                Console.Write("Product ID: ");
                if (int.TryParse(Console.ReadLine(), out int newProductID))
                {
                    product.ProductID = newProductID;
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Product ID must be a number.");
                }
            } while (!flag);
        }

        public void SetCategory(Product product)
        {
            bool flag = false;
            do
            {
                Console.Write("Category: ");
                string newCategory = Console.ReadLine();
                if (!string.IsNullOrEmpty(newCategory))
                {
                    product.Category = newCategory;
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Category cannot be empty.");
                }
            } while (!flag);
        }

        public void SetName(Product product)
        {
            bool flag = false;
            do
            {
                Console.Write("Enter new Name: ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    product.Name = newName;
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Name cannot be empty.");
                }
            } while (!flag);
        }

        public void SetDescription(Product product)
        {
            bool flag = false;
            do
            {
                Console.Write("Description: ");
                string newDescription = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDescription))
                {
                    product.Description = newDescription;
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Description cannot be empty.");
                }
            } while (!flag);
        }

        public void SetPrice(Product product)
        {
            bool flag = false;
            do
            {
                Console.Write("Price: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal newPrice) && newPrice > 0)
                {
                    product.Price = newPrice;
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Price must be a positive number.");
                }
            } while (!flag);
        }

        public void SetUnitInStock(Product product)
        {
            bool flag = false;
            do
            {
                Console.Write("Units in Stock: ");
                if (int.TryParse(Console.ReadLine(), out int unitstock) && unitstock > 0)
                {
                    product.UnitInStock = unitstock;
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Units in Stock must be greater than 0.");
                }
            } while (!flag);
        }

        public override string ToString()
        {
            if (IsInCart)
            {
                return $"---------------------------------------------------------------------\n|  Product Id: {ProductID}  | Name: {Name}  | Category: {Category}  \n  Description: {Description}  | Price: {Price}$\n  Quantity:{Quantity}   \n---------------------------------------------------------------------";

            }
            else if(IsPurchased)
            {
                return $"---------------------------------------------------------------------\n|  Product Id: {ProductID}  | Name: {Name}  | Category: {Category}  \n  Description: {Description}  | Price: {Price}$   \n---------------------------------------------------------------------";

            }
            else
            {
                return $"---------------------------------------------------------------------\n|  Product Id: {ProductID}  | Name: {Name}  | Category: {Category}  \n  Description: {Description}  | Price: {Price}$\n  Unit in Stock: {UnitInStock}   \n---------------------------------------------------------------------";

            }
        }


        

    }

}

