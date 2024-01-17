namespace Core.Aggregates
{
    using Core.Entities;
    using Core.ValueObjects;

    public class AgregadoReserva
    {
        public Reserva Reserva { get; private set; }
        // Otros objetos relacionados, como la entidad Restaurante si es necesario

        public AgregadoReserva(Reserva reserva)
        {
            // Puedes realizar validaciones adicionales aquí
            Reserva = reserva;
        }

        // Métodos para realizar operaciones relacionadas con la reserva
        public void CambiarFechaHora(FechaHoraReserva nuevaFechaHora)
        {
            // Lógica para cambiar la fecha y hora de la reserva
            Reserva.FechaHora = nuevaFechaHora.Fecha + nuevaFechaHora.Hora;
        }
    }
}
