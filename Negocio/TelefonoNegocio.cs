using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace negocioCom
{
    public class TelefonoNegocio
    {
        public int agregarTelefono(Telefono nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TELEFONOS (TELEFONO, DESCRIPCION) VALUES ('" + nuevo.Numero + "', '"+ nuevo.Descripcion +"') SELECT SCOPE_IDENTITY();");
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
    }
}
