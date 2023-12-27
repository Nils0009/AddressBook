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
        _pageContentService.UpdateContact(ContactPerson);
        ContactPerson = new ContactModel();
        await Shell.Current.GoToAsync("..");
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ContactPerson = (query["Contact"] as IContactModel)!;
    }
}
