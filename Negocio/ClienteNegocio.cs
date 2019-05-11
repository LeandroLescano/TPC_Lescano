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
            List<Cliente> listado = new List<Cliente>();
            Cliente nuevo = new Cliente();
            try
            {
                accesoDatos.setearConsulta("Select C.*, D.CALLE, D.ALTURA, L.NOMBRE as LOCALIDAD, D.PISO, D.DEPARTAMENTO, L.CODPOSTAL, L.PARTIDO, L.ID AS IDLOCALIDAD, D.ENTRECALLE1, D.ENTRECALLE2 from CLIENTES AS C LEFT JOIN DOMICILIOS AS D ON D.ID = C.IDDOMICILIO LEFT JOIN LOCALIDADES AS L ON L.ID = D.IDLOCALIDAD");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Cliente();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.TipoPersona = new TipoPersona();
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
                    nuevo.Usuario = new Usuario();
                    if (!Convert.IsDBNull(accesoDatos.Lector["IDUSUARIO"]))
                        nuevo.Usuario.ID = accesoDatos.Lector.GetInt32(8);
                    nuevo.Domicilio = new Domicilio();
                    nuevo.Domicilio.Localidad = new Localidad();
                    nuevo.Domicilio.Edificio = new Edificio();      

                    //Domicilio
                    if (!Convert.IsDBNull(accesoDatos.Lector["IDDOMICILIO"]))
                        nuevo.Domicilio.ID = accesoDatos.Lector.GetInt32(7);
                    if (!Convert.IsDBNull(accesoDatos.Lector["CALLE"]))
                        nuevo.Domicilio.Calle = accesoDatos.Lector.GetString(10);
                    if (!Convert.IsDBNull(accesoDatos.Lector["ALTURA"]))
                        nuevo.Domicilio.Altura = accesoDatos.Lector.GetInt32(11);
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
                accesoDatos.setearConsulta("INSERT INTO CLIENTES (APELLIDOS, NOMBRES, RAZONSOCIAL, DNI, CUIT, FECHNAC, IDDOMICILIO, IDUSUARIO, IDTIPOPERSONA) VALUES (@Apellido, @Nombre, @RazonSocial, @DNI, @CUIT, @FechNac, @Domicilio, @Usuario, @TipoPersona)");
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", esNuloNT(nuevo.Apellido));
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", esNuloNT(nuevo.Nombre));
                accesoDatos.Comando.Parameters.AddWithValue("@RazonSocial", esNuloNT(nuevo.RazonSocial));
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", nuevo.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@CUIT", nuevo.CUIT);
                accesoDatos.Comando.Parameters.AddWithValue("@FechNac", esNulo(nuevo.FechaNacimiento));
                accesoDatos.Comando.Parameters.AddWithValue("@Domicilio", esNulo(nuevo.Domicilio.ID));
                accesoDatos.Comando.Parameters.AddWithValue("@Usuario", esNulo(nuevo.Usuario.ID));
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

        public void eliminarCliente(Cliente nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("DELETE FROM CLIENTES WHERE ID = " + nuevo.ID);
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
                accesoDatos.setearConsulta("UPDATE CLIENTES Set APELLIDOS=@Apellido, NOMBRES=@Nombre, RAZONSOCIAL=@RazonSocial, DNI=@Dni, IDDOMICILIO=@Domicilio, IDTIPOPERSONA=@TipoPersona, CUIT=@Cuit WHERE ID=" + modif.ID.ToString() + " ALTER TABLE PROVEEDORES CHECK CONSTRAINT FK__PROVEEDOR__IDDOM__6A30C649 ");
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
    }
}
