using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoEmpleado
    {
        public bool Vendedor { get { return Vendedor; } set { if (Administrador) Vendedor = false;} }
        public bool Administrador { get { return Administrador; } set { if (Vendedor) Administrador = false;} }
    }
}
