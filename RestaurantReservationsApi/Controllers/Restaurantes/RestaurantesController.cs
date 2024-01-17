namespace RestaurantReservationsApi.Controllers.Restaurantes
{
    using Application.Interfaces;
    using Core.Entities;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly IGestionRestaurante _gestionRestaurante;

        public RestaurantesController(IGestionRestaurante restauranteService)
        {
            _gestionRestaurante = restauranteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurante>>> ObtenerTodos()
        {
            var restaurantes = await _gestionRestaurante.ObtenerTodosAsync();
            return Ok(restaurantes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurante>> ObtenerPorId(Guid id)
        {
            var restaurante = await _gestionRestaurante.ObtenerPorIdAsync(id);
            if (restaurante == null)
            {
                return NotFound();
            }
            return Ok(restaurante);
        }

        [HttpPost]
        public async Task<ActionResult> Crear([FromBody] Restaurante restaurante)
        {
            await _gestionRestaurante.CrearAsync(restaurante);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = restaurante.Id }, restaurante);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(Guid id, [FromBody] Restaurante restaurante)
        {
            if (id != restaurante.Id)
            {
                return BadRequest();
            }

            await _gestionRestaurante.ActualizarAsync(restaurante);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(Guid id)
        {
            await _gestionRestaurante.EliminarAsync(id);
            return NoContent();
        }
    }
}
