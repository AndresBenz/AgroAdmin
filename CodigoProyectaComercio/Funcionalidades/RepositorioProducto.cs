using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioProducto
    {
        public List<Producto> ListarConSp()
        {
            List<Producto> listarProductos = new List<Producto>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelProductos");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.IdProducto = (int)accesoDatos.Lector["IdProducto"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.IdTipo = (int)accesoDatos.Lector["IdTipo"];
                    aux.IdMarca = (int)accesoDatos.Lector["IdMarca"];
                    aux.Precio = (decimal)accesoDatos.Lector["Precio"];
                    aux.StockActual = (int)accesoDatos.Lector["StockActual"];
                    aux.StockMinimo = (int)accesoDatos.Lector["StockMinimo"];

                    listarProductos.Add(aux);
                }

                accesoDatos.cerrarConexion();
                return listarProductos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Producto ObtenerProductoPorId(int? idProducto = null, string nombre = null)
        {
            Producto producto = null;
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                if (idProducto.HasValue)
                {
                    accesoDatos.setearSp("SelProductoPorId");
                    accesoDatos.setearParametros("@IdProducto", idProducto);
                    
                }

                else if (!string.IsNullOrEmpty(nombre))
                {
                    accesoDatos.setearSp("SelProductoPorNombre");
                    accesoDatos.setearParametros("@Nombre", nombre);
                }
                else
                {
                    throw new ArgumentException("Debe especificar al menos un parámetro: idProducto o nombre.");
                }

                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    producto = new Producto();
                    producto.IdProducto = (int)accesoDatos.Lector["IdProducto"];
                    producto.Nombre = (string)accesoDatos.Lector["Nombre"];
                    producto.IdTipo = (int)accesoDatos.Lector["IdTipo"];
                    producto.IdMarca = (int)accesoDatos.Lector["IdMarca"];
                    producto.Precio = (decimal)accesoDatos.Lector["Precio"];
                    producto.StockActual = (int)accesoDatos.Lector["StockActual"];
                    producto.StockMinimo = (int)accesoDatos.Lector["StockMinimo"];
                }

                accesoDatos.cerrarConexion();
                return producto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void AgregarProducto(Producto producto)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("insProducto");

                accesoDatos.setearParametros("@Nombre", producto.Nombre);
                accesoDatos.setearParametros("@Precio", producto.Precio);
                accesoDatos.setearParametros("@StockActual", producto.StockActual);
                accesoDatos.setearParametros("@StockMinimo", producto.StockMinimo);
                accesoDatos.setearParametros("@IdTipo", producto.IdTipo);
                accesoDatos.setearParametros("@IdMarca", producto.IdTipo);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void EliminarProducto(int idProducto)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("DelProducto");
                accesoDatos.setearParametros("@IdProducto", idProducto);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void EditarProducto(Producto producto)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("updProducto");

                accesoDatos.setearParametros("@IdProducto", producto.IdProducto);
                accesoDatos.setearParametros("@Nombre", producto.Nombre);
                accesoDatos.setearParametros("@Precio", producto.Precio);
                accesoDatos.setearParametros("@StockActual", producto.StockActual);
                accesoDatos.setearParametros("@StockMinimo", producto.StockMinimo);
                accesoDatos.setearParametros("@IdTipo", producto.IdTipo);
                accesoDatos.setearParametros("@IdMarca", producto.IdTipo);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el producto", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
