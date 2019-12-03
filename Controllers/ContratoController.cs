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

    public class ContratoController : Controller
    {

        private readonly DepPuestoContexto _context;
        public ContratoController(DepPuestoContexto contexto)
        {
            _context = contexto;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContrato()
        {
            return await _context.Contrato.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contrato>> GetTodoItem(int id)
        {
            var todoItem = await _context.Contrato.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public IActionResult AddContrato([FromBody] Contrato contratos)
        {

            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            this._context.Contrato.Add(contratos);
            this._context.SaveChanges();

            //return new CreatedAtRouteResult("id", new { id = contrato.Id }, contrato);
            return Ok(contratos);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Put([FromBody] Contrato con, int id)
        {

            if (con.Id != id)
            {
                return BadRequest();
            }
            _context.Entry(con).State = EntityState.Modified;
            _context.SaveChanges();
            await _context.SaveChangesAsync();

            return Ok(con);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthors(int id)
        {
            var target = _context.Contrato.FirstOrDefault(ct => ct.Id == id);
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.Contrato.Remove(target);
                _context.SaveChanges();
                return Ok(target);
            }
        }
        [HttpGet("con/{Nombre}")]
        public IActionResult getNom (string nombre)
        {
            var result = (from cont in _context.Contrato
                          where cont.Nombre.StartsWith(nombre)

                          select new
                          {
                              result = cont
                          });
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}