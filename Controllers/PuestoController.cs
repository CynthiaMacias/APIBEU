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
    [Produces("application/json")]
    [Route("api/Departamento/{id_depto}/Puesto/")]
    [ApiController]
    public class PuestosController : Controller
    {
        private readonly DepPuestoContexto context;

        public PuestosController(DepPuestoContexto context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Puesto> GetAll(int id_depto)
        {
            return context.Puesto.Where(x => x.id_depto == id_depto).ToList();
        }
        [HttpGet("Puesto/{id}")]
        public IEnumerable<Puesto> GetPuesto(int id)
        {
            return context.Puesto.Where(x => x.Id == id).ToList();
        }

        [HttpGet("{id}", Name = "Id")]
        public IActionResult GetById(int id)
        {
            var dep = context.Puesto.FirstOrDefault(x => x.Id == id);
            ////var dep = (from a in context.Puesto
            ////join b in context.Departamento
            ////on a.id_depto equals b.Id
            ////where a.id_depto.Equals(id)
            ////select new
            ////{
            ////    Departamento = a
            ////    //Empresa = b
            ////});
            if (dep == null)
            {
                return NotFound();
            }

            return Ok(dep);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Puesto puesto, int puestoId)
        {
            puesto.Id = puestoId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Puesto.Add(puesto);
            context.SaveChanges();
            return Ok(puesto);
            //return new CreatedAtRouteResult("Id", new { id = puesto.Id }, puesto);
        }

        //[HttpPost]
        //public async Task<ActionResult<Departamento>> PostEmpleadoItem(Puesto puesto)
        //{
        //    context.Puesto.Add(puesto);
        //    await context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(Puesto), new { id = puesto.Id }, puesto);
        //}


        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            var provincia = context.Puesto.FirstOrDefault(x => x.Id == id);

            if (provincia == null)
            {
                return NotFound();
            }

            context.Puesto.Remove(provincia);
            context.SaveChanges();
            return Ok(provincia);
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Puesto puest, int id)
        {

            if (puest.Id != id)
            {
                return BadRequest();
            }
            context.Entry(puest).State = EntityState.Modified;
            context.SaveChanges();
            return Ok(puest);
        }
        [HttpGet("pd/{Nombre}")]
        public IActionResult getSearch(string nombre)
        {
            var result = (from pues in context.Puesto
                          where pues.Nombre.StartsWith(nombre)

                          select new
                          {
                              result = pues
                          });

            if (result == null)
            {
                return NotFound();

            }
            return Ok(result);
        }
    }
}