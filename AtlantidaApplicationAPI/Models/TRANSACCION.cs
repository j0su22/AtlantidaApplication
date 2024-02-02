using System.Data.SqlTypes;

namespace AtlantidaApplicationAPI.Models
{
    public class TRANSACCION
    {
        public int id { get; set; }
        public int idtipotransaccion { get; set; }
        public int idcliente { get; set; }
        public int idejecutivo { get; set; }
        public int idproducto { get; set; }
        public int? idagencia { get; set; }
        public DateTime? fechahora { get; set; }
        public float? monto { get; set; }
        public string? descripcion { get; set; }
        public string estado { get; set; }
    }
}
