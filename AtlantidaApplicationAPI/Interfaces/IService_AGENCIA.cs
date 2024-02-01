using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_AGENCIA
    {
        Task<List<AGENCIA>> AGENCIA_SELECT(AGENCIA model);
        Task<List<AGENCIA>> AGENCIA_INSERT(AGENCIA model);
        Task<List<AGENCIA>> AGENCIA_UPDATE(AGENCIA model);
        Task<List<AGENCIA>> AGENCIA_DELETE(AGENCIA model);
    }
}
