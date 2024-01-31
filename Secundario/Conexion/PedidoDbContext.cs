using Microsoft.EntityFrameworkCore;
using Principal.Models;
using Secundario.Models;

namespace Secundario.Conexion
{
    public class PedidoDbContext :DbContext
    {
        public DbSet<Plato> platos { get; set; }
        public DbSet<Detalle> detalles { get; set; }
        public PedidoDbContext(DbContextOptions<PedidoDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plato>().HasMany(p => p.detalles).WithOne(d => d.plato!).HasForeignKey(det => det.platoID);
            modelBuilder.Entity<Detalle>().HasOne(dt => dt.plato).WithMany(pl => pl.detalles).HasForeignKey(dd => dd.platoID);
        }
    }
}
