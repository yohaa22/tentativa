using Microsoft.EntityFrameworkCore;
using LojaAPI.Models;

namespace LojaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servico>()
                .Property(s => s.Preco)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Contrato>()
                .Property(c => c.PrecoCobrado)
                .HasColumnType("decimal(10,2)");
        }
    }
}
