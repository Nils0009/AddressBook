using AddressBookMAUI.Pages;
using AddressBookMAUI.Services;
using AddressBookMAUI.ViewModels;
using AddressBookShared.Interfaces;
using AddressBookShared.Models;
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

            builder.Services.AddSingleton<AddressBookAddPage>();
            builder.Services.AddSingleton<AddressBookListPage>();
            builder.Services.AddSingleton<AddressBookUpdatePage>();

            builder.Services.AddSingleton<AddressBookAddViewModel>();
            builder.Services.AddSingleton<AddressBookListViewModel>();
            builder.Services.AddSingleton<AddressBookUpdateViewModel>();

            builder.Services.AddSingleton<IContactService,ContactService>();
            builder.Services.AddSingleton<IContactModel,ContactModel>();


            return builder.Build();
        }
    }
}
