using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaApplicationAPI.Services
{
    public class AGENCIA_Service : IService_AGENCIA
    {
        private readonly DataContext _dataContext;

        public AGENCIA_Service(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region SELECT
        public async Task<List<AGENCIA>> AGENCIA_SELECT(AGENCIA model, string? CASO, string? FILTRO)
        {
            try
            {
                var result = new List<AGENCIA>();

                switch (CASO)
                {
                    case "TODO":
                        result = await _dataContext.AGENCIA.Where(s =>
                            s.estado != "E"
                        ).ToListAsync();
                        break;

                    case "ID":
                        result = await _dataContext.AGENCIA.Where(s =>
                            s.estado != "E"
                            && s.id == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    case "NAME":
                        result = await _dataContext.AGENCIA.Where(s =>
                            s.estado != "E"
                            && s.nombre.Contains(FILTRO.Trim())
                        ).ToListAsync();
                        break;

                    default:
                        result = await _dataContext.AGENCIA.Where(s =>
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
        public async Task<int> AGENCIA_INSERT(AGENCIA model)
        {
            try
            {
                _dataContext.AGENCIA.Add(model);
                return await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region UPDATE
        public async Task<int> AGENCIA_UPDATE(AGENCIA model)
        {
            try
            {
                var result = await _dataContext.AGENCIA.FirstOrDefaultAsync(s =>
                    s.id == model.id
                );

                result.nombre = model.nombre;
                result.direccion = model.direccion;
                result.telefono = model.telefono;
                result.extension = model.extension;
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
        public async Task<int> AGENCIA_DELETE(AGENCIA model)
        {
            try
            {
                var result = await _dataContext.AGENCIA.FirstOrDefaultAsync(s =>
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
