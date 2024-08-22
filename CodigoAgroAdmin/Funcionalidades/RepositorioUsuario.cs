using Dominio;
using Gestion_de_viajes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioUsuario
    {
        public List<Usuario> ListarConSp()
        {

            List<Usuario> listarUsuario = new List<Usuario>();
            AccesoDatos AccesoDatos = new AccesoDatos();
            try
            {

                AccesoDatos.setearSp("SelReservaCompleto");
                AccesoDatos.ejecutarLectura();

                while (AccesoDatos.Lector.Read())
                {
                    Usuario aux = new Usuario();


                    aux.NombreUsuario = (string)AccesoDatos.Lector["Nombre"];
                    aux.DNI = (int)AccesoDatos.Lector["DNI"];
                    aux.CorreoElectronico = (string)AccesoDatos.Lector["CorreoElectronico"];
                    aux.Telefono = (string)AccesoDatos.Lector["Telefono"];


                    listarUsuario.Add(aux);
                }

                AccesoDatos.cerrarConexion();
                return listarUsuario;

            }


            catch (Exception ex)
            {

                throw ex;
            }

        }
        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            Usuario usuario = new Usuario();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("ObtenerUsuarioPorId");
                accesoDatos.setearParametros("@IdUsuario", idUsuario);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    usuario.IdUsuario = (int)accesoDatos.Lector["IdUsuario"];
                    usuario.DNI = (int)accesoDatos.Lector["DNI"];
                    usuario.NombreUsuario = (string)accesoDatos.Lector["Nombre"];
                    usuario.CorreoElectronico = (string)accesoDatos.Lector["CorreoElectronico"];
                    usuario.Telefono = (string)accesoDatos.Lector["Telefono"];
                }

                accesoDatos.cerrarConexion();
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Loguear(Usuario usuario)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdUsuario, Nombre, TipoUsuario FROM USUARIOS where  CorreoElectronico = @Nombre and DNI = @Contra");

                datos.setearParametros("@Contra", usuario.DNI);
                datos.setearParametros("@Nombre", usuario.CorreoElectronico);


                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUsuario"]) == 2 ? TipoUsuario.Admin : TipoUsuario.Normal;
                    return true;

                }

                return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public void InsUsuario(Usuario nuevo)
        {

            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("InsUsuario");
                accesoDatos.setearParametros("@Nombre", nuevo.NombreUsuario);
                accesoDatos.setearParametros("@CorreoElectronico", nuevo.CorreoElectronico);
                accesoDatos.setearParametros("@DNI", nuevo.DNI);
                accesoDatos.setearParametros("@telefono", nuevo.Telefono);
                accesoDatos.setearParametros("@TipoUsuario", nuevo.TipoUsuario);
              

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int VerificarUsuarioExistente(int dni, string Email)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            accesoDatos.setearSp("verificarUsuarioExistente");
            accesoDatos.setearParametros("@DNI", dni);
            accesoDatos.setearParametros("@CorreoElectronico", Email);
            accesoDatos.ejecutarLectura();
            int valor = 0;
            if (accesoDatos.Lector.Read())
            {
                valor = (int)accesoDatos.Lector["Existe"];

            }

            return valor;


        }

    }
}

