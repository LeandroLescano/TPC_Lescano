using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class EmpleadoNegocio
    {

        public List<Empleado> listarEmpleados()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<Empleado> listado = new List<Empleado>();
            Empleado nuevo;
            try
            {
                accesoDatos.setearConsulta("Select E.*, D.CALLE, D.ALTURA, L.NOMBRE as LOCALIDAD, D.PISO, D.DEPARTAMENTO, L.CODPOSTAL, L.PARTIDO, L.ID AS IDLOCALIDAD, D.ENTRECALLE1, D.ENTRECALLE2, U.USUARIO, U.CONTRASEÑA from EMPLEADOS AS E LEFT JOIN DOMICILIOS AS D ON D.ID = E.IDDOMICILIO LEFT JOIN LOCALIDADES AS L ON L.ID = D.IDLOCALIDAD LEFT JOIN USUARIOS AS U ON U.ID = E.IDUSUARIO");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();

                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Empleado();
                    nuevo.Usuario = new Usuario();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.TipoEmpleado = new TipoEmpleado();
                    nuevo.Estado = accesoDatos.Lector.GetBoolean(9);
                    if ((int)accesoDatos.Lector["IDTIPOEMPLEADO"] == 1)
                    {
                        nuevo.TipoEmpleado.Administrador = true;
                    }
                    else
                    {
                        nuevo.TipoEmpleado.Vendedor = true;
                    }
                    nuevo.Apellido = accesoDatos.Lector.GetString(1);
                    nuevo.Nombre = accesoDatos.Lector.GetString(2);
                    nuevo.CUIL = accesoDatos.Lector.GetString(4);
                    nuevo.DNI = accesoDatos.Lector.GetString(3);
                    nuevo.FechaNacimiento = accesoDatos.Lector.GetDateTime(8);
                    if (!Convert.IsDBNull(accesoDatos.Lector["IDUSUARIO"]))
                        nuevo.Usuario.ID = accesoDatos.Lector.GetInt32(6);
                    if (!Convert.IsDBNull(accesoDatos.Lector["USUARIO"]))
                        nuevo.Usuario.Nombre = accesoDatos.Lector.GetString(20);
                    if (!Convert.IsDBNull(accesoDatos.Lector["USUARIO"]))
                        nuevo.Usuario.Contraseña = accesoDatos.Lector.GetString(21);
                    nuevo.Domicilio = new Domicilio();
                    nuevo.Domicilio.Localidad = new Localidad();
                    nuevo.Domicilio.Edificio = new Edificio();

                    //Domicilio
                    if (!Convert.IsDBNull(accesoDatos.Lector["CALLE"]))
                        nuevo.Domicilio.Calle = accesoDatos.Lector.GetString(10);
                    if (!Convert.IsDBNull(accesoDatos.Lector["ALTURA"]))
                        nuevo.Domicilio.Altura = accesoDatos.Lector.GetInt32(11);
                    if (!Convert.IsDBNull(accesoDatos.Lector["IDDOMICILIO"]))
                        nuevo.Domicilio.ID = accesoDatos.Lector.GetInt32(5);
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

        public EmpleadoLite listarEmpleadoXUsuario(int IDUsuario)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            EmpleadoLite nuevo;
            try
            {
                accesoDatos.setearConsulta("Select * from EMPLEADOS WHERE IDUSUARIO = " + IDUsuario);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                nuevo = new EmpleadoLite();

                while (accesoDatos.Lector.Read())
                {
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.TipoEmpleado = new TipoEmpleado();
                    if ((int)accesoDatos.Lector["IDTIPOEMPLEADO"] == 1)
                    {
                        nuevo.TipoEmpleado.Administrador = true;
                    }
                    else
                    {
                        nuevo.TipoEmpleado.Vendedor = true;
                    }
                    nuevo.Apellido = accesoDatos.Lector.GetString(1);
                    nuevo.Nombre = accesoDatos.Lector.GetString(2);
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

        public void agregarEmpleado(Empleado nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int IDTipoEmpleado;
                if (nuevo.TipoEmpleado.Administrador)
                {
                    IDTipoEmpleado = 1;
                }
                else
                {
                    IDTipoEmpleado = 2;
                }
                accesoDatos.setearConsulta("INSERT INTO EMPLEADOS (APELLIDOS, NOMBRES, DNI, CUIL, FECHNAC, IDDOMICILIO, IDUSUARIO, IDTIPOEMPLEADO) VALUES (@Apellido, @Nombre, @DNI, @CUIL, @FechNac, @Domicilio, @Usuario, @TipoEmpleado)");
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", esNulo(nuevo.Apellido));
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", esNulo(nuevo.Nombre));
                accesoDatos.Comando.Parameters.AddWithValue("@DNI", nuevo.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@CUIL", nuevo.CUIL);
                accesoDatos.Comando.Parameters.AddWithValue("@FechNac", esNulo(nuevo.FechaNacimiento));
                accesoDatos.Comando.Parameters.AddWithValue("@TipoEmpleado", IDTipoEmpleado);
                accesoDatos.Comando.Parameters.AddWithValue("@Usuario", esNulo(nuevo.Usuario.ID));
                accesoDatos.Comando.Parameters.AddWithValue("@Domicilio", esNulo(nuevo.Domicilio.ID));

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

        public void modificarEmpleado(Empleado modif)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int TipoEmpleado;
                if (modif.TipoEmpleado.Administrador)
                {
                    TipoEmpleado = 1;
                }
                else
                {
                    TipoEmpleado = 2;
                }
                accesoDatos.setearConsulta("UPDATE EMPLEADOS Set APELLIDOS=@Apellido, NOMBRES=@Nombre, FECHNAC=@FechNac, DNI=@Dni, IDDOMICILIO=@Domicilio, IDTIPOEMPLEADO=@TipoEmpleado, CUIL=@Cuil, IDUSUARIO=@Usuario WHERE ID=" + modif.ID.ToString() + " ALTER TABLE PROVEEDORES CHECK CONSTRAINT FK__PROVEEDOR__IDDOM__6A30C649 ");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modif.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", modif.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@Dni", modif.DNI);
                accesoDatos.Comando.Parameters.AddWithValue("@Cuil", modif.CUIL);
                accesoDatos.Comando.Parameters.AddWithValue("@FechNac", modif.FechaNacimiento);
                accesoDatos.Comando.Parameters.AddWithValue("@Domicilio", modif.Domicilio.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@Usuario", modif.Usuario.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@TipoEmpleado", TipoEmpleado);
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

        public void eliminarEmpleado(Empleado emp)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("DELETE FROM EMPLEADOS WHERE ID = " + emp.ID);
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

        public void habilitarEmpleado(Empleado emp)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE EMPLEADOS SET ESTADO = 1 WHERE ID = " + emp.ID);
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

        public bool dniCuilDuplicado(string Numero, char Tipo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                if(Tipo == 'D')
                {
                    accesoDatos.setearConsulta("SELECT DNI, CUIL FROM EMPLEADOS WHERE DNI = '"+ Numero +"'");
                }
                else
                {
                    accesoDatos.setearConsulta("SELECT DNI, CUIL FROM EMPLEADOS WHERE CUIL = '" + Numero + "'");
                }
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    return true;
                }
                return false;
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




