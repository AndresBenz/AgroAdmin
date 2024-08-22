using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;
using Gestion_de_viajes;

namespace Funcionalidades 
{
    public class RepositorioPaquete
    {

        public List<PaqueteDeViaje> ListarConSp()
        {

            List<PaqueteDeViaje> listarPaquete = new List<PaqueteDeViaje>();
            AccesoDatos AccesoDatos = new AccesoDatos();
            try
            {

                AccesoDatos.setearSp("SelPaqueteCompleto");
                AccesoDatos.ejecutarLectura();

                while (AccesoDatos.Lector.Read())
                {
                    PaqueteDeViaje aux = new PaqueteDeViaje();


                    aux.IdPaquete = (int)AccesoDatos.Lector["IdPaquete"];
                    aux.cdgDestino = (int)AccesoDatos.Lector["cdgDestino"];
                    aux.NombrePaquete = (string)AccesoDatos.Lector["NombrePaquete"];
                    aux.Descripcion = (string)AccesoDatos.Lector["Descripcion"];
                    aux.PrecioPaquete = (decimal)AccesoDatos.Lector["PrecioPaquete"];
                    aux.Mes = (int)AccesoDatos.Lector["Mes"];
                    aux.Duracion = (int)AccesoDatos.Lector["Duracion"];
                    aux.TipoTransporte = (int)AccesoDatos.Lector["TipoTransporte"];
                    if (AccesoDatos.Lector["URLimagen"] is DBNull) {
                        aux.URLimagen = "https://icrier.org/wp-content/uploads/2022/09/Event-Image-Not-Found.jpg";
                        
                    } else {
                        aux.URLimagen = (string)AccesoDatos.Lector["URLimagen"];
                    }
                    aux.Disponibilidad = (int)AccesoDatos.Lector["Disponibilidad"];
                   



                    ////Aux para Hotel
                    //aux.IdHotel = new Hotel();
                    //aux.IdHotel.IdHotel = (int)AccesoDatos.Lector[""];
                    //aux.IdHotel.NombreHotel = (string)AccesoDatos.Lector[""];
                    //aux.IdHotel.Descripcion = (string)AccesoDatos.Lector[""];

                    listarPaquete.Add(aux);
                }

                AccesoDatos.cerrarConexion();
                return listarPaquete;

            }


            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<PaqueteDeViaje> ListarConSp(int tipoTransporte,  int? mes = null)
        {
            List<PaqueteDeViaje> listarPaquete = new List<PaqueteDeViaje>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelPaqueteCompleto");


               
                accesoDatos.setearParametros("@TipoTransporte", tipoTransporte);
                if (mes.HasValue)
                {
                    accesoDatos.setearParametros("@Mes", mes.Value);
                }

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    PaqueteDeViaje aux = new PaqueteDeViaje();

                    aux.IdPaquete = (int)accesoDatos.Lector["IdPaquete"];
                    aux.cdgDestino = (int)accesoDatos.Lector["cdgDestino"];
                    aux.NombrePaquete = (string)accesoDatos.Lector["NombrePaquete"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    aux.PrecioPaquete = (decimal)accesoDatos.Lector["PrecioPaquete"];
                    aux.Mes = (int)accesoDatos.Lector["Mes"];
                    aux.Duracion = (int)accesoDatos.Lector["Duracion"];
                    aux.TipoTransporte = (int)accesoDatos.Lector["TipoTransporte"];
                    aux.URLimagen = accesoDatos.Lector["URLimagen"] is DBNull ? "https://icrier.org/wp-content/uploads/2022/09/Event-Image-Not-Found.jpg" : (string)accesoDatos.Lector["URLimagen"];
                    

                    listarPaquete.Add(aux);
                }

                accesoDatos.cerrarConexion();
                return listarPaquete;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PaqueteDeViaje ObtenerPaquetePorId(int idPaquete)
        {
            PaqueteDeViaje paquete = new PaqueteDeViaje();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("ObtenerPaquetePorId");
                accesoDatos.setearParametros("@IdPaquete", idPaquete);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    PaqueteDeViaje aux = new PaqueteDeViaje();


                    aux.IdPaquete = (int)accesoDatos.Lector["IdPaquete"];
                    aux.cdgDestino = (int)accesoDatos.Lector["cdgDestino"];
                    aux.NombrePaquete = (string)accesoDatos.Lector["NombrePaquete"];
                    aux.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    aux.PrecioPaquete = (decimal)accesoDatos.Lector["PrecioPaquete"];
                    aux.Mes = (int)accesoDatos.Lector["Mes"];
                    aux.Duracion = (int)accesoDatos.Lector["Duracion"];
                    aux.TipoTransporte = (int)accesoDatos.Lector["TipoTransporte"];
                    aux.URLimagen = accesoDatos.Lector["URLimagen"] is DBNull ? "https://icrier.org/wp-content/uploads/2022/09/Event-Image-Not-Found.jpg" : (string)accesoDatos.Lector["URLimagen"];
                    aux.Disponibilidad = (int)accesoDatos.Lector["Disponibilidad"];
                    paquete = aux;
                }

                accesoDatos.cerrarConexion();
                return paquete;
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
        public void AgregarConSp (PaqueteDeViaje nuevo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("insPaquete");
                accesoDatos.setearParametros("@cdgDestino", nuevo.cdgDestino);
                accesoDatos.setearParametros("@NombrePaquete", nuevo.NombrePaquete);
                accesoDatos.setearParametros("@Descripcion", nuevo.Descripcion);
                accesoDatos.setearParametros("@PrecioPaquete", nuevo.PrecioPaquete);
                accesoDatos.setearParametros("@Mes", nuevo.Mes);
                accesoDatos.setearParametros("@Duracion", nuevo.Duracion);
                accesoDatos.setearParametros("@TipoTransporte", nuevo.TipoTransporte);
                accesoDatos.setearParametros("@URLimagen", nuevo.URLimagen);
                accesoDatos.setearParametros("@Disponibilidad", nuevo.Disponibilidad);
                
                accesoDatos.ejecutarAccion();



            }
            catch (Exception EX )
            {

                throw EX;
            }

            finally
            {
                accesoDatos.cerrarConexion();
            }



        }

        public void ModificarConSp(PaqueteDeViaje modificado)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("updPaquetes");
                accesoDatos.setearParametros("@cdgDestino", modificado.cdgDestino);
                accesoDatos.setearParametros("@NombrePaquete", modificado.NombrePaquete);
                accesoDatos.setearParametros("@Descripcion", modificado.Descripcion);
                accesoDatos.setearParametros("@PrecioPaquete", modificado.PrecioPaquete);
                accesoDatos.setearParametros("@Mes", modificado.Mes);
                accesoDatos.setearParametros("@Duracion", modificado.Duracion);
                accesoDatos.setearParametros("@TipoTransporte", modificado.TipoTransporte);
                accesoDatos.setearParametros("@URLimagen", modificado.URLimagen);
                accesoDatos.setearParametros("@Disponibilidad", modificado.Disponibilidad);
                accesoDatos.setearParametros("@IdPaquete", modificado.IdPaquete);

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
        public void EliminarConSp(int idPaquete)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("DelPaquete");
                accesoDatos.setearParametros("@IdPaquete", idPaquete);
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



        public void EliminarLogicoPorMes(int mes, bool activo)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearConsulta("UPDATE MES SET Activo = @Activo WHERE IdMes = @IdMes");
                accesoDatos.setearParametros("@IdMes", mes);
                accesoDatos.setearParametros("@Activo", activo );
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




    

