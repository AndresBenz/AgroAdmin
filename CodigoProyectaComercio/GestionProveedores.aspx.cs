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
            gvProveedores.DataSource = proveedores;
            gvProveedores.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            listarProveedores.Visible = false;
            formularioProveedor.Visible = true;
            LimpiarFormulario();
            lblTituloFormulario.Text = "Agregar Proveedor";
        }

        protected void gvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int idProveedor = Convert.ToInt32(e.CommandArgument);
                CargarProveedorEnFormulario(idProveedor);
                formularioProveedor.Visible = true;
                listarProveedores.Visible = false;
            }
            else if (e.CommandName == "Eliminar")
            {
                int idProveedor = Convert.ToInt32(e.CommandArgument);
                RepositorioProveedor repositorio = new RepositorioProveedor();
                repositorio.EliminarProveedor(idProveedor);
                CargarProveedores();
            }
        }
       

        protected void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            RepositorioProveedor repositorio = new RepositorioProveedor();
            Proveedor proveedor = new Proveedor
            {
                Nombre = txtNombreProveedor.Text,
                Detalle = txtDetalleProveedor.Text,
                CorreoElectronico = txtCorreoProveedor.Text,
                Telefono = txtTelefonoProveedor.Text
            };

            if (int.TryParse(hfIdProveedor.Value, out int idProveedor) && idProveedor != 0)
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
            listarProveedores.Visible = true;
            formularioProveedor.Visible = false;
        }

        protected void btnCancelarProveedor_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            listarProveedores.Visible = true;
            formularioProveedor.Visible = false;
        }

        private void LimpiarFormulario()
        {
            txtNombreProveedor.Text = string.Empty;
            txtDetalleProveedor.Text = string.Empty;
            txtCorreoProveedor.Text = string.Empty;
            txtTelefonoProveedor.Text = string.Empty;
            hfIdProveedor.Value = string.Empty;
        }

        private void CargarProveedorEnFormulario(int idProveedor)
        {
            RepositorioProveedor repositorio = new RepositorioProveedor();
            Proveedor proveedor = repositorio.ObtenerProveedorPorId(idProveedor);

            if (proveedor != null)
            {
                txtNombreProveedor.Text = proveedor.Nombre;
                txtDetalleProveedor.Text = proveedor.Detalle;
                txtCorreoProveedor.Text = proveedor.CorreoElectronico;
                txtTelefonoProveedor.Text = proveedor.Telefono;
                hfIdProveedor.Value = proveedor.IdProveedor.ToString();
            }
        }
    }
}
