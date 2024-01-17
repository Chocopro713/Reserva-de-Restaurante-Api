namespace RestaurantReservationsApi.Controllers.Reservas
{
    using Application.Interfaces;
    using Core.Entities;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly IGestionReservas _gestionReservas;

        public ReservasController(IGestionReservas gestionReservas)
        {
            _gestionReservas = gestionReservas;
        }

        [HttpGet("{reservaId}")]
        public async Task<IActionResult> ObtenerReservaPorId(Guid reservaId)
        {
            var reserva = await _gestionReservas.ObtenerReservaPorId(reservaId);

            if (reserva == null)
            {
                return NotFound(); // Reserva no encontrada
            }

            return Ok(reserva);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodasReservas()
        {
            var reservas = await _gestionReservas.ObtenerTodasReservas();
            return Ok(reservas);
        }

        [HttpPost]
        public async Task<IActionResult> RealizarReserva([FromBody] Reserva reservaDTO)
        {
            await _gestionReservas.RealizarReserva(reservaDTO.FechaHora, reservaDTO.NumeroPersonas, reservaDTO.RestauranteId, reservaDTO.ClienteId);

            // Puedes devolver la reserva recién creada o simplemente un código 201 Created
            return StatusCode(201);
        }

        [HttpPut("{reservaId}")]
        public async Task<IActionResult> ModificarReserva(Guid reservaId, [FromBody] Reserva reservaDTO)
        {
            await _gestionReservas.ModificarReserva(reservaId, reservaDTO.FechaHora, reservaDTO.NumeroPersonas);

            return NoContent();
        }

        [HttpDelete("{reservaId}")]
        public async Task<IActionResult> CancelarReserva(Guid reservaId)
        {
            await _gestionReservas.CancelarReserva(reservaId);

            return NoContent();
        }
    }
}
