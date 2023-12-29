using AddressBookMAUI.Services;
using AddressBookShared.Interfaces;
using AddressBookShared.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AddressBookMAUI.ViewModels;

public partial class AddressBookDetailViewModel : ObservableObject, IQueryAttributable
{
    private readonly PageContentService _pageContentService;

    public AddressBookDetailViewModel(PageContentService pageContentService)
    {
        _pageContentService = pageContentService;
    }

    [ObservableProperty]
    private IContactModel _contactPerson = new ContactModel();


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
