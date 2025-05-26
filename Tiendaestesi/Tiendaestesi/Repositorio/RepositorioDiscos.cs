using Microsoft.EntityFrameworkCore;
using Tiendaestesi.Modelos;

namespace Tiendaestesi.Repositorio
{
    public class RepositorioDiscos : IRepositorioDiscos
    {
        private readonly TiendaDBContext _context;

        public RepositorioDiscos(TiendaDBContext context)
        {
            _context = context;
        }
        public async Task<Disco> Add(Disco disco)
        {
            await _context.Discos.AddAsync(disco);
            await _context.SaveChangesAsync();
            return disco;
        }
        public async Task Delete(int id)
        {
            var disco = await _context.Discos.FindAsync(id);
            if (disco != null)
            {
                _context.Discos.Remove(disco);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Disco?> Get(int id)
        {
            return await _context.Discos.FindAsync(id);
        }
        public async Task<List<Disco>> GetAll()
        {
            return await _context.Discos.ToListAsync();
        }
        public async Task Update(int id, Disco disco)
        {
            var discoExistente = await _context.Discos.FindAsync(id);
            if (discoExistente != null)
            {
                discoExistente.Titulo = disco.Titulo;
                discoExistente.Artista = disco.Artista;
                discoExistente.Genero = disco.Genero;
                discoExistente.An_Lanzamiento = disco.An_Lanzamiento;
                discoExistente.Precio = disco.Precio;
                discoExistente.Stock = disco.Stock;
                discoExistente.Condicion = disco.Condicion;

                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Disco>> BuscarPorFiltros(FiltroDiscos filtros)
        {
            var query = _context.Discos.AsQueryable();

            if (!string.IsNullOrEmpty(filtros.Genero))
            {
                query = query.Where(d => d.Genero.Contains(filtros.Genero));
            }

            if (!string.IsNullOrEmpty(filtros.Artista))
            {
                query = query.Where(d => d.Artista.Contains(filtros.Artista));
            }

            if (!string.IsNullOrEmpty(filtros.Condicion))
            {
                query = query.Where(d => d.Condicion == filtros.Condicion);
            }

            return await query.ToListAsync();
        }

    }
}

