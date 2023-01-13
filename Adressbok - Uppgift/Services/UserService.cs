using Adressbok___Uppgift.Interfaces;
using Adressbok___Uppgift.Models;

namespace Adressbok___Uppgift.Services
{
    public class UserService : IUserService
    {
        public void AddUser()
        {
            User user = new User();
            Console.WriteLine("Enter First Name: ");
            user.FirstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            user.LastName = Console.ReadLine();

            Console.WriteLine("Enter Email: ");
            user.Email = Console.ReadLine();

            Console.WriteLine("Enter Telephone Number: ");
            user.TelephoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Street Adress: ");
            user.StreetAdress = Console.ReadLine();

            Console.WriteLine("Enter Postcode: ");
            user.PostCode = Console.ReadLine();

            Console.WriteLine("Enter City Name: ");
            user.City = Console.ReadLine();

            Users.Add(user);
            Console.WriteLine("\nPress any key to continue\n");
            Console.ReadKey();
        }


        public void GetAllUsers()
        {
            if(Users.Count == 0)
            {
                Console.WriteLine("The Adressbook Is Empty! Press enter to continue");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("All The Contacts In Your Adressbook: ");
            foreach(var user in Users)
            {
                PrintUser(user);
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        private void PrintUser(User user)
        {
            Console.WriteLine($"First Name: {user.FirstName}");
            Console.WriteLine($"Last Name: {user.LastName}");
            Console.WriteLine($"Email: {user.Email}");

        }

        public void RemovepecificUser()
        {
            throw new NotImplementedException();
        }
    }
}
