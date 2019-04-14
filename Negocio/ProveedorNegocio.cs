using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listarProveedores()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Proveedor> listado = new List<Proveedor>();
            Proveedor nuevo;
            try
            {
                conexion.ConnectionString = "data source=DESKTOP-OT8NQNL\\SQLEXPRESS; initial catalog=FIAMBRERIA; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select ID, NOMBRE FROM PROVEEDORES";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new Proveedor();
                    nuevo.Codigo = lector.GetInt32(0);
                    nuevo.Nombre = lector.GetString(1);
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
                conexion.Close();
            }
        }
    }
}
