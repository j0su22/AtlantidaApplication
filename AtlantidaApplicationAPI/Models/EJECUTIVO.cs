namespace AtlantidaApplicationAPI.Models
{
    public class EJECUTIVO : PERSONA
    {
        public int idejecutivo { get; set; }
        public int idpersona { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int? idagencia { get; set; }
        public int? idcargo { get; set; }
        public string subestado { get; set; }
    }
}
