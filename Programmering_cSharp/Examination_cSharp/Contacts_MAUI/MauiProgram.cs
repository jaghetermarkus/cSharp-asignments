using Contacts_MAUI.Mvvm.ViewModels;
using Contacts_MAUI.Mvvm.Views;
using Contacts_MAUI.Services;
using Microsoft.Extensions.Logging;

namespace Contacts_MAUI;

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
                fonts.AddFont("fa-regular-400.ttf", "FontAwesomeRegular");
                fonts.AddFont("fa-solid-400.ttf", "FontAwesomeSolid");
            });

		builder.Services.AddSingleton<ContactService>();
        builder.Services.AddSingleton<JsonService>();

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<AddViewModel>();
        builder.Services.AddSingleton<AddPage>();

        builder.Services.AddSingleton<EditViewModel>();
        builder.Services.AddSingleton<EditPage>();

        builder.Services.AddSingleton<DetailViewModel>();
        builder.Services.AddSingleton<DetailPage>();

        return builder.Build();
	}
}

