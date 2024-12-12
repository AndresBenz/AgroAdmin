using Dominio;
using iText.Layout.Borders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioVenta
    {
        public List<Venta> ListarConSp()
        {
            List<Venta> listarVentas = new List<Venta>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelVentas");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Venta aux = new Venta();

                    aux.IdVenta = (int)accesoDatos.Lector["IdVenta"];
                    aux.IdCliente = (int)accesoDatos.Lector["IdCliente"];
                    aux.NombreCliente = (string)accesoDatos.Lector["NombreCliente"];
                    aux.Fecha = (DateTime)accesoDatos.Lector["Fecha"];
                    aux.Total = (decimal)accesoDatos.Lector["Total"];

                    listarVentas.Add(aux);
                }

                accesoDatos.cerrarConexion();
                return listarVentas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Venta ObtenerVentaPorId(int idVenta)
        {
            Venta venta = null;
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelVentaPorId");
                accesoDatos.setearParametros("@IdVenta", idVenta);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    venta = new Venta
                    {
                        IdVenta = (int)accesoDatos.Lector["IdVenta"],
                        IdCliente = (int)accesoDatos.Lector["IdCliente"],
                        NombreCliente = (string)accesoDatos.Lector["NombreCliente"],
                        Fecha = (DateTime)accesoDatos.Lector["Fecha"],
                        Total = (decimal)accesoDatos.Lector["Total"]
                    };
                }

                accesoDatos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return venta;
        }

        public void Insertar(Venta venta)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("InsVenta");
                accesoDatos.setearParametros("IdCliente", venta.IdCliente);
                accesoDatos.setearParametros("Fecha", venta.Fecha);
                accesoDatos.setearParametros("Total", venta.Total);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int ObtenerUltimoIdVenta()
        {
            int idVenta = 0;
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelUltimaVenta"); 
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    idVenta = (int)accesoDatos.Lector["IdVenta"];
                }
                accesoDatos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return idVenta;
        }

        public void Actualizar(Venta venta)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("UpdVenta");
                accesoDatos.setearParametros("IdVenta", venta.IdVenta);
                accesoDatos.setearParametros("IdCliente", venta.IdCliente);
                accesoDatos.setearParametros("Fecha", venta.Fecha);
                accesoDatos.setearParametros("Total", venta.Total);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal ObtenerTotalVentasMes()
        {
            decimal totalVentas = 0;
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("SelTotalVentasMes");

  
                accesoDatos.ejecutarLectura();


                if (accesoDatos.Lector.Read() && !Convert.IsDBNull(accesoDatos.Lector["TotalVentas"]))
                {
                    totalVentas = (decimal)accesoDatos.Lector["TotalVentas"];
                }

                accesoDatos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return totalVentas;
        }

        public void Eliminar(int idVenta)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("DelVenta");
                accesoDatos.setearParametros("IdVenta", idVenta);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public decimal CalcularPrecioVenta(int idProducto)
        {
            decimal precioCompra = ObtenerPrecioCompraMasReciente(idProducto);
            decimal porcentajeGanancia = ObtenerPorcentajeGanancia(idProducto);

            decimal precioVenta = precioCompra * (1 + (porcentajeGanancia / 100));
            return precioVenta;
        }

        public decimal ObtenerPrecioCompraMasReciente(int idProducto)
        {
            decimal precioCompra = 0;
            string consulta = "SELECT TOP 1 dc.PrecioCompra FROM DetalleCompra dc INNER JOIN Compras c ON dc.IdCompra = c.IdCompra WHERE dc.IdProducto = @IdProducto ORDER BY c.FechaCompra DESC";


            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametros("@IdProducto", idProducto);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read() && !Convert.IsDBNull(accesoDatos.Lector["PrecioCompra"]))
                {
                    precioCompra = Convert.ToDecimal(accesoDatos.Lector["PrecioCompra"]);
                }

                accesoDatos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return precioCompra;
        }

        public decimal ObtenerPorcentajeGanancia(int idProducto)
        {
            decimal porcentajeGanancia = 0;
            string consulta = "SELECT PorcentajeGanancia FROM Productos WHERE IdProducto = @IdProducto";


            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametros("@IdProducto", idProducto);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read() && !Convert.IsDBNull(accesoDatos.Lector["PorcentajeGanancia"]))
                {
                    porcentajeGanancia = Convert.ToDecimal(accesoDatos.Lector["PorcentajeGanancia"]);
                }

                accesoDatos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return porcentajeGanancia;
        }
    }
}

