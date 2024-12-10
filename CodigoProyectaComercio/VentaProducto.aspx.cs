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
            string id = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionCategoria.aspx?id=" + id);
        }


        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Producto> list = (List<Producto>)Session["listaProductos"];
            List<Producto> listaFiltrada = list.FindAll(x => x.Nombre.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            Session["listaFiltrada"] = listaFiltrada;
            dgvProductos.DataSource = listaFiltrada;
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
                Session["IdClienteSeleccionado"] = cliente.IdCliente;
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
                    RepositorioProducto repositorioProducto = new RepositorioProducto();
                    int stockBD = repositorioProducto.ObtenerStockDesdeBD(idProducto);

                    if (e.CommandName == "Incrementar" && producto.StockActual > 0)
                    {
                        producto.StockActual -= 1;
                    }
                    else if (e.CommandName == "Decrementar" && producto.StockActual < stockBD)
                    {
                        producto.StockActual += 1;
                    }

                    // Obtener la lista completa de productos (asegurarse de que no sea null)
                    List<Producto> listaCompleta = (List<Producto>)Session["listaProductos"] ?? new List<Producto>();
                    Producto productoCompleto = listaCompleta.FirstOrDefault(p => p.IdProducto == idProducto);
                    if (productoCompleto != null)
                    {
                        productoCompleto.StockActual = producto.StockActual;
                    }

                    // Buscar y modificar el producto seleccionado
                    Producto productoSeleccionado = listaSeleccionados.FirstOrDefault(p => p.IdProducto == idProducto);

                    if (e.CommandName == "Incrementar")
                    {
                        if (producto.StockActual > 0)
                        {
                            if (productoSeleccionado == null)
                            {
                                listaSeleccionados.Add(new Producto
                                {
                                    IdProducto = producto.IdProducto,
                                    Nombre = producto.Nombre,
                                    StockActual = producto.StockActual,
                                    CantidadSeleccionada = 1,
                                    Precio = producto.Precio
                                });
                            }
                            else
                            {
                                productoSeleccionado.CantidadSeleccionada += 1;
                                productoSeleccionado.StockActual = producto.StockActual;
                            }
                        }
                    }
                    // Si el comando es "Decrementar", decrementa la cantidad seleccionada
                    else if (e.CommandName == "Decrementar" && productoSeleccionado != null)
                    {
                        if (productoSeleccionado.CantidadSeleccionada > 1)
                        {
                            productoSeleccionado.CantidadSeleccionada -= 1;
                        }
                        else
                        {
                            listaSeleccionados.Remove(productoSeleccionado);

                        }
                        productoSeleccionado.StockActual = producto.StockActual;
                    }

                    // Actualizar las listas de sesión con los cambios realizados
                    Session["listaSeleccionados"] = listaSeleccionados;
                    Session["listaProductos"] = listaCompleta;

                    // Actualizar la grilla de productos
                    dgvProductos.DataSource = listaActual;
                    dgvProductos.DataBind();
                }
            }





        }


        protected void btnVerSeleccionados_Click(object sender, EventArgs e)
        {
            List<Producto> listaSeleccionados = Session["listaSeleccionados"] as List<Producto>;

            if (listaSeleccionados != null && listaSeleccionados.Count > 0)
            {
                dgvSeleccionados.DataSource = listaSeleccionados;
                dgvSeleccionados.DataBind();
                lblMensaje.Visible = false;

                decimal total = CalcularTotal();
                lblTotal.Text = $"Total: ${total:N2}";
                lblTotal.Visible = true;
            }
            else
            {
                lblMensaje.Text = "No se han seleccionado productos.";
                lblMensaje.Visible = true;
                dgvSeleccionados.DataSource = null;
                dgvSeleccionados.DataBind();

                lblTotal.Text = "Total: $0.00";
                lblTotal.Visible = true;
            }
        }


        protected void btnComprarTodos_Click(object sender, EventArgs e)
        {
            if (Session["IdClienteSeleccionado"] != null)
            {
                int idCliente = (int)Session["IdClienteSeleccionado"];

                Venta nuevaVenta = new Venta
                {
                    IdCliente = idCliente,
                    Fecha = DateTime.Now,
                    Total = CalcularTotal(), // Lógica para calcular el total de la venta
                };

                // Insertar la venta
                RepositorioVenta repositorioVenta = new RepositorioVenta();
                repositorioVenta.Insertar(nuevaVenta);

                // Mostrar un mensaje de éxito
                lblMensaje.Text = "Venta registrada exitosamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Visible = true;
            }
            else
            {
                // Mostrar un mensaje si no se ha seleccionado un cliente
                lblMensaje.Text = "Debe buscar y seleccionar un cliente antes de registrar la venta.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
        
    }


        private decimal CalcularTotal()
        {
            // Recuperar la lista de productos desde la sesión
            List<Producto> listaSeleccionados = Session["listaSeleccionados"] as List<Producto>;
        
            return listaSeleccionados.Sum(p => p.Precio * p.CantidadSeleccionada);
        }
    }
}
 
