using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SegurosSelers.Entidades
{
    public class Usuario
    {


        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public int TipoUsuario { get; set; }
        public bool Estado { get; set; }
        public int IdTipoVehiculo { get; set; }
        public int IdGestor { get; set; }

        // Propiedades de navegación
        public Vehiculo Vehiculo { get; set; }
        public Gestor Gestor { get; set; }
    }
}
