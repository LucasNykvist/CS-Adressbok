using Adressbok___Uppgift.Interfaces;

namespace Adressbok___Uppgift.Models
{
    public class Contact : IContact
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get ; set ; } = null!;
        public string Email { get ; set ; } = null!;
        public string TelephoneNumber { get ; set ; } = null!;
        public string StreetAdress { get ; set ; } = null!;
        public string PostCode { get ; set ; } = null!;
        public string City { get ; set ; } = null!;
    }
}
