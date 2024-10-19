using Dominio;
using System;
using System.Collections.Generic;
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
                     aux.IdMarca = (int)accesoDatos.Lector["IdMarca"] ;
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
        

      
    }
}
