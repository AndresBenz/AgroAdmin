using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioProveedor
    {
        public List<Proveedor> ListarConSp()
        {
            List<Proveedor> listarProveedores = new List<Proveedor>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelProveedores");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();

                    aux.IdProveedor = (int)accesoDatos.Lector["IdProveedor"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Direccion = accesoDatos.Lector["Direccion"] as string;
                    aux.CorreoElectronico = accesoDatos.Lector["CorreoElectronico"] as string;
                    aux.Telefono = accesoDatos.Lector["Telefono"] as string;

                    listarProveedores.Add(aux);
                }

                accesoDatos.cerrarConexion();
                return listarProveedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
