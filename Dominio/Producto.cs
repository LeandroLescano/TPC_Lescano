using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto : TipoProducto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Peso { get; set; } //En caso de que sea fraccionable
        public int PorcentajeGanancia { get; set; }
        public int Stock { get; set; }
        public List<Proveedor> Proveedor { get; set; }
    }
}
