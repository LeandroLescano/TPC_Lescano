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
                accesoDatos.setearConsulta("SELECT ID, APELLIDOS, NOMBRES, RAZONSOCIAL, DNI, CUIT, IDTIPOPERSONA, FECHNAC FROM CLIENTES");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Cliente();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.TipoPersona = new TipoPersona();
                    if (accesoDatos.Lector.GetInt32(6) == 1)
                    {
                        nuevo.TipoPersona.Fisica = true;
                        nuevo.FechaNacimiento = (DateTime)accesoDatos.Lector["FECHNAC"];
                        nuevo.Apellido = accesoDatos.Lector.GetString(1);
                        nuevo.Nombre = accesoDatos.Lector.GetString(2);
                    }
                    else
                    {
                        nuevo.TipoPersona.Juridica = true;
                        nuevo.RazonSocial = accesoDatos.Lector.GetString(3);
                    }
                    nuevo.DNI = accesoDatos.Lector.GetString(4);
                    nuevo.CUIT = accesoDatos.Lector.GetString(5);
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
                int tipoPersona;
                if (nuevo.TipoPersona.Fisica)
                    tipoPersona = 1;
                else
                    tipoPersona = 2;
                accesoDatos.setearConsulta("insert into CLIENTES (APELLIDOS, NOMBRES, RAZONSOCIAL, DNI, CUIT, IDTIPOPERSONA, FECHNAC) values ('" + nuevo.Apellido + "', '" + nuevo.Nombre + "', '" + nuevo.RazonSocial + "', '" + nuevo.DNI + "', '" + nuevo.CUIT + "', " + tipoPersona + ", '" + nuevo.FechaNacimiento.ToString("MM/dd/yyyy") + "')");
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
    }
}
