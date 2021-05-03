using System.ComponentModel.DataAnnotations;

namespace APITienda.Models
{
    public class Direccion
    {
        [Key]
        public int Id { get; set; }

        public int Localidad { get; set; }

        public string Calle { get; set; }

        public int Nro { get; set; }
    }
}
