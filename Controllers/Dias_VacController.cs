using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_BU.Data;
using API_BU.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace API_BU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Dias_VacController : Controller  

    {
        private readonly DepPuestoContexto _context;
        public Dias_VacController(DepPuestoContexto contexto)
        {
            _context = contexto;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dias_Vac>>> Get()
        {
            return await _context.Dias_Vac.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dias_Vac>> GetTodoItem(int id)
        {
            var todoItem = await _context.Dias_Vac.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        [HttpGet("anio/{anio}")]
        public async Task<ActionResult<Dias_Vac>> Get(int anio)
        {
            var todoItem = await _context.Dias_Vac.FindAsync(anio);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpGet("d/{ini}/{fin}")]
        public async Task<ActionResult<Dias_Vac>> GetAniosItem(int ini,int fin)
        {
            var anios = (from a in _context.Dias_Vac
                         where (a.Inicio <=ini) && (fin <= a.Fin)

                         select new
                      {
                          anios = a

                      }).FirstOrDefault();
            if (anios == null)
            {
                return NotFound();
            }

            return Ok(anios);
        }
    }
}