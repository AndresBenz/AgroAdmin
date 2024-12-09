using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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
                    aux.IdCategoria = (int)accesoDatos.Lector["IdCategoria"];
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



        public List<Producto> ListarConSpDetalle()
        {
            List<Producto> listarProductos = new List<Producto>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelProductosConDetalles"); 
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.IdProducto = (int)accesoDatos.Lector["IdProducto"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.IdCategoria = (int)accesoDatos.Lector["IdCategoria"];
                    aux.IdMarca = (int)accesoDatos.Lector["IdMarca"];
                    aux.Precio = (decimal)accesoDatos.Lector["Precio"];
                    aux.StockActual = (int)accesoDatos.Lector["StockActual"];
                    aux.StockMinimo = (int)accesoDatos.Lector["StockMinimo"];


                    aux.NombreCategoria = (string)accesoDatos.Lector["NombreCategoria"];
                    aux.NombreMarca = (string)accesoDatos.Lector["NombreMarca"];




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
                    accesoDatos.setearSp("SelProducto");
                }

                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    producto = new Producto();
                    producto.IdProducto = (int)accesoDatos.Lector["IdProducto"];
                    producto.Nombre = (string)accesoDatos.Lector["Nombre"];
                    producto.IdCategoria = (int)accesoDatos.Lector["IdCategoria"];
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
                accesoDatos.setearParametros("@IdCategoria", producto.IdCategoria);
                accesoDatos.setearParametros("@IdMarca", producto.IdMarca);

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


        public int ObtenerTotalProductosEnStock()
        {
            int totalProductos = 0;
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("SelTotalProductos");  
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    totalProductos = (int)accesoDatos.Lector["TotalProductos"];  
                }

                accesoDatos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return totalProductos;
        }

        public List<Producto> ListarProductosBajoStock()
        {
            List<Producto> listarProductos = new List<Producto>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("ObtenerProductosBajoStock");

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.IdProducto = (int)accesoDatos.Lector["IdProducto"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.IdCategoria = (int)accesoDatos.Lector["IdCategoria"];
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
                throw new Exception("Error al listar productos con bajo stock", ex);
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
                accesoDatos.setearParametros("@IdCategoria", producto.IdCategoria);
                accesoDatos.setearParametros("@IdMarca", producto.IdMarca);

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


        public List<Producto> ObtenerProductos(int? idProducto = null, string nombre = null)
        {
            List<Producto> productos = new List<Producto>();
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
                    accesoDatos.setearSp("SelProductosPorNombre");
                    accesoDatos.setearParametros("@Nombre", "%" + nombre + "%"); 
                }
                else
                {
                    accesoDatos.setearSp("SelProductos"); 
                }

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read()) 
                {
                    Producto producto = new Producto
                    {
                        IdProducto = (int)accesoDatos.Lector["IdProducto"],
                        Nombre = (string)accesoDatos.Lector["Nombre"],
                        IdCategoria = (int)accesoDatos.Lector["IdCategoria"],
                        IdMarca = (int)accesoDatos.Lector["IdMarca"],
                        Precio = (decimal)accesoDatos.Lector["Precio"],
                        StockActual = (int)accesoDatos.Lector["StockActual"],
                        StockMinimo = (int)accesoDatos.Lector["StockMinimo"]
                    };

                    productos.Add(producto);
                }

                accesoDatos.cerrarConexion();
                return productos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
