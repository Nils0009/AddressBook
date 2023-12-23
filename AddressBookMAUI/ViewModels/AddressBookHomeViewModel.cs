using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AddressBookMAUI.ViewModels;

public partial class AddressBookHomeViewModel : ObservableObject
{
    [RelayCommand]
    private async Task NavigateToAddPage()
    {
        await Shell.Current.GoToAsync("AddressBookAddPage");
    }

    [RelayCommand]
    private async Task NavigateToListPage()
    {
        await Shell.Current.GoToAsync("AddressBookListPage");
    }

    [RelayCommand]
    private async Task NavigateToSearchPage()
    {
        await Shell.Current.GoToAsync("AddressBookSearchPage");
    }
}
