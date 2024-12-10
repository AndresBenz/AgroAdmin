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
                CargarVentas();
            }
        }


        private void CargarVentas()
        {
            RepositorioVenta repositorio = new RepositorioVenta();
            List<Venta> Venta = repositorio.ListarConSp();
            Session["Ventas"] = Venta;

            GridViewVentas.DataSource = Venta;
            GridViewVentas.DataBind();

            PanelVentas.Visible = true;
            PanelDetallesVenta.Visible = false;
        }


        protected void GridViewVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                int idVenta = Convert.ToInt32(e.CommandArgument);

                CargarDetallesVenta(idVenta);

                PanelVentas.Visible = false;
                PanelDetallesVenta.Visible = true;
            }
        }

        protected void GridViewVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List<Venta> ventas = (List<Venta>)Session["Ventas"];

            GridViewVentas.PageIndex = e.NewPageIndex;

            GridViewVentas.DataSource = ventas;
            GridViewVentas.DataBind();
        }


        private void CargarDetallesVenta(int idVenta)
        {
            RepositorioDetalleVenta repositorio = new RepositorioDetalleVenta();
            List<DetalleVenta> detalles = repositorio.ListarPorVenta(idVenta);

            GridViewDetallesVenta.DataSource = detalles;
            GridViewDetallesVenta.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            PanelVentas.Visible = true;
            PanelDetallesVenta.Visible = false;
        }
    }
}
