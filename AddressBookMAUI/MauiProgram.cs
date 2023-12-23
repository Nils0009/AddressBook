using AddressBookMAUI.Pages;
using AddressBookMAUI.ViewModels;
using Microsoft.Extensions.Logging;

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

            builder.Services.AddSingleton<AddressBookHomePage>();
            builder.Services.AddSingleton<AddressBookAddPage>();
            builder.Services.AddSingleton<AddressBookListPage>();
            builder.Services.AddSingleton<AddressBookUpdatePage>();
            builder.Services.AddSingleton<AddressBookDeletePage>();
            builder.Services.AddSingleton<AddressBookSearchPage>();

            builder.Services.AddSingleton<AddressBookHomeViewModel>();
            builder.Services.AddSingleton<AddressBookAddViewModel>();
            builder.Services.AddSingleton<AddressBookContactListViewModel>();
            builder.Services.AddSingleton<AddressBookUpdateViewModel>();
            builder.Services.AddSingleton<AddressBookDeleteViewModel>();
            builder.Services.AddSingleton<AddressBookSearchViewModel>();


            return builder.Build();
        }
    }
}
