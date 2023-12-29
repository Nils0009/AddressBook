using AddressBookMAUI.Services;
using AddressBookShared.Interfaces;
using AddressBookShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AddressBookMAUI.ViewModels;

public partial class AddressBookUpdateViewModel : ObservableObject, IQueryAttributable
{
    private readonly PageContentService _pageContentService;

    public AddressBookUpdateViewModel(PageContentService pageContentService)
    {
        _pageContentService = pageContentService;
    }

    [ObservableProperty]
    private IContactModel _contactPerson = new ContactModel();

    [RelayCommand]
    public async Task UpdateContactInList()
    {
        if (string.IsNullOrWhiteSpace(ContactPerson.FirstName) ||
            string.IsNullOrWhiteSpace(ContactPerson.LastName) ||
            string.IsNullOrWhiteSpace(ContactPerson.Email) ||
            string.IsNullOrWhiteSpace(ContactPerson.PhoneNumber) ||
            string.IsNullOrWhiteSpace(ContactPerson.StreetName) ||
            string.IsNullOrWhiteSpace(ContactPerson.City) ||
            string.IsNullOrWhiteSpace(ContactPerson.PostalCode))
        {
            if (Application.Current?.MainPage != null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all required fields.", "OK");
            }
            return;
        }
        _pageContentService.UpdateContact(ContactPerson);
        ContactPerson = new ContactModel();
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task NavigateToHome()
    {
        await Shell.Current.GoToAsync("//AddressBookHomePage");
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ContactPerson = (query["Contact"] as IContactModel)!;
    }
}
