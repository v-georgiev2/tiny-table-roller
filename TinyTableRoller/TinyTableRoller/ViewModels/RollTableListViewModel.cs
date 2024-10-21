using TinyTableRoller.Data;
using TinyTableRoller.Service;

namespace TinyTableRoller.ViewModels
{
    public class RollTableListViewModel
    {
        public List<RollTable> RollTables { get; }

        public RollTableListViewModel(IFileStorageService fileStorageService)
        {
            RollTables = fileStorageService.GetAllAsync().GetAwaiter().GetResult();
        }
    }
}
