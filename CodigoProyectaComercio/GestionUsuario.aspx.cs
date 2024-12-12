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
    public partial class GestionUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            RepositorioUsuario repo = new RepositorioUsuario();
            gvUsuarios.DataSource = repo.ListarConSp();
            gvUsuarios.DataBind();
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Eliminar")
            {
                int idUsuario = Convert.ToInt32(e.CommandArgument);

                RepositorioUsuario repositorio = new RepositorioUsuario();
                repositorio.EliminarUsuario(idUsuario);

                CargarUsuarios();
                lblMensaje.Text = "El usuario se elimino correctamente";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }


            if (e.CommandName == "Modificar")
            {
                int idUsuario = Convert.ToInt32(e.CommandArgument);
                RepositorioUsuario repo = new RepositorioUsuario();
                Usuario usuario = repo.ObtenerUsuarioPorId(idUsuario);

                hfIdUsuario.Value = usuario.IdUsuario.ToString();
                txtUsuario.Text = usuario.NombreUsuario;
                txtEmail.Text = usuario.CorreoElectronico;
                txtDNI.Text = usuario.DNI.ToString();
                txtTelefono.Text = usuario.Telefono;
                ddlTipoUsuario.SelectedValue = ((int)usuario.TipoUsuario).ToString();

                formularioUsuario.Visible = true;
                listarUsuarios.Visible = false;

                btnGuardar.Visible = false;
                btnActualizar.Visible = true;
                lblTituloFormulario.Text = "Modificar Usuario";
            }
        }


        private void CargarUsuarioParaModificar(int idUsuario)
        {
            RepositorioUsuario repo = new RepositorioUsuario();
            Usuario usuario = repo.ObtenerUsuarioPorId(idUsuario);

            if (usuario != null)
            {
                txtUsuario.Text = usuario.NombreUsuario;
                txtEmail.Text = usuario.CorreoElectronico;
                txtDNI.Text = usuario.DNI.ToString();
                txtTelefono.Text = usuario.Telefono;
                ddlTipoUsuario.SelectedValue = ((int)usuario.TipoUsuario).ToString();
                btnActualizar.Visible = true;
                hfIdUsuario.Value = idUsuario.ToString();
            }
            else
            {
                lblMensaje.Text = "El usuario no existe.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
           
            LimpiarCampos();
            formularioUsuario.Visible = true;
            listarUsuarios.Visible = false;

           
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;
            lblTituloFormulario.Text = "Agregar Usuario";
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlTipoUsuario.SelectedIndex == 0 || string.IsNullOrEmpty(ddlTipoUsuario.SelectedValue))
                {
                    lblMensajeFormulario.Text = "Por favor, seleccione un tipo de usuario válido.";
                    lblMensajeFormulario.ForeColor = System.Drawing.Color.Red;
                    return; 
                }
                RepositorioUsuario repo = new RepositorioUsuario();

                Usuario usuario = new Usuario
                {
                    NombreUsuario = txtUsuario.Text,
                    CorreoElectronico = txtEmail.Text,
                    DNI = int.Parse(txtDNI.Text),
                    Telefono = txtTelefono.Text,
                    TipoUsuario = (TipoUsuario)int.Parse(ddlTipoUsuario.SelectedValue)
                };

                repo.InsUsuario(usuario);

                lblMensaje.Text = "Usuario guardado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;

                CargarUsuarios();
                LimpiarCampos();

                formularioUsuario.Visible = false;
                listarUsuarios.Visible = true;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al guardar el usuario: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            formularioUsuario.Visible = false;

            listarUsuarios.Visible = true;

          
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int idUsuario = int.Parse(hfIdUsuario.Value);
                RepositorioUsuario repo = new RepositorioUsuario();

                Usuario usuario = new Usuario
                {
                    IdUsuario = idUsuario,
                    NombreUsuario = txtUsuario.Text,
                    CorreoElectronico = txtEmail.Text,
                    DNI = int.Parse(txtDNI.Text),
                    Telefono = txtTelefono.Text,
                    TipoUsuario = (TipoUsuario)int.Parse(ddlTipoUsuario.SelectedValue)
                };

                repo.ModificarUsuario(usuario);
                lblMensaje.Text = "Usuario actualizado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;

                CargarUsuarios();
                LimpiarCampos();

                formularioUsuario.Visible = false;
                listarUsuarios.Visible = true;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar el usuario: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            
        }

        private void LimpiarCampos()
        {
            txtUsuario.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            ddlTipoUsuario.ClearSelection();
            hfIdUsuario.Value = string.Empty;
            btnActualizar.Visible = false;
        }
    

    }
}