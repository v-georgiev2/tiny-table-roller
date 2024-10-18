namespace TinyTableRoller.Data
{
    public class RollTable
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<RollEntry> RollEntries { get; set; } = [];
    }
}
