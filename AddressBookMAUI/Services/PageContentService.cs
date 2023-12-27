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

    private ObservableCollection<IContactModel> _contacts = [];

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
        var contact = _contacts.FirstOrDefault(x => x.Email == contactModel.Email);
        if (contact != null)
        {
            var result = _contactService.UpdateContactInList(contact.Email, contact.FirstName, contact.LastName, contact.Email, contact.PhoneNumber, contact.StreetName, contact.City, contact.PostalCode);
            if (result)
            {
                contact = contactModel;
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
