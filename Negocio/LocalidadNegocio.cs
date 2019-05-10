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
        public int agregarLocalidad(Localidad nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int idLoc = 0;
                accesoDatos.setearConsulta("INSERT INTO LOCALIDADES (NOMBRE, PARTIDO, CODPOSTAL) VALUES ('"+nuevo.Nombre+"', '"+nuevo.Partido+"', '"+nuevo.CPostal+ "') SELECT TOP 1 ID from LOCALIDADES ORDER BY ID DESC");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
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

        public void modificarLocalidad(Domicilio modif)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                LocalidadNegocio negocio = new LocalidadNegocio();
                accesoDatos.setearConsulta("UPDATE LOCALIDADES SET NOMBRE=@Nombre, PARTIDO=@Partido, CODPOSTAL=@CodPostal WHERE ID=" + modif.Localidad.ID);
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modif.Localidad.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Partido", modif.Localidad.Partido);
                accesoDatos.Comando.Parameters.AddWithValue("@CodPostal", modif.Localidad.CPostal);
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

        public int idLocalidad(string Nombre, int idDom)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int idLoc = -1;
                accesoDatos.setearConsulta("Select L.ID FROM LOCALIDADES AS L INNER JOIN DOMICILIOS AS D ON D.IDLOCALIDAD = L.ID where L.NOMBRE LIKE '" + Nombre + "' AND D.ID = "+ idDom);
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

        //public int idLocalidad(string Nombre, string Partido)
        //{
        //    AccesoDatosManager accesoDatos = new AccesoDatosManager();
        //    try
        //    {
        //        int idLoc = -1;
        //        accesoDatos.setearConsulta("Select ID FROM LOCALIDADES where NOMBRE LIKE '" + Nombre + "' AND PARTIDO LIKE '"+ Partido +"'");
        //        accesoDatos.abrirConexion();
        //        accesoDatos.ejecutarConsulta();
        //        while (accesoDatos.Lector.Read())
        //        {
        //            idLoc = accesoDatos.Lector.GetInt32(0);
        //        }
        //        return idLoc;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        accesoDatos.cerrarConexion();
        //    }
        //}

    }
}
