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
    public partial class InicioEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductosBajoStock();
            }
        }


        private void CargarProductosBajoStock()
        {
            try
            {
                RepositorioProducto repositorioProducto = new RepositorioProducto();
                List<Producto> productosBajoStock = repositorioProducto.ListarProductosBajoStock();

                gvProductosBajoStock.DataSource = productosBajoStock;
                gvProductosBajoStock.DataBind();
            }
            catch (Exception ex)
            {
                
                lblError.Text = "Error al cargar los productos: " + ex.Message;
            }
        }

        protected void gvProductosBajoStock_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               

                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red; 
                
            }
        }
    }
}