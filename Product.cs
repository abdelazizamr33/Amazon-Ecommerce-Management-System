using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonManagmentSystem
{
    internal class Product
    {
        public int ProductID { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

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

        public override string ToString()
        {
            return $"Product Id: {ProductID}    | Name: {Name}  | Category: {Category}  | Price: {Price}\nDescription: {Description}";
        }
    }

}

