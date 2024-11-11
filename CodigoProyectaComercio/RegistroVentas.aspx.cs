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
    public partial class RegistroVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDetallesVenta();
            }
        }


        private void CargarDetallesVenta()
        {
            RepositorioDetalleVenta repositorio = new RepositorioDetalleVenta();
            List<DetalleVenta> detallesVenta = repositorio.ListarConSp();

            GridViewDetallesVenta.DataSource = detallesVenta;
            GridViewDetallesVenta.DataBind();
        }
    }
}