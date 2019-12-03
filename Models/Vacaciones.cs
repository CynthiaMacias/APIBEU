using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_BU.Models
{
    public class Vacaciones
    {
        public Vacaciones()
        {
        }

        public Vacaciones(int id_vac)
        {
            Id_vac = id_vac;
        }
        [Key, ForeignKey("Pr_vac")]
        public int Id_vac { get; set; }
        public int Id_emp { get; set; }
        public DateTime Fh_solic { get; set; }
        public int Periodo { get; set; }
        public int Dias_periodo { get; set; }
        public int Dias_disp { get; set; }
        public int D_solicita { get; set; }
        public int D_restantes { get; set; }

        public DateTime Fh_inicio { get; set; }
        public DateTime Fh_fin { get; set; }

        public string Observaciones { get; set; }
        public string Descansos { get; set; }
        public DateTime Fh_reg { get; set; }
        [NotMapped]
        public ICollection<Pr_vac> Arr { get; set; }
 

    }
}
