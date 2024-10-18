using System.Text.Json;
using TinyTableRoller.Data;

namespace TinyTableRoller
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            CreateStorageFileIfNotExists().GetAwaiter().GetResult();
        }

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
