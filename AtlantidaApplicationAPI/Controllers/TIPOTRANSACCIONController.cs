using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtlantidaApplicationAPI.Controllers
{
    [Route("[controller]/api")]
    [ApiController]
    public class TIPOTRANSACCIONController : ControllerBase
    {
        private readonly IService_TIPOTRANSACCION _service;

        public TIPOTRANSACCIONController(IService_TIPOTRANSACCION service)
        {
            _service = service;
        }

        Dictionary<string, object> Response = new Dictionary<string, object>();

        #region SELECT TODO
        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<TIPOTRANSACCION>>> TIPOTRANSACCION_SELECT_TODO(TIPOTRANSACCION model)
        {
            try
            {
                var exit = await _service.TIPOTRANSACCION_SELECT(model, "TODO", "");

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
