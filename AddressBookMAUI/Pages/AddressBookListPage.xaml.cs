using AddressBookMAUI.ViewModels;

namespace AddressBookMAUI.Pages;

public partial class AddressBookListPage : ContentPage
{
	public AddressBookListPage(AddressBookContactListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}