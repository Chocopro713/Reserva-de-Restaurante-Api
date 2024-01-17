namespace Infrastructure.Repositorys
{
    using Core.Entities;
    using Core.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class ReservaRepository : IReservaRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reserva> ObtenerPorIdAsync(Guid reservaId)
        {
            return await _context.Reservas.FindAsync(reservaId);
        }

        public async Task<IEnumerable<Reserva>> ObtenerTodosAsync()
        {
            return await _context.Reservas.ToListAsync();
        }

        public async Task AgregarReservaAsync(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarReservaAsync(Reserva reserva)
        {
            _context.Entry(reserva).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task EliminarReservaAsync(Guid reservaId)
        {
            var reserva = await _context.Reservas.FindAsync(reservaId);

            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
        }
    }
}
