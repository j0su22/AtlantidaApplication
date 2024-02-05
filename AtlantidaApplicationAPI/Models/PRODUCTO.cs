namespace AtlantidaApplicationAPI.Models
{
    public class PRODUCTO
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public double? ptjinteres { get; set; }
        public double? ptjsaldominimo { get; set; }
        public int? rngminimo { get; set; }
        public int? rngmaximo { get; set; }
        public string estado { get; set; }
    }
}
