using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaApplicationAPI.Services
{
    public class PRODUCTO_Service : IService_PRODUCTO
    {
        private readonly DataContext _dataContext;

        public PRODUCTO_Service(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region SELECT
        public async Task<List<PRODUCTO>> PRODUCTO_SELECT(PRODUCTO model, string? CASO, string? FILTRO)
        {
            try
            {
                var result = new List<PRODUCTO>();

                switch (CASO)
                {
                    case "TODO":
                        result = await _dataContext.PRODUCTO.Where(s =>
                            s.estado != "E"
                        ).ToListAsync();
                        break;

                    case "ID":
                        result = await _dataContext.PRODUCTO.Where(s =>
                            s.estado != "E"
                            && s.id == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    case "COD":
                        result = await _dataContext.PRODUCTO.Where(s =>
                            s.estado != "E"
                            && s.codigo == FILTRO
                        ).ToListAsync();
                        break;

                    case "NAME":
                        result = await _dataContext.PRODUCTO.Where(s =>
                            s.estado != "E"
                            && s.nombre.Contains(FILTRO.Trim())
                        ).ToListAsync();
                        break;

                    default:
                        result = await _dataContext.PRODUCTO.Where(s =>
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
        public async Task<int> PRODUCTO_INSERT(PRODUCTO model)
        {
            try
            {
                _dataContext.PRODUCTO.Add(model);
                return await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region UPDATE
        public async Task<int> PRODUCTO_UPDATE(PRODUCTO model)
        {
            try
            {
                var result = await _dataContext.PRODUCTO.FirstOrDefaultAsync(s =>
                    s.id == model.id
                );

                result.nombre = model.nombre;
                result.descripcion = model.descripcion;
                result.ptjinteres = model.ptjinteres;
                result.ptjsaldominimo = model.ptjsaldominimo;
                result.rngminimo = model.rngminimo;
                result.rngmaximo = model.rngmaximo;
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
        public async Task<int> PRODUCTO_DELETE(PRODUCTO model)
        {
            try
            {
                var result = await _dataContext.PRODUCTO.FirstOrDefaultAsync(s =>
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
