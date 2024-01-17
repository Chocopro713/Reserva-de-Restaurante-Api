namespace Core.ValueObjects
{
    public class FechaHoraReserva
    {
        public DateTime Fecha { get; }
        public TimeSpan Hora { get; }

        public FechaHoraReserva(DateTime fecha, TimeSpan hora)
        {
            Fecha = fecha;
            Hora = hora;
        }
        // Puedes incluir métodos adicionales según sea necesario
    }
}
