using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adressbok___Uppgift.Interfaces;

namespace Adressbok___Uppgift.Services
{
    public class Menu : IMenu
    {
        public void ShowMenu()
        {

            Console.WriteLine("Menu 1: Create Contact");

            Console.WriteLine("Menu 2: Show All Contacts");

            Console.WriteLine("Menu 3: Show Contact");

            Console.WriteLine("Menu 4: Remove Contact");

            Console.WriteLine("Menu 5: Close Program");
        }
    }
}
