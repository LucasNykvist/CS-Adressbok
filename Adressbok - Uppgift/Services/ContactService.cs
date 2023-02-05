using System.Text.Json;
using Adressbok___Uppgift.Interfaces;
using Adressbok___Uppgift.Models;

namespace Adressbok___Uppgift.Services
{
    public class ContactService : IContactService
    {
        List<Contact> Contacts = new List<Contact>();

        public void AddContact()
        {
            Contact user = new Contact();

            // Array för alla props som våra kontaker har
            string[] contactProps = { "FirstName", "LastName", "Email", "TelephoneNumber", "StreetAdress", "PostCode", "City" };

            // Foreach loop som går igenom alla props som våra kontakter har
            foreach (string prop in contactProps)
            {
                //MEDANS en prop är tom genomförs logiken inuti blocket
                while (string.IsNullOrEmpty(user.GetType().GetProperty(prop)?.GetValue(user, null)?.ToString()))
                {

                    //Vi ber användaren att ange ett värde till varje prop
                    Console.WriteLine($"Enter {prop}: ");
                    user.GetType().GetProperty(prop).SetValue(user, Console.ReadLine().ToUpper());


                    //Om användare inte anger något printas ett error som säger att de måste ange ett värde - Loopar sedan tillbaks till koden över
                    if (string.IsNullOrWhiteSpace(user.GetType().GetProperty(prop)?.GetValue(user, null)?.ToString()))
                    {
                        Console.WriteLine($"Error, you need to enter {prop}");
                    }
                }
            }

            //Kollar om contacts.json filen existerar och innehåller något
            if (File.Exists("users.json") && File.ReadAllText("users.json").Length > 0)
            {
                //Först sparar vi all användare som finns i filen till jsonString variabeln
                string jsonString = File.ReadAllText("users.json");

                //Sedan skapar vi en lista med alla existerande kontakten
                List<Contact> existingUsers = JsonSerializer.Deserialize<List<Contact>>(jsonString);

                //Efter det lägger vi till den nya kontakten
                existingUsers.Add(user);

                //Sedan serialiserar vi den uppdaterade listan till jsonString variabeln
                jsonString = JsonSerializer.Serialize(existingUsers);

                //Till sist skriver vi över allt i filen med den uppdaterade jsonString
                File.WriteAllText("users.json", jsonString);
            }
            //Om filen är tom lägger vi till kontakten direkt från contacts listan
            else
            {
                Contacts.Add(user);
                string jsonString = JsonSerializer.Serialize(Contacts);
                File.WriteAllText("users.json", jsonString);
            }

            Console.WriteLine("\nPress any key to continue\n");
            Console.ReadKey();
        }

        public void GetAllContacts(string filepath)
        {
            if (File.Exists("users.json"))
            {
                Console.WriteLine("All The Contacts In Your Adressbook: ");
                string jsonString = File.ReadAllText("users.json");
                List<Contact> users = JsonSerializer.Deserialize<List<Contact>>(jsonString);

                foreach (Contact user in users)
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

        public void GetContact(string firstName)
        {
            if (File.Exists("users.json"))
            {
                string jsonString = File.ReadAllText("users.json");
                List<Contact> users = JsonSerializer.Deserialize<List<Contact>>(jsonString);

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

        public void RemoveSpecificContact(string firstName)
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
                    List<Contact> users = JsonSerializer.Deserialize<List<Contact>>(jsonString);
                    Contact user = users.Find(x => x.FirstName == firstName);
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
