using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Funcionalidades;

namespace CodigoAgroAdmin
{
    public partial class Inicio : System.Web.UI.Page
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
            RepositorioProducto repositorio = new RepositorioProducto();
            var productos = repositorio.ListarConSp();
            RepeaterProductos.DataSource = productos;
            RepeaterProductos.DataBind();
        }
    }
}