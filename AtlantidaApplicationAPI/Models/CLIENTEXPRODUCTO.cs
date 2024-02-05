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
        public double? saldoaprobado { get; set; }
        public double? saldodisponible { get; set; }
        public string estado { get; set; }

        // IGNORE
        public string? cliente { get; set; }
        public string? producto { get; set; }
    }
}
