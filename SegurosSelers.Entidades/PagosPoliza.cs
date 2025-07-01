using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosSelers.Entidades
{
    public class PagosPoliza
    {
        public int IdPago { get; set; }
        public int IdUsuario { get; set; }
        public int IdPoliza { get; set; }
        public DateTime? FechaVto { get; set; }
        public string? Observaciones { get; set; }
    }
}

