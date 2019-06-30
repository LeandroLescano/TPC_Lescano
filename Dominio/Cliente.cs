using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Persona
    {
        public int ID { get; set; }
        public Usuario Usuario { get; set; }

        public override string ToString()
        {
            if (this.TipoPersona.Fisica == true)
            {
                if (Nombre != "")
                    return Apellido + ", " + Nombre;
                else
                    return Apellido;
            }
            else
            {
                return RazonSocial;
            }
        }
    }
}
