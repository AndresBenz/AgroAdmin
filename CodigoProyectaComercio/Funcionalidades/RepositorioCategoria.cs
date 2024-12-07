using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionalidades
{
    public class RepositorioCategoria
    {

        public List<Categoria> ListarConSp()
        {
            List<Categoria> listarCategorias = new List<Categoria>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelCategorias");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)accesoDatos.Lector["IdCategoria"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Activo = (bool)accesoDatos.Lector["Activo"];

                    listarCategorias.Add(aux);
                }

                accesoDatos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las categorías: " + ex.Message);
            }

            return listarCategorias;
        }


        public List<Categoria> ListarConSpActivas()
        {
            List<Categoria> listarCategorias = new List<Categoria>();
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("SelCategoriasActivas");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)accesoDatos.Lector["IdCategoria"];
                    aux.Nombre = (string)accesoDatos.Lector["Nombre"];
                    aux.Activo = (bool)accesoDatos.Lector["Activo"];

                    listarCategorias.Add(aux);
                }

                accesoDatos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las categorías: " + ex.Message);
            }

            return listarCategorias;
        }


        public void AgregarCategoria(Categoria categoria)
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                try
                {
                    accesoDatos.setearSp("insCategoria");

                    accesoDatos.setearParametros("@Nombre", categoria.Nombre);
                    accesoDatos.setearParametros("@Activo", categoria.Activo);

                    accesoDatos.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar la categoría", ex);
                }
                finally
                {
                    accesoDatos.cerrarConexion();
                }
            }

        public void EliminarCategoria(int idCategoria)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("DelCategoria");
                accesoDatos.setearParametros("@IdCategoria", idCategoria);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la categoría", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }


        public Categoria ObtenerPorId(int idCategoria)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            Categoria categoria = null;

            try
            {
                accesoDatos.setearSp("sp_ObtenerCategoriaPorId");
                accesoDatos.setearParametros("@IdCategoria", idCategoria);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    categoria = new Categoria
                    {
                        IdCategoria = (int)accesoDatos.Lector["IdCategoria"],
                        Nombre = (string)accesoDatos.Lector["Nombre"],
                        Activo = (bool)accesoDatos.Lector["Activo"]
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la categoría por ID", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }

            return categoria;
        }


        public void EditarCategoria(Categoria categoria)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearSp("updCategoria");

                accesoDatos.setearParametros("@IdCategoria", categoria.IdCategoria);
                accesoDatos.setearParametros("@Nombre", categoria.Nombre);
                accesoDatos.setearParametros("@Activo", categoria.Activo);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la categoría", ex);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

    }
    }
