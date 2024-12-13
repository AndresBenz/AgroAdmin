using Dominio;
using Funcionalidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CodigoAgroAdmin
{
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtFechaInicio.Text, out DateTime fechaInicio) &&
        DateTime.TryParse(txtFechaFin.Text, out DateTime fechaFin))
            {
                int? idCliente = null;
                if (!string.IsNullOrEmpty(txtIdCliente.Text)) 
                {
                    idCliente = Convert.ToInt32(txtIdCliente.Text);
                }

                Reportes reportes = new Reportes();
                List<Dominio.Reporte> reporteVentas = reportes.ObtenerVentasPorCliente(fechaInicio, fechaFin, idCliente);

                gvVentas.DataSource = reporteVentas;
                gvVentas.DataBind();
            }
            else
            {
                lblError.Text = "Por favor, ingresa fechas válidas.";
                lblError.Visible = true;
            }


        }


        protected void btnGenerarReporteCompras_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParse(txtFechaInicioCompra.Text, out DateTime fechaInicio) &&
                DateTime.TryParse(txtFechaFinCompra.Text, out DateTime fechaFin))
            {
                int? idProveedor = null;
                if (!string.IsNullOrEmpty(txtProveedor.Text))
                {
                    idProveedor = Convert.ToInt32(txtProveedor.Text);
                }

                Reportes reportes = new Reportes();
                List<Dominio.Reporte> reporteCompras = reportes.ObtenerComprasPorProveedor(fechaInicio, fechaFin, idProveedor);

                gvCompras.DataSource = reporteCompras;
                gvCompras.DataBind();
            }
            else
            {
                lblErrorCompra.Text = "Por favor, ingresa fechas válidas.";
                lblErrorCompra.Visible = true;
            }
        }
        protected void btnReporteVentas_Click(object sender, EventArgs e)
        {
            pnlVentas.Visible = true;
            pnlCompras.Visible = false;
        }

        protected void btnReporteCompras_Click(object sender, EventArgs e)
        {
            pnlVentas.Visible = false;
            pnlCompras.Visible = true;
        }


        protected void btnCancelarCompra_Click(object sender, EventArgs e)
        {
            pnlVentas.Visible = false;
            pnlCompras.Visible = false;

            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
            txtIdCliente.Text = "";
            txtFechaInicioCompra.Text = "";
            txtFechaFinCompra.Text = "";
            txtProveedor.Text = "";

            lblError.Visible = false;
            lblErrorCompra.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlVentas.Visible = false;
            pnlCompras.Visible = false;

            
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
            txtIdCliente.Text = "";
            lblError.Visible = false;
        }
    }
}