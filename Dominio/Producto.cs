using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int ID { get; set; }
        public Categoria Categoria { get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool Fraccionable { get; set; }
        public decimal Peso { get; set; } //En caso de que sea fraccionable
        public decimal PorcentajeGanancia { get; set; }
        public List<Proveedor> Proveedor { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
