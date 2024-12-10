using Dominio;
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
    }
}

