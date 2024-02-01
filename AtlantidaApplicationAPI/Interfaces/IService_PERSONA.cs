using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_PERSONA
    {
        Task<List<PERSONA>> PERSONA_SELECT(PERSONA model);
        Task<List<PERSONA>> PERSONA_INSERT(PERSONA model);
        Task<List<PERSONA>> PERSONA_UPDATE(PERSONA model);
        Task<List<PERSONA>> PERSONA_DELETE(PERSONA model);
    }
}
