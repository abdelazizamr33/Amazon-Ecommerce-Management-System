using AmazonManagmentSystem.Contexts;
using AmazonManagmentSystem.Models.Users;

namespace AmazonManagmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AmazonDbContext context = new AmazonDbContext();

            AmazonSystem.StartSystem();





        }
    }
}
