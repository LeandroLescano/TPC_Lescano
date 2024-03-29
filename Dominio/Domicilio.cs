﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Domicilio
    {
        public int ID { get; set; }
        public Coordenada Coordenadas { get; set; }
        public Localidad Localidad { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string EntreCalle1 { get; set; }
        public string EntreCalle2 { get; set; }
        public Edificio Edificio { get; set; }

        public override string ToString()
        {
            if(Calle != null)
            {
                return Calle + ", " + Altura;
            }
            else
            {
                return "Sin registro de domicilio.";
            }
        }
    }
}
