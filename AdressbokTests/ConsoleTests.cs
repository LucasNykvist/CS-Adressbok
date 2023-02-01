using Microsoft.VisualStudio.TestTools.UnitTesting;
using Adressbok___Uppgift.Interfaces;
using Adressbok___Uppgift.Services;
using System;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace AdressbokTests
{
    [TestClass]
    public class ConsoleTests
    {
        [TestMethod]
        public void ShowMenu_VisarRätt()
        {
            var menu = new Menu();
            var expectedOutput = "Menu 1: Create Contact\r\nMenu 2: Show All Contacts\r\nMenu 3: Show Specific Contact\r\nMenu 4: Remove Contact\r\nMenu 5: Close Program\r\n";

            using (var consoleOutput = new ConsoleOutput())
            {
                menu.ShowMenu();
                var actualOutput = consoleOutput.GetOuput();
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        public class ConsoleOutput : IDisposable
        {
            private readonly TextWriter _originalOutput;
            private readonly StringWriter _stringWriter;

            public ConsoleOutput()
            {
                _originalOutput = Console.Out;
                _stringWriter = new StringWriter();
                Console.SetOut(_stringWriter);
            }

            public string GetOuput()
            {
                return _stringWriter.ToString();
            }

            public void Dispose()
            {
                Console.SetOut(_originalOutput);
                _stringWriter.Dispose();
            }
        }
    }
}
