namespace Core.ValueObjects
{
    public class NumeroPersonas
    {
        public int Valor { get; }

        public NumeroPersonas(int valor)
        {
            if (valor <= 0)
            {
                // Puedes agregar validaciones según tus requisitos
                throw new ArgumentException("El número de personas debe ser mayor que cero.");
            }

            Valor = valor;
        }
        // Puedes incluir métodos adicionales según sea necesario
    }
}
