using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioCompra
    {
        public List<Compra> ListarCompras()
        {
            List<Compra> listarCompras = new List<Compra>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelCompras");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Compra compra = new Compra
                    {
                        IdCompra = (int)accesoDatos.Lector["IdCompra"],
                        IdProveedor = (int)accesoDatos.Lector["IdProveedor"],
                        FechaCompra = (DateTime)accesoDatos.Lector["FechaCompra"]
                    };

                    listarCompras.Add(compra);
                }

                accesoDatos.cerrarConexion();
                return listarCompras;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las compras", ex);
            }
        }

        public Compra ObtenerCompraPorId(int idCompra)
        {
            Compra compra = null;
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelCompraPorId");
                accesoDatos.setearParametros("@IdCompra", idCompra);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    compra = new Compra
                    {
                        IdCompra = (int)accesoDatos.Lector["IdCompra"],
                        IdProveedor = (int)accesoDatos.Lector["IdProveedor"],
                        FechaCompra = (DateTime)accesoDatos.Lector["FechaCompra"]
                    };
                }

                accesoDatos.cerrarConexion();
                return compra;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la compra por ID", ex);
            }
        }

        public void AgregarCompra(Compra compra)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("insCompra");
                accesoDatos.setearParametros("@IdProveedor", compra.IdProveedor);
                accesoDatos.setearParametros("@FechaCompra", compra.FechaCompra);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la compra", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void EliminarCompra(int idCompra)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("DelCompra");
                accesoDatos.setearParametros("@IdCompra", idCompra);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la compra", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void EditarCompra(Compra compra)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("updCompra");
                accesoDatos.setearParametros("@IdCompra", compra.IdCompra);
                accesoDatos.setearParametros("@IdProveedor", compra.IdProveedor);
                accesoDatos.setearParametros("@FechaCompra", compra.FechaCompra);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la compra", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public List<DetalleCompra> ListarDetallesCompra(int idCompra)
        {
            List<DetalleCompra> listarDetalles = new List<DetalleCompra>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                
                accesoDatos.setearSp("SelDetallesCompra");
                accesoDatos.setearParametros("@IdCompra", idCompra);
                accesoDatos.ejecutarLectura();

              
                while (accesoDatos.Lector.Read())
                {
                    DetalleCompra detalle = new DetalleCompra
                    {
                        IdDetalleCompra = (int)accesoDatos.Lector["IdDetalleCompra"],
                        IdProducto = (int)accesoDatos.Lector["IdProducto"],  
                        Cantidad = (int)accesoDatos.Lector["Cantidad"],
                        PrecioCompra = (decimal)accesoDatos.Lector["PrecioCompra"]
                    };

                    listarDetalles.Add(detalle);
                }

                accesoDatos.cerrarConexion();
                return listarDetalles;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los detalles de la compra", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
