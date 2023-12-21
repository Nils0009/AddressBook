using AddressBookShared.Interfaces;
using System.Diagnostics;

namespace AddressBookShared.Services;
public class ContactService : IContactService
{
    public bool AddContactToList(IContactModel contact)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public IEnumerable<IContactModel> GetAllContacts()
    {
        try
        {

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public IContactModel GetOneContactByEmail(string email)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public bool RemoveContactFromList(string email)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public bool UpdateContactInList(IContactModel contact, string newFirstName, string NewLastName, string newEmail, string newPhoneNumber, string newStreetName, string newCity, string newPostalCode)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
