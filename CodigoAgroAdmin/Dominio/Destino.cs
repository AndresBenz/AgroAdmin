using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Destino
    {
        public int IdDestino { get; set; }
        public int cdgDestino { get; set; }
        public string nombreDestino {  get; set; }
        public int TipoTransporte { get; set; }  // vuelo1 o bus 2
        public decimal Precio { get; set; }

    }
}
