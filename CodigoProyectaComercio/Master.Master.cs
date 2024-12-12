using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodigoAgroAdmin
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           /* if (Session["usuario"] == null || ((Dominio.Usuario)Session["usuario"]).TipoUsuario != Dominio.TipoUsuario.Admin)
            {
                Response.Redirect("~/Login.aspx");
            }*/
        }
    }
}