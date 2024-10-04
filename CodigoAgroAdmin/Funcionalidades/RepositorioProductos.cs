using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Funcionalidades
{
    public class RepositorioProductos
    {
        public List<Productos> ListarProductosConSp()
        {
            List<Productos> listarProductos = new List<Productos>();
            AccesoDatos AccesoDatos = new AccesoDatos();

            try
            {
                // Establecer el nombre del procedimiento almacenado
                AccesoDatos.setearSp("sp_ObtenerProductos");
                AccesoDatos.ejecutarLectura();

                // Leer los resultados del procedimiento almacenado
                while (AccesoDatos.Lector.Read())
                {
                    Productos aux = new Productos();

                    aux.IdProducto = (int)AccesoDatos.Lector["IdProducto"];
                    aux.NombreProducto = (string)AccesoDatos.Lector["NombreProducto"];
                    aux.TipoProducto = (string)AccesoDatos.Lector["TipoProducto"];
                    aux.MarcaProducto = (string)AccesoDatos.Lector["MarcaProducto"];
                    aux.Precio = (decimal)AccesoDatos.Lector["Precio"];
                    aux.StockActual = (int)AccesoDatos.Lector["StockActual"];
                    aux.StockMinimo = (int)AccesoDatos.Lector["StockMinimo"];

                    listarProductos.Add(aux);
                }

                // Cerrar la conexión
                AccesoDatos.cerrarConexion();
                return listarProductos;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw ex;
            }
        }
    }
}
