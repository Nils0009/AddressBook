using AddressBookShared.Interfaces;

namespace AddressBookShared.Services;

public interface IContactService
{
    bool AddContactToList(IContactModel contact);
    IEnumerable<IContactModel> GetAllContacts();
    
    IContactModel GetOneContactByEmail(string email);
    bool UpdateContactInList(IContactModel contact, string newFirstName, string NewLastName, string newEmail, string newPhoneNumber, string newStreetName, string newCity, string newPostalCode);

    bool RemoveContactFromList(string email);
}
