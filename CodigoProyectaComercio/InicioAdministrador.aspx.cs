using Funcionalidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodigoAgroAdmin
{
    public partial class InicioAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RepositorioVenta repoVenta = new RepositorioVenta();
                decimal totalVentas = repoVenta.ObtenerTotalVentasMes();
                lblTotalVentas.Text = "$" + totalVentas.ToString("N2");

                RepositorioCliente repoCliente = new RepositorioCliente();
                int totalClientes = repoCliente.ObtenerTotalClientes();
                lblTotalClientes.Text = totalClientes.ToString();

                RepositorioProducto repoProducto = new RepositorioProducto();
                int totalProductos = repoProducto.ObtenerTotalProductosEnStock();
                lblTotalProductos.Text = totalProductos.ToString();

                RepositorioProveedor repoProveedor = new RepositorioProveedor();
                int totalProveedores = repoProveedor.ObtenerTotalProveedoresActivos();
                lblTotalProveedores.Text = totalProveedores.ToString();

            }
        }
    }
}