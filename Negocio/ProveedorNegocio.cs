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
                accesoDatos.setearConsulta("Select P.*, D.CALLE, D.ALTURA, L.NOMBRE as LOCALIDAD from PROVEEDORES AS P LEFT JOIN DOMICILIOS AS D ON D.ID = P.IDDOMICILIO LEFT JOIN LOCALIDADES AS L ON L.ID = D.IDLOCALIDAD");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Proveedor();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.TipoPersona = new TipoPersona();
                    if((int)accesoDatos.Lector["IDTIPOPERSONA"] == 2)
                    {
                        nuevo.RazonSocial = accesoDatos.Lector.GetString(3);
                        nuevo.TipoPersona.Juridica = true;
                    }
                    else
                    {
                        nuevo.Apellido = accesoDatos.Lector.GetString(1);
                        nuevo.Nombre = accesoDatos.Lector.GetString(2);
                        nuevo.TipoPersona.Fisica = true;
                    }
                    nuevo.CUIT = accesoDatos.Lector.GetString(5);
                    nuevo.DNI = accesoDatos.Lector.GetString(4);
                    nuevo.Domicilio = new Domicilio();
                    nuevo.Domicilio.Localidad = new Localidad();
                    if (!Convert.IsDBNull(accesoDatos.Lector["CALLE"]))
                        nuevo.Domicilio.Calle = accesoDatos.Lector.GetString(8);    
                    if (!Convert.IsDBNull(accesoDatos.Lector["ALTURA"]))
                        nuevo.Domicilio.Altura = accesoDatos.Lector.GetInt32(9);
                    if (!Convert.IsDBNull(accesoDatos.Lector["LOCALIDAD"]))
                        nuevo.Domicilio.Localidad.Nombre = accesoDatos.Lector.GetString(10);
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

        public void agregarProveedor(Proveedor nuevo, int IDDomicilio)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int IDTipoPersona;
                if(nuevo.TipoPersona.Fisica)
                {
                    IDTipoPersona = 1;
                }
                else
                {
                    IDTipoPersona = 2;
                }
                accesoDatos.setearConsulta("INSERT INTO PROVEEDORES (APELLIDOS, NOMBRES, RAZONSOCIAL, DNI, CUIT, IDDOMICILIO, IDTIPOPERSONA) VALUES ('"+ nuevo.Apellido +"', '" + nuevo.Nombre + "', '" + nuevo.RazonSocial +"', '" + nuevo.DNI + "', '" + nuevo.CUIT + "', "+ IDDomicilio +", "+ IDTipoPersona +")");
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

        public void modificarProveedor(Proveedor modif, int idDomicilio)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int TipoPersona;
                accesoDatos.setearConsulta("ALTER TABLE PROVEEDORES NOCHECK CONSTRAINT FK__PROVEEDOR__IDDOM__6A30C649  UPDATE PROVEEDORES Set APELLIDOS=@Apellido, NOMBRES=@Nombre, RAZONSOCIAL=@RazonSocial, DNI=@Dni, IDDOMICILIO=@Domicilio, IDTIPOPERSONA=@TipoPersona, CUIT=@Cuit WHERE ID=" + modif.ID.ToString() + " ALTER TABLE PROVEEDORES CHECK CONSTRAINT FK__PROVEEDOR__IDDOM__6A30C649 ");
                accesoDatos.Comando.Parameters.Clear();
                if(modif.TipoPersona.Fisica)
                {
                    TipoPersona = 1;
                    accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modif.Nombre);
                    accesoDatos.Comando.Parameters.AddWithValue("@Apellido", modif.Apellido);
                    accesoDatos.Comando.Parameters.AddWithValue("@RazonSocial", "");
                }
                else
                {
                    TipoPersona = 2;
                    accesoDatos.Comando.Parameters.AddWithValue("@RazonSocial", modif.RazonSocial);
                    accesoDatos.Comando.Parameters.AddWithValue("@Nombre", "");
                    accesoDatos.Comando.Parameters.AddWithValue("@Apellido", "");
                }
                accesoDatos.Comando.Parameters.AddWithValue("@Dni", modif.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@Cuit", modif.CUIT);
                accesoDatos.Comando.Parameters.AddWithValue("@Domicilio", idDomicilio);
                accesoDatos.Comando.Parameters.AddWithValue("@TipoPersona", TipoPersona);
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
