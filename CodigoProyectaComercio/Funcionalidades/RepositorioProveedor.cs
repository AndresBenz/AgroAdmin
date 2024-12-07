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
                    aux.Detalle = accesoDatos.Lector["Detalle"] as string;
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

        public Proveedor ObtenerProveedorPorId(int idProveedor)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            Proveedor proveedor = null;

            try
            {
                accesoDatos.setearSp("selProveedorPorId");
                accesoDatos.setearParametros("@IdProveedor", idProveedor);

                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    proveedor = new Proveedor
                    {
                        IdProveedor = (int)accesoDatos.Lector["IdProveedor"],
                        Nombre = accesoDatos.Lector["Nombre"].ToString(),
                        Detalle = accesoDatos.Lector["Detalle"].ToString(),
                        CorreoElectronico = accesoDatos.Lector["CorreoElectronico"].ToString(),
                        Telefono = accesoDatos.Lector["Telefono"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el proveedor por ID", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }

            return proveedor;
        }


        public void AgregarProveedor(Proveedor proveedor)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("insProveedor");  
                accesoDatos.setearParametros("@Nombre", proveedor.Nombre);
                accesoDatos.setearParametros("@Detalle", proveedor.Detalle);
                accesoDatos.setearParametros("@CorreoElectronico", proveedor.CorreoElectronico);
                accesoDatos.setearParametros("@Telefono", proveedor.Telefono);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el proveedor", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public int ObtenerTotalProveedoresActivos()
        {
            int totalProveedoresActivos = 0;  
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("SelTotalProveedores");  
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    
                    totalProveedoresActivos = (int)accesoDatos.Lector["TotalProveedores"];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el total de proveedores activos", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }

            return totalProveedoresActivos;
        }



            public void EditarProveedor(Proveedor proveedor)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("updProveedor");
                accesoDatos.setearParametros("@IdProveedor", proveedor.IdProveedor);
                accesoDatos.setearParametros("@Nombre", proveedor.Nombre);
                accesoDatos.setearParametros("@Detalle", proveedor.Detalle);
                accesoDatos.setearParametros("@CorreoElectronico", proveedor.CorreoElectronico);
                accesoDatos.setearParametros("@Telefono", proveedor.Telefono);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el proveedor", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void EliminarProveedor(int idProveedor)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("delProveedor");
                accesoDatos.setearParametros("@IdProveedor", idProveedor);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el proveedor", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

    }
}
