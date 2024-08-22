using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioFecha
    {

        public List<Fechas> ListarConSpPorMes(int mes)
        {
            List<Fechas> fechasactivas = new List<Fechas>();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("ObtenerFechaPorMes");
                accesoDatos.setearParametros("@mes", mes);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read()) 
                {
                    Fechas aux = new Fechas();

                    aux.idFecha = (int)accesoDatos.Lector["IdFecha"];
                    aux.FechaInicio = (DateTime)accesoDatos.Lector["fechainicio"];


                    fechasactivas.Add(aux);
                }   
                accesoDatos.cerrarConexion();
                return fechasactivas;
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
        public Fechas ObtenerFechaPorId (int idfecha)
        {
            Fechas fecha = new Fechas();
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setearSp("ObtenerFechaPorId");
                accesoDatos.setearParametros("@IdFecha", idfecha);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    fecha.FechaInicio = (DateTime)accesoDatos.Lector["FechaInicio"];

                }

                accesoDatos.cerrarConexion();
                return fecha;
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
