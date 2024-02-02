using AtlantidaApplicationAPI.Models;

namespace AtlantidaApplicationAPI.Interfaces
{
    public interface IService_CARGO
    {
        Task<List<CARGO>> CARGO_SELECT(CARGO model, string? CASO, string? FILTRO);
        Task<int> CARGO_INSERT(CARGO model);
        Task<int> CARGO_UPDATE(CARGO model);
        Task<int> CARGO_DELETE(CARGO model);
    }
}
