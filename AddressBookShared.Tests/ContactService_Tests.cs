using AddressBookShared.Interfaces;
using AddressBookShared.Models;
using AddressBookShared.Services;

namespace AddressBookShared.Tests;

public class ContactService_Tests
{
    [Fact]
    public void AddContactToList_Should_AddOneContactToContactList_ReturnTrue()
    {
        //Arrange
        IContactModel contact = new ContactModel { FirstName = "Nils", LastName = "Lind", Email = "NilsLind.88@hotmail.com", PhoneNumber = "0704425137", StreetName = "Bodav", City = "Rättvik", PostalCode = "79596" };
        IContactService contactService = new ContactService();
        
        //Act
        bool result = contactService.AddContactToList(contact);
        
        //Assert
        Assert.True(result);
    }

    [Fact]
    public void GetAllContactsFromList_Should_GetAllContactsFromList_ReturnList()
    {
        //Arrange
        IContactModel contact = new ContactModel { FirstName = "Nils", LastName = "Lind", Email = "NilsLind.88@hotmail.com", PhoneNumber = "0704425137", StreetName = "Bodav", City = "Rättvik", PostalCode = "79596" };
        IContactService contactService = new ContactService();

        //Act
        contactService.AddContactToList(contact);
        var contactList = contactService.GetAllContactsFromList();
        //Assert
        Assert.NotNull(contactList);
    }

    [Fact]
    public void GetOneContactByEmail_Should_GetOneContactFromList_ReturnContact()
    {
        //Arrange
        IContactModel contact = new ContactModel { FirstName = "Nils", LastName = "Lind", Email = "NilsLind.88@hotmail.com", PhoneNumber = "0704425137", StreetName = "Bodav", City = "Rättvik", PostalCode = "79596" };
        IContactService contactService = new ContactService();

        //Act
        contactService.AddContactToList(contact);
        var oneContact = contactService.GetOneContactByEmail(contact.Email);

        //Assert
        Assert.NotNull(oneContact);
    }

    [Fact]
    public void RemoveContactFromList_Should_RemoveOneContactFromList_ReturnTrue()
    {
        //Arrange
        IContactModel contact = new ContactModel { FirstName = "Nils", LastName = "Lind", Email = "NilsLind.88@hotmail.com", PhoneNumber = "0704425137", StreetName = "Bodav", City = "Rättvik", PostalCode = "79596" };
        IContactService contactService = new ContactService();

        //Act
        contactService.AddContactToList(contact);
        var removeContact = contactService.RemoveContactFromList(contact.Email);
        var UpdatedContactList = contactService.GetAllContactsFromList();

        //Assert
        Assert.True(removeContact);
        Assert.DoesNotContain(UpdatedContactList, x => x.Email == contact.Email);
    }

    [Fact]
    public void UpdateContactInList_Should_UpdateOneContactFromList_ReturnTrue()
    {
        //Arrange
        IContactModel contact = new ContactModel { FirstName = "Nils", LastName = "Lind", Email = "NilsLind.88@hotmail.com", PhoneNumber = "0704425137", StreetName = "Bodav", City = "Rättvik", PostalCode = "79596" };
        IContactService contactService = new ContactService();

        //Act
        contactService.AddContactToList(contact);
        var updatedContact = contactService.UpdateContactInList(contact.Email, "Milo", "Lind", "Milo@domain.com", "123123", "Boda", "Rättvik", "79596");
        var UpdatedContactList = contactService.GetAllContactsFromList();

        //Assert
        Assert.True(updatedContact);
        Assert.DoesNotContain(UpdatedContactList, x => x.Email == contact.Email);
        Assert.Contains(UpdatedContactList, x => x.Email == "Milo@domain.com");
    }

}
