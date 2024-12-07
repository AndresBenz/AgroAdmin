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
    public partial class GestionCliente : System.Web.UI.Page
    {
        private RepositorioCliente repositorioCliente = new RepositorioCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            var clientes = repositorioCliente.ListarConSp();
            gvClientes.DataSource = clientes;
            gvClientes.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            listarClientes.Visible = false;
            formularioCliente.Visible = true;

            
            lblTituloFormulario.Text = "Agregar Cliente";
            LimpiarFormulario();
        }

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string dniCliente = e.CommandArgument.ToString();
            if (e.CommandName == "Modificar")
            {
                var cliente = repositorioCliente.ObtenerClientePorId(dniCliente);
                if (cliente != null)
                {
                    txtNombre.Text = cliente.Nombre;
                    txtDNI.Text = cliente.DNI;
                    txtCorreo.Text = cliente.CorreoElectronico;
                    txtTelefono.Text = cliente.Telefono;

                    
                    hfIdCliente.Value = cliente.DNI;
                    listarClientes.Visible = false;
                    formularioCliente.Visible = true;
                    lblTituloFormulario.Text = "Modificar Cliente";
                }
            }
            else if (e.CommandName == "Eliminar")
            {
                repositorioCliente.EliminarCliente(dniCliente);
                CargarClientes();
            }
        }
    
    

        

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Direccion = txtCorreo.Text,
                CorreoElectronico = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                DNI = txtDNI.Text 
            };

            if (!string.IsNullOrEmpty(hfIdCliente.Value))
            {
                cliente.DNI = hfIdCliente.Value;
                repositorioCliente.EditarCliente(cliente);
            }
            else
            {
                repositorioCliente.AgregarCliente(cliente);
            }

            listarClientes.Visible = true;
            formularioCliente.Visible = false;
            CargarClientes();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            listarClientes.Visible = true;
            formularioCliente.Visible = false;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            hfIdCliente.Value = string.Empty;
        }
    }
}