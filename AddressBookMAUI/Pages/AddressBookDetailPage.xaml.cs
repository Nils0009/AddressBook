using AddressBookMAUI.ViewModels;

namespace AddressBookMAUI.Pages;

public partial class AddressBookDetailPage : ContentPage
{
	public AddressBookDetailPage(AddressBookDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}