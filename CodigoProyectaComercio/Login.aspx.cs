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
    public partial class Log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["usuario"] != null)
            {
                Response.Redirect("Perfil.aspx", false);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            RepositorioUsuario repousuario = new RepositorioUsuario();

            try
            {
              
                usuario = new Usuario(txtCorreoLogin.Text, int.Parse(txtDNILogin.Text), false);

              
                if (repousuario.Loguear(usuario))
                {
               
                    Session.Add("usuario", usuario);
                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
       
                    lblmensajeLogin.Text = "Usuario o contraseña incorrecta";
                    lblmensajeLogin.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
            
                lblmensajeLogin.Text = "Error: " + ex.Message;
                lblmensajeLogin.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}