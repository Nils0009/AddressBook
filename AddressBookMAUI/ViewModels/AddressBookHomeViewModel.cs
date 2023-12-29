using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AddressBookMAUI.ViewModels;

public partial class AddressBookHomeViewModel : ObservableObject
{
    [RelayCommand]
    private async Task NavigateToContactList()
    {
        await Shell.Current.GoToAsync("AddressBookListPage");
    }

    [RelayCommand]
    private async Task NavigateToAddContact()
    {
        await Shell.Current.GoToAsync("AddressBookAddPage");
    }
}
