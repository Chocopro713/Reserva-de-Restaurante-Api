namespace Application.UseCases.Reserva
{
    using Application.Interfaces;
    using Core.Interfaces;
    using Core.Entities;
    public class GestionReservas : IGestionReservas
    {
        private readonly IReservaRepository _reservaRepository;

        public GestionReservas(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<Reserva> ObtenerReservaPorId(Guid reservaId)
        {
            return await _reservaRepository.ObtenerPorIdAsync(reservaId);
        }

        public async Task<IEnumerable<Reserva>> ObtenerTodasReservas()
        {
            return await _reservaRepository.ObtenerTodosAsync();
        }

        public async Task RealizarReserva(DateTime fechaHora, int numeroPersonas, Guid restauranteId, Guid clienteId)
        {
            var nuevaReserva = new Reserva
            {
                Id = Guid.NewGuid(),
                FechaHora = fechaHora,
                NumeroPersonas = numeroPersonas,
                RestauranteId = restauranteId,
                ClienteId = clienteId
            };

            await _reservaRepository.AgregarReservaAsync(nuevaReserva);
        }

        public async Task ModificarReserva(Guid reservaId, DateTime nuevaFechaHora, int nuevoNumeroPersonas)
        {
            var reserva = await _reservaRepository.ObtenerPorIdAsync(reservaId);

            if (reserva != null)
            {
                reserva.FechaHora = nuevaFechaHora;
                reserva.NumeroPersonas = nuevoNumeroPersonas;

                await _reservaRepository.ActualizarReservaAsync(reserva);
            }
        }

        public async Task CancelarReserva(Guid reservaId)
        {
            await _reservaRepository.EliminarReservaAsync(reservaId);
        }
    }
}
