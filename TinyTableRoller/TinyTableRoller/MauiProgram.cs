using Microsoft.Extensions.Logging;
using TinyTableRoller.Helpers;
using TinyTableRoller.Service;
using TinyTableRoller.ViewModels;

namespace TinyTableRoller
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<IFileStorageService, FileStorageService>();

            builder.Services.AddTransient<RollTableListViewModel>();

            ServiceHelper.Initialize(builder.Services.BuildServiceProvider());

            return builder.Build();
        }
    }
}