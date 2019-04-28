using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<string> listarNombresMarcas()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<string> listado = new List<string>();
            try
            {
                accesoDatos.setearConsulta("SELECT NOMBRE FROM MARCAS");
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
