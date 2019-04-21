﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public TipoPersona Tipo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public List<Domicilio> Domicilio { get; set; }
        public List<Mail> Mails { get; set; }
        public List<Telefono> Telefonos { get; set; }
    }
}
