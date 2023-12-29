using AddressBookMAUI.Pages;
using AddressBookMAUI.Services;
using AddressBookMAUI.ViewModels;
using AddressBookShared.Services;

namespace AddressBookMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<PageContentService>();

            builder.Services.AddSingleton<AddressBookHomePage>();
            builder.Services.AddSingleton<AddressBookAddPage>();
            builder.Services.AddSingleton<AddressBookListPage>();
            builder.Services.AddSingleton<AddressBookUpdatePage>();
            builder.Services.AddSingleton<AddressBookDetailPage>();

            builder.Services.AddSingleton<AddressBookHomeViewModel>();
            builder.Services.AddSingleton<AddressBookAddViewModel>();
            builder.Services.AddSingleton<AddressBookListViewModel>();
            builder.Services.AddSingleton<AddressBookUpdateViewModel>();
            builder.Services.AddSingleton<AddressBookDetailViewModel>();

            builder.Services.AddSingleton<IContactService, ContactService>();

            return builder.Build();
        }
    }
}
