using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaApplicationAPI.Services
{
    public class TRANSACCION_Service : IService_TRANSACCION
    {
        private readonly DataContext _dataContext;
        private readonly IService_CLIENTEXPRODUCTO _cliProduct;

        public TRANSACCION_Service(DataContext dataContext, IService_CLIENTEXPRODUCTO cliProduct)
        {
            _dataContext = dataContext;
            _cliProduct = cliProduct;
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

                    case "CLIGTO":
                        result = await _dataContext.TRANSACCION.Where(s =>
                            s.estado != "E"
                            && s.idtipotransaccion == 2
                            && s.idcliente == int.Parse(FILTRO)
                        ).ToListAsync();
                        break;

                    case "CLIING":
                        result = await _dataContext.TRANSACCION.Where(s =>
                            s.estado != "E"
                            && s.idtipotransaccion == 1
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
                int salida = 0;

                if (model.idtipotransaccion == 1 || model.idtipotransaccion == 2)
                {
                    var modelCXP = new CLIENTEXPRODUCTO { };
                    var data = await _cliProduct.CLIENTEXPRODUCTO_SELECT(modelCXP, "CLI", model.idcliente.ToString());

                    var dataFiltered = data.FirstOrDefault(s => s.idproducto == model.idproducto);

                    switch (model.idtipotransaccion)
                    {
                        case 1:
                            {
                                if (dataFiltered != null)
                                {
                                    if (dataFiltered.saldodisponible < dataFiltered.saldoaprobado)
                                    {
                                        _dataContext.TRANSACCION.Add(model);
                                        dataFiltered.saldodisponible += model.monto;
                                        await _dataContext.SaveChangesAsync();
                                        salida = 1;
                                    }
                                    else
                                    {
                                        salida = 2;
                                    }
                                }
                                else
                                {
                                    salida = 2;
                                }

                                break;
                            }

                        case 2:
                            {
                                if (dataFiltered != null)
                                {
                                    if (dataFiltered.saldodisponible >= model.monto)
                                    {
                                        _dataContext.TRANSACCION.Add(model);
                                        dataFiltered.saldodisponible -= model.monto;
                                        await _dataContext.SaveChangesAsync();
                                        salida = 1;
                                    }
                                    else
                                    {
                                        salida = 2;
                                    }
                                }
                                else
                                {
                                    salida = 2;
                                }

                                break;
                            }
                    }
                }
                else
                {
                    return 2;
                }

                return salida;
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
