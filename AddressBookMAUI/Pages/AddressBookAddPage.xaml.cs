using AddressBookMAUI.ViewModels;

namespace AddressBookMAUI.Pages;

public partial class AddressBookAddPage : ContentPage
{
	public AddressBookAddPage(AddressBookAddViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}