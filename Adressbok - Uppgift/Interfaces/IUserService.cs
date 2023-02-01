namespace Adressbok___Uppgift.Interfaces
{

    //Interface som säger hur vår Contacts Service ska se ut - vilka metoder vi ska finnas
    public interface IUserService
    {
        void AddUser();

        void GetAllUsers(string filepath);

        void GetUser(string firstName);

        void RemoveSpecificUser(string firstName);

    }
}
