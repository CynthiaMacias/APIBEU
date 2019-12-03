using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_BU.Models;
using API_BU.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using System.IO;

namespace API_BU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly DepPuestoContexto _context;

        public EmpleadoController(DepPuestoContexto contexto)
        {
            _context = contexto;
        }

        // GET: api/Empleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            var data = _context.Empleado.OrderBy(a => a.EmpleadoID).ToListAsync();
            return await data;

            //var data = _context.Empleado
            //    .Include(a => a.Empresa).ToListAsync();
            //return await data;
        }

        // GET: api/Empleado/5
        [HttpGet("{id}")]
        public IActionResult GetEmpleado(int id)
        {
            //var item = await _context.Empleados.FindAsync(id);
            var data = (from a in _context.Empleado
                        join b in _context.Empresas
                        on a.EmpresaID equals b.EmpresaID
                        where a.EmpleadoID.Equals(id)
                        select new
                        {
                            Empleado = a
                            //Empresa = b
                        });

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
        [HttpGet("empleado/")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpdat()
        {
            var data = (from a in _context.Empleado

                        select new
                        {
                            puestosempleado = a.Id_puesto
                            //Empresa = b
                        });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet("CONTRATO/")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpContrato()
        {
            var data = (from a in _context.Empleado

                        select new
                        {
                            contemp = a.Id_contrato
                            //Empresa = b
                        });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet("dep/")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetDepdat()
        {
            var data = (from a in _context.Empleado
                        join b in _context.Puesto
                        on a.Id_puesto equals b.Id
                        select new
                        {
                            depemp = b.id_depto
                            //Empresa = b
                        });
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        // POST: api/Empleado
        [HttpPost("DatosGenerales")]
        public async Task<ActionResult<Empresa>> PostEmpleadoItem(Empleado item)
        {
            _context.Empleado.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleados), new { id = item.EmpleadoID }, item);
        }

        [HttpPut("datosGenerales/{id}")]
        public async Task<IActionResult> PutDatosGenerales(int id, Empleado empleadoItem)
        {
            if (id != empleadoItem.EmpleadoID)
            {
                return BadRequest();
            }

            var empleado = _context.Empleado.Find(id);
            empleado.Nombre = empleadoItem.Nombre;
            empleado.Curp = empleadoItem.Curp;
            empleado.Rfc = empleadoItem.Rfc;
            empleado.Email = empleadoItem.Email;
            empleado.Sexo = empleadoItem.Sexo;
            empleado.Fecha_nacimiento = empleadoItem.Fecha_nacimiento;
            empleado.Edad = empleadoItem.Edad;
            empleado.Lugar_nacimiento = empleadoItem.Lugar_nacimiento;
            empleado.Fecha_ingreso = empleadoItem.Fecha_ingreso;
            empleado.Id_puesto = empleadoItem.Id_puesto;
            empleado.EmpresaID = empleadoItem.EmpresaID;
            empleado.reloj = empleadoItem.reloj;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Empleado/datosPersonales/5
        [HttpPut("datosPersonales/{id}")]
        public async Task<IActionResult> putDatosPersonales(int id, Empleado empleadoItem)
        {
            if (id != empleadoItem.EmpleadoID)
            {
                return BadRequest();
            }

            var empleado = _context.Empleado.Find(id);
            empleado.Direccion = empleadoItem.Direccion;
            empleado.Num_ext = empleadoItem.Num_ext;
            empleado.Num_int = empleadoItem.Num_int;
            empleado.Cp = empleadoItem.Cp;
            empleado.Colonia = empleadoItem.Colonia;
            empleado.Municipio = empleadoItem.Municipio;
            empleado.Pais = empleadoItem.Pais;
            empleado.Entre_calle1 = empleadoItem.Entre_calle1;
            empleado.Entre_calle2 = empleadoItem.Entre_calle2;
            empleado.Edo_ivil = empleadoItem.Edo_ivil;
            empleado.Nombre_padre = empleadoItem.Nombre_padre;
            empleado.Nombre_madre = empleadoItem.Nombre_madre;
            empleado.Lugar_nacimiento = empleadoItem.Lugar_nacimiento;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        // PUT: api/Empleado/salario/5
        [HttpPut("salario/{id}")]
        public async Task<IActionResult> PutSalario(int id, Empleado empleadoItem)
        {
            if (id != empleadoItem.EmpleadoID)
            {
                return BadRequest();
            }

            var empleado = _context.Empleado.Find(id);
            empleado.Num_trajeta = empleadoItem.Num_trajeta;
            empleado.Cta_bancaria = empleadoItem.Cta_bancaria;
            empleado.Categoria = empleadoItem.Categoria;
            empleado.Credito_info = empleadoItem.Credito_info;
            empleado.Porcentaje_info = empleadoItem.Porcentaje_info;
            empleado.Tarjet_despensa = empleadoItem.Tarjet_despensa;
            empleado.Cuenta_despensa = empleadoItem.Cuenta_despensa;
            empleado.Salario_diario = empleadoItem.Salario_diario;
            empleado.Salrio_base = empleadoItem.Salrio_base;
            empleado.Sdi = empleadoItem.Sdi;
            empleado.Afore = empleadoItem.Afore;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Empleado/fiscales/5
        [HttpPut("fiscales/{id}")]
        public async Task<IActionResult> PutFiscales(int id, Empleado empleadoItem)
        {
            if (id != empleadoItem.EmpleadoID)
            {
                return BadRequest();
            }

            var empleado = _context.Empleado.Find(id);
            empleado.Umf = empleadoItem.Umf;
            empleado.Imss = empleadoItem.Imss;
            empleado.Id_contrato = empleadoItem.Id_contrato;
            empleado.Dias_contrato = empleadoItem.Dias_contrato;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleadoItem(int id)
        {
            var todoItem = await _context.Empleado.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Empleado.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFile([FromForm]FileInputModel std)
        {
            // Getting Name
            var id = std.EmpleadoID;
            // Getting Image
            var image = std.Photo;
            // Saving Image on Server
            var path = Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\marti\\OneDrive\\Escritorio\\paginas\\ConsumoApiBellaUnion\\src\\images\\imagenes_perfil", id + "_" + image.FileName);

            var empleado = _context.Empleado.Find(id);

            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                    empleado.Photo = id + "_" + image.FileName;
                    await _context.SaveChangesAsync();
                }
            }
            return Ok(new { status = true, message = "Student Posted Successfully" });
        }
        //public async Task<IActionResult> UploadFile([FromForm]FileInputModel std)
        //{
        //    if (photo == null || photo.Length == 0)
        //        return Content("file not selected");

        //    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", 1 + photo.FileName);

        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await photo.CopyToAsync(stream);

        //        var empleado = _context.Empleado.Find(id);
        //        empleado.Nombre = photo.FileName;

        //        await _context.SaveChangesAsync();
        //    }

        //    return NoContent();
        //}

        //public IActionResult Save(IFormFile photo)
        //{
        //    if (photo == null || photo.Length == 0)
        //    {
        //        return Content("File not selected");
        //    }
        //    else
        //    {
        //        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.FileName);
        //        var stream = new FileStream(path, FileMode.Create);
        //        photo.CopyToAsync(stream);
        //    }
        //    return Ok();
        //}
    }
}