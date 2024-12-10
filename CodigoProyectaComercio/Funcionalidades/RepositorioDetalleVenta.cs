using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioDetalleVenta
    {
        public List<DetalleVenta> ListarConSp()
        {
            List<DetalleVenta> listarDetallesVenta = new List<DetalleVenta>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelDetallesVenta");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    DetalleVenta aux = new DetalleVenta();

                    aux.IdDetalleVenta = (int)accesoDatos.Lector["IdDetalleVenta"];
                    aux.IdVenta = (int)accesoDatos.Lector["IdVenta"];
                    aux.IdProducto = (int)accesoDatos.Lector["IdProducto"];
                    aux.NombreProducto = (string)accesoDatos.Lector["NombreProducto"];
                    aux.Cantidad = (int)accesoDatos.Lector["Cantidad"];
                    aux.PrecioUnitario = (decimal)accesoDatos.Lector["PrecioUnitario"];
                    aux.Subtotal = (decimal)accesoDatos.Lector["Subtotal"];

                    listarDetallesVenta.Add(aux);
                }

                accesoDatos.cerrarConexion();
                return listarDetallesVenta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DetalleVenta> ListarPorVenta(int idVenta)
        {
            List<DetalleVenta> listarDetallesVenta = new List<DetalleVenta>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("SelDetallesPorVenta"); 
                accesoDatos.setearParametros("IdVenta", idVenta);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    DetalleVenta aux = new DetalleVenta();

                    aux.IdDetalleVenta = (int)accesoDatos.Lector["IdDetalleVenta"];
                    aux.IdVenta = (int)accesoDatos.Lector["IdVenta"];
                    aux.IdProducto = (int)accesoDatos.Lector["IdProducto"];
                    aux.NombreProducto = (string)accesoDatos.Lector["NombreProducto"];
                    aux.Cantidad = (int)accesoDatos.Lector["Cantidad"];
                    aux.PrecioUnitario = (decimal)accesoDatos.Lector["PrecioUnitario"];
                    aux.Subtotal = (decimal)accesoDatos.Lector["Subtotal"];

                    listarDetallesVenta.Add(aux);
                }

                accesoDatos.cerrarConexion();
                return listarDetallesVenta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void InsertarDetallesVenta(List<DetalleVenta> listaDetallesVenta)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                // Obtén el ID de la venta insertada previamente
                RepositorioVenta repositorio = new RepositorioVenta();
                int idVenta = repositorio.ObtenerUltimoIdVenta();

                foreach (var detalle in listaDetallesVenta)
                {
                    // Insertar cada detalle de venta
                    accesoDatos.setearSp("InsDetalleVenta");
                    accesoDatos.setearParametros("IdVenta", idVenta);
                    accesoDatos.setearParametros("IdProducto", detalle.IdProducto);
                    accesoDatos.setearParametros("Cantidad", detalle.Cantidad);
                    accesoDatos.setearParametros("PrecioUnitario", detalle.PrecioUnitario);
                    accesoDatos.setearParametros("Subtotal", detalle.Subtotal);
                    accesoDatos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }


        }
    }
}
