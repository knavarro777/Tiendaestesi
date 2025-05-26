using Tiendaestesi.Modelos;

namespace Tiendaestesi.Repositorio
{
    public interface IRepositorioVentas
    {
        Task<List<Venta>> GetAll();
        Task<Venta?> Get(int id);
        Task<Venta> Add(Venta venta);
        Task Update(int id, Venta venta);
        Task Delete(int id);
        Task<List<Venta>> GetByCliente(int clienteId);
        Task<List<Venta>> GetByDisco(int discoId);
    }
}
