using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaApplicationAPI.Services
{
    public class TIPOTRANSACCION_Service : IService_TIPOTRANSACCION
    {
        private readonly DataContext _dataContext;

        public TIPOTRANSACCION_Service(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region SELECT
        public async Task<List<TIPOTRANSACCION>> TIPOTRANSACCION_SELECT(TIPOTRANSACCION model, string? CASO, string? FILTRO)
        {
            try
            {
                var result = new List<TIPOTRANSACCION>();

                switch (CASO)
                {
                    case "TODO":
                        result = await _dataContext.TIPOTRANSACCION.Where(s =>
                            s.estado != "E"
                        ).ToListAsync();
                        break;

                    case "ID":
                        result = await _dataContext.TIPOTRANSACCION.Where(s =>
                            s.estado != "E"
                            && s.id == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    case "COD":
                        result = await _dataContext.TIPOTRANSACCION.Where(s =>
                            s.estado != "E"
                            && s.codigo == FILTRO
                        ).ToListAsync();
                        break;

                    case "NAME":
                        result = await _dataContext.TIPOTRANSACCION.Where(s =>
                            s.estado != "E"
                            && s.nombre.Contains(FILTRO.Trim())
                        ).ToListAsync();
                        break;

                    default:
                        result = await _dataContext.TIPOTRANSACCION.Where(s =>
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
        public async Task<int> TIPOTRANSACCION_INSERT(TIPOTRANSACCION model)
        {
            try
            {
                _dataContext.TIPOTRANSACCION.Add(model);
                return await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region UPDATE
        public async Task<int> TIPOTRANSACCION_UPDATE(TIPOTRANSACCION model)
        {
            try
            {
                var result = await _dataContext.TIPOTRANSACCION.FirstOrDefaultAsync(s =>
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
        public async Task<int> TIPOTRANSACCION_DELETE(TIPOTRANSACCION model)
        {
            try
            {
                var result = await _dataContext.TIPOTRANSACCION.FirstOrDefaultAsync(s =>
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
