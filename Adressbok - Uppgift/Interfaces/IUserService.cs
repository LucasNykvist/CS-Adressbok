namespace Adressbok___Uppgift.Interfaces
{
    public interface IUserService
    {
        void AddUser();

        void GetAllUsers(string filepath);

        void RemoveSpecificUser();

        void SaveToJsonFile(string filepath);
    }
}
