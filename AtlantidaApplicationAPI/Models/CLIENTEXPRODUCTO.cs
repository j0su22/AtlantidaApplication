using System.Data.SqlTypes;

namespace AtlantidaApplicationAPI.Models
{
    public class CLIENTEXPRODUCTO
    {
        public int id { get; set; }
        public int idcliente { get; set; }
        public int idproducto { get; set; }
        public DateTime? fchsolicitud { get; set; }
        public DateTime? fchaprobacion { get; set; }
        public float? saldoaprobado { get; set; }
        public float? saldodisponible { get; set; }
        public string estado { get; set; }
    }
}
