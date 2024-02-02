using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtlantidaApplicationAPI.Controllers
{
    [Route("[controller]/api")]
    [ApiController]
    public class PERSONA_Controller : ControllerBase
    {
        private readonly IService_PERSONA _service;

        public PERSONA_Controller(IService_PERSONA service)
        {
            _service = service;
        }

        Dictionary<string, object> Response = new Dictionary<string, object>();

        #region SELECT TODO
        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<PERSONA>>> PERSONA_SELECT_TODO(PERSONA model)
        {
            try
            {
                var exit = await _service.PERSONA_SELECT(model, "CLI", "");

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
        public async Task<ActionResult<List<PERSONA>>> PERSONA_SELECT_UNO(PERSONA model)
        {
            try
            {
                var exit = await _service.PERSONA_SELECT(model, "ID", model.id.ToString());

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
