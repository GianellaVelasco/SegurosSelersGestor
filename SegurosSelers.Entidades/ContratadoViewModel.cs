using System;

namespace SegurosSelers.Entidades
{
    public class ContratadoViewModel
    {
        public int IdSegCont { get; set; }
        public string ApellidoNombreCliente { get; set; } // Apellido y Nombre del usuario
        public string NombrePackPoliza { get; set; }     // Nombre del Pack de la póliza
        public DateTime FechaContrato { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Observaciones { get; set; }
        public bool EstaVigente { get; set; }            // Propiedad calculada para el estado de vigencia
    }
}