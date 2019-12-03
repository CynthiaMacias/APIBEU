using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_BU.Models
{
    public class Empresa
    {
        public int EmpresaID { get; set; }
        public string Nombre_empresa { get; set; }
        public string Rfc_empresa { get; set; }
        public string Direccion_empresa { get; set; }
        public string Num_ext_empresa { get; set; }
        public string Num_int_empresa { get; set; }
        public string Estado_empresa { get; set; }
        public string Pais_empresa { get; set; }
        public string Municipio_empresa { get; set; }
        public int Cp_empresa { get; set; }
        public string Logo_empresa { get; set; }
    }
}
