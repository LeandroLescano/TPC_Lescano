using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public string Codigo { get; set; }
        public int NumFactura { get; set; }
        public Cliente Cliente { get; set; }
        public List<Producto> Producto { get; set; }
        public List<int> Cantidad { get; set; }
        public List<decimal> PrecioUnitario { get; set; }
        public List<decimal> PrecioParcial { get; set; }
        public decimal PrecioFinal { get; set; }
    }
}
