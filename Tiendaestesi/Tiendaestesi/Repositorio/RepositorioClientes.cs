using Microsoft.EntityFrameworkCore;
using Tiendaestesi.Modelos;
using System;
using System.Threading.Tasks;

namespace Tiendaestesi.Repositorio
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly TiendaDBContext _contexto;

        public RepositorioClientes(TiendaDBContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _contexto.Clientes.ToListAsync();
        }

        public async Task<Cliente?> Get(int id)
        {
            return await _contexto.Clientes.FindAsync(id);
        }

        public async Task<Cliente> Add(Cliente cliente)
        {
            if (!ValidarCliente(cliente))
                throw new ArgumentException("Datos del cliente no válidos.");

            _contexto.Clientes.Add(cliente);
            await _contexto.SaveChangesAsync();
            return cliente;
        }

        public async Task Update(int id, Cliente cliente)
        {
            if (id != cliente.Id)
                throw new ArgumentException("IDs no coinciden");

            if (!ValidarCliente(cliente))
                throw new ArgumentException("Datos del cliente no válidos.");

            _contexto.Entry(cliente).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _contexto.Clientes.Remove(cliente);
                await _contexto.SaveChangesAsync();
            }
        }

        private bool ValidarCliente(Cliente cliente)
        {
            // Validación adicional personalizada
            return cliente.FechaVenta <= DateTime.Now; // Ejemplo: fecha no futura
        }
    }
}