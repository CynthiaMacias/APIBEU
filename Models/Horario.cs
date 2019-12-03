using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_BU.Models
{
    public class Horario
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [StringLength(10)]
        public string El { get; set; }
        [StringLength(10)]
        public string Sl { get; set; }
        [StringLength(10)]
        public string Emar { get; set; }
        [StringLength(10)]
        public string Smar { get; set; }
        [StringLength(10)]
        public string EMier { get; set; }
        [StringLength(10)]
        public string SMier { get; set; }
        [StringLength(10)]
        public string EJ { get; set; }
        [StringLength(10)]
        public string SJ { get; set; }
        [StringLength(10)]
        public string EV { get; set; }
        [StringLength(10)]
        public string SV { get; set; }
        [StringLength(10)]
        public string ES { get; set; }
        [StringLength(10)]
        public string SS { get; set; }
        [StringLength(10)]
        public string ED { get; set; }
        [StringLength(10)]
        public string SD { get; set; }
        public Boolean Turno { get; set; }
        public int Dinicio { get; set; }
        public int Dtrabajar { get; set; }
        public int Ttrabajar { get; set; }
        public Boolean Estatus { get; set; }
    }
}
