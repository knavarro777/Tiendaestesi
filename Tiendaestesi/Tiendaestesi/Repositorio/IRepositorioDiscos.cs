using Tiendaestesi.Modelos;

namespace Tiendaestesi.Repositorio
{
    public interface IRepositorioDiscos
    {
        Task<List<Disco>> GetAll();
        Task<Disco?> Get(int id);
        Task<Disco> Add(Disco disco);
        Task Update(int id, Disco disco);
        Task Delete(int id);
        Task<List<Disco>> BuscarPorFiltros(FiltroDiscos filtros);
    }
    public class FiltroDiscos
    {
        public string? Genero { get; set; }
        public string? Artista { get; set; }
        public string? Condicion { get; set; }
        public int? AnioMin { get; set; }
        public int? AnioMax { get; set; }
    }
}
