using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodigoAgroAdmin
{
    public partial class Empleado : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !((Dominio.Usuario)Session["usuario"]).TipoUsuario.Equals(Dominio.TipoUsuario.Admin) &&!((Dominio.Usuario)Session["usuario"]).TipoUsuario.Equals(Dominio.TipoUsuario.Normal))
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}