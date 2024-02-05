namespace AtlantidaApplication.Models
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
    }
}
