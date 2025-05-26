using Tiendaestesi.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tiendaestesi.Repositorio
{
    public interface IRepositorioClientes
    {
        Task<List<Cliente>> GetAll();
        Task<Cliente?> Get(int id);
        Task<Cliente> Add(Cliente cliente);
        Task Update(int id, Cliente cliente);
        Task Delete(int id);
    }
}