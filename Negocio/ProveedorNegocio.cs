using System;
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
                accesoDatos.setearConsulta("Select * FROM PROVEEDORES");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Proveedor();
                    if((int)accesoDatos.Lector["IDTIPOPERSONA"] == 2)
                    {
                        nuevo.ID = accesoDatos.Lector.GetInt32(0);
                        nuevo.RazonSocial = accesoDatos.Lector.GetString(3);
                        nuevo.DNI = accesoDatos.Lector.GetString(4);
                        nuevo.CUIT = accesoDatos.Lector.GetString(5);
                        listado.Add(nuevo);
                    }
                    else
                    {
                        nuevo.ID = accesoDatos.Lector.GetInt32(0);
                        nuevo.Apellido = accesoDatos.Lector.GetString(1);
                        nuevo.Nombre = accesoDatos.Lector.GetString(2);
                        nuevo.DNI = accesoDatos.Lector.GetString(4);
                        nuevo.CUIT = accesoDatos.Lector.GetString(5);
                        listado.Add(nuevo);
                    }
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
