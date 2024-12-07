using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioMarca
    {
        public List<Marca> ListarConSp()
        {
            List<Marca> listarMarcas = new List<Marca>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelMarcas");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Marca aux = new Marca();

                    aux.IdMarca = (int)accesoDatos.Lector["IdMarca"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Activo = (bool)accesoDatos.Lector["Activo"];

                    listarMarcas.Add(aux);
                }

                accesoDatos.cerrarConexion();
                return listarMarcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Marca> ListarConSpActivas()
        {
            List<Marca> listarMarcas = new List<Marca>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelMarcasActivas");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Marca aux = new Marca();

                    aux.IdMarca = (int)accesoDatos.Lector["IdMarca"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Activo = (bool)accesoDatos.Lector["Activo"];

                    listarMarcas.Add(aux);
                }

                accesoDatos.cerrarConexion();
                return listarMarcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Marca SelMarcaPorId(int idMarca)
        {
            Marca marca = null;
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelMarcaPorId"); 
                accesoDatos.setearParametros("@IdMarca", idMarca); 

                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    marca = new Marca
                    {
                        IdMarca = (int)accesoDatos.Lector["IdMarca"],
                        Nombre = (string)accesoDatos.Lector["Nombre"],
                        Activo = (bool)accesoDatos.Lector["Activo"]
                    };
                }

                accesoDatos.cerrarConexion();
                return marca;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarMarca(string nombre, bool Activo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("InsMarca");
                accesoDatos.setearParametros("@Nombre", nombre);
                accesoDatos.setearParametros("@Activo", Activo);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ModificarMarca(int idMarca, string nombre, bool Activo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("UpdMarca");
                accesoDatos.setearParametros("@IdMarca", idMarca);
                accesoDatos.setearParametros("@Nombre", nombre);
                accesoDatos.setearParametros("@Activo", Activo);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EliminarMarca(int idMarca)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("DelMarca");
                accesoDatos.setearParametros("@IdMarca", idMarca);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
