using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Comercio
    {
        public int ID { get; set; }
        public string NombreFantasia { get; set; }
        public string NombreJuridico { get; set; }
        public string CUIT { get; set; }
        public string IngresosBrutos { get; set; }
        public Domicilio Domicilio { get; set; }
        public DateTime FechaInicio { get; set; }
    }
}
