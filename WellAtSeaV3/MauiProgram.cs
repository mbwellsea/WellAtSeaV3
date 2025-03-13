using Microsoft.Extensions.Logging;

#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

using Microsoft.Maui.Handlers;

namespace WellAtSeaV3;

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
				fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
				fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
			});

        // Remove Entry Borders on Android
        EntryHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
#if ANDROID
			handler.PlatformView.SetBackgroundColor(Color.FromArgb("#F1F1F1").ToAndroid());
			handler.PlatformView.SetHintTextColor(Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Gray));
#endif
        });
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}