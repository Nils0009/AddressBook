using AddressBookMAUI.ViewModels;

namespace AddressBookMAUI.Pages;

public partial class AddressBookAddPage : ContentPage
{
	public AddressBookAddPage(AddressBookAddViewModel AddViewModel)
	{
		InitializeComponent();
		BindingContext = AddViewModel;
	}
}