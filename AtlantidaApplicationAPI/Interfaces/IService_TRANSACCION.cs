using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_TRANSACCION
    {
        Task<List<TRANSACCION>> TRANSACCION_SELECT(TRANSACCION model, string? CASO, string? FILTRO);
        Task<int> TRANSACCION_INSERT(TRANSACCION model);
        Task<int> TRANSACCION_DELETE(TRANSACCION model);
    }
}
