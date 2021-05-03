using System;

namespace APITienda.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        
        public enum Tipo { Telefono, Email, Url, Sms, Otro }
        
        public Tipo TipoContacto { get; set; }
        
        public string Valor { get; set; }
        
        public enum Uso { Casa, Trabajo, Temporal, Antiguo }
        
        public Uso UsoContacto { get; set; }
        
        public DateTime FechaExpira { get; set; }
    }
}
