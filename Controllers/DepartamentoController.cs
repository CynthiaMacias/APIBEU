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
    public class DepartamentoController : ControllerBase
    {
        private readonly DepPuestoContexto _context;
        public DepartamentoController(DepPuestoContexto contexto)
        {
            _context = contexto;
        }

        public async Task<ActionResult<IEnumerable<Departamento>>> GetAll()
        {
            return await _context.Departamento.ToListAsync();
        }
        [HttpGet("{id}", Name = "DepCreado")]
        public IActionResult GetById(int id)
        {
            var dep = _context.Departamento.Include(x => x.Puesto).FirstOrDefault(x => x.Id == id);

            if (dep == null)
            {
                return NotFound();
            }

            return Ok(dep);
        }

        [HttpPost]
        //[ResponseType(typeof(info))]
        public IActionResult Post(Departamento info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(info);
            _context.SaveChanges();
            //return Ok();
            // return CreatedAtRoute("DepCreado", new { id = info.Id });
            //return CreatedAtRoute("GetAll", new { id = info.Id }, info);
            return Ok(info);
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Departamento dep, int id)
        {

            if (dep.Id != id)
            {
                return BadRequest();
            }
            _context.Entry(dep).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(dep);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dep = _context.Departamento.FirstOrDefault(x => x.Id == id);
            if (dep == null)
            {
                return NotFound();
            }
            _context.Departamento.Remove(dep);
            _context.SaveChanges();
            return Ok(dep);
        }
        [HttpGet("dep/{Nombre}")]
        public IActionResult getsearch ( string nombre)
        {
            var result = (from depn in _context.Departamento
                          where depn.Nombre.StartsWith(nombre)

                          select new
                          {
                               result=depn
                          });
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}