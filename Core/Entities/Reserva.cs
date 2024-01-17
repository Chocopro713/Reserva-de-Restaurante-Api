using Core.ValueObjects;

namespace Core.Entities
{
    public class Reserva
    {
        public Guid Id { get; set; }
        public DateTime FechaHora { get; set; }
        public int NumeroPersonas { get; set; }

        public Guid RestauranteId { get; set; }  // Relación con el restaurante
        public Restaurante Restaurante { get; set; }

        public Guid ClienteId { get; set; }      // Relación con el cliente
        public Cliente Cliente { get; set; }
    }
}
