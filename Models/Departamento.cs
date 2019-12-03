using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_BU.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public Departamento()
        {
            Puesto = new List<Puesto>();
        }
        [StringLength(30)]
        [Required]
        public string Nombre { get; set; }
        public Boolean estatus { get; set; }
        public List<Puesto> Puesto { get; set; }
    }
}
