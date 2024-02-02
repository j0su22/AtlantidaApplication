using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaApplicationAPI.Services
{
    public class CARGO_Service : IService_CARGO
    {
        private readonly DataContext _dataContext;

        public CARGO_Service(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region SELECT
        public async Task<List<CARGO>> CARGO_SELECT(CARGO model, string? CASO, string? FILTRO)
        {
            try
            {
                var result = new List<CARGO>();

                switch (CASO)
                {
                    case "TODO":
                        result = await _dataContext.CARGO.Where(s =>
                            s.estado != "E"
                        ).ToListAsync();
                        break;

                    case "ID":
                        result = await _dataContext.CARGO.Where(s =>
                            s.estado != "E"
                            && s.id == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    case "NAME":
                        result = await _dataContext.CARGO.Where(s =>
                            s.estado != "E"
                            && s.nombre.Contains(FILTRO.Trim())
                        ).ToListAsync();
                        break;

                    default:
                        result = await _dataContext.CARGO.Where(s =>
                            s.estado != "E"
                        ).ToListAsync();
                        break;
                }

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region INSERT
        public async Task<int> CARGO_INSERT(CARGO model)
        {
            try
            {
                _dataContext.CARGO.Add(model);
                return await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region UPDATE
        public async Task<int> CARGO_UPDATE(CARGO model)
        {
            try
            {
                var result = await _dataContext.CARGO.FirstOrDefaultAsync(s =>
                    s.id == model.id
                );

                result.nombre = model.nombre;
                result.descripcion = model.descripcion;
                result.estado = model.estado;

                return await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region DELETE
        public async Task<int> CARGO_DELETE(CARGO model)
        {
            try
            {
                var result = await _dataContext.CARGO.FirstOrDefaultAsync(s =>
                    s.id == model.id
                );

                result.estado = "E";

                return await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
