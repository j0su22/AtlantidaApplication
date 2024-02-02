using AtlantidaApplication.Models;
using AtlantidaApplication.API;

namespace AtlantidaApplication.Services
{
    public class ListadoProducto_Service
    {
        private readonly IConfiguration config;

        public async Task<List<ListadoProducto>> ListadoProducto_SELECT()
        {
            var salida =  new List<ListadoProducto>();

            var APIRequets = new AtlantidaAPI(config) { };

            var model = new CLIENTEXPRODUCTO()
            {
                id = 0,
                idcliente = 0,
                idproducto = 0,
                fchaprobacion = null,
                fchsolicitud = null,
                saldoaprobado = 0,
                saldodisponible = 0,
                estado = ""
            };
            var cxp = APIRequets.GetTarjetas(model);

            string responseBody = await cxp.Result.Content.ReadAsStringAsync();

            foreach (var item in responseBody)
            {
                
            }
            return salida;
        }
    }
}
