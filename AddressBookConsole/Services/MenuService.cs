using AddressBookShared.Interfaces;
using AddressBookShared.Models;
using AddressBookShared.Services;
using System.Diagnostics;

namespace AddressBookConsole.Services;

public class MenuService
{
    IContactService _contactService = new ContactService();
    public void ShowMainMenu()
    {
        try
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
                        ShowAddMenu();
                        break;
                    case 2:
                        ShowContactListMenu();
                        break;
                    case 3:
                        ShowContactUpdateMenu();
                        break;
                    case 4:
                        ShowDeleteMenu();
                        break;
                    case 5:
                        ShowContactSearchMenu();
                        break;
                    case 6:
                        ShowExitMenu();
                        break;
                    default:
                        Console.WriteLine("Enter a valid inpuit!");
                        break;
                }
                Console.ReadKey();
                Console.Clear();

            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

    }
    public void ShowAddMenu()
    {
        try
        {
            while (true)
            {
                IContactModel contact = new ContactModel();

                ShowMenuText("Add contact");
                Console.WriteLine("-------------");
                Console.WriteLine();

                Console.Write("First name: ");
                var validatedFirstname = Console.ReadLine()!;
                validatedFirstname = ValidateText(validatedFirstname);
                if (validatedFirstname == null) { break; }
                contact.FirstName = validatedFirstname;

                Console.Write("Last name: ");
                var validatedLastName = Console.ReadLine()!;
                validatedLastName = ValidateText(validatedLastName);
                if (validatedLastName == null) { break; }
                contact.LastName = validatedLastName;


                Console.Write("Email: ");
                var validatedEmail = Console.ReadLine()!;
                validatedEmail = ValidateEmail(validatedEmail);
                if (validatedEmail == null) { break; }
                contact.Email = validatedEmail;

                Console.Write("Phone number: ");
                var validatedPhoneNumber = Console.ReadLine()!;
                validatedPhoneNumber = ValidateNum(validatedPhoneNumber);
                if (validatedPhoneNumber == null) { break; }
                contact.PhoneNumber = validatedPhoneNumber;


                Console.Write("Street name: ");
                var validatedStreetName = Console.ReadLine()!;
                validatedStreetName = ValidateNum(validatedStreetName);
                if (validatedStreetName == null) { break; }
                contact.StreetName = validatedStreetName;


                Console.Write("City: ");
                var validatedCity = Console.ReadLine()!;
                validatedCity = ValidateText(validatedCity);
                if (validatedCity == null) { break; }
                contact.City = validatedCity;

                Console.Write("Postal code: ");
                var validatedPostalCode = Console.ReadLine()!;
                validatedPostalCode = ValidateNum(validatedPostalCode);
                if (validatedPostalCode == null) { break; }
                contact.PostalCode = validatedPostalCode;

                var savedContact = _contactService.AddContactToList(contact);
                if (savedContact != true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Contact already in list");
                    break;
                }
                Console.WriteLine();
                ShowMenuText("Contact saved");
                Console.WriteLine("---------------");

                break;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }


    }
    public void ShowContactListMenu()
    {
        try
        {
            while (true)
            {
                ShowMenuText("Contact list");
                Console.WriteLine("--------------\n");
                var contactList = _contactService.GetAllContactsFromList();

                if (contactList != null && contactList.Any())
                {
                    foreach (var contact in contactList)
                    {
                        Console.WriteLine($"First name: {contact.FirstName}\n" +
                                          $"Last name: {contact.LastName}\n" +
                                          $"Email: {contact.Email}\n" +
                                          $"Phone number: {contact.PhoneNumber}\n" +
                                          $"Street name: {contact.StreetName}\n" +
                                          $"City: {contact.City}\n" +
                                          $"Postal code: {contact.PostalCode}\n" +
                                          "\n-------------------\n");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("The contact list is empty!");
                    Console.WriteLine("--------------------------");
                }
                break;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }
    public void ShowContactUpdateMenu()
    {
        try
        {
            while (true)
            {
                ShowMenuText("Update contact");
                Console.WriteLine("----------------\n");
                Console.Write("Update contact with email: ");
                string userUpdateEmailInput = ValidateEmail(Console.ReadLine()!);
                var contactToBeUpdated = _contactService.GetOneContactByEmail(userUpdateEmailInput);
                Thread.Sleep(500);
                Console.Clear();

                if (contactToBeUpdated != null)
                {
                    ShowMenuText("Contact was found");
                    Console.WriteLine("-------------------");
                    Console.WriteLine();
                    Console.WriteLine($"First name: {contactToBeUpdated.FirstName}\nLast name: {contactToBeUpdated.LastName}\nEmail: {contactToBeUpdated.Email}\nPhone number: {contactToBeUpdated.PhoneNumber}\nStreet name: {contactToBeUpdated.StreetName}\nCity: {contactToBeUpdated.City}\nPostal code: {contactToBeUpdated.PostalCode}");
                    Console.Write("\nDo you want to update? (y/n): ");
                    string userUpdateAnswerInput = ValidateText(Console.ReadLine()!);
                    Thread.Sleep(500);
                    Console.Clear();

                    if (userUpdateAnswerInput == "y")
                    {
                        Console.Write("First name: ");
                        var validatedFirstname = Console.ReadLine()!;
                        validatedFirstname = ValidateText(validatedFirstname);
                        if (validatedFirstname == null) { break; }
                        contactToBeUpdated.FirstName = validatedFirstname;

                        Console.Write("Last name: ");
                        var validatedLastName = Console.ReadLine()!;
                        validatedLastName = ValidateText(validatedLastName);
                        if (validatedLastName == null) { break; }
                        contactToBeUpdated.LastName = validatedLastName;

                        Console.Write("Email: ");
                        var validatedEmail = Console.ReadLine()!;
                        validatedEmail = ValidateEmail(validatedEmail);
                        if (validatedEmail == null) { break; }
                        contactToBeUpdated.Email = validatedEmail;

                        Console.Write("Phone number: ");
                        var validatedPhoneNumber = Console.ReadLine()!;
                        validatedPhoneNumber = ValidateNum(validatedPhoneNumber);
                        if (validatedPhoneNumber == null) { break; }
                        contactToBeUpdated.PhoneNumber = validatedPhoneNumber;

                        Console.Write("Street name: ");
                        var validatedStreetName = Console.ReadLine()!;
                        validatedStreetName = ValidateText(validatedStreetName);
                        if (validatedStreetName == null) { break; }
                        contactToBeUpdated.StreetName = validatedStreetName;

                        Console.Write("City: ");
                        var validatedCity = Console.ReadLine()!;
                        validatedCity = ValidateText(validatedCity);
                        if (validatedCity == null) { break; }
                        contactToBeUpdated.City = validatedCity;

                        Console.Write("Postal code: ");
                        var validatedPostalCode = Console.ReadLine()!;
                        validatedPostalCode = ValidateNum(validatedPostalCode);
                        if (validatedPostalCode == null) { break; }
                        contactToBeUpdated.PostalCode = validatedPostalCode;

                        _contactService.UpdateContactInList(userUpdateEmailInput, validatedFirstname, validatedLastName, validatedEmail, validatedPhoneNumber, validatedStreetName, validatedCity, validatedPostalCode);

                        ShowMenuText("Contact was updated");
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    ShowMenuText("Contact was not found");
                    Console.WriteLine("------------------------");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
    public void ShowDeleteMenu()
    {
        try
        {
            while (true)
            {
                ShowMenuText("Delete contact");
                Console.WriteLine("-----------------\n");
                Console.Write("Remove contact with email: ");
                string userRemoveInput = ValidateEmail(Console.ReadLine()!);
                var userToRemoveFound = _contactService.GetOneContactByEmail(userRemoveInput);

                if (userToRemoveFound != null)
                {
                    Console.WriteLine($"\nFirst name: {userToRemoveFound.FirstName}\nLast name: {userToRemoveFound.LastName}\nEmail: {userToRemoveFound.Email}\nPhone number: {userToRemoveFound.PhoneNumber}\nStreet name: {userToRemoveFound.StreetName}\nCity: {userToRemoveFound.City}\nPostal code: {userToRemoveFound.PostalCode}");
                    Console.WriteLine();
                    Console.Write("Do you want to remove? (y/n): ");
                    string userRemoveInputAnswer = ValidateText(Console.ReadLine()!);
                    Thread.Sleep(500);
                    Console.Clear();
                    if (userRemoveInputAnswer == "y")
                    {
                        var removeUser = _contactService.RemoveContactFromList(userRemoveInput);
                        ShowMenuText("Contact was removed");
                        Thread.Sleep(1000);
                        break;
                    }
                }
                if (userToRemoveFound == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Contact was not found!");
                    break;
                }
                break;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

    }
    public void ShowContactSearchMenu()
    {
        try
        {
            ShowMenuText("Search contact");
            Console.WriteLine("----------------\n");
            Console.Write("Search contact with email: ");
            var userFound = _contactService.GetOneContactByEmail(ValidateEmail(Console.ReadLine()!));
            Thread.Sleep(500);
            Console.Clear();
            if (userFound != null)
            {
                ShowMenuText("Contact was found");
                Console.WriteLine("-------------------");
                Console.WriteLine();
                Console.WriteLine($"First name: {userFound.FirstName}\nLast name: {userFound.LastName}\nEmail: {userFound.Email}\nPhone number: {userFound.PhoneNumber}\nStreet name: {userFound.StreetName}\nCity: {userFound.City}\nPostal code: {userFound.PostalCode}");
            }
            else
            {
                ShowMenuText("Contact was not found");
                Console.WriteLine("------------------------");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

    }
    public static void ShowExitMenu()
    {
        try
        {
            Console.Write("Do you want to exit? (y/n): ");

            string userExitInput = ValidateText(Console.ReadLine()!);
            if (userExitInput == "y")
            {
                Environment.Exit(0);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

    }
    public static void ShowMenuText(string text)
    {
        Console.WriteLine($"\n[{text}]");
    }

    public static string ValidateText(string text)
    {
        if (!string.IsNullOrEmpty(text) && !text!.Any(char.IsDigit))
        {
            return text!.ToLower();
        }

        else
        {
            Console.WriteLine("Invalid input!");
            return null!;
        }

    }
    public static string ValidateNum(string text)
    {
        if (!string.IsNullOrEmpty(text))
        {
            return text!.ToLower();
        }

        else
        {
            Console.WriteLine("Invalid input!");
            return null!;
        }

    }
    public static string ValidateEmail(string text)
    {
        if (!string.IsNullOrEmpty(text) && text!.Contains("@"))
        {
            return text!.ToLower();
        }

        else
        {
            Console.WriteLine("Invalid input!");
            return null!;
        }
    }
}
