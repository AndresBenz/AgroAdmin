using Dominio;
using Gestion_de_viajes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioReserva
    {


        public List<Reserva> ListarConSp()
        {

            List<Reserva> listarReserva = new List<Reserva>();
            AccesoDatos AccesoDatos = new AccesoDatos();
            try
            {

                AccesoDatos.setearSp("SelReservaCompleto");
                AccesoDatos.ejecutarLectura();

                while (AccesoDatos.Lector.Read())
                {
                    Reserva aux = new Reserva();


                    aux.IdReserva = (int)AccesoDatos.Lector["IdReserva"];
                    aux.DNIUsuario = (int)AccesoDatos.Lector["DNI"];
                    aux.estado = (int)AccesoDatos.Lector["EstadoReserva"];
                    aux.Precio = (decimal)AccesoDatos.Lector["Precio"];
                    aux.IdPaquete = (int)AccesoDatos.Lector["IdPaquete"];


                    listarReserva.Add(aux);
                }

                AccesoDatos.cerrarConexion();
                return listarReserva;

            }


            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void AgregarConSp(Reserva nuevo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("insReserva");
                accesoDatos.setearParametros("@DNI", nuevo.DNIUsuario);
                accesoDatos.setearParametros("@EstadoReserva", nuevo.estado);
                accesoDatos.setearParametros("@IdPaquete", nuevo.IdPaquete);
                accesoDatos.setearParametros("@IdHotel", nuevo.idHotel);
                accesoDatos.setearParametros("@Precio", nuevo.Precio);
                accesoDatos.setearParametros("@FechaInicio", nuevo.FechaInicio);

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
        public Reserva ObtenerReservaPorId(int idReserva)
        {
            Reserva reserva = new Reserva();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("ObtenerReservaPorId");
                accesoDatos.setearParametros("@IdReserva", idReserva);
                accesoDatos.ejecutarLectura();
                List<Reserva> listReserva = new List<Reserva>();
                while (accesoDatos.Lector.Read())
                {
                    Reserva aux = new Reserva();

                    aux.IdReserva = (int)accesoDatos.Lector["IdReserva"];
                    aux.DNIUsuario = (int)accesoDatos.Lector["DNI"];
                    aux.estado = (int)accesoDatos.Lector["EstadoReserva"];
                    aux.IdPaquete = (int)accesoDatos.Lector["IdPaquete"];
                    aux.idHotel = (int)accesoDatos.Lector["IdHotel"];
                    aux.Precio = (decimal)accesoDatos.Lector["Precio"];
                    aux.FechaInicio = (DateTime)accesoDatos.Lector["FechaInicio"];
                    listReserva.Add(aux);
                    //reserva = aux;
                }
                    accesoDatos.cerrarConexion();
                return reserva;
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
        public List<ReservaFinal>  ObtenerReservaPorDNI(int DNI)
        {
            Reserva reserva = new Reserva();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("ObtenerReservaPorDNI");
                accesoDatos.setearParametros("@DNI", DNI);
                accesoDatos.ejecutarLectura();
                List<ReservaFinal> listReserva = new List<ReservaFinal>();
                while (accesoDatos.Lector.Read())
                {
                    ReservaFinal aux = new ReservaFinal();

                    aux.IdReserva = (int)accesoDatos.Lector["IdReserva"];
                    aux.DNIUsuario = (int)accesoDatos.Lector["DniUsuario"];
                    aux.estado = (int)accesoDatos.Lector["EstadoReserva"];
                    aux.IdPaquete = (int)accesoDatos.Lector["IdPaquete"];
                    aux.NombrePaquete= (string)accesoDatos.Lector["NombrePaquete"];
                    aux.idHotel = (int)accesoDatos.Lector["IdHotel"];
                    aux.nombreHotel = (string)accesoDatos.Lector["NombreHotel"];
                    aux.Precio = (decimal)accesoDatos.Lector["Precio"];
                    aux.FechaInicio = (DateTime)accesoDatos.Lector["FechaInicio"];
                    aux.cdgdestino= (int)accesoDatos.Lector["cdgDestino"];

                    listReserva.Add(aux);
                    //reserva = aux;

                }

                accesoDatos.cerrarConexion();
              
                return listReserva;
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
        public int ObtenerUltimoRegistro()
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            int IdReserva = 0; // ultimo id 
            try
            {
                accesoDatos.setearSp("ObtenerUltimoRegistroReserva");
                accesoDatos.ejecutarLectura();


                if (accesoDatos.Lector.Read())
                {

                    IdReserva = (int)accesoDatos.Lector["IdReserva"];

                }
                return IdReserva;


            }


            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void updEstadoReserva(int idReserva,int idPaquete)
        {
            
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("updEstadoReserva");
                accesoDatos.setearParametros("@IdReserva", idReserva);
                accesoDatos.setearParametros("@IdPaquete", idPaquete);
                accesoDatos.ejecutarLectura();

               
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
