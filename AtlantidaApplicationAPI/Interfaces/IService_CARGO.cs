using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_CARGO
    {
        Task<List<CARGO>> CARGO_SELECT(CARGO model);
        Task<List<CARGO>> CARGO_INSERT(CARGO model);
        Task<List<CARGO>> CARGO_UPDATE(CARGO model);
        Task<List<CARGO>> CARGO_DELETE(CARGO model);
    }
}
