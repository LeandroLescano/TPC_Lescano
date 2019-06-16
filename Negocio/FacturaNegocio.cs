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
        public void agregarFactura(Factura nueva)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO FACTURAS (IDDOMICILIO, NUMEROFACTURA, IMPORTE, FECHAINICIO, FECHAACTUAL, FECHAVENCIMIENTO) VALUES(@Domicilio, @NumFactura, @Importe, @FechaInicio, @FechaActual, @FechaVencimiento)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Domicilio", nueva.Domicilio.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@NumFactura", nueva.Numero);
                accesoDatos.Comando.Parameters.AddWithValue("@Importe", nueva.Importe);
                //accesoDatos.Comando.Parameters.AddWithValue("@CUIT", nueva.CUIT);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaInicio", nueva.FechaInicio);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaActual", nueva.FechaActual);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaVencimiento", nueva.FechaVencimiento);
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
