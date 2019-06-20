using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class FacturaNegocio
    {
        public int agregarFactura(Factura nueva)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO FACTURAS (NUMERO, CUIT ,IDDOMICILIO, FECHAINICIO, FECHAACTUAL, INGRESOSBRUTOS) " +
                                         "VALUES(@NumFactura, @CUIT, @Domicilio, @FechaInicio, @FechaActual, @IngresosB) SELECT SCOPE_IDENTITY();");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Domicilio", nueva.Domicilio.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@NumFactura", nueva.Numero);
                accesoDatos.Comando.Parameters.AddWithValue("@CUIT", nueva.CUIT);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaInicio", nueva.FechaInicio);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaActual", nueva.FechaActual);
                accesoDatos.Comando.Parameters.AddWithValue("@IngresosB", nueva.IngresosBrutos);
                accesoDatos.abrirConexion();
                return accesoDatos.ejecutarAccionReturn();
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

        internal Factura listarFactura(int ID)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                DomicilioNegocio negocioD = new DomicilioNegocio();
                Factura nueva = new Factura();
                accesoDatos.setearConsulta("SELECT * FROM FACTURAS WHERE ID = " + ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nueva.Numero = accesoDatos.Lector.GetString(1);
                    nueva.CUIT = accesoDatos.Lector.GetString(2);
                    nueva.Domicilio = negocioD.listarDomicilio(accesoDatos.Lector.GetInt32(3));
                    nueva.FechaActual = accesoDatos.Lector.GetDateTime(4);
                    nueva.FechaInicio = accesoDatos.Lector.GetDateTime(5);
                    nueva.IngresosBrutos = accesoDatos.Lector.GetString(6);

                }
                return nueva;
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
