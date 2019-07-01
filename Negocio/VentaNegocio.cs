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
        public int agregarVenta(Venta nueva)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO VENTAS (IDCLIENTE, IDFACTURA, IMPORTE) VALUES(@Cliente, @Factura, @Importe) SELECT SCOPE_IDENTITY();");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Cliente", nueva.Cliente.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@Factura", nueva.Factura.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@Importe", nueva.Importe);
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

        public void agregarProductosXVenta(int IDVenta, int IDProd, int Cantidad, decimal Kilos)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO PRODUCTOS_X_VENTA(IDVENTA, IDPRODUCTO, CANTIDAD, KILOS) VALUES(@venta, @Producto, @Cantidad, @Kilos)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Venta", IDVenta);
                accesoDatos.Comando.Parameters.AddWithValue("@Producto", IDProd);
                accesoDatos.Comando.Parameters.AddWithValue("@Cantidad", Cantidad);
                accesoDatos.Comando.Parameters.AddWithValue("@Kilos", Kilos.ToString().Replace(',','.'));
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

        public List<Venta> listarVentas()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            ClienteNegocio negocioC = new ClienteNegocio();
            FacturaNegocio negocioF = new FacturaNegocio();
            List<Venta> listado = new List<Venta>();
            Venta nueva = new Venta();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM VENTAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nueva = new Venta();
                    nueva.Cliente = new Cliente();
                    nueva.Factura = new Factura();
                    nueva.Detalle = new List<DetalleVenta>();
                    nueva.ID = accesoDatos.Lector.GetInt32(0);
                    nueva.Cliente = negocioC.listarCliente(accesoDatos.Lector.GetInt32(1));
                    nueva.Factura = negocioF.listarFactura(accesoDatos.Lector.GetInt32(2));
                    listarProductosXVenta(nueva);
                    nueva.Importe = accesoDatos.Lector.GetDecimal(3);
                    listado.Add(nueva);
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

        private void listarProductosXVenta(Venta venta)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            ProductoNegocio negocioP = new ProductoNegocio();
            DetalleVenta detalle;
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM PRODUCTOS_X_VENTA WHERE ID = " + venta.ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    detalle = new DetalleVenta();
                    detalle.Producto = new Producto();
                    detalle.Producto = negocioP.listarProducto(accesoDatos.Lector.GetInt32(2));
                    detalle.Cantidad = accesoDatos.Lector.GetInt32(3);
                    detalle.Kilos = accesoDatos.Lector.GetDecimal(4);
                    detalle.PrecioUnitario = detalle.Producto.PrecioUnitario;
                    detalle.PrecioParcial = (detalle.Cantidad * detalle.PrecioUnitario) + (detalle.PrecioUnitario * detalle.Kilos);
                    venta.Detalle.Add(detalle);
                }
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
