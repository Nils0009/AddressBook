using AddressBookMAUI.Pages;

namespace AddressBookMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddressBookAddPage), typeof(AddressBookAddPage));
            Routing.RegisterRoute(nameof(AddressBookListPage), typeof(AddressBookListPage));
            Routing.RegisterRoute(nameof(AddressBookUpdatePage), typeof(AddressBookUpdatePage));
            Routing.RegisterRoute(nameof(AddressBookDetailPage), typeof(AddressBookDetailPage));
            Routing.RegisterRoute(nameof(AddressBookHomePage), typeof(AddressBookHomePage));

        }
    }
}
