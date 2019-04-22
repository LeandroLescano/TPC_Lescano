using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int Codigo { get; set; }
        public Picada Picada { get; set; }
        public string Descripcion { get; set; }
        public Cliente Cliente { get; set; }
    }
}
