using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_EJECUTIVO
    {
        Task<List<EJECUTIVO>> EJECUTIVO_SELECT(EJECUTIVO model, string? CASO, string? FILTRO);
        Task<int> EJECUTIVO_INSERT(EJECUTIVO model);
        Task<int> EJECUTIVO_UPDATE(EJECUTIVO model);
        Task<int> EJECUTIVO_DELETE(EJECUTIVO model);
    }
}
