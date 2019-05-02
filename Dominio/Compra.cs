using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public string ID { get; set; }
        public Proveedor Proveedor { get; set; }
        public DetalleCompra Detalle { get; set; }

    }
}
