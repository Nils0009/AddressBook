using AddressBookMAUI.ViewModels;

namespace AddressBookMAUI.Pages;

public partial class AddressBookHomePage : ContentPage
{
	public AddressBookHomePage(AddressBookHomeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}