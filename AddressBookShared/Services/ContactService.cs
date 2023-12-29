using AddressBookShared.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AddressBookShared.Services;
public class ContactService : IContactService
{
    public List<IContactModel> ContactList { get; private set; } = [];
    private readonly FileService _fileService = new();

    /// <summary>
    /// Adds a contact to the list if it doesn't already exist based on the email address.
    /// </summary>
    /// <param name="contact">A object of IContactModel representing the contact to add.</param>
    /// <returns>Returns true if the contact was added to the list and saved to file, false otherwise.</returns>
    public bool AddContactToList(IContactModel contact)
    {
        try
        {
            //Checks if the contact exists in the list based on email
            if (!ContactList.Any(x => x.Email == contact.Email)) 
            {
                //Adds the contact
                ContactList.Add(contact);

                //Converting the list to JSON and saves to file
                string json = JsonConvert.SerializeObject(ContactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileService.SaveContentToFile(json);
                
                //Returns the result of the save
                return result;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        //Returns false if something goes wrong
        return false;
    }

    /// <summary>
    /// Gets and returns all contacts in the list
    /// </summary>
    /// <returns>Returns the list if it's not null. </returns>
    public IEnumerable<IContactModel> GetAllContactsFromList()
    {
        try
        {
            //Check if the list is null
            if (ContactList != null)
            {
                //Get the file and deserialize it to list
                var content = _fileService.GetContentFromFile();
                ContactList = JsonConvert.DeserializeObject<List<IContactModel>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All})!;
                
                //Returns all contacts in list
                return ContactList!;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        //Returns null if the list is empty or something went wrong
        return null!;
    }

    /// <summary>
    /// Get one contact based on email.
    /// </summary>
    /// <param name="email">Email used to search efter contact</param>
    /// <returns>If found send back contact connected to email. Else send back null</returns>
    public IContactModel GetOneContactByEmail(string email)
    {
        try
        {
            //Check if the email is valid and not empty
            if (!string.IsNullOrEmpty(email))
            {
                //Loops through all contacts in list
                foreach (var contact in ContactList)
                {
                    //Get content from file if email is found. Updates the list and return the contact.
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

        //Return null if nothing is found or something went wrong.
        return null!;
    }

    /// <summary>
    /// Delete one contact from list based on email
    /// </summary>
    /// <param name="email">The email address of the contact to be removed.</param>
    /// <returns>Returns true if contact is removed from list and list is updated</returns>
    public bool RemoveContactFromList(string email)
    {
        try
        {
            //Check if the email is valid and not empty
            if (!string.IsNullOrEmpty(email))
            {
                //Loops through all contacts in list
                foreach (var contact in ContactList)
                {
                    //Remove contact from list if email is found.
                    if (contact.Email == email)
                    {
                        ContactList.Remove(contact);

                        //Converts list to JSON and save to file
                        string json = JsonConvert.SerializeObject(ContactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                        var result = _fileService.SaveContentToFile(json);
                        
                        //Return the result from the save
                        return result;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        //Returns false if no match is found or something went wrong
        return false;
    }

    /// <summary>
    /// Updates contact in list with new information
    /// </summary>
    /// <param name="oldEmail">Email to current contact</param>
    /// <param name="newFirstName">New first name</param>
    /// <param name="newLastName">New last name</param>
    /// <param name="newEmail">New email</param>
    /// <param name="newPhoneNumber">New phone number</param>
    /// <param name="newStreetName">New street name</param>
    /// <param name="newCity">New city</param>
    /// <param name="newPostalCode">New postal code</param>
    /// <returns>Returns true if contact is updated and saved to file. Else returns false</returns>
    public bool UpdateContactInList(string oldEmail, string newFirstName, string newLastName, string newEmail, string newPhoneNumber, string newStreetName, string newCity, string newPostalCode)
    {
        try
        {
            //Loops through all contacts in list
            foreach (var contact in ContactList)
            {
                //If email is found update it.
                if (contact.Email == oldEmail)
                {
                    contact.FirstName = newFirstName;
                    contact.LastName = newLastName;
                    contact.Email = newEmail;
                    contact.PhoneNumber = newPhoneNumber;
                    contact.StreetName = newStreetName;
                    contact.City = newCity;
                    contact.PostalCode = newPostalCode;

                    //Converts list to JSON and saves it to file
                    string json = JsonConvert.SerializeObject(ContactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                    var result = _fileService.SaveContentToFile(json);

                    //Returns the result of the save
                    return result;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        //Returns false if no email is found or something went wrong
        return false;
    }
}
