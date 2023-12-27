using AddressBookMAUI.Services;
using AddressBookShared.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AddressBookMAUI.ViewModels;

public partial class AddressBookListViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<IContactModel> _contactList = new ObservableCollection<IContactModel>();

    private readonly PageContentService _pageContentService;

    public AddressBookListViewModel(PageContentService pageContentService)
    {
        _pageContentService = pageContentService;

        _pageContentService.ContactsUpdated += (sender, e) =>
        {
            ContactList = new ObservableCollection<IContactModel>(_pageContentService.GetContacts());
        };

        ContactList = new ObservableCollection<IContactModel>(_pageContentService.GetContacts());
    }





    [RelayCommand]
    private async Task NavigateToAdd()
    {
        await Shell.Current.GoToAsync("AddressBookAddPage");
    }

    [RelayCommand]
    private async Task NavigateToEdit(IContactModel contactModel)
    {
        var parameters = new ShellNavigationQueryParameters
        {
            {"Contact", contactModel }
        };

        await Shell.Current.GoToAsync("AddressBookUpdatePage", parameters);
    }

    [RelayCommand]
    private void DeleteContact(IContactModel contactModel) 
    {
        if (contactModel != null)
        {
            _pageContentService.RemoveContact(contactModel);

            ContactList = new ObservableCollection<IContactModel>(_pageContentService.GetContacts());
        }


        
    }
}
