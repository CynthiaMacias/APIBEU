using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_BU.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        public Boolean Estatus { get;set; }
    }
}
