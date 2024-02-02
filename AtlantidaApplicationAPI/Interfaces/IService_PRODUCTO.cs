using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_PRODUCTO
    {
        Task<List<PRODUCTO>> PRODUCTO_SELECT(PRODUCTO model, string? CASO, string? FILTRO);
        Task<int> PRODUCTO_INSERT(PRODUCTO model);
        Task<int> PRODUCTO_UPDATE(PRODUCTO model);
        Task<int> PRODUCTO_DELETE(PRODUCTO model);
    }
}
