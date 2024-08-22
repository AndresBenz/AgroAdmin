using Dominio;
using Gestion_de_viajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioHotel
    {
        public List<Hotel> ListarConSp()
        {

            List<Hotel> listarHotel = new List<Hotel>();
            AccesoDatos AccesoDatos = new AccesoDatos();
            try
            {

                AccesoDatos.setearSp("SelHotelCompleto");
                AccesoDatos.ejecutarLectura();

                while (AccesoDatos.Lector.Read())
                {
                    Hotel aux = new Hotel();


                    aux.IdHotel = (int)AccesoDatos.Lector["IdHotel"];
                    aux.NombreHotel = (string)AccesoDatos.Lector["NombreHotel"];
                    aux.Descripcion = (string)AccesoDatos.Lector["Descripcion"];
                    aux.PrecioPorNoche = (decimal)AccesoDatos.Lector["PrecioPorNoche"];
                    aux.cdgDestino = (int)AccesoDatos.Lector["cdgDestino"];
                    aux.URLimagen = (string)AccesoDatos.Lector["URLimagen"];


        listarHotel.Add(aux);
                }

                AccesoDatos.cerrarConexion();
                return listarHotel;

            }


            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Hotel> SelHotelCompletoPorDestino(int cdgDestino)
        {
            List <Hotel> listarHotelDestino = new List<Hotel>();
            AccesoDatos accesoDatos= new AccesoDatos();


            try
            {
                accesoDatos.setearSp("SelHotelCompletoPorDestino");
                accesoDatos.setearParametros("@cdgDestino", cdgDestino);

                accesoDatos.ejecutarLectura();
                while(accesoDatos.Lector.Read())
                {
                     Hotel aux = new Hotel();

                    aux.IdHotel = (int)accesoDatos.Lector["IdHotel"];
                    aux.NombreHotel = (string)accesoDatos.Lector["NombreHotel"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    aux.PrecioPorNoche = (decimal)accesoDatos.Lector["PrecioPorNoche"];
                    aux.cdgDestino = (int)accesoDatos.Lector["cdgDestino"];
                    aux.URLimagen = accesoDatos.Lector["URLimagen"] is DBNull ? "https://icrier.org/wp-content/uploads/2022/09/Event-Image-Not-Found.jpg" : (string)accesoDatos.Lector["URLimagen"];




                    listarHotelDestino.Add(aux);

                }
                accesoDatos.cerrarConexion();
                return listarHotelDestino;

            }
            catch (Exception ex )
            {

                throw ex;
            }




        }

        public Hotel ObtenerHotelPorId(int idHotel)
        {
            Hotel hotel = new Hotel();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("ObtenerHotelPorId");
                accesoDatos.setearParametros("@IdHotel", idHotel);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    Hotel aux = new Hotel();

                    aux.IdHotel = (int)accesoDatos.Lector["IdHotel"];
                    aux.NombreHotel = (string)accesoDatos.Lector["NombreHotel"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    aux.PrecioPorNoche = (decimal)accesoDatos.Lector["PrecioPorNoche"];
                    aux.cdgDestino = (int)accesoDatos.Lector["cdgDestino"];
                    aux.URLimagen = accesoDatos.Lector["URLimagen"] is DBNull ? "https://icrier.org/wp-content/uploads/2022/09/Event-Image-Not-Found.jpg" : (string)accesoDatos.Lector["URLimagen"];
                    hotel = aux;
                }

                accesoDatos.cerrarConexion();
                return hotel;
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

        public void AgregarConSp (Hotel nuevo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("insHotel");
                accesoDatos.setearParametros("@NombreHotel", nuevo.NombreHotel);
                accesoDatos.setearParametros("@Descripcion", nuevo.Descripcion);
                accesoDatos.setearParametros("@PrecioPorNoche", nuevo.PrecioPorNoche);
                accesoDatos.setearParametros("@cdgDestino", nuevo.cdgDestino);
                accesoDatos.setearParametros("@URLimagen", nuevo.URLimagen);

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

        public void ModificarConSp(Hotel Modificado)
        {

            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("updHotel");
                accesoDatos.setearParametros("@idHotel", Modificado.IdHotel);
                accesoDatos.setearParametros("@NombreHotel", Modificado.NombreHotel);
                accesoDatos.setearParametros("@Descripcion", Modificado.Descripcion);
                accesoDatos.setearParametros("@PrecioPorNoche", Modificado.PrecioPorNoche);
                accesoDatos.setearParametros("@cdgDestino", Modificado.cdgDestino);
                accesoDatos.setearParametros("@URLimagen", Modificado.URLimagen);


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
        public void EliminarConSp(int idHotel)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("DelHotel");
                accesoDatos.setearParametros("@IdHotel", idHotel);
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
