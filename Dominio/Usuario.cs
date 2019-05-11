using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }

        public override string ToString()
        {
            if (Nombre != null)
            {
                return Nombre;
            }
            else
            {
                return "Sin registro de usuario.";
            }
        }
    }
}
