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
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idUsuario;
                if (int.TryParse(Request.QueryString["idUsuario"], out idUsuario))
                {
                    CargarUsuario(idUsuario);
                }
                else
                {
                    lblMensaje.Text = "Usuario no encontrado.";
                }
            }
        }

        private void CargarUsuario(int idUsuario)
        {
            RepositorioUsuario repo = new RepositorioUsuario();
            Usuario usuario = repo.ObtenerUsuarioPorId(idUsuario);

            if (usuario != null)
            {
                txtUsuario.Text = usuario.NombreUsuario;
                txtEmail.Text = usuario.CorreoElectronico;
                txtDNI.Text = usuario.DNI.ToString();
                txtTelefono.Text = usuario.Telefono;
                ddlTipoUsuario.SelectedValue = ((int)usuario.TipoUsuario).ToString();
            }
            else
            {
                lblMensaje.Text = "El usuario no existe.";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int idUsuario = int.Parse(Request.QueryString["idUsuario"]);
                RepositorioUsuario repo = new RepositorioUsuario();

                Usuario usuario = new Usuario
                {
                    IdUsuario = idUsuario,
                    NombreUsuario = txtUsuario.Text,
                    CorreoElectronico = txtEmail.Text,
                    DNI = int.Parse(txtDNI.Text),
                    Telefono = txtTelefono.Text,
                    TipoUsuario = (TipoUsuario)int.Parse(ddlTipoUsuario.SelectedValue)
                };

                repo.ModificarUsuario(usuario);
                lblMensaje.Text = "Usuario actualizado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar el usuario: " + ex.Message;
            }
        }
    }
}
