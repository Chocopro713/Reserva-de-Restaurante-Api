namespace RestaurantReservationsApi.Controllers.Clientes
{
    using Application.Interfaces;
    using Core.Entities;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IGestionClientes _gestionClientes;

        public ClientesController(IGestionClientes gestionClientes)
        {
            _gestionClientes = gestionClientes;
        }

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> ObtenerClientePorId(Guid clienteId)
        {
            var cliente = await _gestionClientes.ObtenerClientePorId(clienteId);

            if (cliente == null)
            {
                return NotFound(); // Cliente no encontrado
            }

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodosClientes()
        {
            var clientes = await _gestionClientes.ObtenerTodosClientes();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCliente([FromBody] Cliente clienteDTO)
        {
            await _gestionClientes.RegistrarCliente(clienteDTO.Nombre, clienteDTO.CorreoElectronico);

            return CreatedAtAction(nameof(ObtenerClientePorId), new { clienteId = clienteDTO.Id }, clienteDTO);
        }

        [HttpPut("{clienteId}")]
        public async Task<IActionResult> ActualizarInformacionCliente(Guid clienteId, [FromBody] Cliente clienteDTO)
        {
            await _gestionClientes.ActualizarInformacionCliente(clienteId, clienteDTO.Nombre, clienteDTO.CorreoElectronico);

            return NoContent();
        }

        [HttpDelete("{clienteId}")]
        public async Task<IActionResult> EliminarCliente(Guid clienteId)
        {
            await _gestionClientes.EliminarCliente(clienteId);

            return NoContent();
        }
    }
}
