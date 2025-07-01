using System;

namespace SegurosSelers.Entidades
{
    public class UsuarioPolizaViewModel
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public bool EstadoUsuario { get; set; }
        public string NombrePoliza { get; set; }
        public DateTime? FechaContrato { get; set; }
        public DateTime? FechaFinContrato { get; set; }
        public DateTime? _fechaVencimientoPago; // Campo privado para almacenar el valor real

        // Propiedad pública que el DataGridView usará para la columna "Vencimiento"
        public string FechaVencimientoDisplay => _fechaVencimientoPago.HasValue ? _fechaVencimientoPago.Value.ToString("dd/MM/yyyy") : "N/A";

        // Propiedad original, pero ahora el DataGridView no la usará directamente para la columna "Vencimiento"
        public DateTime? FechaVencimientoPago
        {
            get => _fechaVencimientoPago;
            set => _fechaVencimientoPago = value;
        }

        public bool EstaVencida { get; set; }
        public string EstadoVencimientoTexto { get; set; }
    }
}
