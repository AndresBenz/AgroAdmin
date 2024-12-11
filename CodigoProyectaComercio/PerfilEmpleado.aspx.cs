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
    public partial class PerfilEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["usuario"] != null)
                {
                    Usuario usuarioSesion = (Usuario)Session["usuario"];

                    RepositorioUsuario repositorio = new RepositorioUsuario();
                    Usuario usuario = repositorio.ObtenerUsuarioPorId(usuarioSesion.IdUsuario);


                    MostrarDetallesUsuario(usuario);

                }
                else
                {

                    Response.Redirect("Login.aspx");
                }
            }


        }
        private void MostrarDetallesUsuario(Usuario usuario)
        {

            lblIdUsuario.Text = usuario.IdUsuario.ToString();
            lblDNI.Text = usuario.DNI.ToString();
            lblNombre.Text = usuario.NombreUsuario;
            lblCorreoElectronico.Text = usuario.CorreoElectronico;
            lblTelefono.Text = usuario.Telefono;
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}