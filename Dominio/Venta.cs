using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public string ID { get; set; }
        public Cliente Cliente { get; set; }
        public Factura Factura { get; set; }
        public List<DetalleVenta> Detalle { get; set; }
        public decimal Importe { get; set; }
    }
}
