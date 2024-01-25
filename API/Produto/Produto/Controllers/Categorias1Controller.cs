using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Produto.Data;
using Produto.Entities;

namespace Produto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Categorias1Controller : ControllerBase
    {
        private readonly ProdutoDb _context;

        public Categorias1Controller(ProdutoDb context)
        {
            _context = context;
        }

        // GET: api/Categorias1
        [HttpGet]
        [Authorize(Roles = "admin,gerente,funcionario")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        // GET: api/Categorias1/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,gerente,funcionario")]
        public async Task<ActionResult<Categoria>> GetCategoria(long id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("editar/{id}")]
        [Authorize(Roles = "gerente,admin")]
        public async Task<IActionResult> PutCategoria(long id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categorias1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin,funcionario")]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
        }

        // DELETE: api/Categorias1/5
        [HttpDelete("deletar/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCategoria(long id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(long id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
