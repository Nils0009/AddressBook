using AddressBookShared.Interfaces;
using AddressBookShared.Models;
using AddressBookShared.Services;

namespace AddressBookConsole.Services;

public class MenuService
{
    IContactService _contactService = new ContactService();
    public void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine("**MENU**");
            Console.WriteLine();
            Console.WriteLine("[1] Add contact");
            Console.WriteLine("[2] Contact List");
            Console.WriteLine("[3] Update contact");
            Console.WriteLine("[4] Delete contact");
            Console.WriteLine("[5] Search contact");
            Console.WriteLine("[6] Exit");
            int.TryParse(Console.ReadLine(), out int userMenuInput);

            Console.Clear();

            switch (userMenuInput)
            {
                case 1:
                    IContactModel contact = new ContactModel();

                    Console.WriteLine("Add contact");
                    Console.Write("First name: ");
                    contact.FirstName = Console.ReadLine()!.ToLower();
                    Console.Write("Last name: ");
                    contact.LastName = Console.ReadLine()!.ToLower();
                    Console.Write("Email: ");
                    contact.Email = Console.ReadLine()!.ToLower();
                    Console.Write("Phone number: ");
                    contact.PhoneNumber = Console.ReadLine()!.ToLower();
                    Console.Write("Street name: ");
                    contact.StreetName = Console.ReadLine()!.ToLower();
                    Console.Write("City: ");
                    contact.City = Console.ReadLine()!.ToLower();
                    Console.Write("Postal code: ");
                    contact.PostalCode = Console.ReadLine()!.ToLower();

                    _contactService.AddContactToList(contact);
                    break;
                case 2:
                    Console.WriteLine("Contact list");
                    _contactService.GetAllContactsFromList();
                    foreach (ContactModel contact1 in _contactService.GetAllContactsFromList())
                    {
                        Console.WriteLine($"{contact1.FirstName}, {contact1.LastName}, {contact1.Email}, {contact1.PhoneNumber}, {contact1.StreetName}, {contact1.City}, {contact1.PostalCode}");
                    }
                    break;
                case 3:
                    Console.Write("Update contact with email: ");
                    string userUpdateEmailInput = Console.ReadLine()!.ToLower();
                    var contactToBeUpdated = _contactService.GetOneContactByEmail(userUpdateEmailInput);
                    Console.WriteLine("Contact found");
                    Console.WriteLine($"{contactToBeUpdated.FirstName}, {contactToBeUpdated.LastName}, {contactToBeUpdated.Email}, {contactToBeUpdated.PhoneNumber}, {contactToBeUpdated.StreetName}, {contactToBeUpdated.City}, {contactToBeUpdated.PostalCode}");
                    Console.Write("Do you want to update? (y/n): ");
                    string userUpdateAnswerInput = Console.ReadLine()!.ToLower();
                    if (userUpdateAnswerInput == "y")
                    {
                        Console.Write("First name: ");
                        string newFirstName = Console.ReadLine()!.ToLower();
                        contactToBeUpdated.FirstName = newFirstName;

                        Console.Write("Last name: ");
                        string newLastName = Console.ReadLine()!.ToLower();
                        contactToBeUpdated.LastName = newLastName;

                        Console.Write("Email: ");
                        string newEmail = Console.ReadLine()!.ToLower();
                        contactToBeUpdated.Email = newEmail;

                        Console.Write("Phone number: ");
                        string newPhoneNumber = Console.ReadLine()!.ToLower();
                        contactToBeUpdated.PhoneNumber = newPhoneNumber;

                        Console.Write("Street name: ");
                        string newStreetName = Console.ReadLine()!.ToLower();
                        contactToBeUpdated.StreetName = newStreetName;

                        Console.Write("City: ");
                        string newCity = Console.ReadLine()!.ToLower();
                        contactToBeUpdated.City = newCity;

                        Console.Write("Postal code: ");
                        string newPostalCode = Console.ReadLine()!.ToLower();
                        contactToBeUpdated.PostalCode = newPostalCode;

                        _contactService.UpdateContactInList(contactToBeUpdated, newFirstName, newLastName, newEmail, newPhoneNumber, newStreetName, newCity, newPostalCode);

                        Console.WriteLine("Contact was updated");
                    }
                    break;
                case 4:
                    Console.WriteLine("Delete contact");
                    Console.Write("Remove contact with email: ");
                    string userRemoveInput = Console.ReadLine()!.ToLower();
                    var userToRemoveFound = _contactService.GetOneContactByEmail(userRemoveInput);

                    if (userToRemoveFound != null)
                    {
                        userToRemoveFound.FirstName = Console.ReadLine()!;
                        userToRemoveFound.LastName = Console.ReadLine()!;
                        userToRemoveFound.Email = Console.ReadLine()!;
                        userToRemoveFound.PhoneNumber = Console.ReadLine()!;
                        userToRemoveFound.StreetName = Console.ReadLine()!;
                        userToRemoveFound.City = Console.ReadLine()!;
                        userToRemoveFound.PostalCode = Console.ReadLine()!;

                        Console.Write("Do you want to remove? (y/n): ");
                        string userRemoveInputAnswer = Console.ReadLine()!;

                        if (userRemoveInputAnswer == "y")
                        {
                            _contactService.RemoveContactFromList(userRemoveInput);
                            Console.WriteLine("Contact was removed");
                        }
                    }


                    break;
                case 5:
                    Console.Write("Search contact with email: ");
                    string userSearchInput = Console.ReadLine()!.ToLower();
                    if (!string.IsNullOrEmpty(userSearchInput))
                    {
                        var userFound = _contactService.GetOneContactByEmail(userSearchInput);
                        Console.WriteLine("Contact was found");
                        Console.WriteLine($"{userFound.FirstName}, {userFound.LastName}, {userFound.Email}, {userFound.PhoneNumber}, {userFound.StreetName}, {userFound.City}, {userFound.PostalCode}");
                    }
                    break;
                case 6:
                    Console.Write("Do you want to exit (y/n)?: ");
                    string userExitInput = Console.ReadLine()!.ToLower();
                    if (userExitInput == "y")
                    {
                        Environment.Exit(0);
                    }
                    break;
            }

        }
    }
}
