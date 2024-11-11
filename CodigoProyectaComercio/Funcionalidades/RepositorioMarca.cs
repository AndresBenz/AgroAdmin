using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioMarca
    {
        public List<Marca> ListarConSp()
        {
            List<Marca> listarMarcas = new List<Marca>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelMarcas");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Marca aux = new Marca();

                    aux.IdMarca = (int)accesoDatos.Lector["IdMarca"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];

                    listarMarcas.Add(aux);
                }

                accesoDatos.cerrarConexion();
                return listarMarcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
