using AtlantidaApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace AtlantidaApplication.Controllers
{
    public class ListadoProductoController : Controller
    {
        public IActionResult Index()
        {
            ListadoProducto_Service _service = new ListadoProducto_Service();

            _service.ListadoProducto_SELECT();

            return View();
        }
    }
}
