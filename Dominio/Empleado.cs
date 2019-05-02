using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado : Persona
    {
        public int ID { get; set; }
        public string CUIL { get; set; }
        public TipoEmpleado TipoEmpleado { get; set; }
        public Usuario Usuario { get; set; }
    }
}
