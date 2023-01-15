namespace Adressbok___Uppgift.Interfaces
{
    public interface IUserService
    {
        void AddUser();

        void GetAllUsers(string filepath);

        void GetUser(string firstName);

        void RemoveSpecificUser(string firstName);

    }
}
