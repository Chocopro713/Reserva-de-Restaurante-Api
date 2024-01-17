namespace Application.Interfaces
{
    using Core.Entities;

    public interface IGestionRestaurante
    {
        Task<IEnumerable<Restaurante>> ObtenerTodosAsync();
        Task<Restaurante> ObtenerPorIdAsync(Guid id);
        Task CrearAsync(Restaurante restaurante);
        Task ActualizarAsync(Restaurante restaurante);
        Task EliminarAsync(Guid id);
    }
}
