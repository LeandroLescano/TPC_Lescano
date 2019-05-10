using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listarMarcas()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<Marca> listado = new List<Marca>();
            Marca nueva;
            try
            {
                accesoDatos.setearConsulta("SELECT ID, NOMBRE FROM MARCAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nueva = new Marca();
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

        public void agregarMarca(Marca nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO MARCAS (NOMBRE) VALUES('" + nuevo.Nombre + "')");
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

        public void eliminarMarca(Marca marca)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("DELETE FROM MARCAS WHERE ID = " + marca.ID);
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
