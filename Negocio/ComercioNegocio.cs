using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace negocioCom
{
    public class ComercioNegocio
    {
        public Comercio listarComercio()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            DomicilioNegocio negocioDom = new DomicilioNegocio();
            Comercio nuevo = new Comercio();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM COMERCIOS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Comercio();
                    nuevo.Domicilio = new Domicilio();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.CUIT = accesoDatos.Lector.GetString(1);
                    nuevo.NombreJuridico = accesoDatos.Lector.GetString(2);
                    nuevo.NombreFantasia = accesoDatos.Lector.GetString(3);
                    nuevo.IngresosBrutos = accesoDatos.Lector.GetString(4);
                    nuevo.FechaInicio = accesoDatos.Lector.GetDateTime(5).Date;
                    nuevo.Domicilio.ID = accesoDatos.Lector.GetInt32(6);
                    nuevo.Domicilio = negocioDom.listarDomicilio(nuevo.Domicilio.ID);
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

        public void agregarComercio(Comercio nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO COMERCIOS (CUIT, NOMBREJURIDICO, NOMBREFANTASIA, INGRESOSBRUTOS, FECHAINICIO, IDDOMICILIO) VALUES (@Cuit, @NombreJ, @NombreF, @IBrutos, @FInicio, @Domicilio)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Cuit", nuevo.CUIT);
                accesoDatos.Comando.Parameters.AddWithValue("@NombreJ", nuevo.NombreJuridico);
                accesoDatos.Comando.Parameters.AddWithValue("@NombreF", nuevo.NombreFantasia);
                accesoDatos.Comando.Parameters.AddWithValue("@IBrutos", nuevo.IngresosBrutos);
                accesoDatos.Comando.Parameters.AddWithValue("@FInicio", nuevo.FechaInicio);
                accesoDatos.Comando.Parameters.AddWithValue("@Domicilio", nuevo.Domicilio.ID);
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

        public void modificarComercio(Comercio comercio)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE COMERCIOS SET CUIT = @Cuit, NOMBREJURIDICO = @NombreF, NOMBREFANTASIA = @NombreF, INGRESOSBRUTOS = @IBrutos, FECHAINICIO = @FInicio, IDDOMICILIO = @Domicilio WHERE ID = " + comercio.ID);
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Cuit", comercio.CUIT);
                accesoDatos.Comando.Parameters.AddWithValue("@NombreJ", comercio.NombreJuridico);
                accesoDatos.Comando.Parameters.AddWithValue("@NombreF", comercio.NombreFantasia);
                accesoDatos.Comando.Parameters.AddWithValue("@IBrutos", comercio.IngresosBrutos);
                accesoDatos.Comando.Parameters.AddWithValue("@FInicio", comercio.FechaInicio);
                accesoDatos.Comando.Parameters.AddWithValue("@Domicilio", comercio.Domicilio.ID);
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
