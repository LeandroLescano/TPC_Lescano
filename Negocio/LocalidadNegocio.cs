﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace negocioCom
{
    public class LocalidadNegocio
    {
        public int agregarLocalidad(Localidad nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO LOCALIDADES (NOMBRE, PARTIDO, CODPOSTAL) VALUES ('"+nuevo.Nombre+"', '"+nuevo.Partido+"', '"+nuevo.CPostal+ "') SELECT SCOPE_IDENTITY();");
                accesoDatos.abrirConexion();
                return accesoDatos.ejecutarAccionReturn();
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

        public int buscarLocalidad(Localidad loc)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int idLoc = -1;
                accesoDatos.setearConsulta("Select * FROM LOCALIDADES WHERE NOMBRE LIKE '"+loc.Nombre+"' AND PARTIDO LIKE '"+loc.Partido+"' AND CODPOSTAL LIKE '" + loc.CPostal + "'");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    idLoc = accesoDatos.Lector.GetInt32(0);
                }
                return idLoc;
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
