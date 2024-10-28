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
            RepeaterClientes.DataSource = clientes;
            RepeaterClientes.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            phFormulario.Visible = true;
            btnGuardar.Text = "Guardar Cliente";
            LimpiarFormulario();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string dniCliente = ((LinkButton)sender).CommandArgument; 
            var cliente = repositorioCliente.ObtenerClientePorId(dniCliente);

            if (cliente != null)
            {
                nombreCliente.Text = cliente.Nombre;
                direccionCliente.Text = cliente.Direccion;
                correoCliente.Text = cliente.CorreoElectronico;
                telefonoCliente.Text = cliente.Telefono;
                DNICliente.Text = cliente.DNI;

                phFormulario.Visible = true;
                btnGuardar.Text = "Modificar Cliente";
                hiddenIdCliente.Value = cliente.DNI; 
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string dniCliente = ((LinkButton)sender).CommandArgument; 
            repositorioCliente.EliminarCliente(dniCliente);
            CargarClientes();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Nombre = nombreCliente.Text,
                Direccion = direccionCliente.Text,
                CorreoElectronico = correoCliente.Text,
                Telefono = telefonoCliente.Text,
                DNI = DNICliente.Text 
            };

            if (btnGuardar.Text == "Modificar Cliente")
            {
                cliente.DNI = hiddenIdCliente.Value; 
                repositorioCliente.EditarCliente(cliente);
            }
            else
            {
                repositorioCliente.AgregarCliente(cliente);
            }

            phFormulario.Visible = false;
            CargarClientes();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            phFormulario.Visible = false;
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            nombreCliente.Text = string.Empty;
            direccionCliente.Text = string.Empty;
            correoCliente.Text = string.Empty;
            telefonoCliente.Text = string.Empty;
            hiddenIdCliente.Value = string.Empty;
            DNICliente.Text = string.Empty; 
        }
    }
}