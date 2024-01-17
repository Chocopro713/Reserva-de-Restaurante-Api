namespace Application.Interfaces
{
    using Core.Entities;

    public interface IGestionReservas
    {
        Task<Reserva> ObtenerReservaPorId(Guid reservaId);
        Task<IEnumerable<Reserva>> ObtenerTodasReservas();
        Task RealizarReserva(DateTime fechaHora, int numeroPersonas, Guid restauranteId, Guid clienteId);
        Task ModificarReserva(Guid reservaId, DateTime nuevaFechaHora, int nuevoNumeroPersonas);
        Task CancelarReserva(Guid reservaId);
    }
}
