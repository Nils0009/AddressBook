using AddressBookShared.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AddressBookShared.Services;
public class ContactService : IContactService
{
    private List<IContactModel> _contactList = new List<IContactModel>();
    private readonly FileService _fileService = new();

    public bool AddContactToList(IContactModel contact)
    {
        try
        {
            if (!_contactList.Any(x => x.Email == contact.Email)) 
            {
                _contactList.Add(contact);

                string json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileService.SaveContentToFile(json);
                return result;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }

    public IEnumerable<IContactModel> GetAllContactsFromList()
    {
        try
        {
            if (_contactList != null)
            {
                var content = _fileService.GetContentFromFile();
                _contactList = JsonConvert.DeserializeObject<List<IContactModel>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All})!;
            }
            return _contactList!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public IContactModel GetOneContactByEmail(string email)
    {
        try
        {
            if (!string.IsNullOrEmpty(email))
            {
                var content = _fileService.GetContentFromFile();
                _contactList = JsonConvert.DeserializeObject<List<IContactModel>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;

                foreach (var contact in _contactList)
                {
                    if (contact.Email == email)
                    {                    
                        return contact;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public bool RemoveContactFromList(string email)
    {
        try
        {
            if (!string.IsNullOrEmpty(email))
            {
                foreach(var contact in _contactList)
                {
                    if(contact.Email == email)
                    {
                        _contactList.Remove(contact);
                        return true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }

    public bool UpdateContactInList(IContactModel contact, string newFirstName, string NewLastName, string newEmail, string newPhoneNumber, string newStreetName, string newCity, string newPostalCode)
    {
        try
        {
            if (contact != null)
            {
                contact.FirstName = newFirstName;
                contact.LastName = NewLastName;
                contact.Email = newEmail;
                contact.PhoneNumber = newPhoneNumber;
                contact.StreetName = newStreetName;
                contact.City = newCity;
                contact.PostalCode = newPostalCode;

                string json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileService.SaveContentToFile(json);

                return result;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }
}
