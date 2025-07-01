using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosSelers.Entidades
{
    public class Poliza
    {
        public int IdPoliza { get; set; }
        public string NombrePack { get; set; }
        public string DescripcionCobertura { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
    }
}