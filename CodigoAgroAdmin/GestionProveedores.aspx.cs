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
        private static List<Proveedor> proveedores = new List<Proveedor>
        {
            new Proveedor { IdProveedor = 1, Nombre = "Proveedor 1", Direccion = "Direccion 1", CorreoElectronico = "correo1@example.com", Telefono = "123456789" },
            new Proveedor { IdProveedor = 2, Nombre = "Proveedor 2", Direccion = "Direccion 2", CorreoElectronico = "correo2@example.com", Telefono = "987654321" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
            }
        }

        private void CargarProveedores()
        {
            RepeaterProveedores.DataSource = proveedores;
            RepeaterProveedores.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            phFormulario.Visible = true;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            // Lógica para editar un proveedor (simulación)
            int idProveedor = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            Proveedor proveedor = proveedores.Find(p => p.IdProveedor == idProveedor);
            if (proveedor != null)
            {
                nombreProveedor.Text = proveedor.Nombre;
                direccionProveedor.Text = proveedor.Direccion;
                correoProveedor.Text = proveedor.CorreoElectronico;
                telefonoProveedor.Text = proveedor.Telefono;
                phFormulario.Visible = true;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // Lógica para eliminar un proveedor (simulación)
            int idProveedor = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            proveedores.RemoveAll(p => p.IdProveedor == idProveedor);
            CargarProveedores();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Simulación de guardar un nuevo proveedor
            Proveedor nuevoProveedor = new Proveedor
            {
                IdProveedor = proveedores.Count + 1, // Simulación de ID
                Nombre = nombreProveedor.Text,
                Direccion = direccionProveedor.Text,
                CorreoElectronico = correoProveedor.Text,
                Telefono = telefonoProveedor.Text
            };

            proveedores.Add(nuevoProveedor);

            CargarProveedores();
            phFormulario.Visible = false; // Oculta el formulario después de guardar
            LimpiarFormulario(); // Limpia el formulario
        }

        private void LimpiarFormulario()
        {
            nombreProveedor.Text = string.Empty;
            direccionProveedor.Text = string.Empty;
            correoProveedor.Text = string.Empty;
            telefonoProveedor.Text = string.Empty;
        }
    }

    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
    }
}
