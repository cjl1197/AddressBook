using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using AddressBook.Helpers;

namespace AddressBook;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		BorderlessEntry.RemoveBorders();
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("fa-brands.otf", "FAB");
				fonts.AddFont("fa-regular.otf", "FAR");
				fonts.AddFont("fa-solid.otf", "FAS");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddSingleton<PeopleService>();
		builder.Services.AddTransient<PeopleVM>();

		return builder.Build();
	}
	

}
