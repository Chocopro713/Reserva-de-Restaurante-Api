namespace Infrastructure
{
    using Core.Interfaces;
    using Infrastructure.Repositorys;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración de la base de datos y otras dependencias

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();

            return services;
        }
    }
}
