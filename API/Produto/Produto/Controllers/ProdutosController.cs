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
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoDb _context;

        public ProdutosController(ProdutoDb context)
        {
            _context = context;
        }

        [HttpGet("/api/[controller]/pages")]
        public async Task<ActionResult<IEnumerable<Produtos>>> PageProduto([FromQuery] int skip = 0, [FromQuery] int take = 2)
        {
            List<Produtos> prod = await _context.Produtos.AsNoTracking().Skip(skip * take).Take(take).ToListAsync();

            var categorias = await _context.Categorias.ToListAsync();

            foreach (var itemProduto in prod)
            {
                foreach (var categoria in categorias)
                {
                    if (categoria.Id == itemProduto.Idcategoria)
                    {
                        itemProduto.Categoria = categoria;
                    }
                }
            }

            return prod;
        }
        [HttpGet("/api/[controller]/filtro")]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutosByDescricao([FromQuery] string descricao)
        {
            List<Produtos> lista = await _context.Produtos.ToListAsync();
            var produtos = (from prod in lista where prod.Descricao.ToLower().Contains(descricao.ToLower()) select prod).ToList();

            var categorias = await _context.Categorias.ToListAsync();

            foreach (var itemProduto in produtos)
            {
                foreach (var categoria in categorias)
                {
                    if (categoria.Id == itemProduto.Idcategoria)
                    {
                        itemProduto.Categoria = categoria;
                    }
                }
            }
            return produtos;
        }
        // GET: api/Produtos
        [HttpGet]
        [Authorize(Roles = "admin,gerente,funcionario")]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutos()
        {
            var produtos = await _context.Produtos.ToListAsync();
            var categorias = await _context.Categorias.ToListAsync();

            foreach (var itemProduto in produtos)
            {
                foreach (var categoria in categorias)
                {
                    if (categoria.Id == itemProduto.Idcategoria)
                    {
                        itemProduto.Categoria = categoria;
                    }
                }
            }

            return produtos;
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,gerente,funcionario")]
        public async Task<ActionResult<Produtos>> GetProdutos(long id)
        {
            var produtos = await _context.Produtos.FirstAsync(produto => produto.Id == id);

            if (produtos == null)
            {
                return NotFound();
            }

            var categorias = await _context.Categorias.ToListAsync();


            foreach (var categoria in categorias)
            {
                if (categoria.Id == produtos.Idcategoria)
                {
                    produtos.Categoria = categoria;
                }
            }


            return produtos;
        }

        [HttpGet("/api/[controller]/categoria/{id}")]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutosByCategoria([FromRoute] int id)
        {
            List<Produtos> produtos = await _context.Produtos.ToListAsync();

            var proByCategoria = (from prod in produtos where prod.Idcategoria == id select prod).ToList();

            Categoria categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);

            foreach (Produtos itemProduto in produtos)
            {
                itemProduto.Categoria = categoria;
            }

            return proByCategoria;
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("editar/{id}")]
        [Authorize(Roles = "gerente,admin")]
        public async Task<IActionResult> PutProdutos(long id, Produtos produtos)
        {
            if (id != produtos.Id)
            {
                return BadRequest();
            }

            _context.Entry(produtos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosExists(id))
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

        // POST: api/Produtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin,funcionario")]
        public async Task<ActionResult<Produtos>> PostProdutos(Produtos produtos)
        {
            var categoriaId = await _context.Categorias.FirstOrDefaultAsync(categoria => categoria.Id == produtos.Idcategoria);

            if (categoriaId == null)
            {
                return NoContent();
            }

            await _context.Produtos.AddAsync(produtos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutos", new { id = produtos.Id }, produtos);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("deletar/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteProdutos(long id)
        {
            var produtos = await _context.Produtos.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produtos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutosExists(long id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
