using AddressBookShared.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AddressBookShared.Services;
public class ContactService : IContactService
{
    public List<IContactModel> ContactList { get; private set; } = [];
    private readonly FileService _fileService = new();

    public bool AddContactToList(IContactModel contact)
    {
        try
        {
            if (!ContactList.Any(x => x.Email == contact.Email)) 
            {
                ContactList.Add(contact);

                string json = JsonConvert.SerializeObject(ContactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
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
            if (ContactList != null)
            {
                var content = _fileService.GetContentFromFile();
                ContactList = JsonConvert.DeserializeObject<List<IContactModel>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All})!;
                return ContactList!;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public IContactModel GetOneContactByEmail(string email)
    {
        try
        {
            if (!string.IsNullOrEmpty(email))
            {
                foreach (var contact in ContactList)
                {
                    if (contact.Email == email)
                    {
                        var content = _fileService.GetContentFromFile();
                        ContactList = JsonConvert.DeserializeObject<List<IContactModel>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;

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
                foreach(var contact in ContactList)
                {
                    if(contact.Email == email)
                    {
                        ContactList.Remove(contact);
                        string json = JsonConvert.SerializeObject(ContactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                        var result = _fileService.SaveContentToFile(json);
                        return result;
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

    public bool UpdateContactInList(string oldEmail, string newFirstName, string newLastName, string newEmail, string newPhoneNumber, string newStreetName, string newCity, string newPostalCode)
    {
        try
        {
            foreach (var contact in ContactList)
            {
                if (contact.Email == oldEmail)
                {
                    contact.FirstName = newFirstName;
                    contact.LastName = newLastName;
                    contact.Email = newEmail;
                    contact.PhoneNumber = newPhoneNumber;
                    contact.StreetName = newStreetName;
                    contact.City = newCity;
                    contact.PostalCode = newPostalCode;

                    string json = JsonConvert.SerializeObject(ContactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    var result = _fileService.SaveContentToFile(json);

                    return result;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }
}
