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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    Usuario nuevo = new Usuario();
                    RepositorioUsuario repoUsuario = new RepositorioUsuario();
                    nuevo.NombreUsuario = txtUsuarioRegistro.Text;
                    nuevo.CorreoElectronico = txtEmailRegistro.Text;
                    nuevo.DNI = int.Parse(txtDNIRegistro.Text);
                    nuevo.Telefono = txtTelefonoRegistro.Text;
                    int tipo = int.Parse(ddlTipoUsuario.SelectedValue);
                    nuevo.TipoUsuario = (TipoUsuario)tipo;

                    repoUsuario.InsUsuario(nuevo);

                    lblMensajeRegistro.Text = "Registro exitoso. Ahora puede iniciar sesión.";
                    lblMensajeRegistro.ForeColor = System.Drawing.Color.Green;
                    lblMensajeRegistro.Visible = true;

                    // Limpiar los campos de entrada
                    txtUsuarioRegistro.Text = string.Empty;
                    txtEmailRegistro.Text = string.Empty;
                    txtDNIRegistro.Text = string.Empty;
                    txtTelefonoRegistro.Text = string.Empty;

                }
                catch (Exception ex)
                {
                    lblMensajeRegistro.Text = "Error al registrar usuario. " + ex.Message;
                    lblMensajeRegistro.ForeColor = System.Drawing.Color.Red;
                    lblMensajeRegistro.Visible = true;
                }
            }
        }
    }
}
    
