using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_PERSONA
    {
        Task<List<PERSONA>> PERSONA_SELECT(PERSONA model, string? CASO, string? FILTRO);
        Task<int> PERSONA_INSERT(PERSONA model);
        Task<int> PERSONA_UPDATE(PERSONA model);
        Task<int> PERSONA_DELETE(PERSONA model);
    }
}
