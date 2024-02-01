using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_EJECUTIVO
    {
        Task<List<EJECUTIVO>> EJECUTIVO_SELECT(EJECUTIVO model);
        Task<List<EJECUTIVO>> EJECUTIVO_INSERT(EJECUTIVO model);
        Task<List<EJECUTIVO>> EJECUTIVO_UPDATE(EJECUTIVO model);
        Task<List<EJECUTIVO>> EJECUTIVO_DELETE(EJECUTIVO model);
    }
}
