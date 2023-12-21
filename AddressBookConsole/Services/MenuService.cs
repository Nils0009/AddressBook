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
            }
            Console.ReadKey();
            Console.Clear();

        }
    }
    public void ShowAddMenu()
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


            Console.WriteLine();
            ShowMenuText("Contact saved");
            Console.WriteLine("---------------");
            _contactService.AddContactToList(contact);
            break;
        }

    }
    public void ShowContactListMenu()
    {
        ShowMenuText("Contact list");
        Console.WriteLine("---------------");
        Console.WriteLine();

        if (_contactService.GetAllContactsFromList() != null)
        {
            foreach (ContactModel contact in _contactService.GetAllContactsFromList())
            {
                Console.WriteLine($"{contact.FirstName}, {contact.LastName}, {contact.Email}, {contact.PhoneNumber}, {contact.StreetName}, {contact.City}, {contact.PostalCode}");
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("The contact list is empty!");
            Console.WriteLine("--------------------------");
        }


    }
    public void ShowContactUpdateMenu()
    {
        while (true)
        {
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
                validatedStreetName = ValidateNum(validatedStreetName);
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

                _contactService.UpdateContactInList(contactToBeUpdated, validatedFirstname, validatedLastName, validatedEmail, validatedPhoneNumber, validatedStreetName, validatedCity, validatedPostalCode);

                ShowMenuText("Contact was updated");
                break;
            }
        }
    }
    public void ShowDeleteMenu()
    {
        ShowMenuText("Delete contact");
        Console.WriteLine("--------------");
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
                ShowMenuText("Contact was removed");
            }

        }


    }
    public void ShowContactSearchMenu()
    {
        Console.Write("Search contact with email: ");
        Console.WriteLine("------------------------");
        string userSearchInput = Console.ReadLine()!.ToLower();
        if (!string.IsNullOrEmpty(userSearchInput))
        {
            var userFound = _contactService.GetOneContactByEmail(userSearchInput);
            Console.WriteLine("Contact was found");
            Console.WriteLine($"{userFound.FirstName}, {userFound.LastName}, {userFound.Email}, {userFound.PhoneNumber}, {userFound.StreetName}, {userFound.City}, {userFound.PostalCode}");
        }
    }
    public void ShowExitMenu()
    {
        Console.Write("Do you want to exit (y/n)?: ");
        Console.WriteLine("---------------------------");
        string userExitInput = Console.ReadLine()!.ToLower();
        if (userExitInput == "y")
        {
            Environment.Exit(0);
        }
    }
    public void ShowMenuText(string text)
    {
        Console.WriteLine($"[{text}]");
    }

    public string ValidateText(string text)
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
    public string ValidateNum(string text)
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
    public string ValidateEmail(string text)
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
