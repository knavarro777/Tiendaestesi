using Microsoft.EntityFrameworkCore;
using Tiendaestesi.Modelos;

namespace Tiendaestesi.Repositorio
{
    public class RepositorioVentas : IRepositorioVentas
    {
        private readonly TiendaDBContext _context;

        public RepositorioVentas(TiendaDBContext context)
        {
            _context = context;
        }

        public async Task<Venta> Add(Venta venta)
        {
            // Validación básica antes de agregar
            if (venta.Cantidad <= 0 || venta.Total <= 0)
            {
                throw new ArgumentException("Cantidad y Total deben ser mayores a cero");
            }

            await _context.Ventas.AddAsync(venta);
            await _context.SaveChangesAsync();
            return venta;
        }

        public async Task Delete(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Venta?> Get(int id)
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Disco)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<Venta>> GetAll()
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Disco)
                .ToListAsync();
        }

        public async Task Update(int id, Venta venta)
        {
            var ventaExistente = await _context.Ventas.FindAsync(id);
            if (ventaExistente != null)
            {
                // Validación básica antes de actualizar
                if (venta.Cantidad <= 0 || venta.Total <= 0)
                {
                    throw new ArgumentException("Cantidad y Total deben ser mayores a cero");
                }

                ventaExistente.ClienteId = venta.ClienteId;
                ventaExistente.DiscoId = venta.DiscoId;
                ventaExistente.FechaVenta = venta.FechaVenta;
                ventaExistente.Cantidad = venta.Cantidad;
                ventaExistente.Total = venta.Total;
                ventaExistente.MetodoPago = venta.MetodoPago;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Venta>> GetByCliente(int clienteId)
        {
            return await _context.Ventas
                .Where(v => v.ClienteId == clienteId)
                .Include(v => v.Disco)
                .ToListAsync();
        }

        public async Task<List<Venta>> GetByDisco(int discoId)
        {
            return await _context.Ventas
                .Where(v => v.DiscoId == discoId)
                .Include(v => v.Cliente)
                .ToListAsync();
        }
    }
}