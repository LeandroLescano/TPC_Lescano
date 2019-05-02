using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor : Persona
    {
        public int ID { get; set; }
        public Usuario Usuario { get; set; }

        public override string ToString()
        {
            TipoPersona = new TipoPersona();
            if (TipoPersona.Fisica)
            {
                return Apellido + ", " + Nombre;
            }
            else
            {
                return RazonSocial;
            }
        }
    }
}
