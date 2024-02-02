using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_TIPOTRANSACCION
    {
        Task<List<TIPOTRANSACCION>> TIPOTRANSACCION_SELECT(TIPOTRANSACCION model, string? CASO, string? FILTRO);
        Task<int> TIPOTRANSACCION_INSERT(TIPOTRANSACCION model);
        Task<int> TIPOTRANSACCION_UPDATE(TIPOTRANSACCION model);
        Task<int> TIPOTRANSACCION_DELETE(TIPOTRANSACCION model);
    }
}
