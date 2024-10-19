using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Funcionalidades
{
    public class RepositorioCliente
    {
        public List<Cliente> ListarConSp()
        {
            List<Cliente> listarClientes = new List<Cliente>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelClientes");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    
                        aux.IdCliente = (int)accesoDatos.Lector["IdCliente"];
                        aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                        aux.Direccion = accesoDatos.Lector["Direccion"] as string;
                        aux.CorreoElectronico = (string)accesoDatos.Lector["CorreoElectronico"];
                        aux.Telefono = accesoDatos.Lector["Telefono"] as string;
                    
                    listarClientes.Add(aux);
                }

                accesoDatos.cerrarConexion();
                return listarClientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
