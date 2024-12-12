using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } 
        public string NombreMarca { get; set; }
        public int IdMarca { get; set; } 
        public decimal Precio { get; set; }

        public decimal PrecioTotal
        {
            get
            {
                return Precio * CantidadSeleccionada;
            }
        }

        public int CantidadSeleccionada { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public decimal PorcentajeGanancia { get; set; }
    }
}
