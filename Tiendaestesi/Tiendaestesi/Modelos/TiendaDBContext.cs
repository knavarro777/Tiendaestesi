using Microsoft.EntityFrameworkCore;

namespace Tiendaestesi.Modelos
{
    public class TiendaDBContext : DbContext
    {
        public TiendaDBContext(DbContextOptions<TiendaDBContext> options) : base(options)
        {
        }
        public DbSet<Disco> Discos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }

    }
    
}
