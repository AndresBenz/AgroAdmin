using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioProductoProveedor
    {
        public List<ProductoProveedor> ListarConSp()
        {
            List<ProductoProveedor> listarProductoProveedor = new List<ProductoProveedor>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelProductoProveedor");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    ProductoProveedor aux = new ProductoProveedor();

                    aux.IdProducto = (int)accesoDatos.Lector["IdProducto"];
                    aux.IdProveedor = (int)accesoDatos.Lector["IdProveedor"];

                    listarProductoProveedor.Add(aux);
                }

                accesoDatos.cerrarConexion();
                return listarProductoProveedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarProductoAProveedor(int idProducto,int idProveedor )
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                string consulta = "INSERT INTO ProductoProveedor (IdProducto,IdProveedor) VALUES (@IdProducto, @IdProveedor )";
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametros("@IdProducto", idProducto);
                accesoDatos.setearParametros("@IdProveedor", idProveedor);
               
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto al proveedor.", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }


        public void EliminarProductoDeProveedor(int idProveedor, int idProducto)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                string consulta = "DELETE FROM ProductoProveedor WHERE IdProveedor = @IdProveedor AND IdProducto = @IdProducto";
                accesoDatos.setearConsulta(consulta);
                accesoDatos.setearParametros("@IdProveedor", idProveedor);
                accesoDatos.setearParametros("@IdProducto", idProducto);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto del proveedor.", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
