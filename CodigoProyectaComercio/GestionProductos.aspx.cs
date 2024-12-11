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
            RepositorioProducto repositorioProductos = new RepositorioProducto();
            Session.Add("listaProductos", repositorioProductos.ListarConSpDetalle());
            
            dgvProductos.DataSource = Session["listaProductos"];
            dgvProductos.DataBind();
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




        protected void GridViewProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Eliminar")
                {
                    int idProducto = Convert.ToInt32(e.CommandArgument);

                    repoProducto.EliminarProducto(idProducto);

                    lblMensaje.Text = "Producto eliminado correctamente.";
                    lblMensaje.CssClass = "alert alert-success";
                    lblMensaje.Visible = true;

                    CargarProductos();
                }
                else if (e.CommandName == "Editar")
                {
                    int idProducto = Convert.ToInt32(e.CommandArgument);

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
                        lblMensaje.Text = "Producto no encontrado.";
                        lblMensaje.CssClass = "alert alert-warning";
                        lblMensaje.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
                lblMensaje.Visible = true;
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            tituloFormulario.InnerText = "Agregar Producto";
            hiddenIdProducto.Value = string.Empty;
            LimpiarFormulario();
            divListado.Visible = false;
            divFormulario.Visible = true;
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

        protected void txtfiltro_TextChanged(object sender, EventArgs e)
        {
            List<Producto> lista = (List<Producto>)Session["listaProductos"];
            List<Producto> listafiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            dgvProductos.DataSource = listafiltrada;
            dgvProductos.DataBind();
        }
    }
}