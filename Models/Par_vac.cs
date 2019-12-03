using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_BU.Models
{
    public class Pr_vac
    {
        public Pr_vac(int id)
        {
           Id = id;
        }        

        //[Key]
        public int Id { get; set; }
        public int Id_emp { get; set; }
        [ForeignKey("Vacaciones")]
        public int  Id_vac  { get; set; }
     
        public string Fecha { get; set; }
    }
}
