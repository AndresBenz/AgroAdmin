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


        protected void rblMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string metodoPagoSeleccionado = rblMetodoPago.SelectedValue;

            lblMetodoPagoSeleccionado.Text = "Método de pago seleccionado: " + metodoPagoSeleccionado;


        }




        private void CargarProductosPorProveedor(int idProveedor)
        {
            try
            {
                List<Producto> productos = repositorioProveedor.ObtenerProductosPorProveedor(idProveedor);

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
                TextBox txtPrecio = (TextBox)row.FindControl("txtPrecio");

                if (int.TryParse(txtCantidad.Text, out int cantidad) && cantidad > 0 &&
            decimal.TryParse(txtPrecio.Text, out decimal precio) && precio >= 0)
                {
                    List<Producto> productosSeleccionados = (List<Producto>)Session["productosSeleccionados"];
                    RepositorioProducto repositorioProducto = new RepositorioProducto();
                    Producto producto = repositorioProducto.ObtenerProductoPorId(idProducto);

                    if (producto != null)
                    {
                        producto.Precio = precio;
                        producto.CantidadSeleccionada = cantidad;
                        Producto existente = productosSeleccionados.FirstOrDefault(p => p.IdProducto == idProducto);

                        if (existente == null)
                        {

                       
                            productosSeleccionados.Add(producto);
                        }
                        else
                        {
                            existente.CantidadSeleccionada += cantidad;
                            existente.Precio = precio;
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
            decimal totalGeneral = productosSeleccionados.Sum(p => p.Precio * p.CantidadSeleccionada);
            lblTotal.Text = totalGeneral.ToString("F2");

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

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProveedor = Convert.ToInt32(ddlProveedores.SelectedValue);
                string metodoPago = rblMetodoPago.SelectedValue;

                Compra compra = new Compra
                {
                    IdProveedor = idProveedor,
                    FechaCompra = DateTime.Now,
                    TipoPago = metodoPago
                };

                RepositorioCompra repositorioCompra = new RepositorioCompra();
                repositorioCompra.AgregarCompra(compra);

                int idCompra = repositorioCompra.ObtenerUltimoIdCompra();

                List<Producto> productosSeleccionados = (List<Producto>)Session["productosSeleccionados"];
                List<DetalleCompra> detallesCompra = new List<DetalleCompra>();

                foreach (Producto producto in productosSeleccionados)
                {
                    RepositorioProducto repositorioProduct  = new RepositorioProducto();
                    int stockActual = repositorioProduct.ObtenerStockProducto(producto.IdProducto);
                    int nuevoStock = stockActual + producto.CantidadSeleccionada;
                    repositorioProduct.ActualizarStock(producto.IdProducto, nuevoStock);


                    DetalleCompra detalle = new DetalleCompra
                    {
                        IdCompra = idCompra,
                        IdProducto = producto.IdProducto,
                        Cantidad = producto.CantidadSeleccionada,
                        PrecioCompra = producto.Precio,
                        Subtotal = producto.Precio * producto.CantidadSeleccionada
                    };

                    detallesCompra.Add(detalle);
                }

                RepositorioCompra repositorioDetalleCompra = new RepositorioCompra();
                repositorioDetalleCompra.AgregarDetallesCompra(detallesCompra);

                lblMensaje.Text = "Compra registrada exitosamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                Session["productosSeleccionados"] = new List<Producto>(); 
                ActualizarVistaSeleccionados();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al registrar la compra: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}

    
