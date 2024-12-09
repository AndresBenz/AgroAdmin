using CodigoProyectaComercio;
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
    public partial class VentaProducto : System.Web.UI.Page
    {

     

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                RepositorioProducto repositorioProducto = new RepositorioProducto();
                List<Producto> listaProductos = repositorioProducto.ListarConSp();
                Session["listaProductos"] = listaProductos;
                dgvProductos.DataSource = listaProductos;
                dgvProductos.DataBind();
            }
        }

        protected void dgvProductos_SelectedIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;
            dgvProductos.DataBind();
        }
        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id= dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionCategoria.aspx?id=" + id);
        }


        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Producto> list = (List<Producto>)Session["listaProductos"];
            List<Producto> listaFiltrada = list.FindAll(x => x.Nombre.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            Session["listaFiltrada"] = listaFiltrada;
            dgvProductos.DataSource= listaFiltrada;
            dgvProductos.DataBind();        
        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();
            RepositorioCliente repositorioCliente = new RepositorioCliente();

            Cliente cliente = repositorioCliente.ObtenerClientePorId(dni);

            pnlClienteNoExiste.Visible = false;
            pnlClienteEncontrado.Visible = false;

            if (cliente == null)
            {
                pnlClienteNoExiste.Visible = true;

            }
            else
            {
                pnlClienteEncontrado.Visible = true;

                lblNombre.Text = cliente.Nombre;
                lblDireccion.Text = cliente.Direccion;
                lblCorreo.Text = cliente.CorreoElectronico;

            }
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            formularioCliente.Visible = true;
            lblTituloFormulario.Text = "Agregar Cliente";
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                CorreoElectronico = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                DNI = txtDNI2.Text
            };
         RepositorioCliente repositorioCliente = new RepositorioCliente();


        repositorioCliente.AgregarCliente(cliente);

            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtDNI.Text = "";

            formularioCliente.Visible = false;

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            formularioCliente.Visible = false;
        }


        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Incrementar" || e.CommandName == "Decrementar")
            {


                List<Producto> listaActual = Session["listaFiltrada"] != null
            ? (List<Producto>)Session["listaFiltrada"]
            : (List<Producto>)Session["listaProductos"];

                List<Producto> listaSeleccionados = Session["listaSeleccionados"] as List<Producto> ?? new List<Producto>();


                int idProducto = Convert.ToInt32(e.CommandArgument);

                Producto producto = listaActual.FirstOrDefault(p => p.IdProducto == idProducto);

                if (producto != null)
                {
                    if (e.CommandName == "Incrementar" && producto.StockActual > 0)
                    {
                        producto.StockActual -= 1;
                    }
                    else if (e.CommandName == "Decrementar" ) 
                    {
                        producto.StockActual += 1;
                    }

                    List<Producto> listaCompleta = (List<Producto>)Session["listaProductos"];
                    Producto productoCompleto = listaCompleta.FirstOrDefault(p => p.IdProducto == idProducto);
                    if (productoCompleto != null)
                    {
                        productoCompleto.StockActual = producto.StockActual;
                    }

                    Producto productoSeleccionado = listaSeleccionados.FirstOrDefault(p => p.IdProducto == idProducto);
                    if (producto.StockActual > 0)
                    {
                        if (productoSeleccionado == null)
                        {
                            listaSeleccionados.Add(new Producto
                            {
                                IdProducto = producto.IdProducto,
                                Nombre = producto.Nombre,
                                StockActual = producto.StockActual,
                                CantidadSeleccionada = 1
                            });
                        }
                        else
                        {
                            productoSeleccionado.CantidadSeleccionada += 1;
                            productoSeleccionado.StockActual = producto.StockActual;
                        }
                    }


                    Session["listaProductos"] = listaCompleta;
                    Session["listaSeleccionados"] = listaSeleccionados;
                    dgvProductos.DataSource = listaActual;
                    dgvProductos.DataBind();
                }




            }
        }


        protected void btnVerSeleccionados_Click(object sender, EventArgs e)
        {
            // Obtener la lista de productos seleccionados
            List<Producto> listaSeleccionados = Session["listaSeleccionados"] as List<Producto>;

            if (listaSeleccionados != null && listaSeleccionados.Count > 0)
            {
                // Mostrar los productos seleccionados en un GridView
                dgvSeleccionados.DataSource = listaSeleccionados;
                dgvSeleccionados.DataBind();
            }
            else
            {
                
            }
        }

    }
 }
