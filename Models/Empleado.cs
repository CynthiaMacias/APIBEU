using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_BU.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Num_ext { get; set; }
        public string Num_int { get; set; }
        public int Cp { get; set; }
        public string Colonia { get; set; }
        public string Municipio { get; set; }
        public string Pais { get; set; }
        public string Entre_calle1 { get; set; }
        public string Entre_calle2 { get; set; }
        public string Curp { get; set; }
        public string Rfc { get; set; }
        public string Sexo { get; set; }
        public string Edo_ivil { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public int Edad { get; set; }
        public int Num_trajeta { get; set; }
        public int Cta_bancaria { get; set; }
        public int Imss { get; set; }
        public int Umf { get; set; }
        public string Categoria { get; set; }
        public int Credito_info { get; set; }
        public int Porcentaje_info { get; set; }
        public string Nombre_padre { get; set; }
        public string Nombre_madre { get; set; }
        public string Lugar_nacimiento { get; set; }
        public int Tarjet_despensa { get; set; }
        public int Cuenta_despensa { get; set; }
        public string Afore { get; set; }
        public string Email { get; set; }
        public DateTime Fecha_ingreso { get; set; }
        public float Salario_diario { get; set; }
        public float Salrio_base { get; set; }
        public float Sdi { get; set; }
        public int Dias_contrato { get; set; }
        public DateTime Fecha_creacion { get; set; }
        public string Photo { get; set; }
        public int Id_usuario_creo { get; set; }
        public int Id_puesto { get; set; }
        public int Id_contrato { get; set; }
        public int EmpresaID { get; set; }
        public int reloj { get; set; }
    }
}
