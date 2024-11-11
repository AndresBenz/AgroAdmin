using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Funcionalidades;

namespace CodigoAgroAdmin
{
    public partial class PantallaEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RepositorioProducto repProductos = new RepositorioProducto();
            string busqueda = txtBuscar.Text.Trim();
            Producto producto = null;

            if (int.TryParse(busqueda, out int idProducto))
            {

                producto = repProductos.ObtenerProductoPorId(idProducto);
            }
            else
            {

                producto = repProductos.ObtenerProductoPorId(null, busqueda);
            }

        }

        protected void btnAgregarCarrito_Command(object sender, CommandEventArgs e)
        {

            string idProducto = e.CommandArgument.ToString();
            Response.Write("Producto agregado al carrito con ID: " + idProducto);

        }

        protected void btnVerDetalles_Command(object sender, CommandEventArgs e)
        {
            int idProducto = Convert.ToInt32(e.CommandArgument);
            Response.Redirect($"DetallesProducto.aspx?IdProducto={idProducto}");
        }
        private void CargarProductos()
        {
            RepositorioProducto repositorio = new RepositorioProducto();
            var productos = repositorio.ListarConSp();
            RepeaterProductos.DataSource = productos;
            RepeaterProductos.DataBind();
        }
    }
}
