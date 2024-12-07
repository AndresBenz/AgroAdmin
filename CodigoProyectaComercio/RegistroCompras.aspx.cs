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
    public partial class RegistroCompras : System.Web.UI.Page
    {
        private RepositorioCompra repositorioCompra;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                repositorioCompra = new RepositorioCompra();
                CargarCompras();
            }

        }

        private void CargarCompras()
        {
            repositorioCompra = new RepositorioCompra();
            List<Compra> compras = repositorioCompra.ListarCompras();
            gvCompras.DataSource = compras;
            gvCompras.DataBind();
        }

        protected void gvCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                int idCompra = Convert.ToInt32(e.CommandArgument);
                CargarDetallesCompra(idCompra);

                PanelCompras.Visible = false;
                PanelDetallesCompra.Visible = true;
            }
        }

        private void CargarDetallesCompra(int idCompra)
        {
            if (repositorioCompra == null)
            {
                repositorioCompra = new RepositorioCompra(); 
            }

            List<DetalleCompra> detalles = repositorioCompra.ListarDetallesCompra(idCompra);
            gvDetallesCompra.DataSource = detalles;
            gvDetallesCompra.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
         
            PanelCompras.Visible = true;
            PanelDetallesCompra.Visible = false;
        }
    }
}