using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reporte
    {
        // Para ventas
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public decimal Total { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        // Para compras
        public int IdCompra { get; set; }
        public string Proveedor { get; set; }
        public DateTime FechaCompra { get; set; }
        public string TipoPago { get; set; }
        public decimal PrecioCompra { get; set; }  
        public decimal SubtotalCompra { get; set; }     

    }
}
