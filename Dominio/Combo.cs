using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Combo
    {
        public string Nombre { get; set; }
        public List<Producto> Productos { get; set; }
        public string Descripción { get; set; }
        public int DiasAnticipo { get; set; }
        public decimal Precio { get; set; }
    }
}
