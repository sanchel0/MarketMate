﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class RecepcionBE
    {
        public RecepcionBE(OrdenCompraBE orden, DateTime fechaR, int numFact, decimal montoFact, DateTime fechaFact)
        {
            Orden = orden;
            FechaRecepcion = fechaR;
            NumeroFactura = numFact;
            MontoFactura = montoFact;
            FechaFactura = fechaFact;
        }
        public int NumeroRecepcion { get; set; }
        public OrdenCompraBE Orden { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public List<DetalleRecepcionBE> Detalles { get; set; }
        public int NumeroFactura { get; set; }
        public decimal MontoFactura { get; set; }
        public DateTime FechaFactura { get; set; }
    }
}
