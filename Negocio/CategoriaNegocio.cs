﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listarCategorias()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<Categoria> listado = new List<Categoria>();
            Categoria nueva;
            try
            {
                accesoDatos.setearConsulta("SELECT ID, NOMBRE FROM CATEGORIAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nueva = new Categoria();
                    nueva.ID = accesoDatos.Lector.GetInt32(0);
                    nueva.Nombre = accesoDatos.Lector.GetString(1);
                    listado.Add(nueva);
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

        public void agregarCategoria(Categoria nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO CATEGORIAS (NOMBRE) VALUES('" + nuevo.Nombre + "')");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();
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
