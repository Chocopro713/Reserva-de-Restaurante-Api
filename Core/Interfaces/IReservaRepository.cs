namespace Core.Interfaces
{
    using Core.Entities;
    public interface IReservaRepository
    {
        Task<Reserva> ObtenerPorIdAsync(Guid reservaId);
        Task<IEnumerable<Reserva>> ObtenerTodosAsync();
        Task AgregarReservaAsync(Reserva reserva);
        Task ActualizarReservaAsync(Reserva reserva);
        Task EliminarReservaAsync(Guid reservaId);
    }
}
