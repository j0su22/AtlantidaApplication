using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_CLIENTE
    {
        Task<List<CLIENTE>> CLIENTE_SELECT(CLIENTE model);
        Task<List<CLIENTE>> CLIENTE_INSERT(CLIENTE model);
        Task<List<CLIENTE>> CLIENTE_UPDATE(CLIENTE model);
        Task<List<CLIENTE>> CLIENTE_DELETE(CLIENTE model);
    }
}
