using Domain.Entidades;
using Infra_db.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace Infra_db.Context
{
    public class ContextSql : DbContext
    {


        public ContextSql(DbContextOptions<ContextSql> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracao());
            
        }

    }
}
