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
        private RepositorioCliente repositorioCliente = new RepositorioCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProductos();
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


        private void CargarProductos(string filtro = "")
        {
            RepositorioProducto repositorioProducto = new RepositorioProducto();
            List<Producto> productos = new List<Producto>();

            if (string.IsNullOrEmpty(filtro))
            {
                productos = repositorioProducto.ListarConSp();
            }
            else
            {
              
                Producto producto = repositorioProducto.ObtenerProductoPorId(null, filtro);  
                if (producto != null)
                {
                    productos.Add(producto);
                }
            }

            ddlProductos.DataSource = productos;
            ddlProductos.DataTextField = "Nombre";  
            ddlProductos.DataValueField = "IdProducto";  
            ddlProductos.DataBind();

            
            ddlProductos.Items.Insert(0, new ListItem("Seleccione un producto", ""));

          
        }

        protected void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarProducto.Text.Trim();
            CargarProductos(filtro);
        }

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productoId = ddlProductos.SelectedValue;
        }

    }


}
