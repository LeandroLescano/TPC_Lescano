using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int ID { get; set; }
        public Combo Combo { get; set; }
        public string Descripcion { get; set; }
        public Cliente Cliente { get; set; }
        public decimal PrecioFinal { get; set; }
        public string Estado { get; set; }
    }
}
