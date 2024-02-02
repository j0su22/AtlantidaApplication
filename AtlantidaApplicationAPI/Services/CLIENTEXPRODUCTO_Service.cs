using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaApplicationAPI.Services
{
    public class CLIENTEXPRODUCTO_Service : IService_CLIENTEXPRODUCTO
    {
        private readonly DataContext _dataContext;

        public CLIENTEXPRODUCTO_Service(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region SELECT
        public async Task<List<CLIENTEXPRODUCTO>> CLIENTEXPRODUCTO_SELECT(CLIENTEXPRODUCTO model, string? CASO, string? FILTRO)
        {
            try
            {
                var result = new List<CLIENTEXPRODUCTO>();

                switch (CASO)
                {
                    case "TODO":
                        result = await _dataContext.CLIENTEXPRODUCTO.Where(s =>
                            s.estado != "E"
                        ).ToListAsync();
                        break;

                    case "ID":
                        result = await _dataContext.CLIENTEXPRODUCTO.Where(s =>
                            s.estado != "E"
                            && s.id == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    case "CLI":
                        result = await _dataContext.CLIENTEXPRODUCTO.Where(s =>
                            s.estado != "E"
                            && s.idcliente == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    case "PRO":
                        result = await _dataContext.CLIENTEXPRODUCTO.Where(s =>
                            s.estado != "E"
                            && s.idproducto == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    default:
                        result = await _dataContext.CLIENTEXPRODUCTO.Where(s =>
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
        public async Task<int> CLIENTEXPRODUCTO_INSERT(CLIENTEXPRODUCTO model)
        {
            try
            {
                _dataContext.CLIENTEXPRODUCTO.Add(model);
                return await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region UPDATE
        public async Task<int> CLIENTEXPRODUCTO_UPDATE(CLIENTEXPRODUCTO model)
        {
            try
            {
                var result = await _dataContext.CLIENTEXPRODUCTO.FirstOrDefaultAsync(s =>
                    s.id == model.id
                );

                result.fchaprobacion = DateTime.Now;
                result.saldoaprobado = model.saldoaprobado;
                result.saldodisponible = model.saldodisponible;
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
        public async Task<int> CLIENTEXPRODUCTO_DELETE(CLIENTEXPRODUCTO model)
        {
            try
            {
                var result = await _dataContext.CLIENTEXPRODUCTO.FirstOrDefaultAsync(s =>
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
