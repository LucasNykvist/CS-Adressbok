using Adressbok___Uppgift.Models;
using Adressbok___Uppgift.Services;


bool isRunning = true;
while (isRunning)
{
    Menu menu = new Menu();
    UserService userService = new UserService();
    menu.ShowMenu();
    if (Int32.TryParse(Console.ReadLine(), out int menuChoice))
    {
        switch (menuChoice)
        {
            case 1:
                userService.AddUser();
                break;

            case 2:
                userService.GetAllUsers();
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