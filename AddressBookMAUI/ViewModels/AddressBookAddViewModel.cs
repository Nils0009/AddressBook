using AddressBookMAUI.Services;
using AddressBookShared.Interfaces;
using AddressBookShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.RegularExpressions;

namespace AddressBookMAUI.ViewModels;

public partial class AddressBookAddViewModel : ObservableObject
{
    private readonly PageContentService _pageContentService;

    public AddressBookAddViewModel(PageContentService pageContentService)
    {
        _pageContentService = pageContentService;
    }

    [ObservableProperty]
    private IContactModel _contactPerson = new ContactModel();

    [RelayCommand]
    public async Task AddContactToList()
    {
        if (string.IsNullOrWhiteSpace(ContactPerson.FirstName) ||
        string.IsNullOrWhiteSpace(ContactPerson.LastName) ||
        string.IsNullOrWhiteSpace(ContactPerson.Email) ||
        !IsValidEmail(ContactPerson.Email)) 
        {

            if (Application.Current?.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all required fields.", "OK");
            }
            return; 
        }


        _pageContentService.AddContact(ContactPerson);
        ContactPerson = new ContactModel();
        await Shell.Current.GoToAsync("AddressBookListPage");
    }

    [RelayCommand]
    private async Task NavigateToHome()
    {
        await Shell.Current.GoToAsync("//AddressBookHomePage");
    }

    private static bool IsValidEmail(string email)
    {
        string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        Regex regex = new Regex(emailPattern);
        return regex.IsMatch(email);
    }
}
