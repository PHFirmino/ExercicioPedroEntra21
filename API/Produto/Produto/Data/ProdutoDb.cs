using Microsoft.EntityFrameworkCore;
using Produto.Entities;

namespace Produto.Data
{
    public class ProdutoDb : DbContext
    {
        public ProdutoDb(DbContextOptions<ProdutoDb> options) : base(options)
        {
        }

        public DbSet<Produtos> Produtos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<User> Users { get; set; }
    }
}
