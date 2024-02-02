namespace AtlantidaApplication.Models
{
    public class PERSONA
    {
        public int id { get; set; }
        public string dui { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string? correo { get; set; }
        public string? telefono { get; set; }
        public DateTime fchnacimiento { get; set; }
        public string flgejecutivo { get; set; }
        public string estado { get; set; }
    }
}
