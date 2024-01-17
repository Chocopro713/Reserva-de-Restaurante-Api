namespace Core.Interfaces
{
    using Core.Entities;
    public interface IClienteRepository
    {
        Task<Cliente> ObtenerPorIdAsync(Guid clienteId);
        Task<IEnumerable<Cliente>> ObtenerTodosAsync();
        Task AgregarClienteAsync(Cliente cliente);
        Task ActualizarClienteAsync(Cliente cliente);
        Task EliminarClienteAsync(Guid clienteId);
    }
}
