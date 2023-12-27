using AddressBookMAUI.ViewModels;

namespace AddressBookMAUI.Pages;

public partial class AddressBookListPage : ContentPage
{
    public AddressBookListPage(AddressBookListViewModel listViewModel)
	{
		InitializeComponent();
		BindingContext = listViewModel;

    }

}