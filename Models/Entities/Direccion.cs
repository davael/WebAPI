using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
