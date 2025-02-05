using AmazonManagmentSystem.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AmazonManagmentSystem
{
    internal static class System
    {
        
        public static void StartSystem()
        {
            bool flag = false;
            User newUser=null;
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

            List<User> users = new List<User>()
            { 
            new Merchant("zizoamr920@gmail.com","Abdelaziz","01143949265","1234","password1234@#$"),
            new Customer("abdelaziz@gmail.com","zizo","01143949265","1234","password1234@#$"),
            new Customer("lol@gmail.com","LOL","01943941265","8991","lol1122@#$"),
            };
            

            if(Result==1)
            {
                Console.Clear();
                newUser=Login(users,newUser);
            }
            else
            {
                Console.Clear();
                newUser=CreateNewUser(users,newUser);
            }

            Console.Clear();
            if (newUser is Customer)
            {
                CustomerHome((Customer) newUser);
            }
            
            

        }

        //Home Page
        public  static User Login(List<User> users,User newUser)
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Amazon   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Login   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------\n");
            bool flag = false;
            newUser.Email=EmailInput();
            newUser.Password = PasswordInput(); ;

            if(CheckEmailExist(users, newUser.Email))
            {

                if (CheckPasswordExist(users,newUser.Password))
                {
                    return newUser;
                }
                else
                {
                    do
                    {
                        newUser.Password = PasswordInput();
                        if (CheckPasswordExist(users, newUser.Password))
                        {
                            flag = true;
                        }
                    } while (flag == false);flag = false;
                }
            }
            else
            {
                Console.WriteLine("User dont Exist would you Like to Create New User\n1) Create\t2) Main Menu");
                int Result;
                do
                {
                    flag = int.TryParse(Console.ReadLine(), out Result);
                    if(Result==1) CreateNewUser(users,newUser);
                    else if (Result==2) StartSystem();

                } while (flag != true);

            }
            return null;
        }

        #region Inputs
        public static string EmailInput()
        {
            bool flag = false;
            string email;
            // email defensive code @,.com check length >8
            do
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
                if (!email.Contains(".com") && email.Contains("@"))
                {
                    flag = false;
                    Console.WriteLine("Please enter 'example@gmail.com' format");
                }
                else flag = true;

            } while (flag != true);
            return email;
        }
        public static string PasswordInput()
        {
            string password;
            bool flag = false;
            do
            {
                Console.WriteLine("Make Sure Your Password is More than 8 Characters iclude Special Characters");
                Console.Write("Password: ");
                password = Console.ReadLine();

                if (string.IsNullOrEmpty(password))
                {
                    flag = false;
                }
                else flag = true;
            } while (flag != true);
            return password;
        } 
        
        #endregion

        public static User CreateNewUser(List<User> users, User newUser)
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
                if(result==1 || result==2)
                {
                    flag = true;
                }
            }while(flag != true);

            if(result==1)
            {
                 newUser = new Merchant();

            }
            else
            {
                newUser= new Customer();
            }
            do
            {
                User.SetEmail(newUser);
                User.SetName(newUser);
                User.SetPhoneNum(newUser);
                User.SetVisaNum(newUser);
                User.Setpassword(newUser);
                flag = CheckEmailExist(users, newUser.Email);
                if(flag==true)
                {
                    Console.Clear();
                    Console.WriteLine("Email ALready Exist");
                }
            }while(flag != false);

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

        public static void CustomerHome(Customer user)
        {
            bool flag = false;
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Amazon   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("|  1 Browse Products    |  2  My Cart     | 3 Profile    | 4 Exit  |");
            Console.WriteLine("--------------------------------------------------------------------");
            int choice;
            do
            {
                Console.Write("Navigate Pages Through Numbers: ");
                flag = int.TryParse(Console.ReadLine(), out choice);
                if (choice!=1||choice!=2||choice!=3||choice!=4)
                {
                    flag = false;
                }
                else { flag = true; }
            } while (flag == false);

            switch(choice)
            {
                case 1:
                    // broswe product
                    break;
                case 2: 
                    ViewMyCart(user);
                    break;
                case 3:
                    // profile
                    break;
                case 4:
                    //exit
                    break;
            }

        }

        public static void ViewMyCart(Customer user)
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------     Amazon   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("-------------------------    My Cart   -----------------------------");
            Console.WriteLine("--------------------------------------------------------------------\n");
            Console.WriteLine();
            user.ViewCart();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"Total Money:\t\t\t\t{user.TotalMoney}");
        }
    }
}
