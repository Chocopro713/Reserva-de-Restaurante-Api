using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys
{
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly ApplicationDbContext _context;

        public RestauranteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurante>> ObtenerTodosAsync()
        {
            return await _context.Restaurantes.ToListAsync();
        }

        public async Task<Restaurante> ObtenerPorIdAsync(Guid id)
        {
            return await _context.Restaurantes.FindAsync(id);
        }

        public async Task CrearAsync(Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Restaurante restaurante)
        {
            _context.Entry(restaurante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(Guid id)
        {
            var restaurante = await _context.Restaurantes.FindAsync(id);
            if (restaurante != null)
            {
                _context.Restaurantes.Remove(restaurante);
                await _context.SaveChangesAsync();
            }
        }
    }
}
