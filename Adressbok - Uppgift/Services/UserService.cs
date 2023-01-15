﻿using System.Text.Json;
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

            string[] contactProps = { "FirstName", "LastName", "Email", "TelephoneNumber", "StreetAdress", "PostCode", "City" };

            foreach (string prop in contactProps)
            {
                while (string.IsNullOrEmpty(user.GetType().GetProperty(prop)?.GetValue(user, null)?.ToString()))
                {
                    Console.WriteLine($"Enter {prop}: ");
                    user.GetType().GetProperty(prop).SetValue(user, Console.ReadLine().ToUpper());

                    if (string.IsNullOrWhiteSpace(user.GetType().GetProperty(prop)?.GetValue(user, null)?.ToString()))
                    {
                        Console.WriteLine($"Error, you need to enter {prop}");
                    }
                }
            }

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
                    Console.WriteLine("Contact dose not exist!");
                }

            }
            else
            {
                Console.WriteLine("Contact file not found!");
            }
        }

        public void RemoveSpecificUser(string firstName)
        {
            Console.WriteLine("Are you sure you want to remove this contact?`\n" +
                "'Y' for YES\n" +
                "'N' for NO");

            bool YesNo = true;
            string accept = Console.ReadLine().ToUpper();

            switch (accept)
            {
                case "Y":
                    YesNo = true;
                    break;

                case "N":
                    YesNo = false;
                    break;

                default:
                    Console.WriteLine("Not a valid option");
                    break;
            }

            if (YesNo)
            {
                if (File.Exists("users.json"))
                {
                    string jsonString = File.ReadAllText("users.json");
                    List<User> users = JsonSerializer.Deserialize<List<User>>(jsonString);
                    User user = users.Find(x => x.FirstName == firstName);
                    if (user != null)
                    {
                        users.Remove(user);
                        jsonString = JsonSerializer.Serialize(users);
                        File.WriteAllText("users.json", jsonString);
                        Console.WriteLine("Contact was deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Contact not found!");
                    }
                }
                else
                {
                    Console.WriteLine("Contact file not found!");
                }
            }
            else
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Contact will not be removed\n");
                Console.WriteLine("Press any key to continue");
                Console.WriteLine("---------------------");
                Console.ReadKey();
            }
        }
    }
}
