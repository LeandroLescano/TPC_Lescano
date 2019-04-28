﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listarProveedores()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<Proveedor> listado = new List<Proveedor>();
            Proveedor nuevo;
            try
            {
                accesoDatos.setearConsulta("Select ID, RAZONSOCIAL FROM PROVEEDORES");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Proveedor();
                    nuevo.Codigo = accesoDatos.Lector.GetInt32(0);
                    nuevo.RazonSocial = accesoDatos.Lector.GetString(1);
                    listado.Add(nuevo);
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
