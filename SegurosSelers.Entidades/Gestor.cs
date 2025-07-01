using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SegurosSelers.Entidades
{
    // En SegurosSelers.Entidades\Gestor.cs
    public class Gestor
    {
        public int IdGestor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; } // Esta es la propiedad que da el aviso

        // Constructor
        public Gestor(string nombre, string apellido, string correo, string clave)
        {
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Clave = clave; // Aseguramos que 'Clave' siempre reciba un valor
        }

        // Si tienes un constructor vacío, asegúrate de inicializar las propiedades allí también
        public Gestor()
        {
            Nombre = string.Empty; // O un valor por defecto adecuado
            Apellido = string.Empty;
            Correo = string.Empty;
            Clave = string.Empty; // Inicializar 'Clave' aquí
        }
    }
}