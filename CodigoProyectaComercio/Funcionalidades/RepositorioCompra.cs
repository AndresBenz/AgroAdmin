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
                        NombreProveedor = (string)accesoDatos.Lector["NombreProveedor"],
                        FechaCompra = (DateTime)accesoDatos.Lector["FechaCompra"],
                        TipoPago = (string)accesoDatos.Lector["TipoPago"]
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
                        NombreProveedor = (string)accesoDatos.Lector["NombreProveedor"],
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
                accesoDatos.setearParametros("@TipoPago", compra.TipoPago);
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

        public void AgregarDetallesCompra(List<DetalleCompra> detallesCompra)
        {
            foreach (DetalleCompra detalle in detallesCompra)
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                try
                {
                    accesoDatos.setearSp("InsDetalleCompra");
                    accesoDatos.setearParametros("@IdCompra", detalle.IdCompra);
                    accesoDatos.setearParametros("@IdProducto", detalle.IdProducto);
                    accesoDatos.setearParametros("@Cantidad", detalle.Cantidad);
                    accesoDatos.setearParametros("@PrecioCompra", detalle.PrecioCompra);
                    accesoDatos.setearParametros("@Subtotal", detalle.Subtotal);

                    accesoDatos.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar detalles de compra", ex);
                }
                finally
                {
                    accesoDatos.cerrarConexion();
                }
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


        public int ObtenerUltimoIdCompra()
        {
            int idCompra = 0;
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("ObtenerUltimoIdCompra");

                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    idCompra = (int)accesoDatos.Lector["IdCompra"];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el último IdCompra", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }

            return idCompra;
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
                        NombreProducto = (string)accesoDatos.Lector["Nombre"],
                        Cantidad = (int)accesoDatos.Lector["Cantidad"],
                        PrecioCompra = (decimal)accesoDatos.Lector["PrecioCompra"],
                        Subtotal = (decimal)accesoDatos.Lector["Subtotal"]

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
