﻿using BE;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Services
{
    public class OrdenCompraPdfContent : IPdfContent
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

        public void GeneratePdfContent(Document document)
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
            Font fontTitle = FontFactory.GetFont(FontFactory.TIMES_BOLD, 18f);
            Paragraph title = new Paragraph("Purchase Order Report", fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            document.Add(title);
            //document.Add(new Paragraph("Purchase Order Report (Single Order)", FontFactory.GetFont(FontFactory.TIMES, 16, BaseColor.BLACK)));
            // Información de la orden de compra
            document.Add(new Paragraph($"Número de Orden: {orden.NumeroOrden}"));
            if (orden.NumeroTransferencia.HasValue)
                document.Add(new Paragraph($"Número de Transferencia: {orden.NumeroTransferencia}"));
            document.Add(new Paragraph($"Número de Cotización: {orden.NumeroCotizacion}"));
            document.Add(new Paragraph($"Fecha de Emisión: {orden.FechaEmision:dd/MM/yyyy}"));
            document.Add(new Paragraph($"Fecha Límite de Entrega: {orden.FechaLimiteEntrega:dd/MM/yyyy}"));
            document.Add(new Paragraph($"Estado: {orden.Estado}"));
            document.Add(new Paragraph($"Total: {orden.Total:C}"));
            document.Add(new Paragraph("\n"));

            // Información del proveedor
            document.Add(new Paragraph("---Datos del Proveedor---"));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph($"CUIT: {orden.Proveedor.CUIT}")); 
            document.Add(new Paragraph($"Nombre: {orden.Proveedor.Nombre}"));
            document.Add(new Paragraph($"Correo Electrónico: {orden.Proveedor.Correo}"));
            document.Add(new Paragraph($"Teléfono: {orden.Proveedor.Telefono}"));
            document.Add(new Paragraph("\n"));

            document.Add(new Paragraph("Detalles de los Productos:") { Alignment = Element.ALIGN_LEFT, SpacingBefore = 10f });

            PdfPTable table = new PdfPTable(7);
            table.WidthPercentage = 100;

            table.AddCell("Producto");
            table.AddCell("Cantidad Solicitada");
            table.AddCell("Cantidad Recibida");
            table.AddCell("Precio Unitario");
            table.AddCell("Subtotal");
            table.AddCell("IVA");
            table.AddCell("Total (con IVA)");

            foreach (var detalle in orden.Detalles)
            {
                table.AddCell(detalle.Producto.Nombre);
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
            document.Add(new Paragraph("Purchase Orders Report (Multiple Orders)", FontFactory.GetFont(FontFactory.TIMES, 16, BaseColor.BLACK)));

            PdfPTable table = new PdfPTable(6);
            table.WidthPercentage = 100;
            table.AddCell("Order Number");
            table.AddCell("Issue Date");
            table.AddCell("Delivery Deadline");
            table.AddCell("Total");
            table.AddCell("Status");
            table.AddCell("Supplier");

            foreach (var orden in _ordenes)
            {
                table.AddCell(orden.NumeroOrden.ToString());
                table.AddCell(orden.FechaEmision.ToShortDateString());
                table.AddCell(orden.FechaLimiteEntrega.ToShortDateString());
                table.AddCell(orden.Total.ToString("C"));
                table.AddCell(orden.Estado);
                table.AddCell(orden.Proveedor.Nombre);
            }

            document.Add(table);
        }
    }
}
