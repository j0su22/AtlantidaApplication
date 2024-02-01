using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_PRODUCTO
    {
        Task<List<PRODUCTO>> PRODUCTO_SELECT(PRODUCTO model);
        Task<List<PRODUCTO>> PRODUCTO_INSERT(PRODUCTO model);
        Task<List<PRODUCTO>> PRODUCTO_UPDATE(PRODUCTO model);
        Task<List<PRODUCTO>> PRODUCTO_DELETE(PRODUCTO model);
    }
}
