using Dominio;
using Funcionalidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodigoAgroAdmin
{
    public partial class GestionMarca : System.Web.UI.Page
    {
        RepositorioMarca repoMarca = new RepositorioMarca();
        private int idMarcaSeleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MostrarLista();
            }
        }

        private void CargarMarcas()
        {
            var marcas = repoMarca.ListarConSp();
            gvMarcas.DataSource = marcas;
            gvMarcas.DataBind();
        }

        private void MostrarLista()
        {
            divListaMarcas.Visible = true;
            divEditarMarca.Visible = false;
            CargarMarcas();
        }

        private void MostrarFormulario()
        {
            divListaMarcas.Visible = false;
            divEditarMarca.Visible = true;
        }


        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {

            LimpiarFormulario();
            ViewState["IdMarcaSeleccionada"] = null;
            MostrarFormulario();
        }

        protected void gvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idMarca = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Modificar")
            {
                var marca = repoMarca.SelMarcaPorId(idMarca);

                if (marca != null)
                {

                    ViewState["IdMarcaSeleccionada"] = idMarca;



                    txtNombreEditar.Text = marca.Nombre;
                    chkActivoEditar.Checked = marca.Activo;

                    MostrarFormulario();
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                repoMarca.EliminarMarca(idMarca);
                CargarMarcas();
            }
        }


        protected void btnGuardarEditarMarca_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string nombre = txtNombreEditar.Text.Trim();
            bool activo = chkActivoEditar.Checked;


            int idMarcaSeleccionada = (int)(ViewState["IdMarcaSeleccionada"] ?? 0);

            if (!string.IsNullOrEmpty(nombre))
            {
                if (idMarcaSeleccionada > 0)
                {
                    repoMarca.ModificarMarca(idMarcaSeleccionada, nombre, activo);
                }
                else
                {
                    repoMarca.AgregarMarca(nombre, activo);
                }

                MostrarLista();
            }
            }
            else
            {
                lblErrorEditar.Visible = true;
            }

        }


        protected void btnCancelarEditar_Click(object sender, EventArgs e)
        {
            MostrarLista();

        }

        private void LimpiarFormulario()
        {
            txtNombreEditar.Text = string.Empty;
            chkActivoEditar.Checked = false;
            lblErrorEditar.Visible = false;
        }
    }

}