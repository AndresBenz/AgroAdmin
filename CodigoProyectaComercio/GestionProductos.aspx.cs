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
                btnGuardar.Visible = false;
                btnCancelar.Visible = false;
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
                    hiddenIdProducto.Value = producto.IdProducto.ToString();

                    nombreProducto.Text = producto.Nombre;
                    precioProducto.Text = producto.Precio.ToString();
                    categoriaProducto.Text=producto.IdCategoria.ToString();
                    marcaProducto.Text=producto.IdMarca.ToString();
                    stockActual.Text = producto.StockActual.ToString();
                    stockMinimo.Text = producto.StockMinimo.ToString();
                    lblMensaje.Visible = false;
                    phFormulario.Visible = true;
                    phAcciones.Visible = true;
                }
                else
                {

                    lblMensaje.Text = "Producto no encontrado.";
                    lblMensaje.Visible = true;
                    ResetearFormulario();
                    phAcciones.Visible= false;
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, ingrese un ID válido.";
                lblMensaje.Visible = true;
                phAcciones.Visible = false;
                ResetearFormulario();
            }
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(hiddenIdProducto.Value, out int idProducto))
            {
                RepositorioProducto repProductos = new RepositorioProducto();
                var producto = repProductos.ObtenerProductoPorId(idProducto);

                if (producto != null)
                {
                    nombreProducto.Text = producto.Nombre;
                    precioProducto.Text = producto.Precio.ToString();
                    stockActual.Text = producto.StockActual.ToString();
                    stockMinimo.Text = producto.StockMinimo.ToString();

                   
                    phFormulario.Visible = true;
                    btnGuardar.Visible = false; 
                    btnConfirmarEditar.Visible = true; 
                    btnCancelar.Visible = true; 
                    phAcciones.Visible = false; 
                }
                else
                {
                    lblMensajeFormulario.Text = "Producto no encontrado.";
                    lblMensajeFormulario.Visible = true;
                }
            }
            else
            {
                lblMensajeFormulario.Text = "No se pudo encontrar el ID del producto.";
                lblMensajeFormulario.Visible = true;
            }


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            phFormulario.Visible = false;
            btnGuardar.Visible = false;
            phAcciones.Visible = false;

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(hiddenIdProducto.Value, out int idProducto) && idProducto != 0)
            {
                RepositorioProducto repProductos = new RepositorioProducto();

                try
                {
                    repProductos.EliminarProducto(idProducto);
                    lblMensajeFormulario.Text = "Producto eliminado correctamente.";
                }
                catch (Exception ex)
                {
                    lblMensajeFormulario.Text = "Error al eliminar el producto: " + ex.Message;
                }

                lblMensajeFormulario.Visible = true;
                ResetearFormulario();
                phFormulario.Visible = false;
                phAcciones.Visible = false;
            }
            else
            {
                lblMensajeFormulario.Text = "No se pudo encontrar el ID del producto.";
                lblMensajeFormulario.Visible = true;
            }
        }



       
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            phFormulario.Visible = true;
            phAcciones.Visible = false;
            btnGuardar.Visible=true;
            ResetearFormulario();
        }


        private void ResetearFormulario()
        {
            nombreProducto.Text = string.Empty;
            precioProducto.Text = string.Empty;
            categoriaProducto.Text = string.Empty;
            stockActual.Text = string.Empty;
            stockMinimo.Text = string.Empty;
            hiddenIdProducto.Value = string.Empty;
            lblMensajeFormulario.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioProducto repProductos = new RepositorioProducto();
            Producto producto = new Producto
            {
                Nombre = nombreProducto.Text,
            };

            if (!decimal.TryParse(precioProducto.Text, out decimal precio))
            {
                lblMensajeFormulario.Text = "Por favor, ingrese un precio válido.";
                lblMensajeFormulario.Visible = true;
                return;
            }
            producto.Precio = precio;

            if (!int.TryParse(categoriaProducto.Text, out int idtipoProducto))
            {
                lblMensajeFormulario.Text = "Por favor, ingrese un tipo de producto valido";
                lblMensajeFormulario.Visible = true;
                return;
            }
            producto.IdCategoria = idtipoProducto;


            if (!int.TryParse(marcaProducto.Text, out int idMarcaProducto))
            {
                lblMensajeFormulario.Text = "Por favor, ingrese un tipo de producto valido";
                lblMensajeFormulario.Visible = true;
                return;
            }
            producto.IdMarca = idMarcaProducto;




            if (!int.TryParse(stockActual.Text, out int parsedStockActual))
            {
                lblMensajeFormulario.Text = "Por favor, ingrese un stock actual válido.";
                lblMensajeFormulario.Visible = true;
                return;
            }
            producto.StockActual = parsedStockActual;

            if (!int.TryParse(stockMinimo.Text, out int parsedStockMinimo))
            {
                lblMensajeFormulario.Text = "Por favor, ingrese un stock mínimo válido.";
                lblMensajeFormulario.Visible = true;
                return;
            }
            producto.StockMinimo = parsedStockMinimo;

            producto.IdProducto = 0;
            repProductos.AgregarProducto(producto);
            lblMensajeFormulario.Text = "Producto guardado correctamente.";

            lblMensajeFormulario.Visible = true;
            ResetearFormulario();
            phFormulario.Visible = false;
        }



        protected void btnConfirmarEditar_Click(object sender, EventArgs e)
        {
            RepositorioProducto repProductos = new RepositorioProducto();
            Producto producto = new Producto
            {
                IdProducto = int.Parse(hiddenIdProducto.Value), 
                Nombre = nombreProducto.Text,
            };

            if (!decimal.TryParse(precioProducto.Text, out decimal precio))
            {
                lblMensajeFormulario.Text = "Por favor, ingrese un precio válido.";
                lblMensajeFormulario.Visible = true;
                return;
            }
            producto.Precio = precio;

            if (!int.TryParse(categoriaProducto.Text, out int idtipoProducto))
            {
                lblMensajeFormulario.Text = "Por favor, ingrese un stock actual válido.";
                lblMensajeFormulario.Visible = true;
                return;
            }
            producto.IdCategoria = idtipoProducto;


            if (!int.TryParse(marcaProducto.Text, out int idMarcaProducto))
            {
                lblMensajeFormulario.Text = "Por favor, ingrese un stock actual válido.";
                lblMensajeFormulario.Visible = true;
                return;
            }
            producto.IdMarca = idMarcaProducto;



            if (!int.TryParse(stockActual.Text, out int parsedStockActual))
            {
                lblMensajeFormulario.Text = "Por favor, ingrese un stock actual válido.";
                lblMensajeFormulario.Visible = true;
                return;
            }
            producto.StockActual = parsedStockActual;

            if (!int.TryParse(stockMinimo.Text, out int parsedStockMinimo))
            {
                lblMensajeFormulario.Text = "Por favor, ingrese un stock mínimo válido.";
                lblMensajeFormulario.Visible = true;
                return;
            }
            producto.StockMinimo = parsedStockMinimo;

        
            repProductos.EditarProducto(producto);
            lblMensajeFormulario.Text = "Producto editado correctamente.";
            lblMensajeFormulario.Visible = true;

            ResetearFormulario(); 
            phFormulario.Visible = false; 
            phAcciones.Visible = true; 
        }
    }
}