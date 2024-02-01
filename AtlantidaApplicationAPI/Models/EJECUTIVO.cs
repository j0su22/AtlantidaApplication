namespace AtlantidaApplicationAPI.Models
{
    public class EJECUTIVO
    {
        public int id { get; set; }
        public int idpersona { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int? idagencia { get; set; }
        public int? idcargo { get; set; }
    }
}
