using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listarProductos()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<Producto> listado = new List<Producto>();
            Producto nuevo = new Producto();
            try
            {
                accesoDatos.setearConsulta("Select P.ID, P.NOMBRE, M.NOMBRE as MARCA ,P.PRECIOUNITARIO ,P.STOCK,PROV.ID, PROV.RAZONSOCIAL,C.NOMBRE AS CATEGORIA from PRODUCTOS AS P LEFT JOIN MARCAS AS M ON M.ID = P.IDMARCA LEFT JOIN PROVEEDORES_X_PRODUCTO AS PP ON PP.IDPRODUCTO = P.ID LEFT JOIN PROVEEDORES AS PROV ON PROV.ID = PP.IDPROVEEDOR LEFT JOIN CATEGORIAS AS C ON C.ID = P.IDCATEGORIA");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Producto();
                    nuevo.Codigo = accesoDatos.Lector.GetInt32(0);
                    nuevo.Nombre = accesoDatos.Lector.GetString(1);
                    nuevo.Marca = new Marca();
                    nuevo.Marca.Nombre = accesoDatos.Lector["MARCA"].ToString();
                    nuevo.PrecioUnitario = accesoDatos.Lector.GetDecimal(3);
                    nuevo.Proveedor = new List<Proveedor>();
                    nuevo.Proveedor.Add(convertirProveedor(accesoDatos.Lector)); 
                    nuevo.Categoria = new Categoria();
                    nuevo.Categoria.Nombre = accesoDatos.Lector["CATEGORIA"].ToString();
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
                accesoDatos.cerrarConexion();
            }
        }

        private Proveedor convertirProveedor(SqlDataReader lector)
        {
            Proveedor prov = new Proveedor();
            prov.Codigo = lector.GetInt32(5);
            prov.RazonSocial = lector.GetString(6);
            return prov;
        }

        public List<string> listarNombresProd()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<string> listado = new List<string>();
            try
            {
                accesoDatos.setearConsulta("SELECT NOMBRE FROM PRODUCTOS");
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
