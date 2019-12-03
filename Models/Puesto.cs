using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_BU.Models
{
    public class Puesto
    {
        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Nombre { get; set; }
        [ForeignKey("Departamento")]
        public int id_depto { get; set; }
        public Boolean estatus { get; set; }
        [JsonIgnore]
        public Departamento Departamento { get; set; }

    }
}
