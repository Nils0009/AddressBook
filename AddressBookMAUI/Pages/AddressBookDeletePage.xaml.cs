using AddressBookMAUI.ViewModels;

namespace AddressBookMAUI.Pages;

public partial class AddressBookDeletePage : ContentPage
{
	public AddressBookDeletePage(AddressBookDeleteViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}