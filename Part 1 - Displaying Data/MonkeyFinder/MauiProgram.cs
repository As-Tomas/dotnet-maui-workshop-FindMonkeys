using Microsoft.Extensions.Logging;
using MonkeyFinder.Services;
using MonkeyFinder.View;

namespace MonkeyFinder;

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
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		// AddTransient create new instance of every time is called
		// AddSingleton create it once and keep it around and return when its called
		builder.Services.AddSingleton<MonkeyService>();

        builder.Services.AddSingleton<MainPage>();
		
		builder.Services.AddSingleton<MonkeysViewModel>();

		return builder.Build();
	}
}
