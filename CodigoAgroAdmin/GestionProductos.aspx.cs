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
    public partial class GestionProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
           
            if (int.TryParse(txtBuscar.Text.Trim(), out int idProducto))
            {
               
                RepositorioProducto repProductos = new RepositorioProducto();
                var producto = repProductos.ObtenerProductoPorId(idProducto);

                if (producto != null)
                {
                    //lo muestra en el formulario
                    nombreProducto.Text = producto.Nombre;
                    precioProducto.Text = producto.Precio.ToString();
                    stockActual.Text = producto.StockActual.ToString();
                    stockMinimo.Text = producto.StockMinimo.ToString();
                    lblMensaje.Visible = false; 
                    phFormulario.Visible = true; 
                }
                else
                {
                    
                    lblMensaje.Text = "Producto no encontrado.";
                    lblMensaje.Visible = true;
                    ResetearFormulario(); 
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, ingrese un ID válido.";
                lblMensaje.Visible = true;
                ResetearFormulario(); 
            }
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        { }

        protected void btnEliminar_Click(object sender, EventArgs e)
        { }



        private void CargarProducto(int idProducto)
        {
            RepositorioProducto repositorioProducto = new RepositorioProducto();
            Producto producto = repositorioProducto.ObtenerProductoPorId(idProducto);

            if (producto != null)
            {
               
                nombreProducto.Text = producto.Nombre;
                precioProducto.Text = producto.Precio.ToString();
                stockActual.Text = producto.StockActual.ToString();
                stockMinimo.Text = producto.StockMinimo.ToString();
            }
            else
            {
             
                lblMensaje.Text = "Producto no encontrado.";
                lblMensaje.Visible = true;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
           
            phFormulario.Visible = true;
            ResetearFormulario(); 
        }


        private void ResetearFormulario()
        {
            nombreProducto.Text = string.Empty;
            precioProducto.Text = string.Empty;
            stockActual.Text = string.Empty;
            stockMinimo.Text = string.Empty;
            lblMensajeFormulario.Visible = false; 
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
           
            phFormulario.Visible = false;
        }
    }
}