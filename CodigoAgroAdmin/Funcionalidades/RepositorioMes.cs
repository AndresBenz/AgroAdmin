using Gestion_de_viajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Funcionalidades;

namespace Funcionalidades
{
    public class RepositorioMes
    {
        public List<Mes> ListarConSp()
        {
            List<Mes> mesesActivos = new List<Mes>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("SelObtenerMesActivoPorId");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read()) 
                {
                    Mes aux = new Mes();

                    aux.IdMes = (int)accesoDatos.Lector["IdMes"];
                    aux.NombreMes = (string)accesoDatos.Lector["NombreMes"];
                    aux.Activo = true;
                    
                    mesesActivos.Add(aux);
                }   
                accesoDatos.cerrarConexion();
                return mesesActivos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }


        public List<Mes> ObtenerMesActivoPorId(int idMes)
        {
            List<Mes> mesesActivos = new List<Mes>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("SelObtenerMesActivoPorId");
                accesoDatos.setearParametros("@Activo", idMes);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Mes aux = new Mes();

                    aux.IdMes = (int)accesoDatos.Lector["IdMes"];
                    aux.NombreMes = (string)accesoDatos.Lector["NombreMes"];
                    aux.Activo = true;

                    mesesActivos.Add(aux);
                }
                accesoDatos.cerrarConexion();
                return mesesActivos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void ActualizarEstadoMes(int idMes, bool activo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("updEstadoMes");
                accesoDatos.setearParametros("@IdMes", idMes);
                accesoDatos.setearParametros("@Activo", activo);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
    
}
