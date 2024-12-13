using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class Reportes
    {
        public List<Reporte> ObtenerVentasPorCliente(DateTime fechaInicio, DateTime fechaFin, int? idCliente = null)
        {
            List<Reporte> reporteVentas = new List<Reporte>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelReportVentasPorCliente");
                accesoDatos.setearParametros("@FechaInicio", fechaInicio);
                accesoDatos.setearParametros("@FechaFin", fechaFin);

                if (idCliente.HasValue)
                {
                    accesoDatos.setearParametros("@IdCliente", idCliente.Value);
                }
                else
                {
                    accesoDatos.setearParametros("@IdCliente", DBNull.Value);
                }

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Reporte aux = new Reporte
                    {
                        IdVenta = (int)accesoDatos.Lector["IdVenta"],
                        Cliente = (string)accesoDatos.Lector["Cliente"],
                        Fecha = (DateTime)accesoDatos.Lector["Fecha"],
                        Total = (decimal)accesoDatos.Lector["Total"]
                    };

                    reporteVentas.Add(aux);
                }

                accesoDatos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return reporteVentas;
        }



        public List<Reporte> ObtenerComprasPorProveedor(DateTime fechaInicio, DateTime fechaFin, int? idProveedor = null)
        {
            List<Reporte> reporteCompras = new List<Reporte>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelReportComprasPorProveedor");
                accesoDatos.setearParametros("@FechaInicio", fechaInicio);
                accesoDatos.setearParametros("@FechaFin", fechaFin);

                if (idProveedor.HasValue)
                {
                    accesoDatos.setearParametros("@IdProveedor", idProveedor.Value);
                }
                else
                {
                    accesoDatos.setearParametros("@IdProveedor", DBNull.Value);
                }

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Reporte aux = new Reporte
                    {
                        IdCompra = (int)accesoDatos.Lector["IdCompra"],
                        Proveedor = (string)accesoDatos.Lector["Proveedor"],
                        FechaCompra = (DateTime)accesoDatos.Lector["FechaCompra"],
                        TipoPago = (string)accesoDatos.Lector["TipoPago"],
                        IdProducto = (int)accesoDatos.Lector["IdProducto"],
                        Producto = (string)accesoDatos.Lector["Producto"],
                        Cantidad = (int)accesoDatos.Lector["Cantidad"],
                        PrecioCompra = (decimal)accesoDatos.Lector["PrecioCompra"],
                        Subtotal = (decimal)accesoDatos.Lector["Subtotal"]
                    };

                    reporteCompras.Add(aux);
                }

                accesoDatos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return reporteCompras;
        }
    }
}
