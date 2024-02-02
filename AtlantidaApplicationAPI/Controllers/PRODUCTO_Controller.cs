using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtlantidaApplicationAPI.Controllers
{
    [Route("[controller]/api")]
    [ApiController]
    public class PRODUCTO_Controller : ControllerBase
    {
        private readonly IService_PRODUCTO _service;

        public PRODUCTO_Controller(IService_PRODUCTO service)
        {
            _service = service;
        }

        Dictionary<string, object> Response = new Dictionary<string, object>();

        #region SELECT TODO
        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<PRODUCTO>>> PRODUCTO_SELECT_TODO(PRODUCTO model)
        {
            try
            {
                var exit = await _service.PRODUCTO_SELECT(model, "TODO", "");

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

        #region SELECT PRODUCTO
        [HttpPost]
        [Route("GetProducto")]
        public async Task<ActionResult<List<PRODUCTO>>> PRODUCTO_SELECT_UNO(PRODUCTO model)
        {
            try
            {
                var exit = await _service.PRODUCTO_SELECT(model, "CLI", model.id.ToString());

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
    }
}
