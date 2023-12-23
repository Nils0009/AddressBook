using AddressBookMAUI.ViewModels;

namespace AddressBookMAUI.Pages;

public partial class AddressBookSearchPage : ContentPage
{
	public AddressBookSearchPage(AddressBookSearchViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}