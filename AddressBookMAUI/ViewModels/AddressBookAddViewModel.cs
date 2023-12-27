using AddressBookMAUI.Services;
using AddressBookShared.Interfaces;
using AddressBookShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
        _pageContentService.AddContact(ContactPerson);
        ContactPerson = new ContactModel();
        await Shell.Current.GoToAsync("..");
    }
}
