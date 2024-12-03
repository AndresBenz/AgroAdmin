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
                CargarMarcas();
            }
        }

        private void CargarMarcas()
        {
            var marcas = repoMarca.ListarConSp();
            gvMarcas.DataSource = marcas;
            gvMarcas.DataBind();
        }

        protected void gvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idMarca = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Modificar")
            {
                var marca = repoMarca.SelMarcaPorId(idMarca);

                if (marca != null)
                {
                    idMarcaSeleccionada = idMarca;
                    ViewState["IdMarcaSeleccionada"] = idMarca; 
                    divEditarMarca.Visible = true;

                    
                    txtNombreEditar.Text = marca.Nombre;
                    chkActivoEditar.Checked = marca.Activo; 
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
            string nombre = txtNombreEditar.Text.Trim();
            bool activo = chkActivoEditar.Checked;

           
            int idMarcaSeleccionada = (int)(ViewState["IdMarcaSeleccionada"] ?? 0);

            if (idMarcaSeleccionada > 0 && !string.IsNullOrEmpty(nombre))
            {
               
                repoMarca.ModificarMarca(idMarcaSeleccionada, nombre, activo);

                
                CargarMarcas();
                divEditarMarca.Visible = false;

               
                txtNombreEditar.Text = string.Empty;
                chkActivoEditar.Checked = false;
                lblErrorEditar.Visible = false; 
            }
            else
            {
                lblErrorEditar.Visible = true; 
            }
        }

       
        protected void btnCancelarEditar_Click(object sender, EventArgs e)
        {
            divEditarMarca.Visible = false;  

            txtNombreEditar.Text = string.Empty;
            chkActivoEditar.Checked = false;
        }
    }

}