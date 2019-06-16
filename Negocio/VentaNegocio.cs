using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class VentaNegocio
    {
        public void agregarVenta(Venta nueva)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO VENTAS (IDCLIENTE, IDFACTURA, IMPORTE) VALUES(@Cliente, @Factura, @Importe)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Cliente", nueva.Cliente.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@Factura", nueva.Factura.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@Importe", nueva.Importe);
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
