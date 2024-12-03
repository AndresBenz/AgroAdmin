using Funcionalidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodigoAgroAdmin
{
    public partial class GestionUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            RepositorioUsuario repo = new RepositorioUsuario();
            gvUsuarios.DataSource = repo.ListarConSp();
            gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idUsuario = Convert.ToInt32(e.CommandArgument);
            RepositorioUsuario repo = new RepositorioUsuario();

            if (e.CommandName == "Modificar")
            {
             
                Response.Redirect($"ModificarUsuario.aspx?idUsuario={idUsuario}");
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    
                    repo.EliminarUsuario(idUsuario);
                    CargarUsuarios(); 
                    lblMensaje.Text = "Usuario eliminado exitosamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    
                    lblMensaje.Text = "Error al eliminar usuario: " + ex.Message;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}