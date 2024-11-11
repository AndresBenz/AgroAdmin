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
    }
}
