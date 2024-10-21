using TinyTableRoller.Data;

namespace TinyTableRoller.Service
{
    public interface IFileStorageService
    {
        Task<List<RollTable>> GetAllAsync();
        Task AddAsync(RollTable rollTable);
    }
}