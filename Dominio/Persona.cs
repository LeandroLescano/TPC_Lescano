using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CUIT { get; set; }
        public string Mail { get; set; }
        public string TelefonoLinea { get; set; }
        public string TelefonoCelular { get; set; }

        //Se comparte el Cliente, Vendedor y Administrador
        //public string NombreUsuario { get; set; }
        //public string Contraseña { get; set; }
    }
}
