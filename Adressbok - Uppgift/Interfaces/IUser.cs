// förnamn, efternamn, e-postadress, telefonnummer, gatuadress, postnummer och ort.

namespace Adressbok___Uppgift.Interfaces
{
    public interface IContact
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string TelephoneNumber { get; set; }
        string StreetAdress { get; set; }
        string PostCode { get; set; }
        string City { get; set; }
    }
}
