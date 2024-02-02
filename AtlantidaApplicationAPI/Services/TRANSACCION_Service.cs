using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaApplicationAPI.Services
{
    public class TRANSACCION_Service : IService_TRANSACCION
    {
        private readonly DataContext _dataContext;

        public TRANSACCION_Service(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region SELECT
        public async Task<List<TRANSACCION>> TRANSACCION_SELECT(TRANSACCION model, string? CASO, string? FILTRO)
        {
            try
            {
                var result = new List<TRANSACCION>();

                DateTime? fch = null;
                if (CASO == "FCH" || CASO == "FCHMIN" || CASO == "FCHMAX")
                {
                    fch = DateTime.Parse(FILTRO);
                }

                switch (CASO)
                {
                    case "TODO":
                        result = await _dataContext.TRANSACCION.Where(s =>
                            s.estado != "E"
                        ).ToListAsync();
                        break;

                    case "ID":
                        result = await _dataContext.TRANSACCION.Where(s =>
                            s.estado != "E"
                            && s.id == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    case "TIP":
                        result = await _dataContext.TRANSACCION.Where(s =>
                            s.estado != "E"
                            && s.idtipotransaccion == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    case "CLI":
                        result = await _dataContext.TRANSACCION.Where(s =>
                            s.estado != "E"
                            && s.idcliente == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    case "EJE":
                        result = await _dataContext.TRANSACCION.Where(s =>
                            s.estado != "E"
                            && s.idejecutivo == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    case "OFI":
                        result = await _dataContext.TRANSACCION.Where(s =>
                            s.estado != "E"
                            && s.idagencia == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    case "FCH":
                        result = await _dataContext.TRANSACCION.Where(s =>
                            s.estado != "E"
                            && s.fechahora == fch
                        ).ToListAsync();
                        break;

                    case "FCHMIN":
                        result = await _dataContext.TRANSACCION.Where(s =>
                            s.estado != "E"
                            && s.fechahora >= fch
                        ).ToListAsync();
                        break;

                    case "FCHMAX":
                        result = await _dataContext.TRANSACCION.Where(s =>
                            s.estado != "E"
                            && s.fechahora <= fch
                        ).ToListAsync();
                        break;

                    default:
                        result = await _dataContext.TRANSACCION.Where(s =>
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
        public async Task<int> TRANSACCION_INSERT(TRANSACCION model)
        {
            try
            {
                _dataContext.TRANSACCION.Add(model);
                return await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region DELETE
        public async Task<int> TRANSACCION_DELETE(TRANSACCION model)
        {
            try
            {
                var result = await _dataContext.TRANSACCION.FirstOrDefaultAsync(s =>
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
