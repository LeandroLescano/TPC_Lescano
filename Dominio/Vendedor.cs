﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vendedor : Persona
    {
        public int Codigo { get; set; }
        public string CUIL { get; set; }
        public decimal Sueldo { get; set; }

    }
}
