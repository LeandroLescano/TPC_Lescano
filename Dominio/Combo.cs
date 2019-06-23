using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Combo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public List<DetalleCombo> Productos { get; set; }
        public string Descripcion { get; set; }
        public int DiasAnticipo { get; set; }
        public decimal Precio { get; set; }
        public string RutaImagen { get; set; }
        public bool Estado { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
