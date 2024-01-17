namespace Infrastructure
{
    using Core.Entities;
    using Microsoft.EntityFrameworkCore;
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de otras entidades...

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Restaurante)
                .WithMany()
                .HasForeignKey(r => r.RestauranteId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // optionsBuilder.UseSqlServer("Server=PTTEC24BOG\\SQLEXPRESS;Database=RestaurantReservationsdb;Trusted_Connection=true;TrustServerCertificate=true;");
            optionsBuilder.UseSqlServer("Server=PTTEC24BOG\\SQLEXPRESS;Database=RestaurantReservationsdb;Trusted_Connection=true;TrustServerCertificate=true;",
                b => b.MigrationsAssembly("RestaurantReservationsApi"));
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
    }
}
