using Dominio;
using Funcionalidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodigoAgroAdmin
{

    public partial class GestionCategoria : System.Web.UI.Page
    {
        private RepositorioCategoria repositorioCategoria = new RepositorioCategoria();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarLista();

                CargarCategorias();
            }
        }

        private void CargarCategorias()
        {
            try
            {

                List<Categoria> categorias = repositorioCategoria.ListarConSp();


                if (categorias != null && categorias.Count > 0)
                {

                    gvCategorias.DataSource = categorias;
                    gvCategorias.DataBind();
                }
                else
                {
                    lblMensaje.Text = "No se encontraron categorías.";
                    lblMensaje.CssClass = "text-warning";
                }
            }
            catch (Exception ex)
            {

                lblMensaje.Text = "Error al cargar las categorías: " + ex.Message;
                lblMensaje.CssClass = "text-danger";
            }
        }

        protected void btnAgregarNueva_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            
            MostrarFormulario();
        }

        protected void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria nuevaCategoria = new Categoria
                {
                    Nombre = txtNombreCategoria.Text,
                    Activo = chkActivo.Checked
                };

                if (!string.IsNullOrEmpty(hfIdCategoria.Value))
                {
                    nuevaCategoria.IdCategoria = Convert.ToInt32(hfIdCategoria.Value);
                    repositorioCategoria.EditarCategoria(nuevaCategoria);
                    lblMensaje.Text = "Categoría modificada correctamente.";
                }
                else
                {
                    repositorioCategoria.AgregarCategoria(nuevaCategoria);
                    lblMensaje.Text = "Categoría agregada correctamente.";
                }

                lblMensaje.CssClass = "text-success";

                LimpiarFormulario();
                MostrarLista();
                CargarCategorias();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al procesar la categoría: " + ex.Message;
                lblMensaje.CssClass = "text-danger";
            }
        }

        protected void gvCategorias_RowCommand(object source, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarCategoria")
            {
                int idCategoria = Convert.ToInt32(e.CommandArgument);


                Categoria categoria = repositorioCategoria.ObtenerPorId(idCategoria);

                if (categoria != null)
                {

                    hfIdCategoria.Value = categoria.IdCategoria.ToString();
                    txtNombreCategoria.Text = categoria.Nombre;
                    chkActivo.Checked = categoria.Activo;

                    btnGuardarCategoria.Text = "Guardar Cambios";
                    MostrarFormulario();
                }
            }
            else if (e.CommandName == "EliminarCategoria")
            {
                int idCategoria = Convert.ToInt32(e.CommandArgument);
                repositorioCategoria.EliminarCategoria(idCategoria);

                lblMensaje.Text = "Categoría eliminada correctamente.";
                lblMensaje.CssClass = "text-success";

                CargarCategorias();
            }

        }


        protected void btnVolver_Click(object sender, EventArgs e)
        {
            
            LimpiarFormulario();
            MostrarLista();
        }

        private void MostrarFormulario()
        {
            divFormulario.Visible = true;
            divLista.Visible = false;
        }

        private void MostrarLista()
        {
            divFormulario.Visible = false;
            divLista.Visible = true;
        }

        private void LimpiarFormulario()
        {
            hfIdCategoria.Value = string.Empty;
            txtNombreCategoria.Text = string.Empty;
            chkActivo.Checked = false;
            btnGuardarCategoria.Text = "Agregar Categoría";
        }

    }
}
