using AddressBookMAUI.ViewModels;

namespace AddressBookMAUI.Pages;

public partial class AddressBookUpdatePage : ContentPage
{
	public AddressBookUpdatePage(AddressBookUpdateViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}