using Dominio;
using Funcionalidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodigoAgroAdmin
{
    public partial class GestionProductos : System.Web.UI.Page
    {
        RepositorioProducto repoProducto = new RepositorioProducto();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarProductos();
                CargarCategorias();
                CargarMarcas();

            }
        }


        private void CargarProductos()
        {
            var productos = repoProducto.ListarConSpDetalle();
            RepeaterProductos.DataSource = productos;
            RepeaterProductos.DataBind();
            divListado.Visible = true;
            divFormulario.Visible = false;
        }


        private void CargarCategorias()
        {
            RepositorioCategoria categoriaNegocio = new RepositorioCategoria(); 
            
                var categorias = categoriaNegocio.ListarConSpActivas(); 
                categoriaProducto.DataSource = categorias;
                categoriaProducto.DataTextField = "Nombre"; 
                categoriaProducto.DataValueField = "IdCategoria"; 
                categoriaProducto.DataBind();

                categoriaProducto.Items.Insert(0, new ListItem("Seleccione Categoria", ""));
            
           
        }

        private void CargarMarcas()
        {
            RepositorioMarca marcaNegocio = new RepositorioMarca(); 
           
                var marcas = marcaNegocio.ListarConSpActivas(); 
                marcaProducto.DataSource = marcas;
                marcaProducto.DataTextField = "Nombre"; 
                marcaProducto.DataValueField = "IdMarca"; 
                marcaProducto.DataBind();

                marcaProducto.Items.Insert(0, new ListItem("Seleccione Marca", ""));
            
           
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            tituloFormulario.InnerText = "Agregar Producto";
            hiddenIdProducto.Value = string.Empty;
            LimpiarFormulario();
            divListado.Visible = false;
            divFormulario.Visible = true;
        }



        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btnEditar = (LinkButton)sender;
            int idProducto = Convert.ToInt32(btnEditar.CommandArgument);
            var producto = repoProducto.ObtenerProductoPorId(idProducto);

            if (producto != null)
            {
                tituloFormulario.InnerText = "Editar Producto";
                nombreProducto.Text = producto.Nombre;
                precioProducto.Text = producto.Precio.ToString();

                stockActual.Text = producto.StockActual.ToString();
                stockMinimo.Text = producto.StockMinimo.ToString();


                if (categoriaProducto.Items.FindByValue(producto.IdCategoria.ToString()) != null)
                {
                    categoriaProducto.SelectedValue = producto.IdCategoria.ToString();
                }
                else
                {
                    categoriaProducto.SelectedIndex = 0; 
                }


                if (marcaProducto.Items.FindByValue(producto.IdMarca.ToString()) != null)
                {
                    marcaProducto.SelectedValue = producto.IdMarca.ToString();
                }
                else
                {
                    marcaProducto.SelectedIndex = 0; 
                }
                hiddenIdProducto.Value = producto.IdProducto.ToString();

                divListado.Visible = false;
                divFormulario.Visible = true;
            }
            else
            {
                lblMensajeFormulario.Text = "Producto no encontrado.";
                lblMensajeFormulario.Visible = true;
            }
        }



        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(criterio))
            {
                CargarProductos();
                lblMensaje.Text = "";
                lblMensaje.Visible = false;

                return;
            }


            Producto producto = null;

            if (int.TryParse(criterio, out int idProducto))
            {
                
                producto = repoProducto.ObtenerProductoPorId(idProducto);
            }
            else if (!string.IsNullOrEmpty(criterio))
            {
                producto = repoProducto.ObtenerProductoPorId(nombre: criterio);
            }
            else
            {
                lblMensaje.Text = "Por favor, ingresa un ID o un nombre válido para buscar.";
                lblMensaje.Visible = true;
                return;
            }

            if (producto != null)
            {
                
                var productosEncontrados = new List<Producto> { producto };
                RepeaterProductos.DataSource = productosEncontrados;
                RepeaterProductos.DataBind();
                divListado.Visible = true;
                divFormulario.Visible = false;
                lblMensaje.Text = "";
                lblMensaje.Visible = false;
            }
            else
            {

                lblMensaje.Text = "No se encontró ningún producto con el criterio ingresado.";
                lblMensaje.Visible = true;
                RepeaterProductos.DataSource = null;
                RepeaterProductos.DataBind();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
              
                LinkButton btnEliminar = (LinkButton)sender;
                int idProducto = Convert.ToInt32(btnEliminar.CommandArgument); 

               
                repoProducto.EliminarProducto(idProducto);

                lblMensaje.Text = "Producto eliminado correctamente.";
                lblMensaje.Visible = true;

                CargarProductos();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar el producto: " + ex.Message;
                lblMensaje.Visible = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }


        private void LimpiarFormulario()
        {
            nombreProducto.Text = string.Empty;
            precioProducto.Text = string.Empty;
            categoriaProducto.SelectedIndex = 0;
            marcaProducto.SelectedIndex = 0;
            stockActual.Text = string.Empty;
            stockMinimo.Text = string.Empty;
            lblMensajeFormulario.Visible = false;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (categoriaProducto.SelectedIndex == 0)
            {
                lblMensajeFormulario.Text = "Por favor, selecciona una categoría válida.";
                lblMensajeFormulario.Visible = true;
                return; 
            }

            if (marcaProducto.SelectedIndex == 0)
            {
                lblMensajeFormulario.Text = "Por favor, selecciona una marca válida.";
                lblMensajeFormulario.Visible = true;
                return; 
            }

            Producto producto = new Producto
            {
                Nombre = nombreProducto.Text,
                Precio = Convert.ToDecimal(precioProducto.Text),
                IdCategoria = Convert.ToInt32(categoriaProducto.SelectedValue),
                IdMarca = Convert.ToInt32(marcaProducto.SelectedValue),
                StockActual = Convert.ToInt32(stockActual.Text),
                StockMinimo = Convert.ToInt32(stockMinimo.Text)
            };

            if (string.IsNullOrEmpty(hiddenIdProducto.Value))
            {
                repoProducto.AgregarProducto(producto);
                lblMensajeFormulario.Text = "Producto agregado correctamente.";
            }
            else
            {
                producto.IdProducto = Convert.ToInt32(hiddenIdProducto.Value);
                repoProducto.EditarProducto(producto);
                lblMensajeFormulario.Text = "Producto actualizado correctamente.";
            }
            lblMensajeFormulario.Visible = true;
            CargarProductos();
        }




    }
}