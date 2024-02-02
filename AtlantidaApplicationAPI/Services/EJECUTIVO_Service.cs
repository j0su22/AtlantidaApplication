using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaApplicationAPI.Services
{
    public class EJECUTIVO_Service : IService_EJECUTIVO
    {
        private readonly DataContext _dataContext;

        public EJECUTIVO_Service(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region SELECT
        public async Task<List<EJECUTIVO>> EJECUTIVO_SELECT(EJECUTIVO model, string? CASO, string? FILTRO)
        {
            try
            {
                var result = new List<EJECUTIVO>();

                switch (CASO)
                {
                    case "TODO":
                        result = await _dataContext.EJECUTIVO.Where(s =>
                            s.estado != "E"
                        ).ToListAsync();
                        break;

                    case "ID":
                        result = await _dataContext.EJECUTIVO.Where(s =>
                            s.estado != "E"
                            && s.id == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    default:
                        result = await _dataContext.EJECUTIVO.Where(s =>
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
        public async Task<int> EJECUTIVO_INSERT(EJECUTIVO model)
        {
            try
            {
                _dataContext.EJECUTIVO.Add(model);
                return await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region UPDATE
        public async Task<int> EJECUTIVO_UPDATE(EJECUTIVO model)
        {
            try
            {
                var result = await _dataContext.EJECUTIVO.FirstOrDefaultAsync(s =>
                    s.id == model.id
                );

                result.idagencia = model.idagencia;
                result.idcargo = model.idcargo;
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
        public async Task<int> EJECUTIVO_DELETE(EJECUTIVO model)
        {
            try
            {
                var ejecutivo = await _dataContext.EJECUTIVO.FirstOrDefaultAsync(s =>
                    s.id == model.id
                );

                var person = await _dataContext.PERSONA.FirstOrDefaultAsync(s =>
                    s.id == model.idpersona
                );

                person.estado = "E";

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
