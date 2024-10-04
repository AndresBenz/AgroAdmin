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
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

         private void CargarProductos()
        {
            RepositorioProductos repo = new RepositorioProductos();

            // Obtener la lista de productos
            List<Productos> productos = repo.ListarProductosConSp();

            // Enlazar los productos al GridView
            gvProductos.DataSource = productos;
            gvProductos.DataBind();
        }
    }
}
}