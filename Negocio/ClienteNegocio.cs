﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<string> listarNombresClientes()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<string> listado = new List<string>();
            try
            {
                accesoDatos.setearConsulta("SELECT RAZONSOCIAL AS NOMBRE FROM CLIENTES WHERE IDTIPOPERSONA = 2 UNION Select(APELLIDOS + ', ' + NOMBRES) AS NOMBRE FROM CLIENTES WHERE IDTIPOPERSONA = 1");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    listado.Add(accesoDatos.Lector.GetString(0));
                }
                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
