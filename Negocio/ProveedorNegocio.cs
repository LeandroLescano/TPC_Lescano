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

        public List<ProveedorLite> listarProveedoresXProducto(int idProd)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<ProveedorLite> listado = new List<ProveedorLite>();
            ProveedorLite nuevo = new ProveedorLite();
            try
            {
                accesoDatos.setearConsulta("Select P.ID, (P.NOMBRES + ', ' + P.APELLIDOS) AS 'NOMBRE Y/O RAZON SOCIAL', P.DNI, P.CUIT from PROVEEDORES_X_PRODUCTO as PP inner join PROVEEDORES as P on P.ID = PP.IDPROVEEDOR Where PP.IDPRODUCTO = " + idProd + " AND IDTIPOPERSONA = 1 UNION Select P.ID, RAZONSOCIAL, P.DNI, P.CUIT from PROVEEDORES_X_PRODUCTO as PP inner join PROVEEDORES as P on P.ID = PP.IDPROVEEDOR Where PP.IDPRODUCTO = " + idProd + "AND IDTIPOPERSONA = 2");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new ProveedorLite();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Nombre = accesoDatos.Lector.GetString(1);
                    nuevo.DNI = accesoDatos.Lector.GetString(2).ToString();
                    nuevo.CUIT = accesoDatos.Lector.GetString(3).ToString();
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

        public void agregarProvXProductos(int IDProd, Proveedor Prov)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO PROVEEDORES_X_PRODUCTO (IDPRODUCTO, IDPROVEEDOR) VALUES(" + IDProd + ", " + Prov.ID + ")");
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

        public void eliminarProvXProductos(int IDProd)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.abrirConexion();
                accesoDatos.setearConsulta("DELETE FROM PROVEEDORES_X_PRODUCTO WHERE IDPRODUCTO = " + IDProd);
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
    }
}
