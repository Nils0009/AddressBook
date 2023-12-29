using AddressBookShared.Interfaces;
using AddressBookShared.Services;
using System.Collections.ObjectModel;

namespace AddressBookMAUI.Services;

public class PageContentService
{
    private readonly IContactService _contactService;

    public PageContentService(IContactService contactService)
    {
        _contactService = contactService;
    }

    private List<IContactModel> _contacts = [];

    public EventHandler? ContactsUpdated;

    public void AddContact(IContactModel contactModel) 
    { 
        if (contactModel != null)
        {
            var result = _contactService.AddContactToList(contactModel);
            if(result)
            {
                _contacts.Add(contactModel);
                ContactsUpdated?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public IEnumerable<IContactModel> GetContacts()
    { 
        var contacts = _contactService.GetAllContactsFromList();
        if (contacts != null)
        {
            return contacts;
        }
        else { return _contacts; }
                      
    }

    public void UpdateContact(IContactModel contactModel)
    {

        if (contactModel != null)
        {
            var result = _contactService.UpdateContactInList(contactModel.Email, contactModel.FirstName, contactModel.LastName, contactModel.Email, contactModel.PhoneNumber, contactModel.StreetName, contactModel.City, contactModel.PostalCode);
            if (result)
            {
                ContactsUpdated?.Invoke(this, EventArgs.Empty);
            }       
        }

    }

    public void RemoveContact(IContactModel contactModel)
    {
        if (contactModel != null)
        {
            var result = _contactService.RemoveContactFromList(contactModel.Email);
            if (!result)
            {
                _contacts.Remove(contactModel);
                ContactsUpdated?.Invoke(this, EventArgs.Empty);
            }

        }

    }


}
