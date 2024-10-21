using System.Text.Json;
using TinyTableRoller.Data;

namespace TinyTableRoller.Service
{
    // not necessarily needed to be an injected service,
    // but can add dependencies here easily later and it looks better now than a static class
    public class FileStorageService : IFileStorageService
    {
        private readonly string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Data", "roll-tables.json");

        public async Task<List<RollTable>> GetAllAsync()
        {
            using var fileStream = File.OpenRead(filePath);
            using var reader = new StreamReader(fileStream);

            var json = await reader.ReadToEndAsync();
            var list = JsonSerializer.Deserialize<List<RollTable>>(json) ?? [];

            // temp

            if (list.Count == 0)
                list.Add(new()
                {
                    Name = "wow new one",
                    Description = "a very nice nice long description of the best roll table to ever exist enjoy using it and rolling big numbers",
                    RollEntries =
                    [
                        new()
                        {
                            RollValue = 1,
                            Description = "awesome thing 1 happens"
                        },
                        new()
                        {
                            RollValue = 2,
                            Description = "awesome thing 2 happens"
                        },
                        new()
                        {
                            RollValue = 3,
                            Description = "awesome thing 3 happens"
                        },
                        new()
                        {
                            RollValue = 4,
                            Description = "awesome thing 4 happens"
                        },
                        new()
                        {
                            RollValue = 5,
                            Description = "awesome thing 5 happens"
                        },
                    ]
                });

            return list;
        }

        public async Task AddAsync(RollTable rollTable)
        {
            var fileMode = File.Exists(filePath) ? FileMode.Truncate : FileMode.CreateNew;
            using var fileStream = File.Open(filePath, fileMode);
            using var streamWriter = new StreamWriter(fileStream);

            var list = await GetAllAsync();
            list.Add(rollTable);

            var json = JsonSerializer.Serialize(list);

            await streamWriter.WriteAsync(json);
        }
    }
}
