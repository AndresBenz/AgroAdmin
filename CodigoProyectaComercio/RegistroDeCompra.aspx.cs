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
    public partial class RegistroDeCompra : System.Web.UI.Page
    {
        private RepositorioProveedor repositorioProveedor = new RepositorioProveedor();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
                Session["productosSeleccionados"] = new List<Producto>();
            }



        }

        private void CargarProveedores()
        {
            try
            {
                
                List<Proveedor> proveedores = repositorioProveedor.ListarConSp();

                
                ddlProveedores.DataSource = proveedores;
                ddlProveedores.DataTextField = "Nombre"; 
                ddlProveedores.DataValueField = "IdProveedor"; 
                ddlProveedores.DataBind();
                ddlProveedores.Items.Insert(0, new ListItem("Seleccione un proveedor", "0"));
            }
            catch (Exception ex)
            {
               
                Response.Write("Error al cargar proveedores: " + ex.Message);
            }
        }

        protected void ddlProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProveedor = Convert.ToInt32(ddlProveedores.SelectedValue);
            if (idProveedor != 0) 
            {
                CargarProductosPorProveedor(idProveedor);
            }
            else
            {
                gvProductos.DataSource = null;
                gvProductos.DataBind();
            }
        }





        private void CargarProductosPorProveedor(int idProveedor)
        {
            try
            {
                // Obtener productos del proveedor
                List<Producto> productos = repositorioProveedor.ObtenerProductosPorProveedor(idProveedor);

                // Vincular datos al GridView
                gvProductos.DataSource = productos;
                gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error al cargar productos: " + ex.Message);
            }
        }


        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");

                if (int.TryParse(txtCantidad.Text, out int cantidad) && cantidad > 0)
                {
                    List<Producto> productosSeleccionados = (List<Producto>)Session["productosSeleccionados"];
                    RepositorioProducto repositorioProducto = new RepositorioProducto();
                    Producto producto = repositorioProducto.ObtenerProductoPorId(idProducto);

                    if (producto != null)
                    {
                        Producto existente = productosSeleccionados.FirstOrDefault(p => p.IdProducto == idProducto);

                        if (existente == null)
                        {
                            producto.CantidadSeleccionada = cantidad;
                            productosSeleccionados.Add(producto);
                        }
                        else
                        {
                            existente.CantidadSeleccionada += cantidad;
                        }

                        Session["productosSeleccionados"] = productosSeleccionados;
                        ActualizarVistaSeleccionados();
                    }
                }
            }
        }


        private void ActualizarVistaSeleccionados()
        {
            List<Producto> productosSeleccionados = (List<Producto>)Session["productosSeleccionados"];
            gvSeleccionados.DataSource = productosSeleccionados;
            gvSeleccionados.DataBind();
        }

       

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session["productosSeleccionados"] = new List<Producto>();
            ActualizarVistaSeleccionados();
            lblMensaje.Text = "Selección cancelada.";
            lblMensaje.ForeColor = System.Drawing.Color.Orange;
        }


        protected void gvSeleccionados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);

                List<Producto> productosSeleccionados = (List<Producto>)Session["productosSeleccionados"];

                Producto productoAEliminar = productosSeleccionados.FirstOrDefault(p => p.IdProducto == idProducto);
                if (productoAEliminar != null)
                {
                    productosSeleccionados.Remove(productoAEliminar);
                    Session["productosSeleccionados"] = productosSeleccionados; 
                }

                ActualizarVistaSeleccionados();
            }
        }


    }
}

    
