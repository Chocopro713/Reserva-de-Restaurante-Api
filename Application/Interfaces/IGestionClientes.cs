namespace Application.Interfaces
{
    using Core.Entities;

    public interface IGestionClientes
    {
        Task<Cliente> ObtenerClientePorId(Guid clienteId);
        Task<IEnumerable<Cliente>> ObtenerTodosClientes();
        Task RegistrarCliente(string nombre, string correoElectronico);
        Task ActualizarInformacionCliente(Guid clienteId, string nuevoNombre, string nuevoCorreo);
        Task EliminarCliente(Guid clienteId);
    }
}
