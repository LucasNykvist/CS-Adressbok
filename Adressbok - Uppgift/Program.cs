using Adressbok___Uppgift.Models;
using Adressbok___Uppgift.Services;

UserService userService = new UserService();
bool isRunning = true;
while (isRunning)
{
    Menu menu = new Menu();
    menu.ShowMenu();
    if (Int32.TryParse(Console.ReadLine(), out int menuChoice))
    {
        switch (menuChoice)
        {
            case 1:
                userService.AddUser();
                userService.SaveToJsonFile("users.json");
                break;

            case 2:
                userService.GetAllUsers("users.json");
                break;

            case 3:

                break;

            case 4:

                break;

            case 5:
                isRunning = false;
                break;

            default:
                Console.WriteLine("-------------- Invalid Menu Choice --------------");
                break;
        }
    } else
    {
        Console.WriteLine("Invalid Input, Please enter a valid menu choice");
    }
}