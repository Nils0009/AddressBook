using AddressBookShared.Interfaces;
using AddressBookShared.Models;
using AddressBookShared.Services;
using Newtonsoft.Json;

namespace AddressBookShared.Tests;

public class FileService_Tests
{
    [Fact]
    public void SaveContentToFile_Should_SaveContentToFile_ReturnTrue()
    {
        //Arrange
        IContactModel contact = new ContactModel { FirstName = "Nils", LastName = "Lind", Email = "NilsLind.88@hotmail.com", PhoneNumber = "0704425137", StreetName = "Bodav", City = "Rättvik", PostalCode = "79596" };
        IContactService contactService = new ContactService();
        FileService fileService = new();

        //Act
        contactService.AddContactToList(contact);
        var contactList = contactService.GetAllContactsFromList();
        string json = JsonConvert.SerializeObject(contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        var result = fileService.SaveContentToFile(json);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void GetContentFromFile_Should_GetContentFromFile_ReturnContent()
    {
        //Arrange
        IContactModel contact = new ContactModel { FirstName = "Nils", LastName = "Lind", Email = "NilsLind.88@hotmail.com", PhoneNumber = "0704425137", StreetName = "Bodav", City = "Rättvik", PostalCode = "79596" };
        IContactService contactService = new ContactService();
        FileService fileService = new();

        //Act
        contactService.AddContactToList(contact);
        var contactList = contactService.GetAllContactsFromList();
        string json = JsonConvert.SerializeObject(contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        var result = fileService.SaveContentToFile(json);

        var content = fileService.GetContentFromFile();
        contactList = JsonConvert.DeserializeObject<List<IContactModel>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;


        //Assert
        Assert.Equal(json, content);
    }
}
