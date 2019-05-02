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
            Empleado nuevo = new Empleado();
            try
            {
                accesoDatos.setearConsulta("SELECT E.ID, E.APELLIDOS, E.NOMBRES, E.DNI, E.IDTIPOEMPLEADO FROM EMPLEADOS AS E");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Empleado();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Apellido = accesoDatos.Lector.GetString(1); 
                    nuevo.Nombre = accesoDatos.Lector.GetString(2);
                    nuevo.DNI = accesoDatos.Lector.GetString(3);
                    //nuevo.Domicilio
                    //nuevo.Telefonos
                    //nuevo.Mails
                    //nuevo.TipoEmpleado = accesoDatos.Lector.GetString(1);
                    //nuevo.Usuario
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

    }
}

