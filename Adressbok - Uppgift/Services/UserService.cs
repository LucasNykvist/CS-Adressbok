using System.Text.Json;
using System.IO;
using Adressbok___Uppgift.Interfaces;
using Adressbok___Uppgift.Models;

namespace Adressbok___Uppgift.Services
{
    public class UserService : IUserService
    {
        List<User> Users = new List<User>();
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


        public void GetAllUsers(string filepath)
        {

            if (!File.Exists(filepath))
            {
                Console.WriteLine("There Is No Adressbook File! Press enter to continue...");
                Console.ReadKey();
                return;
            }

            var jsonString = File.ReadAllText(filepath);

            Users = JsonSerializer.Deserialize<List<User>>(jsonString);

            if(Users.Count == 0)
            {
                Console.WriteLine("The Adressbook Is Empty! Press enter to continue...");
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

        public void RemoveSpecificUser()
        {
            throw new NotImplementedException();
        }

        public void SaveToJsonFile(string filepath)
        {

            var serializedUsers = new List<string>();

            foreach (var user in Users)
            {
                var _jsonString = JsonSerializer.Serialize(user);
                serializedUsers.Add(_jsonString);
            }

            var jsonString = string.Join(",", serializedUsers + "]");

            jsonString = "[" + jsonString + "]";

            File.AppendAllText(filepath, jsonString);
        }

    }
}
