using AmazonManagmentSystem.Models;
using AmazonManagmentSystem.Models.Users;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AmazonManagmentSystem
{
    internal static class AmazonSystem
    {
        public static List<User> users { get; set; }
        public static List<Product> Products { get; set; }

        // testing data
        static AmazonSystem()
        {
            users = new List<User>()
            {
            new Merchant("zizoamr920@gmail.com","Abdelaziz","01143949265","1234","Password@1"),
            new Merchant("m@gmail.com","Abdelaziz","01143949265","1234","m"),
            new Customer("zoz@gmail.com","zizo","01143949265","1234","Password@1"),
            new Customer("lol@gmail.com","LOL","01943941265","8991","Lol2004@1"),
            new Customer("c@gmail.com","LOL","01943941265","8991","a"),
            };
            Products = new List<Product>()
            {
                new Product(1,"Phone","IPHONE 16 pro","256 Gb",120000,4),
                new Product(2,"TV","LG","50 inch",13000,2),
                new Product(3,"Perfume","Jaguar","50ml ",700,10),
                new Product(4,"Phone","Samsung S25","128 Gb",70000,1),
                new Product(5,"Home Appliance","Fridge","2 doors",20000,3),
            };

           

        }
        public static void StartSystem()
        {
            bool flag = false;
            User newUser = new User();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Amazon   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------");

            Console.WriteLine("\t1) Login\t\t\t2) Create New User");
            int Result;
            do
            {
                Console.Write("Choice: ");
                flag = int.TryParse(Console.ReadLine(), out Result);

            } while (flag != true);
            if (Result == 1)
            {
                Console.Clear();
                newUser = Login(newUser);
            }
            else
            {
                Console.Clear();
                newUser = CreateNewUser(newUser);
            }
            Console.Clear();
            if (newUser is Customer)
            {
                CustomerView((Customer)newUser);
            }
            else if (newUser is Merchant)
            {
                MerchantView((Merchant)newUser);
            }
        }


        public static User Login(User newUser)
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Amazon   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Login   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------\n");
            string email = EmailRegex();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var existingUser = users.FirstOrDefault(u => u.Email == email);

            if (existingUser == null)
            {
                Console.WriteLine("User does not exist. Would you like to create a new user?");
                Console.WriteLine("1) Create New User\t2) Main Menu\t3) Login Again");
                int result;
                while (!int.TryParse(Console.ReadLine(), out result) || (result != 1 && result != 2 && result != 3)) ;

                if (result == 1) return CreateNewUser(new User());
                else if (result == 2) StartSystem();
                else Login(newUser);
            }
            else
            {
                while (existingUser.Password != password)
                {
                    Console.WriteLine("Incorrect password! Try again.");
                    password = PasswordInput();
                }
            }
            return existingUser;

        }

        #region Inputs
        public static string EmailRegex()
        {
            string email;
            bool flag;
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            do
            {
                Console.Write("Email: ");
                email = Console.ReadLine();

                flag = Regex.IsMatch(email, emailPattern);

                if (!flag)
                {
                    Console.WriteLine("Invalid email format. Please enter a valid email (e.g., example@gmail.com).");
                }

            } while (!flag);

            return email;
        }
        public static string PasswordInput()
        {
            string password;
            bool flag;
            string passwordPattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

            do
            {
                Console.Write("password: ");
                password = Console.ReadLine();

                flag = Regex.IsMatch(password, passwordPattern);

                if (!flag)
                {
                    Console.WriteLine("Invalid password! Your password must contain:");
                    Console.WriteLine("✅ At least 8 characters");
                    Console.WriteLine("✅ At least one letter");
                    Console.WriteLine("✅ At least one number");
                    Console.WriteLine("✅ At least one special character (@$!%*?&)");
                }

            } while (!flag);

            return password;
        }

        #endregion

        public static User CreateNewUser(User newUser)
        {
            bool flag = false;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Amazon   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     SignUp   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------\n");

            Console.Write("Choose Account Type:\n1) Merchant\t2) Customer :");
            int result;
            do
            {
                flag = int.TryParse(Console.ReadLine(), out result);
                if (result == 1 || result == 2)
                {
                    flag = true;
                }
            } while (flag != true);

            if (result == 1)
            {
                newUser = new Merchant();

            }
            else
            {
                newUser = new Customer();
            }
            do
            {
                User.SetEmail(newUser);
                User.SetName(newUser);
                User.SetPhoneNum(newUser);
                User.SetVisaNum(newUser);
                User.Setpassword(newUser);
                flag = CheckEmailExist(users, newUser.Email);
                if (flag == true)
                {
                    Console.Clear();
                    Console.WriteLine("Email ALready Exist");
                }
            } while (flag != false);

            return newUser;
        }

        #region Check Data
        public static bool CheckUserExist(List<User> users, string email, string password) // make it bool
        {
            if (CheckEmailExist(users, email) && CheckPasswordExist(users, password))
            {
                return true;
            }
            return false;
        }
        public static bool CheckEmailExist(List<User> users, string email)
        {
            foreach (User user in users)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckPasswordExist(List<User> users, string password)
        {
            foreach (User user in users)
            {
                if (user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Customer View
        public static void CustomerView(Customer user)
        {
            int choice;
            bool flag = false;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Amazon   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("|  1 Browse Products    |  2  My Cart     | 3 Profile    | 4 Exit  |");
            Console.WriteLine("--------------------------------------------------------------------");
            do
            {
                Console.Write("Navigate Pages Through Numbers: ");
                flag = int.TryParse(Console.ReadLine(), out choice);

                if (flag && (choice >= 1 && choice <= 4))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1 and 4.");
                }
            } while (true);

            switch (choice)
            {
                case 1:
                    // broswe product
                    Console.Clear();
                    ViewBrowseProducts(user);
                    break;
                case 2:
                    Console.Clear();
                    ViewMyCart(user);
                    break;
                case 3:
                    // profile
                    Console.Clear();
                    ViewProfile(user);
                    break;
                case 4:
                    //exit
                    Console.Clear();
                    StartSystem();
                    break;
            }

        }

        public static void ViewMyCart(Customer user)
        {
            int choice;
            bool flag = false;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Amazon   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------    My Cart   -----------------------------");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("[<- -1 ]Home --------------------------------------------------------\n");
            Console.WriteLine();
            user.ViewCart(user);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"\t\t\t\t\t\tTotal Money:\t{user.TotalMoney(user.Cart)}$");

            #region Choice
            do
            {
                Console.Write("\nPurchase Product [1] | Home [-1]: ");
                flag = int.TryParse(Console.ReadLine(), out choice);

                if (choice == -1)
                {
                    Console.Clear();
                    CustomerView(user);
                    break; // Exit the loop
                }
                else if (choice == 1)
                {
                    int P_id;
                    bool ValidProduct = false;

                    do
                    {
                        Console.Write("Enter Product ID You Will Purchase: ");
                        ValidProduct = int.TryParse(Console.ReadLine(), out P_id);

                        if (ValidProduct)
                        {
                            var product = user.Cart.FirstOrDefault(p => p.ProductID == P_id);
                            if (product != null)
                            {
                                user.PurchaseProduct(product);
                                if (product.Quantity > 1)
                                {
                                    product.Quantity--;
                                    product.UnitInStock--;
                                }
                                else if (product.Quantity == 1)
                                {
                                    user.RemoveFromCart(product); // Remove from cart if quantity is 1
                                    product.Quantity = 0; // Ensure quantity is set to zero
                                    product.UnitInStock--; // Decrease stock count only once
                                }
                                Console.WriteLine($"Purchased: {product.Name}");
                                break; // Exit product selection loop after purchase
                            }
                            else
                            {
                                Console.WriteLine("Invalid Product ID. Try again.");
                                ValidProduct = false; // Force retry
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Enter a valid numeric Product ID.");
                        }

                    } while (!ValidProduct);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Enter 1 to purchase or -1 to go home.");
                }

            } while (choice != -1);

            #endregion

        }

        public static void ViewBrowseProducts(Customer user)
        {
            int choice;
            bool flag = false;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Amazon   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("----------------------    Browse Products   -------------------------");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("[<- -1 ]Home --------------------------------------------------------\n");

            Console.WriteLine("\nProducts: ");
            foreach (var product in Products)
            {
                Console.WriteLine(product);
            }
            #region Choice
            do
            {
                Console.Write("\n Add To Cart (1)\t|\tHome (-1): ");
                flag = int.TryParse(Console.ReadLine(), out choice);

                if (choice == -1)
                {
                    Console.Clear();
                    CustomerView(user);
                    break; // Exits the loop
                }
                else if (choice == 1)
                {
                    int id;
                    bool validProduct = false;

                    do
                    {
                        Console.Write("Enter Product ID: ");
                        flag = int.TryParse(Console.ReadLine(), out id);

                        if (flag)
                        {
                            Product product = Products.FirstOrDefault(p => p.ProductID == id);

                            if (product != null)
                            {
                                var cartProduct = user.Cart.FirstOrDefault(p => p.ProductID == id);

                                if (cartProduct != null)
                                {
                                    cartProduct.Quantity++;
                                }
                                else
                                {
                                    product.Quantity = 1;
                                    product.IsInCart = true;
                                    user.Cart.Add(product);
                                }

                                validProduct = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Product ID. Try again.");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Enter a number.");
                        }
                    } while (!validProduct);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1 to add a product or -1 to exit.");
                }
            } while (choice != -1);

            #endregion

        }


        #endregion

        #region Merchant View

        public static void MerchantView(Merchant user)
        {
            int choice;
            bool flag;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Amazon   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("| 1 My Products on Market  | 2  Add New Prodcut  | 3 Profile | 4 Exit|");
            Console.WriteLine("---------------------------------------------------------------------\n");
            Console.WriteLine("[<- -1 ]Home --------------------------------------------------------\n");


            do
            {
                Console.Write("Navigate Pages Through Numbers: ");
                flag = int.TryParse(Console.ReadLine(), out choice);

                if (flag && (choice >= 1 && choice <= 4))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1 and 4.");
                }
            } while (true);

            switch (choice)
            {
                case 1:
                    // broswe product
                    Console.Clear();
                    MyProductsSellView(user);
                    break;
                //case 2:
                //    Console.Clear();
                //    ViewMyCart(user);
                //    break;
                case 3:
                    // profile
                    Console.Clear();
                    ViewProfile(user);
                    break;
                case 4:
                    //exit
                    Console.Clear();
                    StartSystem();
                    break;
            }
        }


        public static void MyProductsSellView(Merchant user)
        {
            int choice;
            bool flag = false;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Amazon   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("---------------------    My Products Selling   ---------------------");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("[<- -1 ]Home --------------------------------------------------------\n");

            Console.WriteLine("\tMarket: ");

            
            if (user.ProductSelling.Count != 0)
            {
                foreach (var product in user.ProductSelling)
                {
                    Console.WriteLine(product);
                }
            }

            #region Choice
            do
            {
                Console.Write("\n Remove from Market (1)\t|\tHome (-1): ");
                flag = int.TryParse(Console.ReadLine(), out choice);

                if (choice == -1)
                {
                    Console.Clear();
                    MerchantView(user);
                    break; // Exit loop
                }
                else if (choice == 1)
                {
                    int id;
                    bool validProduct = false;

                    do
                    {
                        Console.Write("Enter Product ID: ");
                        flag = int.TryParse(Console.ReadLine(), out id);

                        if (flag)
                        {
                            var sellingProduct = user.ProductSelling.FirstOrDefault(p => p.ProductID == id);

                            if (sellingProduct != null)
                            {
                                if (sellingProduct.Quantity > 1)
                                {
                                    sellingProduct.Quantity--; // Reduce quantity by 1
                                    Console.WriteLine($"Decreased quantity of {sellingProduct.Name}. Remaining: {sellingProduct.Quantity}");
                                }
                                else
                                {
                                    user.ProductSelling.Remove(sellingProduct); // Remove if last quantity
                                    Console.WriteLine($"{sellingProduct.Name} has been removed from your selling list.");
                                }

                                validProduct = true;
                            }
                            else
                            {
                                Console.WriteLine("Product not found in your selling list.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Enter a valid product ID.");
                        }
                    } while (!validProduct);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1 to remove a product or -1 to exit.");
                }
            } while (choice != -1);

            #endregion
        }

        public static void AddNewProductView(Merchant user)
        {

        }

        #endregion

        public static void ViewProfile(User user)
        {
            int choice;
            bool flag = false;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Amazon   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("------------------------    My Profile   ----------------------------");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("[<- -1 ]Home --------------------------------------------------------\n");

            Console.WriteLine($"Welcome Back {user.Name}");
            Console.WriteLine("\t\tAccount Information");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine(user);
            Console.WriteLine("\n---------------------------------------------------------------------");

            if (user is Customer customer)
            {
                Console.WriteLine("\t\tPurchased Products");
                Console.WriteLine("---------------------------------------------------------------------\n");

                if (customer.PurchasedProducts.Count == 0)
                {
                }
                else
                {
                    foreach (var product in customer.PurchasedProducts)
                    {
                        product.IsPurchased = true;
                        product.IsInCart = false;
                        Console.WriteLine(product);
                        product.IsPurchased = false;
                    }
                }
                Console.WriteLine("\n---------------------------------------------------------------------");
                Console.WriteLine($"\t\t\t\t\tTotal Money Spent: {customer.TotalMoney(customer.PurchasedProducts)}$");

            }

            else if (user is Merchant merchant)
            {
                Console.WriteLine("\t\tSold Products");
                Console.WriteLine("---------------------------------------------------------------------\n");

                if (merchant.ProductSold.Count == 0)
                {
                }
                else
                {
                    foreach (var product in merchant.ProductSold)
                    {

                        Console.WriteLine(product);

                    }
                }
                Console.WriteLine("\n---------------------------------------------------------------------");
                Console.WriteLine($"\t\t\t\t\tTotal Money Profits: {merchant.TotalMoney(merchant.ProductSold)}$");
            }

            #region Back to Home Choice
            do
            {
                Console.Write("Navigate: ");
                flag = int.TryParse(Console.ReadLine(), out choice);
                if (choice == -1)
                {
                    Console.Clear();
                    if (user is Customer c)
                    {
                        CustomerView(c);
                    }
                    else if (user is Merchant m)
                    {
                        MerchantView(m);
                    }
                }
                else flag = false;
            } while (!flag);
            #endregion

        }
    
    }
}
