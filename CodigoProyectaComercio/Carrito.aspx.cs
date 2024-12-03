using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Funcionalidades; 

namespace CodigoProyectaComercio
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
           
            int idProducto = Convert.ToInt32(e.CommandArgument);

       
        }


    }
}
