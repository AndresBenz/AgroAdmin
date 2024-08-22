using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioRelReservaXusuario
    {
        public void  InsRelReservaXusuario (RelReservaXusuario nuevo)
        {
            AccesoDatos accesoDatos = new AccesoDatos ();
            try
            {
            accesoDatos.setearSp("insRelReservaXUsuario");
            accesoDatos.setearParametros("IdReserva", nuevo.IdReserva);
            accesoDatos.setearParametros("DniUsuario", nuevo.DniUsuario);

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
