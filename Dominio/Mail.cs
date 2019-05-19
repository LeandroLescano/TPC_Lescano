using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mail
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }

        public override string ToString()
        {
            return Direccion;
        }
    }
}
