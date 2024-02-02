using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaApplicationAPI.Services
{
    public class PERSONA_Service : IService_PERSONA
    {
        private readonly DataContext _dataContext;

        public PERSONA_Service(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region SELECT
        public async Task<List<PERSONA>> PERSONA_SELECT(PERSONA model, string? CASO, string? FILTRO)
        {
            try
            {
                var result = new List<PERSONA>();

                switch (CASO)
                {
                    case "TODO":
                        result = await _dataContext.PERSONA.Where(s =>
                            s.estado != "E"
                        ).ToListAsync();
                        break;

                    case "ID":
                        result = await _dataContext.PERSONA.Where(s =>
                            s.estado != "E"
                            && s.id == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    case "NAME":
                        result = await _dataContext.PERSONA.Where(s =>
                            s.estado != "E"
                            && s.nombres.Contains(FILTRO.Trim())
                        ).ToListAsync();
                        break;

                    default:
                        result = await _dataContext.PERSONA.Where(s =>
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
        public async Task<int> PERSONA_INSERT(PERSONA model)
        {
            try
            {
                _dataContext.PERSONA.Add(model);
                return await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region UPDATE
        public async Task<int> PERSONA_UPDATE(PERSONA model)
        {
            try
            {
                var result = await _dataContext.PERSONA.FirstOrDefaultAsync(s =>
                    s.id == model.id
                );

                result.dui = model.dui;
                result.nombres = model.nombres;
                result.apellidos = model.apellidos;
                result.correo = model.correo;
                result.telefono = model.telefono;
                result.fchnacimiento = model.fchnacimiento;
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
        public async Task<int> PERSONA_DELETE(PERSONA model)
        {
            try
            {
                var result = await _dataContext.PERSONA.FirstOrDefaultAsync(s =>
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
