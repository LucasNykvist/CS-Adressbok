using Adressbok___Uppgift.Services;


//Instansiering av service för skapa, visa och radera kontakter
UserService userService = new UserService();

//Variabel för aktivering och avstängning av program
bool isRunning = true;

while (isRunning)
{
    //Instansiering av meny service
    Menu menu = new Menu();

    //Användning av metoden i menu som visar menyvalen och visas varje gång ett case är klart
    menu.ShowMenu();

    // Tar in en readline som blir meny valet som används i switch-case.
    // OM det är en siffra mellan 1-5 kommer vi in i någon sorts logik
    if (Int32.TryParse(Console.ReadLine(), out int menuChoice))
    {
        switch (menuChoice)
        {
                // Case 1 som aktiverar AddUser metoden från userService
            case 1:
                userService.AddUser();
                break;

                // Case 2 som aktiverar GetAllUsers metoden från userService
            case 2:
                userService.GetAllUsers("users.json");
                break;

                // Case 3 som aktiverar GetUser metoden från userService
            case 3:
                Console.WriteLine("Enter the first name of the contact you would like to see");
                userService.GetUser(Console.ReadLine().ToUpper());
                break;

                // Case 4 som aktiverar RemoveSpecificUser metoden från userService
            case 4:
                Console.WriteLine("Enter the first name of the contact you would like to remove");               
                userService.RemoveSpecificUser(Console.ReadLine().ToUpper());

                break;

                // Case 5 som sätter isRunning variablen till false och därmed stänger av programmet
            case 5:
                isRunning = false;
                break;

                // Default caset som dyker upp om en annan siffra än 1-5 angivits
            default:
                Console.WriteLine("-------------- Invalid Menu Choice --------------");
                break;
        }

        
    }
    // OM det inte är en siffra och är exempelvis en text kommer vi in else blocket som säger till användaren att inputen inte är giltig
    else
    {
        Console.WriteLine("Invalid Input, Please enter a valid menu choice");
    }
}