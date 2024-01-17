using Application.Interfaces;
using Application.UseCases.Cliente;
using Application.UseCases.Reserva;
using Application.UseCases.Restaurante;
using Core.Interfaces;
using Infrastructure.Repositorys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Infrastructure.ApplicationDbContext>();

// Configuración de la base de datos y otras dependencias
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IRestauranteRepository, RestauranteRepository>();

// Agregar servicios de la capa Application
builder.Services.AddScoped<IGestionClientes, GestionClientes>();
builder.Services.AddScoped<IGestionReservas, GestionReservas>();
builder.Services.AddScoped<IGestionRestaurante, GestionRestaurante>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
