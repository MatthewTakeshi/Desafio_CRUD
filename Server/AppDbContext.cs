using Desafio_CRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace Desafio_CRUD.Server
{
     public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Modelo_Produto> Produtos { get; set; }
    }
}