using System.Text.Json;
using TinyTableRoller.Data;

namespace TinyTableRoller.Views;

public partial class RollTableListContentPage : ContentPage
{
	private readonly List<RollTable> rollTables = [];

	public RollTableListContentPage()
	{
		InitializeComponent();

        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "Data", "roll-tables.json");
        using FileStream InputStream = File.OpenRead(targetFile);
        using StreamReader reader = new StreamReader(InputStream);
        var json = reader.ReadToEndAsync().GetAwaiter().GetResult();

        rollTables = JsonSerializer.Deserialize<List<RollTable>>(json) ?? [];
    }
}