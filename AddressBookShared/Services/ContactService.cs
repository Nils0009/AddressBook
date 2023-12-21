using AddressBookShared.Interfaces;

namespace AddressBookShared.Services;
public class ContactService : IContactService
{
    public bool AddContactToList(IContactModel contact)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IContactModel> GetAllContacts()
    {
        throw new NotImplementedException();
    }

    public IContactModel GetOneContactByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public bool RemoveContactFromList(string email)
    {
        throw new NotImplementedException();
    }

    public bool UpdateContactInList(IContactModel contact, string newFirstName, string NewLastName, string newEmail, string newPhoneNumber, string newStreetName, string newCity, string newPostalCode)
    {
        throw new NotImplementedException();
    }
}
