using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtlantidaApplicationAPI.Controllers
{
    [Route("[controller]/api")]
    [ApiController]
    public class TRANSACCION_Controller : ControllerBase
    {
        private readonly IService_TRANSACCION _service;

        public TRANSACCION_Controller(IService_TRANSACCION service)
        {
            _service = service;
        }

        Dictionary<string, object> Response = new Dictionary<string, object>();

        #region SELECT TODO
        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<TRANSACCION>>> TRANSACCION_SELECT_TODO(TRANSACCION model)
        {
            try
            {
                var exit = await _service.TRANSACCION_SELECT(model, "TODO", "");

                if (exit.Any())
                {
                    Response.Add("RESPONSE", exit);
                    return StatusCode(200, Response);
                }
                else
                {
                    Response.Add("RESPONSE", "No se encontro información");
                    return StatusCode(200, Response);
                }
            }
            catch (Exception e)
            {
                Response.Add("RESPONSE", e.Message);
                return StatusCode(500, Response);
            }
        }
        #endregion

        #region SELECT TRANSACCION
        [HttpPost]
        [Route("GetTransaccion")]
        public async Task<ActionResult<List<TRANSACCION>>> TRANSACCION_SELECT_UNO(TRANSACCION model)
        {
            try
            {
                var exit = await _service.TRANSACCION_SELECT(model, "ID", model.id.ToString());

                if (exit.Any())
                {
                    Response.Add("RESPONSE", exit);
                    return StatusCode(200, Response);
                }
                else
                {
                    Response.Add("RESPONSE", "No se encontro información");
                    return StatusCode(200, Response);
                }
            }
            catch (Exception e)
            {
                Response.Add("RESPONSE", e.Message);
                return StatusCode(500, Response);
            }
        }
        #endregion

        #region SELECT TRANSACCION CLIENTE
        [HttpPost]
        [Route("GetTranssClie")]
        public async Task<ActionResult<List<TRANSACCION>>> TRANSACCION_SELECT_CLIENTE(TRANSACCION model)
        {
            try
            {
                var exit = await _service.TRANSACCION_SELECT(model, "CLI", model.idcliente.ToString());

                if (exit.Any())
                {
                    Response.Add("RESPONSE", exit);
                    return StatusCode(200, Response);
                }
                else
                {
                    Response.Add("RESPONSE", "No se encontro información");
                    return StatusCode(200, Response);
                }
            }
            catch (Exception e)
            {
                Response.Add("RESPONSE", e.Message);
                return StatusCode(500, Response);
            }
        }
        #endregion

        #region SELECT TRANSACCION CLIENTE GASTOS
        [HttpPost]
        [Route("GetTranssClieGto")]
        public async Task<ActionResult<List<TRANSACCION>>> TRANSACCION_SELECT_CLIENTE_GASTOS(TRANSACCION model)
        {
            try
            {
                var exit = await _service.TRANSACCION_SELECT(model, "CLIGTO", model.idcliente.ToString());

                if (exit.Any())
                {
                    Response.Add("RESPONSE", exit);
                    return StatusCode(200, Response);
                }
                else
                {
                    Response.Add("RESPONSE", "No se encontro información");
                    return StatusCode(200, Response);
                }
            }
            catch (Exception e)
            {
                Response.Add("RESPONSE", e.Message);
                return StatusCode(500, Response);
            }
        }
        #endregion

        #region SELECT TRANSACCION CLIENTE PAGOS
        [HttpPost]
        [Route("GetTranssClieIng")]
        public async Task<ActionResult<List<TRANSACCION>>> TRANSACCION_SELECT_CLIENTE_PAGOS(TRANSACCION model)
        {
            try
            {
                var exit = await _service.TRANSACCION_SELECT(model, "CLIING", model.idcliente.ToString());

                if (exit.Any())
                {
                    Response.Add("RESPONSE", exit);
                    return StatusCode(200, Response);
                }
                else
                {
                    Response.Add("RESPONSE", "No se encontro información");
                    return StatusCode(200, Response);
                }
            }
            catch (Exception e)
            {
                Response.Add("RESPONSE", e.Message);
                return StatusCode(500, Response);
            }
        }
        #endregion

        #region INSERT TRANSACCION
        [HttpPost]
        [Route("Insert")]
        public async Task<ActionResult<List<TRANSACCION>>> TRANSACCION_INSERT(TRANSACCION model)
        {
            try
            {
                var exit = await _service.TRANSACCION_INSERT(model);

                if (exit > 0)
                {
                    Response.Add("RESPONSE", exit);
                    return StatusCode(200, Response);
                }
                else
                {
                    Response.Add("RESPONSE", "Error al insertar");
                    return StatusCode(200, Response);
                }
            }
            catch (Exception e)
            {
                Response.Add("RESPONSE", e.Message);
                return StatusCode(500, Response);
            }
        }
        #endregion

        #region INSERT TRANSACCION
        [HttpPost]
        [Route("InsertGto")]
        public async Task<ActionResult<List<TRANSACCION>>> TRANSACCION_INSERT_GTO(TRANSACCION model)
        {
            try
            {
                model.idtipotransaccion = 1;
                var exit = await _service.TRANSACCION_INSERT(model);

                if (exit > 0)
                {
                    Response.Add("RESPONSE", exit);
                    return StatusCode(200, Response);
                }
                else
                {
                    Response.Add("RESPONSE", "Error al insertar");
                    return StatusCode(200, Response);
                }
            }
            catch (Exception e)
            {
                Response.Add("RESPONSE", e.Message);
                return StatusCode(500, Response);
            }
        }
        #endregion

        #region INSERT TRANSACCION
        [HttpPost]
        [Route("InsertIng")]
        public async Task<ActionResult<List<TRANSACCION>>> TRANSACCION_INSERT_ING(TRANSACCION model)
        {
            try
            {
                model.idtipotransaccion = 2;
                var exit = await _service.TRANSACCION_INSERT(model);

                if (exit > 0)
                {
                    Response.Add("RESPONSE", exit);
                    return StatusCode(200, Response);
                }
                else
                {
                    Response.Add("RESPONSE", "Error al insertar");
                    return StatusCode(200, Response);
                }
            }
            catch (Exception e)
            {
                Response.Add("RESPONSE", e.Message);
                return StatusCode(500, Response);
            }
        }
        #endregion
    }
}
