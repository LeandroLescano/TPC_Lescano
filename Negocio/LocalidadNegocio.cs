using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class LocalidadNegocio
    {
        public void agregarLocalidad(Localidad nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO LOCALIDADES (NOMBRE, PARTIDO, CODPOSTAL) VALUES ('"+nuevo.Nombre+"', '"+nuevo.Partido+"', '"+nuevo.CPostal+"')");
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

        public int idLocalidad(string Nombre, string Partido)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int idLoc = -1;
                accesoDatos.setearConsulta("Select ID FROM LOCALIDADES where NOMBRE LIKE '" + Nombre + "' AND PARTIDO LIKE '"+ Partido + "'");
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
