using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtlantidaApplicationAPI.Controllers
{
    [Route("[controller]/api")]
    [ApiController]
    public class CLIENTEXPRODUCTOController : ControllerBase
    {
        private readonly IService_CLIENTEXPRODUCTO _service;
        private readonly IService_PERSONA _cli;
        private readonly IService_PRODUCTO _product;
        private readonly string empty;

        public CLIENTEXPRODUCTOController(IService_CLIENTEXPRODUCTO service, IService_PERSONA cli, IService_PRODUCTO product)
        {
            _service = service;
            _cli = cli;
            _product = product;
        }

        Dictionary<string, object> Response = new Dictionary<string, object>();

        #region SELECT TODO
        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<CLIENTEXPRODUCTO>>> CLIENTEXPRODUCTO_SELECT_TODO(CLIENTEXPRODUCTO model)
        {
            try
            {
                var exit = await _service.CLIENTEXPRODUCTO_SELECT(model, "TODO", "");
                var modelClie = new PERSONA();
                var clientes = await _cli.PERSONA_SELECT(modelClie, "TODO", "");
                var modelPro = new PRODUCTO();
                var productos = await _product.PRODUCTO_SELECT(modelPro, "TODO", "");

                foreach (var item in exit)
                {
                    item.cliente = item.idcliente != null
                        ? clientes.Where(s => s.id == item.idcliente) != null
                            ? clientes.FirstOrDefault(s => s.id == item.idcliente).nombres
                            : empty
                        : empty;

                    item.producto = item.idproducto != null
                        ? productos.Where(s => s.id == item.idproducto) != null
                            ? productos.FirstOrDefault(s => s.id == item.idproducto).descripcion
                            : empty
                        : empty;
                }

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

        #region SELECT CLIENTE
        [HttpPost]
        [Route("GetCliente")]
        public async Task<ActionResult<List<CLIENTEXPRODUCTO>>> CLIENTEXPRODUCTO_SELECT_CLIENTE(CLIENTEXPRODUCTO model)
        {
            try
            {
                var exit = await _service.CLIENTEXPRODUCTO_SELECT(model, "CLI", model.idcliente.ToString());

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

        #region INSERT
        [HttpPost]
        [Route("Insert")]
        public async Task<ActionResult<List<CLIENTEXPRODUCTO>>> CLIENTEXPRODUCTO_INSERT(CLIENTEXPRODUCTO model)
        {
            try
            {
                var exit = await _service.CLIENTEXPRODUCTO_INSERT(model);

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

        #region UDPATE
        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult<List<CLIENTEXPRODUCTO>>> CLIENTEXPRODUCTO_UDPATE(CLIENTEXPRODUCTO model)
        {
            try
            {
                var exit = await _service.CLIENTEXPRODUCTO_UPDATE(model);

                if (exit > 0)
                {
                    Response.Add("RESPONSE", exit);
                    return StatusCode(200, Response);
                }
                else
                {
                    Response.Add("RESPONSE", "Error al actualizar");
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

        #region DELETE
        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<List<CLIENTEXPRODUCTO>>> CLIENTEXPRODUCTO_DELETE(CLIENTEXPRODUCTO model)
        {
            try
            {
                var exit = await _service.CLIENTEXPRODUCTO_DELETE(model);

                if (exit > 0)
                {
                    Response.Add("RESPONSE", exit);
                    return StatusCode(200, Response);
                }
                else
                {
                    Response.Add("RESPONSE", "Error al eliminar");
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
