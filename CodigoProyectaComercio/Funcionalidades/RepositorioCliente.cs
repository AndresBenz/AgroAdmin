using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                        aux.DNI = (string)accesoDatos.Lector["DNI"];
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

        public Cliente ObtenerClientePorId(string DNICliente)
        {
            Cliente cliente = null;
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("SelClientePorId");
                accesoDatos.setearParametros("@DNI", DNICliente);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    cliente = new Cliente
                    {
                        IdCliente = (int)accesoDatos.Lector["IdCliente"],
                        Nombre = (string)accesoDatos.Lector["Nombre"],
                        DNI = (string)accesoDatos.Lector["DNI"],
                        Direccion = (string)accesoDatos.Lector["Direccion"],
                        CorreoElectronico = (string)accesoDatos.Lector["CorreoElectronico"],
                        Telefono = (string)accesoDatos.Lector["Telefono"]
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente por ID", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }

            return cliente;
        }


        public void AgregarCliente(Cliente cliente)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("insCliente");
                accesoDatos.setearParametros("@Nombre", cliente.Nombre);
                accesoDatos.setearParametros("@Direccion", cliente.Direccion);
                accesoDatos.setearParametros("@CorreoElectronico", cliente.CorreoElectronico);
                accesoDatos.setearParametros("@Telefono", cliente.Telefono);
                accesoDatos.setearParametros("@DNI", cliente.DNI);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el cliente", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void EliminarCliente(string DNICliente)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("delCliente");
                accesoDatos.setearParametros("@DNI", DNICliente);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public int ObtenerTotalClientes()
        {
            int totalClientes = 0;
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("SelTotalClientes");  
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    totalClientes = (int)accesoDatos.Lector["TotalClientes"];
                }

                accesoDatos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return totalClientes;
        }

        public void EditarCliente(Cliente cliente)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("updCliente");
                accesoDatos.setearParametros("@IdCliente", cliente.IdCliente);
                accesoDatos.setearParametros("@Nombre", cliente.Nombre);
                accesoDatos.setearParametros("@Direccion", cliente.Direccion);
                accesoDatos.setearParametros("@CorreoElectronico", cliente.CorreoElectronico);
                accesoDatos.setearParametros("@Telefono", cliente.Telefono);
                accesoDatos.setearParametros("@DNI", cliente.DNI);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el cliente", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }


    }
}
