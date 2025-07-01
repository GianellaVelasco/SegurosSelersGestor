// Archivo: SegurosSelers.Entidades\Siniestro.cs
using System;

namespace SegurosSelers.Entidades
{
    public class Siniestro
    {
        public int IdSiniestro { get; set; } // Mapea a 'idSiniestro'
        public DateTime FechaSiniestro { get; set; } // Mapea a 'fecha'
        public TimeSpan HoraSiniestro { get; set; } // Mapea a 'hora'
        public string? Descripcion { get; set; } // Puede ser null
        public string UrlFoto { get; set; } // Mapea a 'imagenUrl'
        public string Estado { get; set; } // Mapea a 'estadoSolicitud'
        public int IdUsuario { get; set; } // Mapea a 'idUsuario' (para relacionar con el cliente)
        public int IdPoliza { get; set; } // Mapea a 'idPoliza'

        // Nota: La propiedad 'Activo' no es una columna directa en tu DDL de Siniestro,
        // se maneja lógicamente en el ViewModel y el Service a partir de 'estadoSolicitud'.
        // Las propiedades como Apellido, Nombre y TipoVehiculo no van en esta entidad,
        // se obtienen mediante JOINs en el servicio y se mapean al ViewModel.
    }
}