namespace Application.UseCases.Cliente
{
    using Application.Interfaces;
    using Core.Interfaces;
    using Core.Entities;
    public class GestionClientes : IGestionClientes
    {
        private readonly IClienteRepository _clienteRepository;

        public GestionClientes(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> ObtenerClientePorId(Guid clienteId)
        {
            return await _clienteRepository.ObtenerPorIdAsync(clienteId);
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodosClientes()
        {
            return await _clienteRepository.ObtenerTodosAsync();
        }

        public async Task RegistrarCliente(string nombre, string correoElectronico)
        {
            var nuevoCliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nombre = nombre,
                CorreoElectronico = correoElectronico
            };

            await _clienteRepository.AgregarClienteAsync(nuevoCliente);
        }

        public async Task ActualizarInformacionCliente(Guid clienteId, string nuevoNombre, string nuevoCorreo)
        {
            var cliente = await _clienteRepository.ObtenerPorIdAsync(clienteId);

            if (cliente != null)
            {
                cliente.Nombre = nuevoNombre;
                cliente.CorreoElectronico = nuevoCorreo;

                await _clienteRepository.ActualizarClienteAsync(cliente);
            }
        }

        public async Task EliminarCliente(Guid clienteId)
        {
            await _clienteRepository.EliminarClienteAsync(clienteId);
        }
    }
}
