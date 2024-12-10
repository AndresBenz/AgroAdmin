using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Funcionalidades
{
    public class AccesoDatos
    {

        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {

         conexion = new SqlConnection("server= DESKTOP-BCI06CT\\SQLEXPRESS; database=PROYECTACOMERCIO; Integrated Security = True");



            comando = new SqlCommand();
        }
        public void setearSp(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;

        }


        public void resetearComando()
        {
            if (comando != null)
            {
                comando.Parameters.Clear();
                comando.CommandText = string.Empty;
            }
        }


        public void abrirConexion()
        {
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
        }



        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
        public void setearParametros(string nombre, object valor)
        {

            comando.Parameters.AddWithValue(nombre, valor);
        }
        
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                // Solo abre la conexión si no está ya abierta
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }












    }
}
