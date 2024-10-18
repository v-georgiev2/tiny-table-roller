using Microsoft.Extensions.Logging;
using System.Text.Json;
using TinyTableRoller.Data;

namespace TinyTableRoller
{
    public static class MauiProgram
    {
        public static async Task<MauiApp> CreateMauiApp()
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

            await CreateStorageFileIfNotExists();

            return builder.Build();
        }

        // some temp stuff to test with
        private static async Task CreateStorageFileIfNotExists()
        {
            var filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Data", "roll-tables.json");

            if (File.Exists(filePath))
                return;

            // create one to see in menus
            var rollTable = new RollTable
            {
                Name = "test roll table",
                Description = "wow the first roll table, awesome",
                RollEntries =
                [
                    new()
                    {
                        RollValue = 1,
                        Description = "you lose"
                    },
                    new()
                    {
                        RollValue = 2,
                        Description = "you win"
                    }
                ]
            };

            var json = JsonSerializer.Serialize(new List<RollTable> { rollTable });

            using var outputStream = File.OpenWrite(filePath);
            using var streamWriter = new StreamWriter(outputStream);
            await streamWriter.WriteAsync(json);
        }
    }
}
