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
    public partial class GestionProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
            }
        }

        private void CargarProveedores()
        {
            RepositorioProveedor repositorio = new RepositorioProveedor();
            List<Proveedor> proveedores = repositorio.ListarConSp();
            RepeaterProveedores.DataSource = proveedores;
            RepeaterProveedores.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            phFormulario.Visible = true;
            LimpiarFormulario();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idProveedor = Convert.ToInt32((sender as LinkButton).CommandArgument);
            CargarProveedorEnFormulario(idProveedor);
            phFormulario.Visible = true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idProveedor = Convert.ToInt32((sender as LinkButton).CommandArgument);
            RepositorioProveedor repositorio = new RepositorioProveedor();
            repositorio.EliminarProveedor(idProveedor);
            CargarProveedores();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioProveedor repositorio = new RepositorioProveedor();
            Proveedor proveedor = new Proveedor
            {
                Nombre = nombreProveedor.Text,
                Direccion = direccionProveedor.Text,
                CorreoElectronico = correoProveedor.Text,
                Telefono = telefonoProveedor.Text
            };

            if (int.TryParse(hiddenIdProveedor.Value, out int idProveedor) && idProveedor != 0)
            {
                proveedor.IdProveedor = idProveedor;
                repositorio.EditarProveedor(proveedor);
            }
            else
            {
                repositorio.AgregarProveedor(proveedor);
            }

            CargarProveedores();
            LimpiarFormulario();
            phFormulario.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            phFormulario.Visible = false;
        }

        private void LimpiarFormulario()
        {
            nombreProveedor.Text = string.Empty;
            direccionProveedor.Text = string.Empty;
            correoProveedor.Text = string.Empty;
            telefonoProveedor.Text = string.Empty;
            hiddenIdProveedor.Value = string.Empty;
        }

        private void CargarProveedorEnFormulario(int idProveedor)
        {
            RepositorioProveedor repositorio = new RepositorioProveedor();
            Proveedor proveedor = repositorio.ObtenerProveedorPorId(idProveedor);

            if (proveedor != null)
            {
                nombreProveedor.Text = proveedor.Nombre;
                direccionProveedor.Text = proveedor.Direccion;
                correoProveedor.Text = proveedor.CorreoElectronico;
                telefonoProveedor.Text = proveedor.Telefono;
                hiddenIdProveedor.Value = proveedor.IdProveedor.ToString();
            }
        }
    }
}
