using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_BU.Controllers;
using API_BU.Models;
using Microsoft.EntityFrameworkCore;
namespace API_BU.Data
{
    public class DepPuestoContexto : DbContext
    {
        public DepPuestoContexto()
        {
        }

        public DepPuestoContexto(DbContextOptions<DepPuestoContexto> options) :
            base(options)
        {

        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Puesto> Puesto { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Reloj> Reloj { get; set; }

        public DbSet<ProgHorario> ProgHorario { get; set; }
        public DbSet<Vacaciones> Vacaciones { get; set; }
        public DbSet<Dias_Vac> Dias_Vac { get; set; }
        public DbSet<Pr_vac> Pr_vac { get; set; }
        //public ICollection<Pr_vac> Par_vac { get; set; }
        //public DbSet<Datos> Par_vacc { get; set; }
        //public ICollection<Pr_vac> Pr_vac { get; } = new List<Pr_vac>();

    }
}
