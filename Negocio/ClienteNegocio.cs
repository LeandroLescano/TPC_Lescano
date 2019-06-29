using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {

        public List<Cliente> listarClientes()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            DomicilioNegocio negocioD = new DomicilioNegocio();
            List<Cliente> listado = new List<Cliente>();
            Cliente nuevo = new Cliente();
            try
            {
                accesoDatos.setearConsulta("Select C.*, D.CALLE, D.ALTURA, L.NOMBRE as LOCALIDAD, D.PISO, D.DEPARTAMENTO, L.CODPOSTAL, L.PARTIDO, L.ID AS IDLOCALIDAD, D.ENTRECALLE1, D.ENTRECALLE2, M.MAIL from CLIENTES AS C LEFT JOIN DOMICILIOS AS D ON D.ID = C.IDDOMICILIO LEFT JOIN LOCALIDADES AS L ON L.ID = D.IDLOCALIDAD LEFT JOIN MAILS_X_CLIENTES AS MC ON MC.IDCLIENTE = C.ID LEFT JOIN MAILS AS M ON M.ID = MC.IDMAIL ");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Cliente();
                    nuevo.TipoPersona = new TipoPersona();
                    nuevo.Usuario = new Usuario();
                    nuevo.Domicilio = new Domicilio();
                    nuevo.Domicilio.Localidad = new Localidad();
                    nuevo.Domicilio.Edificio = new Edificio();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Estado = accesoDatos.Lector.GetBoolean(10);
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
                        nuevo.FechaNacimiento = accesoDatos.Lector.GetDateTime(6);
                    }
                    nuevo.DNI = accesoDatos.Lector.GetString(4);
                    nuevo.CUIT = accesoDatos.Lector.GetString(5);

                    //Usuario
                    if (!Convert.IsDBNull(accesoDatos.Lector["IDUSUARIO"]))
                        nuevo.Usuario.ID = accesoDatos.Lector.GetInt32(8);

                    //Domicilio
                    if (!Convert.IsDBNull(accesoDatos.Lector["IDDOMICILIO"]))
                        nuevo.Domicilio = negocioD.listarDomicilio(accesoDatos.Lector.GetInt32(7));

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

        public Cliente listarCliente(int ID)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Cliente nuevo = new Cliente();
            try
            {
                accesoDatos.setearConsulta("Select C.*, D.CALLE, D.ALTURA, L.NOMBRE as LOCALIDAD, D.PISO, D.DEPARTAMENTO, L.CODPOSTAL, L.PARTIDO, L.ID AS IDLOCALIDAD, D.ENTRECALLE1, D.ENTRECALLE2, M.MAIL from CLIENTES AS C LEFT JOIN DOMICILIOS AS D ON D.ID = C.IDDOMICILIO LEFT JOIN LOCALIDADES AS L ON L.ID = D.IDLOCALIDAD LEFT JOIN MAILS_X_CLIENTES AS MC ON MC.IDCLIENTE = C.ID LEFT JOIN MAILS AS M ON M.ID = MC.IDMAIL WHERE C.ID = " + ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Cliente();
                    nuevo.TipoPersona = new TipoPersona();
                    nuevo.Usuario = new Usuario();
                    nuevo.Domicilio = new Domicilio();
                    nuevo.Domicilio.Localidad = new Localidad();
                    nuevo.Domicilio.Edificio = new Edificio();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Estado = accesoDatos.Lector.GetBoolean(10);
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
                        nuevo.FechaNacimiento = accesoDatos.Lector.GetDateTime(6);
                    }
                    nuevo.DNI = accesoDatos.Lector.GetString(4);
                    nuevo.CUIT = accesoDatos.Lector.GetString(5);

                    //Usuario
                    if (!Convert.IsDBNull(accesoDatos.Lector["IDUSUARIO"]))
                        nuevo.Usuario.ID = accesoDatos.Lector.GetInt32(8);

                    //Domicilio
                    if (!Convert.IsDBNull(accesoDatos.Lector["IDDOMICILIO"]))
                        nuevo.Domicilio.ID = accesoDatos.Lector.GetInt32(7);
                    if (!Convert.IsDBNull(accesoDatos.Lector["CALLE"]))
                        nuevo.Domicilio.Calle = accesoDatos.Lector.GetString(11);
                    if (!Convert.IsDBNull(accesoDatos.Lector["ALTURA"]))
                        nuevo.Domicilio.Altura = accesoDatos.Lector.GetInt32(12);
                    if (!Convert.IsDBNull(accesoDatos.Lector["ENTRECALLE1"]))
                        nuevo.Domicilio.EntreCalle1 = accesoDatos.Lector.GetString(19);
                    if (!Convert.IsDBNull(accesoDatos.Lector["ENTRECALLE2"]))
                        nuevo.Domicilio.EntreCalle2 = accesoDatos.Lector.GetString(20);

                    //Edificio
                    if (!Convert.IsDBNull(accesoDatos.Lector["PISO"]))
                        nuevo.Domicilio.Edificio.Piso = accesoDatos.Lector.GetInt32(14);
                    if (!Convert.IsDBNull(accesoDatos.Lector["DEPARTAMENTO"]))
                        nuevo.Domicilio.Edificio.Departamento = accesoDatos.Lector.GetString(15);

                    //Localidad
                    if (!Convert.IsDBNull(accesoDatos.Lector["LOCALIDAD"]))
                        nuevo.Domicilio.Localidad.Nombre = accesoDatos.Lector.GetString(13);
                    if (!Convert.IsDBNull(accesoDatos.Lector["CODPOSTAL"]))
                        nuevo.Domicilio.Localidad.CPostal = accesoDatos.Lector.GetString(16);
                    if (!Convert.IsDBNull(accesoDatos.Lector["PARTIDO"]))
                        nuevo.Domicilio.Localidad.Partido = accesoDatos.Lector.GetString(17);
                    if (!Convert.IsDBNull(accesoDatos.Lector["IDLOCALIDAD"]))
                        nuevo.Domicilio.Localidad.ID = accesoDatos.Lector.GetInt32(18);
                }

                return nuevo;
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

        public void agregarCliente(Cliente nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int IDTipoPersona;
                if (nuevo.TipoPersona.Fisica)
                {
                    IDTipoPersona = 1;
                }
                else
                {
                    IDTipoPersona = 2;
                }
                accesoDatos.setearConsulta("INSERT INTO CLIENTES (APELLIDOS, NOMBRES, RAZONSOCIAL, DNI, CUIT, FECHNAC, IDDOMICILIO, IDUSUARIO, IDTIPOPERSONA) VALUES (@Apellido, @Nombre, @RazonSocial, @DNI, @CUIT, @FechNac, @Domicilio, @Usuario, @TipoPersona) SELECT SCOPE_IDENTITY();");
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", esNuloNT(nuevo.Apellido));
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", esNuloNT(nuevo.Nombre));
                accesoDatos.Comando.Parameters.AddWithValue("@RazonSocial", esNuloNT(nuevo.RazonSocial));
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", nuevo.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@CUIT", esNuloNT(nuevo.CUIT));
                accesoDatos.Comando.Parameters.AddWithValue("@FechNac", esNulo(nuevo.FechaNacimiento));
                accesoDatos.Comando.Parameters.AddWithValue("@Domicilio", esNulo(nuevo.Domicilio.ID));
                accesoDatos.Comando.Parameters.AddWithValue("@Usuario", esNulo(nuevo.Usuario.ID));
                accesoDatos.Comando.Parameters.AddWithValue("@TipoPersona", IDTipoPersona);
                accesoDatos.abrirConexion();
                nuevo.ID = accesoDatos.ejecutarAccionReturn();
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

        public void eliminarCliente(Cliente cliente)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("DELETE FROM CLIENTES WHERE ID = " + cliente.ID);
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

        public void modificarCliente(Cliente modif)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int TipoPersona;
                accesoDatos.setearConsulta("ALTER TABLE CLIENTES NOCHECK CONSTRAINT FK__CLIENTES__IDDOMI__4F7CD00D UPDATE CLIENTES Set APELLIDOS=@Apellido, NOMBRES=@Nombre, RAZONSOCIAL=@RazonSocial, DNI=@Dni, IDDOMICILIO=@Domicilio, IDTIPOPERSONA=@TipoPersona, CUIT=@Cuit WHERE ID=" + modif.ID.ToString() + " ALTER TABLE CLIENTES NOCHECK CONSTRAINT FK__CLIENTES__IDDOMI__4F7CD00D");
                accesoDatos.Comando.Parameters.Clear();
                if (modif.TipoPersona.Fisica)
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

        public void habilitarCliente(Cliente cliente)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE CLIENTES SET ESTADO = 1 WHERE ID = " + cliente.ID);
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

        //MAILS POR CLIENTE
        public List<Mail> listarMailsXCliente(Cliente cliente)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<Mail> listado = new List<Mail>();
            Mail nuevo;
            try
            {
                accesoDatos.setearConsulta("SELECT M.* FROM MAILS AS M INNER JOIN MAILS_X_CLIENTES AS MC ON MC.IDMAIL = M.ID WHERE MC.IDCLIENTE = " + cliente.ID);
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

        public void agregarMailXCliente(Cliente cliente, int IDMail)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO MAILS_X_CLIENTES (IDCLIENTE, IDMAIL) VALUES(" + cliente.ID + ", " + IDMail + ")");
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

        public void eliminarMailXCliente(Cliente cliente)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.abrirConexion();
                accesoDatos.setearConsulta("DELETE FROM MAILS_X_CLIENTES WHERE IDCLIENTE = " + cliente.ID);
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

        //TELEFONOS POR CLIENTE
        public List<Telefono> listarTelefonosXCliente(Cliente cliente)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<Telefono> listado = new List<Telefono>();
            Telefono nuevo;
            try
            {
                accesoDatos.setearConsulta("SELECT T.* FROM TELEFONOS AS T INNER JOIN TELEFONOS_X_CLIENTES AS TC ON TC.IDTELEFONO = T.ID WHERE TC.IDCLIENTE = " + cliente.ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Telefono();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Numero = accesoDatos.Lector.GetString(1);
                    nuevo.Descripcion = accesoDatos.Lector.GetString(2);
                    if(nuevo.Descripcion == "")
                    {
                        nuevo.Descripcion = "Sin definir";
                    }
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

        public void agregarTelefonoXCliente(Cliente cliente, int IDTel)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO TELEFONOS_X_CLIENTES (IDCLIENTE, IDTELEFONO) VALUES(" + cliente.ID + ", " + IDTel + ")");
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

        public void eliminarTelefonoXCliente(Cliente cliente)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.abrirConexion();
                accesoDatos.setearConsulta("DELETE FROM TELEFONOS_X_CLIENTES WHERE IDCLIENTE = " + cliente.ID);
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
            double num;
            bool isNumber = Double.TryParse(Convert.ToString(campo), out num);
            if (isNumber)
            {
                if ((int)campo == 0)
                    return DBNull.Value;
                else
                    return campo;
            }
            else if (campo == null)
            {
                return DBNull.Value;
            }
            else
            {
                return campo;
            }
        }

        private object esNuloNT(object campo)
        {
            if (campo == null)
                return "";
            else
                return campo;
        }

        //USUARIO POR CLIENTE
        public int verificarUsuario(string UDNI, string PASS)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("SELECT C.ID, U.USUARIO, U.CONTRASEÑA FROM CLIENTES AS C INNER JOIN USUARIOS AS U ON U.ID = C.IDUSUARIO WHERE(U.USUARIO = '"+UDNI+"' OR C.DNI = '"+UDNI+"') AND U.CONTRASEÑA = '"+ PASS +"'");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    return accesoDatos.Lector.GetInt32(0);
                }
                return -1;
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
