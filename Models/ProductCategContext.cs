using Microsoft.EntityFrameworkCore;

namespace ExamenAPIRestFul.Models
{
    public class ProductCategContext: DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ETHPHOS; Database=CodigoApiRest; Integrated Security=True; Trust Server Certificate=True");
        }

    }
}
