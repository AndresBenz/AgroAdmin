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
    public partial class DetalleDeLaVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    RepositorioVenta repositorioVenta = new RepositorioVenta();
                    int idVenta = repositorioVenta.ObtenerUltimoIdVenta();

                    if (idVenta == 0)
                    {
                        lblTotal.Text = "No se encontró ninguna venta registrada.";
                        return;
                    }

                    Venta venta = repositorioVenta.ObtenerVentaPorId(idVenta);

                    if (venta == null)
                    {
                        lblTotal.Text = "No se encontró la venta especificada.";
                        return;
                    }

                    lblTotal.Text = $"Total de la Venta: ${venta.Total:N2}";
                    lblCliente.Text = $"Cliente: {venta.NombreCliente}";
                    lblFecha.Text = $"Fecha: {venta.Fecha:dd/MM/yyyy}";

                    RepositorioDetalleVenta repositorioDetalle = new RepositorioDetalleVenta();
                    List<DetalleVenta> detallesVenta = repositorioDetalle.ListarPorVenta(idVenta);

                    if (detallesVenta != null && detallesVenta.Count > 0)
                    {
                        dgvDetallesVenta.DataSource = detallesVenta;
                        dgvDetallesVenta.DataBind();
                    }
                    else
                    {
                        lblTotal.Text += "<br>No hay detalles para esta venta.";
                    }
                }
                catch (Exception ex)
                {
                    lblTotal.Text = $"Ocurrió un error: {ex.Message}";
                }
            }
        }
    }
}