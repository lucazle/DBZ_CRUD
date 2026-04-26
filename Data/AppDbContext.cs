using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.Models;

namespace ProjetoDBZ.Data   
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Personagem> DBZ { get; set; }

    }
}

//criando banco de dados chamado dbz que puxa o modelo da pasta models 