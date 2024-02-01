using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_TRANSACCION
    {
        Task<List<TRANSACCION>> TRANSACCION_SELECT(TRANSACCION model);
        Task<List<TRANSACCION>> TRANSACCION_INSERT(TRANSACCION model);
        Task<List<TRANSACCION>> TRANSACCION_UPDATE(TRANSACCION model);
        Task<List<TRANSACCION>> TRANSACCION_DELETE(TRANSACCION model);
    }
}
