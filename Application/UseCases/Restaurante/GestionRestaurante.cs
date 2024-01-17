namespace Application.UseCases.Restaurante
{
    using Application.Interfaces;
    using Core.Interfaces;
    using Core.Entities;

    public class GestionRestaurante : IGestionRestaurante
    {
        private readonly IRestauranteRepository _restauranteRepository;

        public GestionRestaurante(IRestauranteRepository restauranteRepository)
        {
            _restauranteRepository = restauranteRepository;
        }

        public async Task<IEnumerable<Restaurante>> ObtenerTodosAsync()
        {
            return await _restauranteRepository.ObtenerTodosAsync();
        }

        public async Task<Restaurante> ObtenerPorIdAsync(Guid id)
        {
            return await _restauranteRepository.ObtenerPorIdAsync(id);
        }

        public async Task CrearAsync(Restaurante restaurante)
        {
            await _restauranteRepository.CrearAsync(restaurante);
        }

        public async Task ActualizarAsync(Restaurante restaurante)
        {
            await _restauranteRepository.ActualizarAsync(restaurante);
        }

        public async Task EliminarAsync(Guid id)
        {
            await _restauranteRepository.EliminarAsync(id);
        }
    }
}
