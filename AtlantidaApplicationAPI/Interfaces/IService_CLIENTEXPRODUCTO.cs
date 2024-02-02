using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_CLIENTEXPRODUCTO
    {
        Task<List<CLIENTEXPRODUCTO>> CLIENTEXPRODUCTO_SELECT(CLIENTEXPRODUCTO model, string? CASO, string? FILTRO);
        Task<int> CLIENTEXPRODUCTO_INSERT(CLIENTEXPRODUCTO model);
        Task<int> CLIENTEXPRODUCTO_UPDATE(CLIENTEXPRODUCTO model);
        Task<int> CLIENTEXPRODUCTO_DELETE(CLIENTEXPRODUCTO model);
    }
}
