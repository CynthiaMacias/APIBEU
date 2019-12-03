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
    public class EmpresaController : ControllerBase
    {
        private readonly DepPuestoContexto _context;

        public EmpresaController(DepPuestoContexto contexto)
        {
            _context = contexto;
        }

        // GET: api/Empresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            return await _context.Empresas.ToListAsync();
        }

        // GET: api/Empresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
            var item = await _context.Empresas.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST: api/Empresa
        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresaItem(Empresa item)
        {
            _context.Empresas.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpresas), new { id = item.EmpresaID }, item);
        }

        // PUT: api/Empresa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa(long id, Empresa empresaItem)
        {
            if (id != empresaItem.EmpresaID)
            {
                return BadRequest();
            }

            _context.Entry(empresaItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresaItem(int id)
        {
            var todoItem = await _context.Empresas.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost("uploadLogo")]
        public async Task<IActionResult> UploadFile([FromForm] FileEMpresaLogo std)
        {
            // Getting Name
            var id = std.EmpresaID;
            // Getting Image
            var image = std.Photo;
            // Saving Image on Server
            var path = Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\marti\\OneDrive\\Escritorio\\paginas\\ConsumoApiBellaUnion\\src\\images\\imagenes_empresa", id + "_" + image.FileName);

            var empresa = _context.Empresas.Find(id);

            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                    empresa.Logo_empresa = id + "_" + image.FileName;
                    await _context.SaveChangesAsync();
                }
            }
            return Ok(new { status = true, message = "Student Posted Successfully" });
        }
    }
}