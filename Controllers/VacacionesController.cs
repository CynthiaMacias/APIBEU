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
    public class VacacionesController : ControllerBase
    {

        private readonly DepPuestoContexto _context;
        public VacacionesController(DepPuestoContexto contexto)
        {
            _context = contexto;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacaciones>>> GetVac()
        {
            return await _context.Vacaciones.ToListAsync();
        }
        [HttpGet("{id}")]
        public IActionResult GetVac(int id)
        {
            //var item = await _context.Empleados.FindAsync(id);
            var data = (from a in _context.Vacaciones
                        join b in _context.Empleado
                        on a.Id_emp equals b.EmpleadoID
                        where a.Id_emp.Equals(id)
                        orderby a.Id_vac descending
                        select new
                        {
                            dias = a
                           
                        }).FirstOrDefault();

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }     
      
        private static readonly IList<Pr_vac> _games = new List<Pr_vac>();
        [HttpPost]
        public async Task<IActionResult> AddVac([FromBody] Vacaciones vac)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return BadRequest();

                }
                int id = vac.Id_vac;
                var game = new Pr_vac(id);
                _games.Add(game);
             

                foreach (var item in vac.Arr)
                {
                
                    _context.Pr_vac.Add(item);

                }

                this._context.Vacaciones.Add(vac);
                
                this._context.SaveChanges();

                foreach (var i in vac.Arr)
                {
                    i.Id_vac = vac.Id_vac;

                }
                _context.Entry(vac).State = EntityState.Modified;
                _context.SaveChanges();
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            return Ok(vac);

        }
        //[HttpPost("Partidas/")]
        //public async Task<IActionResult> AddPvac([FromBody] Vacaciones vac)
        //{
        //    try
        //    {
        //        //if (!this.ModelState.IsValid)
        //        //{
        //        //    return BadRequest();

        //        //}
        //        int id = vac.Id;
        //        var game = new Pr_vac(id);
        //        _games.Add(game);

        //        foreach (var item in vac.Arr)
        //        {
        //            item.Id_vac = id;
        //            _context.Pr_vac.Add(item);

        //        }
        //        this._context.Vacaciones.Add(vac);
        //        this._context.SaveChanges();

        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Write(ex.ToString());
        //    }

        //    return Ok(vac);

        //}
        [HttpGet("Vac/{id}")]
        public async Task<ActionResult<Vacaciones>> GetVacId(int id)
        {
            var data = (from a in _context.Vacaciones
                        join b in _context.Empleado
                        on a.Id_emp equals b.EmpleadoID
                        where a.Id_emp.Equals(id)
                        orderby a.Id_vac ascending
                        select new
                        {
                            dias = a

                        });

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
        [HttpGet("v/{Nombre}")]
        public IActionResult GetSearch(string nombre)
        {


            var result = (from emp in _context.Empleado
                          where emp.Nombre.StartsWith(nombre)
                          select new
                          {
                              result = emp

                          });
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


    }
}