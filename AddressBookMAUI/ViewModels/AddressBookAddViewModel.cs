using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AddressBookMAUI.ViewModels;

public partial class AddressBookAddViewModel : ObservableObject
{
    [RelayCommand]
    private async Task NavigateToHomePage()
    {
        await Shell.Current.GoToAsync("AddressBookHomePage");
    }
}
