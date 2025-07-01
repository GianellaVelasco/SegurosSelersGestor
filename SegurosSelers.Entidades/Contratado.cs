using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosSelers.Entidades
{
    public class Contratado
    {
        public int IdSegCont { get; set; }
        public int IdUsuario { get; set; }
        public int IdPoliza { get; set; }
        public DateTime FechaContrato { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Observaciones { get; set; }
    }

}