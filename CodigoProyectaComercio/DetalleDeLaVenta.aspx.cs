using Dominio;
using Funcionalidades;

using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;


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

                    lblTotal.Text = $" ${venta.Total:N2}";
                    lblCliente.Text = $" {venta.NombreCliente}";
                    lblFecha.Text = $"{venta.Fecha:dd/MM/yyyy}";

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

        protected void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            Document document = new Document(PageSize.A4);
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            string imagePath = Server.MapPath("~/logo.png");
            if (File.Exists(imagePath))
            {
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(imagePath);
                logo.ScaleToFit(200f, 100f);  
                logo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                document.Add(logo);
            }

            Font titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            Paragraph title = new Paragraph("Detalle de la Venta", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            Font textFont = FontFactory.GetFont("Arial", 12);
            document.Add(new Paragraph($"Cliente: {lblCliente.Text}", textFont));
            document.Add(new Paragraph($"Fecha: {lblFecha.Text}", textFont));
            document.Add(new Paragraph($"Total: {lblTotal.Text}", textFont));
            document.Add(new Paragraph("\n"));

            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100; 
            table.SetWidths(new float[] { 3f, 1f, 2f, 2f }); 

            // Estilo para los encabezados
            Font headerFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.WHITE);
            PdfPCell headerCell;

            headerCell = new PdfPCell(new Phrase("Producto", headerFont));
            headerCell.BackgroundColor = BaseColor.DARK_GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            headerCell = new PdfPCell(new Phrase("Cantidad", headerFont));
            headerCell.BackgroundColor = BaseColor.DARK_GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            headerCell = new PdfPCell(new Phrase("Precio Unitario", headerFont));
            headerCell.BackgroundColor = BaseColor.DARK_GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            headerCell = new PdfPCell(new Phrase("Subtotal", headerFont));
            headerCell.BackgroundColor = BaseColor.DARK_GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            Font cellFont = FontFactory.GetFont("Arial", 10);

            foreach (GridViewRow row in dgvDetallesVenta.Rows)
            {
                table.AddCell(new PdfPCell(new Phrase(row.Cells[0].Text, cellFont)) { HorizontalAlignment = Element.ALIGN_LEFT });
                table.AddCell(new PdfPCell(new Phrase(row.Cells[1].Text, cellFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase(row.Cells[2].Text, cellFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                table.AddCell(new PdfPCell(new Phrase(row.Cells[3].Text, cellFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
            }

            document.Add(table);
            document.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=DetalleVenta.pdf");
            Response.BinaryWrite(memoryStream.ToArray());
            Response.End();
        }

    }
}