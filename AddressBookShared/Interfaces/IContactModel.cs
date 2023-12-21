namespace AddressBookShared.Interfaces;

public interface IContactModel
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
    string StreetName { get; set; }
    string City { get; set; }
    string PostalCode { get; set; }
}
