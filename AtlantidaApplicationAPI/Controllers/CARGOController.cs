using AtlantidaApplicationAPI.Interfaces;
using AtlantidaApplicationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtlantidaApplicationAPI.Controllers
{
    [Route("[controller]/api")]
    [ApiController]
    public class CARGOController : ControllerBase
    {
        private readonly IService_CARGO _service;

        public CARGOController(IService_CARGO service)
        {
            _service = service;
        }

        Dictionary<string, object> Response = new Dictionary<string, object>();

        #region SELECT
        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<List<CARGO>>> CARGO_SELECT(CARGO model)
        {
            try
            {
                var exit = await _service.CARGO_SELECT(model, "TODO", "");

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
