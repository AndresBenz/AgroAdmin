using Dominio;
using Gestion_de_viajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioExcursiones
    {




        public List<Excursiones> ListarConSp()
        {

            List<Excursiones> listarExcursiones = new List<Excursiones>();
            AccesoDatos AccesoDatos = new AccesoDatos();
            try
            {

                AccesoDatos.setearSp("SelExcursionesCompleto");
                AccesoDatos.ejecutarLectura();

                while (AccesoDatos.Lector.Read())
                {
                    Excursiones aux = new Excursiones();


                    aux.IdExcursion = (int)AccesoDatos.Lector["IdExcursion"];
                    aux.cdgDestino = (int)AccesoDatos.Lector["cdgdestino"];
                    aux.Descripcion = (string)AccesoDatos.Lector["Descripcion"];
                    aux.Precio = (decimal)AccesoDatos.Lector["Precio"];
                    aux.duracion = (int)AccesoDatos.Lector["Duracion"];
                    aux.Nombre = (string)AccesoDatos.Lector["Nombre"];




                    listarExcursiones.Add(aux);
                }

                AccesoDatos.cerrarConexion();
                return listarExcursiones;

            }


            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Excursiones> ObtenerExcursionesPorDestino(int cdgDestino)
        {
            List<Excursiones> excursiones = new List<Excursiones>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {

                accesoDatos.setearSp("SelExcursionesPorDestino");

                accesoDatos.setearParametros("@cdgDestino", cdgDestino);
                accesoDatos.ejecutarLectura();


                while (accesoDatos.Lector.Read())
                {
                    Excursiones excursion = new Excursiones();

                    excursion.IdExcursion = (int)accesoDatos.Lector["IdExcursion"];
                    excursion.cdgDestino = (int)accesoDatos.Lector["cdgDestino"];
                    excursion.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    excursion.Precio = (decimal)accesoDatos.Lector["Precio"];
                    excursion.duracion = (int)accesoDatos.Lector["Duracion"];
                    excursion.Nombre = (string)accesoDatos.Lector["Nombre"];

                    excursiones.Add(excursion);
                }

                return excursiones;
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

        public List<Excursiones> ObtenerExcursionesPorDestinoIncluida(int cdgDestino)
        {
            List<Excursiones> excursiones = new List<Excursiones>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {

                accesoDatos.setearSp("ObtenerExcursionesIncluidas");

                accesoDatos.setearParametros("@cdgDestino", cdgDestino);
                accesoDatos.ejecutarLectura();


                while (accesoDatos.Lector.Read())
                {
                    Excursiones excursion = new Excursiones();

                    excursion.IdExcursion = (int)accesoDatos.Lector["IdExcursion"];
                    excursion.cdgDestino = (int)accesoDatos.Lector["cdgDestino"];
                  
                 
                    excursion.duracion = (int)accesoDatos.Lector["Duracion"];
                    excursion.Nombre = (string)accesoDatos.Lector["Nombre"];

                    excursiones.Add(excursion); 
                }

                return excursiones;
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

        public Excursiones ObtenerExcursionesPorId(int idExcursion)
        {
            Excursiones excursiones = new Excursiones();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("ObtenerExcursionesPorId");
                accesoDatos.setearParametros("@idExcursion", idExcursion);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    Excursiones aux = new Excursiones();

                    aux.IdExcursion = (int)accesoDatos.Lector["IdExcursion"];
                    aux.cdgDestino = (int)accesoDatos.Lector["cdgDestino"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    aux.Precio = (decimal)accesoDatos.Lector["Precio"];
                    aux.duracion = (int)accesoDatos.Lector["Duracion"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];

                    excursiones = aux;
                }

                accesoDatos.cerrarConexion();
                return excursiones;
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

        public void AgregarConSp(Excursiones nuevo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("insExcursiones");
                accesoDatos.setearParametros("@cdgDestino", nuevo.cdgDestino);
                accesoDatos.setearParametros("@Descripcion", nuevo.Descripcion);
                accesoDatos.setearParametros("@Precio", nuevo.Precio);
                accesoDatos.setearParametros("@Duracion", nuevo.duracion);
                accesoDatos.setearParametros("@Nombre", nuevo.Nombre);

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

        public void ModificarConSp(Excursiones modificado)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("updExcursiones");
                accesoDatos.setearParametros("@IdExcursion", modificado.IdExcursion);
                accesoDatos.setearParametros("@cdgDestino", modificado.cdgDestino);
                accesoDatos.setearParametros("@Descripcion", modificado.Descripcion);
                accesoDatos.setearParametros("@Precio", modificado.Precio);
                accesoDatos.setearParametros("@Duracion", modificado.duracion);
                accesoDatos.setearParametros("@Nombre", modificado.Nombre);

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

        public void EliminarConSp(int idExcursiones)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("DelExcursiones");
                accesoDatos.setearParametros("@IdExcursiones", idExcursiones);
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
