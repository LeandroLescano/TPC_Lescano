using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Factura
    {
        public int ID { get; set; }
        public int Numero { get; set; }
        public string CUIT { get; set; }
        public List<DetalleVenta> ListadoProductos { get; set; }
        public Domicilio Domicilio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaActual { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
    }
}
