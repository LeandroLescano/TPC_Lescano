using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Complejo
    {
        public int Codigo { get; set; }
        //Complejo de viviendas
        public string Manzana { get; set; }
        public string NumeroVivienda { get; set; }
        //Complejo de torres
        public string NumeroTorre { get; set; }
        public Edificio Torre { get; set; }
    }
}
