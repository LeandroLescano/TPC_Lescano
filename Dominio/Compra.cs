using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public string Codigo { get; set; }
        public Proveedor Proveedor { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario
        {
            get { return Producto.PrecioUnitario; }
        }
        public decimal PrecioFinal
        {
            get { return PrecioUnitario * Cantidad; }
        }
    }
}
