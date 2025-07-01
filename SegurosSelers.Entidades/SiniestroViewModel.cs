// Archivo: SegurosSelers.Entidades\SiniestroViewModel.cs
using System;

namespace SegurosSelers.Entidades
{
    public class SiniestroViewModel
    {
        public int IdSiniestro { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaSiniestro { get; set; }
        public TimeSpan HoraSiniestro { get; set; }

        // Propiedad para la URL de la imagen del SINIESTRO (viene de Siniestro.imagenUrl)
        public string ImagenUrlSiniestro { get; set; } = string.Empty; // Renombrada para mayor claridad

        // Propiedades combinadas de otras entidades para la vista
        public string ApellidoNombreCliente { get; set; } = string.Empty;

        // Propiedades específicas del VEHÍCULO (vienen de la tabla Vehiculo)
        public string NombreTipoVehiculo { get; set; } = string.Empty; // El nombre del tipo de vehículo (ej: "Auto", "Moto")
        public string ImagenUrlVehiculo { get; set; } = string.Empty; // La URL de la imagen del vehículo

        // Otros campos que puedas tener
        public string Direccion { get; set; } = string.Empty;
        //public string ApellidoNombreGestor { get; set; = string.Empty;
        public string NombrePackPoliza { get; set; } = string.Empty;
        public string MarcaVehiculo { get; set; } = string.Empty; // Si estas vienen de otro lado
        public string ModeloVehiculo { get; set; } = string.Empty;
        public string PatenteVehiculo { get; set; } = string.Empty;

        public SiniestroViewModel() { }
    }
}