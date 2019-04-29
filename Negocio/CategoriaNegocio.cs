using System;
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
        public List<string> listarNombresCategorias()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<string> listado = new List<string>();
            try
            {
                accesoDatos.setearConsulta("SELECT NOMBRE FROM CATEGORIAS");
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
