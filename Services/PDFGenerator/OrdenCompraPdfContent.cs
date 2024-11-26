using BE;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Services
{
    public class OrdenCompraPdfContent : BasePdfContent
    {
        private List<OrdenCompraBE> _ordenes;
        private bool _isSingle;
        public OrdenCompraPdfContent(List<OrdenCompraBE> ordenes)
        {
            _ordenes = ordenes;
            _isSingle = _ordenes.Count == 1;
            
        }

        public OrdenCompraPdfContent(OrdenCompraBE orden)
        {
            _ordenes = new List<OrdenCompraBE> { orden };
            _isSingle = true;
        }

        public override void GeneratePdfContent(Document document)
        {
            if (_isSingle)
            {
                GenerateSingleOrderContent(document);
            }
            else
            {
                GenerateMultipleOrdersContent(document);
            }
        }

        private void GenerateSingleOrderContent(Document document)
        {
            var orden = _ordenes[0];

            Paragraph title = new Paragraph(GetTranslation("PurchaseOrderReport"), fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            document.Add(title);

            // Información de la orden de compra
            document.Add(new Paragraph($"{GetTranslation("OrderNumber")}: {orden.NumeroOrden}"));
            if (orden.NumeroTransferencia.HasValue)
                document.Add(new Paragraph($"{GetTranslation("TransferNumber")}: {orden.NumeroTransferencia}"));
            document.Add(new Paragraph($"{GetTranslation("QuotationNumber")}: {orden.NumeroCotizacion}"));
            document.Add(new Paragraph($"{GetTranslation("IssueDate")}: {orden.FechaEmision:dd/MM/yyyy}"));
            document.Add(new Paragraph($"{GetTranslation("DeliveryDeadline")}: {orden.FechaLimiteEntrega:dd/MM/yyyy}"));
            document.Add(new Paragraph($"{GetTranslation("Status")}: {GetTranslation(orden.Estado)}"));
            document.Add(new Paragraph($"{GetTranslation("Total")}: {orden.Total:C}"));

            // Información del proveedor
            document.Add(new Paragraph(new Phrase(GetTranslation("SupplierDetails"), fontSubTitle)) { Alignment = Element.ALIGN_LEFT, SpacingBefore = 10f, SpacingAfter = 10f });
            document.Add(new Paragraph($"{GetTranslation("CUIT")}: {orden.Proveedor.CUIT}"));
            document.Add(new Paragraph($"{GetTranslation("SupplierName")}: {orden.Proveedor.Nombre}"));
            document.Add(new Paragraph($"{GetTranslation("Email")}: {orden.Proveedor.Correo}"));
            document.Add(new Paragraph($"{GetTranslation("Phone")}: {orden.Proveedor.Telefono}"));

            document.Add(new Paragraph(new Phrase(GetTranslation("ProductDetails"), fontSubTitle)) { Alignment = Element.ALIGN_LEFT, SpacingBefore = 10f, SpacingAfter = 10f });

            PdfPTable table = new PdfPTable(7);
            table.WidthPercentage = 100;

            // Encabezados de la tabla
            table.AddCell(GetTranslation("Product"));
            table.AddCell(GetTranslation("RequestedQuantity"));
            table.AddCell(GetTranslation("ReceivedQuantity"));
            table.AddCell(GetTranslation("UnitPrice"));
            table.AddCell(GetTranslation("Subtotal"));
            table.AddCell(GetTranslation("VAT"));
            table.AddCell(GetTranslation("TotalWithVAT"));

            foreach (var detalle in orden.Detalles)
            {
                table.AddCell(GetTranslation(detalle.Producto.Nombre));
                table.AddCell(detalle.CantidadSolicitada.ToString());
                table.AddCell(detalle.CantidadRecibida.ToString());
                table.AddCell($"{detalle.PrecioUnitario:C}");
                table.AddCell($"{detalle.SubTotal:C}");
                table.AddCell($"{detalle.PorcentajeIVA}%");
                table.AddCell($"{detalle.TotalConIVA:C}");
            }

            document.Add(table);
        }

        private void GenerateMultipleOrdersContent(Document document)
        {
            document.Add(new Paragraph(GetTranslation("PurchaseOrdersReportMultiple"), FontFactory.GetFont(FontFactory.TIMES, 16, BaseColor.BLACK)));

            PdfPTable table = new PdfPTable(6);
            table.WidthPercentage = 100;

            // Encabezados de la tabla
            table.AddCell(GetTranslation("OrderNumber"));
            table.AddCell(GetTranslation("IssueDate"));
            table.AddCell(GetTranslation("DeliveryDeadline"));
            table.AddCell(GetTranslation("Total"));
            table.AddCell(GetTranslation("Status"));
            table.AddCell(GetTranslation("Supplier"));

            foreach (var orden in _ordenes)
            {
                table.AddCell(orden.NumeroOrden.ToString());
                table.AddCell(orden.FechaEmision.ToShortDateString());
                table.AddCell(orden.FechaLimiteEntrega.ToShortDateString());
                table.AddCell(orden.Total.ToString("C"));
                table.AddCell(GetTranslation(orden.Estado));
                table.AddCell(orden.Proveedor.Nombre);
            }

            document.Add(table);
        }
    }
}
