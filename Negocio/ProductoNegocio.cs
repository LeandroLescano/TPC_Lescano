using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listarProductos()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Producto> listado = new List<Producto>();
            Producto nuevo;
            try
            {
                conexion.ConnectionString = "data source=DESKTOP-OT8NQNL\\SQLEXPRESS; initial catalog=FIAMBRERIA; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select P.ID, P.NOMBRE, M.NOMBRE, PROV.NOMBRE from PRODUCTOS AS P INNER JOIN MARCAS AS M ON M.ID = P.IDMARCA INNER JOIN PROVEEDORES AS PROV ON PROV.ID = P.IDPROVEEDOR";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    nuevo = new Producto();
                    nuevo.Codigo = lector.GetInt32(0);
                    nuevo.Nombre = lector.GetString(1);
                    nuevo.Marca = lector.GetString(2);
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
