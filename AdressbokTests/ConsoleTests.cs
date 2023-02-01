using System;
using System.Text.Json;
using Adressbok___Uppgift.Interfaces;
using Adressbok___Uppgift.Models;
using Adressbok___Uppgift.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdressbokTests
{
    [TestClass]
    public class ConsoleTests
    {
        List<User> Users = new List<User>();
        public void AddUser(string fileName)
        {
            User user = new User();

            // Array f�r alla props som v�ra kontaker har
            string[] contactProps = { "FirstName", "LastName", "Email", "TelephoneNumber", "StreetAdress", "PostCode", "City" };

            // Foreach loop som g�r igenom alla props som v�ra kontakter har
            foreach (string prop in contactProps)
            {
                //MEDANS en prop �r tom genomf�rs logiken inuti blocket
                while (string.IsNullOrEmpty(user.GetType().GetProperty(prop)?.GetValue(user, null)?.ToString()))
                {

                    //Vi ber anv�ndaren att ange ett v�rde till varje prop
                    Console.WriteLine($"Enter {prop}: ");
                    user.GetType().GetProperty(prop).SetValue(user, Console.ReadLine().ToUpper());


                    //Om anv�ndare inte anger n�got printas ett error som s�ger att de m�ste ange ett v�rde - Loopar sedan tillbaks till koden �ver
                    if (string.IsNullOrWhiteSpace(user.GetType().GetProperty(prop)?.GetValue(user, null)?.ToString()))
                    {
                        Console.WriteLine($"Error, you need to enter {prop}");
                    }
                }
            }

            //Kollar om contacts.json filen existerar och inneh�ller n�got
            if (File.Exists("users.json") && File.ReadAllText("users.json").Length > 0)
            {
                //F�rst sparar vi all anv�ndare som finns i filen till jsonString variabeln
                string jsonString = File.ReadAllText("users.json");

                //Sedan skapar vi en lista med alla existerande kontakten
                List<User> existingUsers = JsonSerializer.Deserialize<List<User>>(jsonString);

                //Efter det l�gger vi till den nya kontakten
                existingUsers.Add(user);

                //Sedan serialiserar vi den uppdaterade listan till jsonString variabeln
                jsonString = JsonSerializer.Serialize(existingUsers);

                //Till sist skriver vi �ver allt i filen med den uppdaterade jsonString
                File.WriteAllText("users.json", jsonString);
            }
            //Om filen �r tom l�gger vi till kontakten direkt fr�n contacts listan
            else
            {
                Users.Add(user);
                string jsonString = JsonSerializer.Serialize(Users);
                File.WriteAllText("users.json", jsonString);
            }

            Console.WriteLine("\nPress any key to continue\n");
            Console.ReadKey();
        }

        [TestMethod]
        public void TestAddUsers() {

            string testFileName = "users_test.json";
            string expectedFirstName = "John";
            string expectedLastName = "Doe";
            string expectedEmail = "john.doe@example.com";
            string expectedTelephoneNumber = "123456789";
            string expectedStreetAddress = "1 Main St.";
            string expectedPostCode = "12345";
            string expectedCity = "Anytown";

            if (File.Exists(testFileName))
            {
                File.Delete(testFileName);
            }

            using (StringReader reader = new StringReader($"{expectedFirstName}\n{expectedLastName}\n{expectedEmail}\n{expectedTelephoneNumber}\n{expectedStreetAddress}\n{expectedPostCode}\n{expectedCity}\n"))
            {
                Console.SetIn(reader);
                AddUser(testFileName);
            }

            Assert.IsTrue(File.Exists(testFileName));
            string jsonString = File.ReadAllText(testFileName);
            List<User> users = JsonSerializer.Deserialize<List<User>>(jsonString);
            Assert.AreEqual(1, users.Count);
            User user = users[0];
            Assert.AreEqual(expectedFirstName, user.FirstName);
            Assert.AreEqual(expectedLastName, user.LastName);
            Assert.AreEqual(expectedEmail, user.Email);
            Assert.AreEqual(expectedTelephoneNumber, user.TelephoneNumber);
            Assert.AreEqual(expectedStreetAddress, user.StreetAdress);
            Assert.AreEqual(expectedPostCode, user.PostCode);
            Assert.AreEqual(expectedCity, user.City);

            File.Delete(testFileName);
        }
    }
}