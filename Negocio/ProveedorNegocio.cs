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
                accesoDatos.setearConsulta("Select P.*, D.CALLE, D.ALTURA, L.NOMBRE as LOCALIDAD, D.PISO, D.DEPARTAMENTO, L.CODPOSTAL, L.PARTIDO, L.ID AS IDLOCALIDAD, D.ENTRECALLE1, D.ENTRECALLE2 from PROVEEDORES AS P LEFT JOIN DOMICILIOS AS D ON D.ID = P.IDDOMICILIO LEFT JOIN LOCALIDADES AS L ON L.ID = D.IDLOCALIDAD");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Proveedor();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.TipoPersona = new TipoPersona();
                    nuevo.Estado = accesoDatos.Lector.GetBoolean(9);
                    if ((int)accesoDatos.Lector["IDTIPOPERSONA"] == 2)
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
                    nuevo.Domicilio.Edificio = new Edificio();


                    //Domicilio
                    if (!Convert.IsDBNull(accesoDatos.Lector["CALLE"]))
                        nuevo.Domicilio.Calle = accesoDatos.Lector.GetString(10);    
                    if (!Convert.IsDBNull(accesoDatos.Lector["ALTURA"]))
                        nuevo.Domicilio.Altura = accesoDatos.Lector.GetInt32(11);
                    if (!Convert.IsDBNull(accesoDatos.Lector["IDDOMICILIO"]))
                        nuevo.Domicilio.ID = accesoDatos.Lector.GetInt32(6);
                    if (!Convert.IsDBNull(accesoDatos.Lector["ENTRECALLE1"]))
                        nuevo.Domicilio.EntreCalle1 = accesoDatos.Lector.GetString(18);
                    if (!Convert.IsDBNull(accesoDatos.Lector["ENTRECALLE2"]))
                        nuevo.Domicilio.EntreCalle2 = accesoDatos.Lector.GetString(19);

                    //Edificio
                    if (!Convert.IsDBNull(accesoDatos.Lector["PISO"]))
                        nuevo.Domicilio.Edificio.Piso = accesoDatos.Lector.GetInt32(13);
                    if (!Convert.IsDBNull(accesoDatos.Lector["DEPARTAMENTO"]))
                        nuevo.Domicilio.Edificio.Departamento = accesoDatos.Lector.GetString(14);

                    //Localidad
                    if (!Convert.IsDBNull(accesoDatos.Lector["LOCALIDAD"]))
                        nuevo.Domicilio.Localidad.Nombre = accesoDatos.Lector.GetString(12);
                    if (!Convert.IsDBNull(accesoDatos.Lector["CODPOSTAL"]))
                        nuevo.Domicilio.Localidad.CPostal = accesoDatos.Lector.GetString(15);
                    if (!Convert.IsDBNull(accesoDatos.Lector["PARTIDO"]))
                        nuevo.Domicilio.Localidad.Partido = accesoDatos.Lector.GetString(16);
                    if (!Convert.IsDBNull(accesoDatos.Lector["IDLOCALIDAD"]))
                        nuevo.Domicilio.Localidad.ID = accesoDatos.Lector.GetInt32(17);

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

        public void agregarProveedor(Proveedor nuevo)
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
                accesoDatos.setearConsulta("INSERT INTO PROVEEDORES (APELLIDOS, NOMBRES, RAZONSOCIAL, DNI, CUIT, IDDOMICILIO, IDTIPOPERSONA) VALUES (@Apellido, @Nombre, @RazonSocial, @DNi, @CUIT, @Domicilio, @TipoPersona)");
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", esNulo(nuevo.Apellido));
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", esNulo(nuevo.Nombre));
                accesoDatos.Comando.Parameters.AddWithValue("@RazonSocial", esNulo(nuevo.RazonSocial));
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", nuevo.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@CUIT", nuevo.CUIT);
                if(nuevo.Domicilio.ID != 0)
                {
                    accesoDatos.Comando.Parameters.AddWithValue("@Domicilio", nuevo.Domicilio.ID);
                }
                else
                {
                    accesoDatos.Comando.Parameters.AddWithValue("@Domicilio", DBNull.Value);
                }
                accesoDatos.Comando.Parameters.AddWithValue("@TipoPersona", IDTipoPersona);

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

        public void modificarProveedor(Proveedor modif)
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
                accesoDatos.Comando.Parameters.AddWithValue("@Domicilio", modif.Domicilio.ID);
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

        public void eliminarProveedor(Proveedor prov)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("DELETE FROM PROVEEDORES WHERE ID = " + prov.ID);
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

        public void habilitarProveedor(Proveedor prov)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE PROVEEDORES SET ESTADO = 1 WHERE ID = " + prov.ID);
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

        //PROVEEDORES X PRODUCTO
        public List<ProveedorLite> listarProveedoresXProducto(int IDProd)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<ProveedorLite> listado = new List<ProveedorLite>();
            ProveedorLite nuevo = new ProveedorLite();
            try
            {
                accesoDatos.setearConsulta("Select P.ID, (P.NOMBRES + ', ' + P.APELLIDOS) AS 'NOMBRE Y/O RAZON SOCIAL', P.DNI, P.CUIT from PROVEEDORES_X_PRODUCTO as PP inner join PROVEEDORES as P on P.ID = PP.IDPROVEEDOR Where PP.IDPRODUCTO = " + IDProd + " AND IDTIPOPERSONA = 1 UNION Select P.ID, RAZONSOCIAL, P.DNI, P.CUIT from PROVEEDORES_X_PRODUCTO as PP inner join PROVEEDORES as P on P.ID = PP.IDPROVEEDOR Where PP.IDPRODUCTO = " + IDProd + "AND IDTIPOPERSONA = 2");
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

        //MAILS POR PROVEEDOR
        public List<Mail> listarMailsXProveedor(Proveedor prov)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<Mail> listado = new List<Mail>();
            Mail nuevo;
            try
            {
                accesoDatos.setearConsulta("SELECT M.* FROM MAILS AS M INNER JOIN MAILS_X_PROVEEDORES AS MP ON MP.IDMAIL = M.ID WHERE MP.IDPROVEEDOR =" + prov.ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Mail();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Direccion = accesoDatos.Lector.GetString(1);
                    nuevo.Descripcion = accesoDatos.Lector.GetString(2);
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

        public void agregarMailXProveedor(Proveedor local, int IDMail)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO MAILS_X_PROVEEDORES (IDPROVEEDOR, IDMAIL) VALUES(" + local.ID + ", " + IDMail + ")");
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

        public void eliminarMailXProveedor(Proveedor prov)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.abrirConexion();
                accesoDatos.setearConsulta("DELETE FROM MAILS_X_PROVEEDORES WHERE IDPROVEEDOR = " + prov.ID);
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

        //TELEFONOS POR PROVEEDOR
        public List<Telefono> listarTelefonosXProveedor(Proveedor prov)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<Telefono> listado = new List<Telefono>();
            Telefono nuevo;
            try
            {
                accesoDatos.setearConsulta("SELECT T.* FROM TELEFONOS AS T INNER JOIN TELEFONOS_X_PROVEEDORES AS TP ON TP.IDTELEFONO = T.ID WHERE TP.IDPROVEEDOR = " + prov.ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Telefono();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Numero = accesoDatos.Lector.GetString(1);
                    nuevo.Descripcion = accesoDatos.Lector.GetString(2);
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

        public void agregarTelefonoXProveedor(Proveedor prov, int IDTel)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TELEFONOS_X_PROVEEDORES (IDPROVEEDOR, IDTELEFONO) VALUES(" + prov.ID + ", " + IDTel + ")");
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

        public void eliminarTelefonoXProveedor(Proveedor prov)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.abrirConexion();
                accesoDatos.setearConsulta("DELETE FROM TELEFONOS_X_PROVEEDORES WHERE IDPROVEEDOR = " + prov.ID);
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

        private object esNulo(object campo)
        {
            if (campo == null)
                return "";
            else
                return campo;
        }
    }
}
