namespace Adressbok___Uppgift.Interfaces
{

    //Interface som säger hur vår Contacts Service ska se ut - vilka metoder vi ska finnas
    public interface IContactService
    {
        void AddContact();

        void GetAllContacts(string filepath);

        void GetContact(string firstName);

        void RemoveSpecificContact(string firstName);

    }
}
