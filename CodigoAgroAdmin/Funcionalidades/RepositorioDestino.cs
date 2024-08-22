using Dominio;
using Gestion_de_viajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioDestino
    {
        public List<Destino> ListarConSp()
        {

            List<Destino> listarDestinos = new List<Destino>();
            AccesoDatos AccesoDatos = new AccesoDatos();
            try
            {

                AccesoDatos.setearSp("SelDestinoCompleto");
                AccesoDatos.ejecutarLectura();

                while (AccesoDatos.Lector.Read())
                {
                    Destino aux = new Destino();


                    aux.IdDestino = (int)AccesoDatos.Lector["IdDestino"];
                    aux.cdgDestino = (int)AccesoDatos.Lector["cdgDestino"];
                    aux.nombreDestino = (string)AccesoDatos.Lector["NombreDestino"];
                

                    listarDestinos.Add(aux);
                }

                AccesoDatos.cerrarConexion();
                return listarDestinos;

            }


            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Destino ObtenerDestinoPorcdgDestino(int cdgDestino)
        {
            Destino destino = new Destino();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("ObtenerDestinoPorcdgDestino");
                accesoDatos.setearParametros("@cdgDestino", cdgDestino);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    Destino aux = new Destino();


                    aux.IdDestino = (int)accesoDatos.Lector["IdDestino"];
                    aux.cdgDestino = (int)accesoDatos.Lector["cdgDestino"];
                    aux.nombreDestino = (string)accesoDatos.Lector["NombreDestino"];
                   
                    destino = aux;
                }

                accesoDatos.cerrarConexion();
                return destino;
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
        public Destino ObtenerDestinoPorId(int idDestino)
        {
            Destino destino = new Destino();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("ObtenerDestinoPorId");
                accesoDatos.setearParametros("@IdDestino", idDestino);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    Destino aux = new Destino();


                    aux.IdDestino = (int)accesoDatos.Lector["IdDestino"];
                    aux.cdgDestino = (int)accesoDatos.Lector["cdgDestino"];
                    aux.nombreDestino = (string)accesoDatos.Lector["NombreDestino"];
                 
                    destino = aux;
                }

                accesoDatos.cerrarConexion();
                return destino;
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
        public void AgregarConSp(Destino nuevo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("insDestino");
                accesoDatos.setearParametros("@cdgDestino", nuevo.cdgDestino);
                accesoDatos.setearParametros("@NombreDestino", nuevo.nombreDestino);
              


                accesoDatos.ejecutarAccion();



            }
            catch (Exception EX)
            {

                throw EX;
            }

            finally
            {
                accesoDatos.cerrarConexion();
            }



        }


        public void EliminarDestino(int idDestino)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("Del_Destino");
                accesoDatos.setearParametros("@IdDestino", idDestino);

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
