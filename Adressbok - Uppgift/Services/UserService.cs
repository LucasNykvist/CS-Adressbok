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


            if (File.Exists("users.json") && File.ReadAllText("users.json").Length > 0)
            {
                string jsonString = File.ReadAllText("users.json");
                List<User> existingUsers = JsonSerializer.Deserialize<List<User>>(jsonString);
                existingUsers.Add(user);
                jsonString = JsonSerializer.Serialize(existingUsers);
                File.WriteAllText("users.json", jsonString);
            }
            else
            {
                Users.Add(user);
                string jsonString = JsonSerializer.Serialize(Users);
                File.WriteAllText("users.json", jsonString);
            }

            Console.WriteLine("\nPress any key to continue\n");
            Console.ReadKey();
        }

        public void GetAllUsers(string filepath)
        {

            if (File.Exists("users.json"))
            {
                Console.WriteLine("All The Contacts In Your Adressbook: ");
                string jsonString = File.ReadAllText("users.json");
                List<User> users = JsonSerializer.Deserialize<List<User>>(jsonString);

                foreach (User user in users)
                {
                    Console.WriteLine("First Name: " + user.FirstName);
                    Console.WriteLine("Last Name: " + user.LastName);
                    Console.WriteLine("Email: " + user.Email);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("There is no file containing any contacts");
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        public void GetUser(string firstName)
        {
            if (File.Exists("users.json"))
            {
                string jsonString = File.ReadAllText("users.json");
                List<User> users = JsonSerializer.Deserialize<List<User>>(jsonString);

                var user = users.Find(x => x.FirstName == firstName);

                if (user != null)
                {
                    Console.WriteLine("---The Contact Was Found---\n");
                    Console.WriteLine("First Name: " + user.FirstName);
                    Console.WriteLine("Last Name: " + user.LastName);
                    Console.WriteLine("Email: " + user.Email);
                    Console.WriteLine("Telephone Number: " + user.TelephoneNumber);
                    Console.WriteLine($"Adress: {user.StreetAdress}, {user.PostCode} {user.City}\n");
                    Console.WriteLine("---------------------------\n");

                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("User not found!");
                }

            }
            else
            {
                Console.WriteLine("There is no file containing any contacts");
            }
        }

        public void RemoveSpecificUser()
        {
            throw new NotImplementedException();
        }
    }
}
