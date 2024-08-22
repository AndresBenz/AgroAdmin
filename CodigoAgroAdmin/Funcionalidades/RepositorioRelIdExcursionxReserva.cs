using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioRelIdExcursionxReserva
    {

        public void InsRelReservaXusuario(RelExcursionxReserva nuevo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("insRelExcursionXreserva");
                accesoDatos.setearParametros("IdExcursion", nuevo.IdExcursion);
                accesoDatos.setearParametros("IdReserva", nuevo.IdReserva);

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
        public List<selRelExcursionxReserva> ListarConSp(int idreserva)
        {
            List<selRelExcursionxReserva> listRelExcursionxReserva = new List<selRelExcursionxReserva>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("selRelExcursionXreserva");
                accesoDatos.setearParametros("IdReserva", idreserva);

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    selRelExcursionxReserva aux = new selRelExcursionxReserva();

                    aux.IdExcursion= (int)accesoDatos.Lector["IdExcursion"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];

                    listRelExcursionxReserva.Add(aux);
                }
                accesoDatos.cerrarConexion();
                return listRelExcursionxReserva;
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
