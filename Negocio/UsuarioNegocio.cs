using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public int agregarUsuario(Usuario nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO USUARIOS (USUARIO, CONTRASEÑA) VALUES ('" + nuevo.Nombre + "', '" + nuevo.Contraseña + "') SELECT SCOPE_IDENTITY();");
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
