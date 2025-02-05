using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AmazonManagmentSystem.Users
{
    internal class User
    {
        public string Email { get; set; }
        
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        
        public string VisaNumber { get; set; }
        
        public string Password { get; set; }
        

        public User()
        {
            
        }
        public User(string email,string name,string phonenum,string visanum,string pass)
        {
            Email = email;
            Name = name;
            PhoneNumber = phonenum;
            VisaNumber=visanum;
            Password = pass;
        }
        public static void SetName(User user)
        {
            user.Name = Console.ReadLine();
        }

        public static void SetEmail(User user)
        {
            bool flag = false;
            do
            {
                Console.Write("Email: ");
                string inputEmail = Console.ReadLine(); // Read input once

                // Regular Expression for basic email validation
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                if (!string.IsNullOrEmpty(inputEmail) &&
                    Regex.IsMatch(inputEmail, emailPattern) &&
                    inputEmail.Length > 8)
                {
                    user.Email = inputEmail; // Assign email only if valid
                    flag = true; // Exit loop
                }
                else
                {
                    Console.WriteLine("Invalid email. Please enter in 'example123@gmail.com' format.");
                }

            } while (!flag);
        }

        public static void SetPhoneNum(User user)
        {
            bool flag = false;
            do
            {
                Console.Write("Phone Number: ");
                user.PhoneNumber = Console.ReadLine();
                if (!string.IsNullOrEmpty(user.PhoneNumber) &&
                    user.PhoneNumber.All(char.IsDigit) &&
                    user.PhoneNumber.Length == 11)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    Console.WriteLine("Invalid phone number. Please enter a valid 11-digit number (e.g., 01 xx xxxx xxxx).");
                }

            } while (!flag);
        }

        public static void SetVisaNum(User user)
        {
            bool flag = false;
            do
            {
                Console.Write("Visa Number: ");
                user.VisaNumber = Console.ReadLine();

                if (!string.IsNullOrEmpty(user.VisaNumber) &&
                    user.VisaNumber.All(char.IsDigit) &&
                    user.VisaNumber.Length == 16)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    Console.WriteLine("Invalid Visa number. Please enter a valid 16-digit number.");
                }

            } while (!flag);
        }

        public static void Setpassword(User user)
        {
            string password;
            bool flag = false;
            Console.WriteLine("Make Sure Your Password is More than 8 Characters iclude Special Characters");
            do
            {
                Console.Write("Password: ");
                user.Password = Console.ReadLine();

                if (string.IsNullOrEmpty(user.Password))
                {
                    flag = false;
                }
                else flag = true;
            } while (flag != true);
        }
    }
}
