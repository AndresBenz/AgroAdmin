using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Excursiones
    {
        public int IdExcursion {  get; set; }
        public int cdgDestino { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int duracion { get; set; }

        public string Nombre { get; set; }

    }
}
