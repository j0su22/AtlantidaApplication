using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_AGENCIA
    {
        Task<List<AGENCIA>> AGENCIA_SELECT(AGENCIA model, string? CASO, string? FILTRO);
        Task<int> AGENCIA_INSERT(AGENCIA model);
        Task<int> AGENCIA_UPDATE(AGENCIA model);
        Task<int> AGENCIA_DELETE(AGENCIA model);
    }
}
