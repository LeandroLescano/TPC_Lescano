using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoEmpleado
    {
        public bool Vendedor { get; set; }
        public bool Administrador { get; set; }

        public override string ToString()
        {
            if (Vendedor)
                return "Vendedor";
            else
                return "Administrador";
        }
    }
}
