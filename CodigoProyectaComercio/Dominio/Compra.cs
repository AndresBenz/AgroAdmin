using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }

        public string NombreProveedor{ get; set; }

        public DateTime FechaCompra { get; set; }
    }
}
