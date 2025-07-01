namespace SegurosSelers.Entidades
{
    public class PolizaViewModel
    {
        public int IdPoliza { get; set; }
        public string NombrePack { get; set; }
        public bool Estado { get; set; } // Este es el booleano que usaremos para el toggle

        // Nueva propiedad para el texto de estado que se mostrará en una columna de texto
        public string EstadoTexto => Estado ? "Activa" : "Inactiva"; // Mostrará "Activa" o "Inactiva"
    }
}