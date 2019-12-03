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
namespace API_BU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgHorarioController : ControllerBase
    {
        private readonly DepPuestoContexto _context;
        public ProgHorarioController(DepPuestoContexto contexto)
        {
            _context = contexto;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgHorario>>> GetProg()
        {
            return await _context.ProgHorario.ToListAsync();
        }
        [HttpPost]
       
        public IActionResult Create([FromBody] ProgHorario pr, int id)
        {
            pr.Id = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProgHorario.Add(pr);
            _context.SaveChanges();
            return Ok(pr);
            //return new CreatedAtRouteResult("Id", new { id = puesto.Id }, puesto);
        }

        [HttpGet("{id}/{semana}")]
        public IActionResult GetByIdph(int id,int semana)
        {
            //var ph = _context.ProgHorario.FirstOrDefault(x => x.Id_emp == id); 
            var ph = (from a in _context.ProgHorario
                       join b in _context.Empleado
                       on a.Id_emp equals b.EmpleadoID
                       where a.Id_emp.Equals(id) && a.semana.Equals(semana)
                       orderby a.Id descending
                      select new
                       {
                           ph = a
                          
                       }).FirstOrDefault();
 
            if (ph == null)
            {
                return NotFound();
            }
            return Ok(ph);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdphr(int id)
        {

            //var ph = _context.ProgHorario.FirstOrDefault(x => x.Id_emp == id); 
            var ph = (from a in _context.ProgHorario
                      join b in _context.Empleado
                      on a.Id_emp equals b.EmpleadoID
                      where a.Id_emp.Equals(id)

                      select new
                      {
                          ph = a

                      });
            if (ph == null)
            {
                return NotFound();
            }

            return Ok(ph);
        }
        [HttpGet("pr/{Nombre}")]
        public IActionResult GetBynomlike(string nombre)
        {


            var result = (from ed in _context.Empleado
                          where ed.Nombre.StartsWith(nombre)


                          select new
                          {
                              result = ed

                          });
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProg(int id)
        {
           _context.ProgHorario.Where(p => p.Id_emp == id)
               .ToList().ForEach(p => _context.ProgHorario.Remove(p));
            _context.SaveChanges();
            return Ok();
        }
    

    }
}