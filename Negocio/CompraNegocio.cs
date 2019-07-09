using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace negocioCom
{
    public class CompraNegocio
    {
        public int agregarCompra(Compra nueva)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO COMPRAS (IDPROVEEDOR, IMPORTE, FECHA) VALUES(@Proveedor, @Importe, @Fecha) SELECT SCOPE_IDENTITY();");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Proveedor", nueva.Proveedor.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@Fecha", DateTime.Now.Date);
                accesoDatos.Comando.Parameters.AddWithValue("@Importe", nueva.Importe.ToString().Replace(',','.'));
                
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

        public void agregarProductosXCompra(int IDCompra, int IDProducto, int Cantidad)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO PRODUCTOS_X_COMPRA(IDCOMPRA, IDPRODUCTO, CANTIDAD) VALUES(@Compra, @Producto, @Cantidad)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Compra", IDCompra);
                accesoDatos.Comando.Parameters.AddWithValue("@Producto", IDProducto);
                accesoDatos.Comando.Parameters.AddWithValue("@Cantidad", Cantidad);
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

        public List<Compra> listarCompras()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            ProveedorNegocio negocioP = new ProveedorNegocio();
            List<Compra> listado = new List<Compra>();
            Compra nueva = new Compra();
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM COMPRAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nueva = new Compra();
                    nueva.Proveedor = new Proveedor();
                    nueva.Detalle = new List<DetalleCompra>();
                    nueva.ID = accesoDatos.Lector.GetInt32(0);
                    nueva.Proveedor = negocioP.listarProveedor(accesoDatos.Lector.GetInt32(1));
                    listarProductosXCompra(nueva);
                    nueva.Importe = accesoDatos.Lector.GetDecimal(2);
                    nueva.Fecha = accesoDatos.Lector.GetDateTime(3);
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

        private void listarProductosXCompra(Compra compra)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            ProductoNegocio negocioP = new ProductoNegocio();
            DetalleCompra detalle;
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM PRODUCTOS_X_COMPRA WHERE IDCOMPRA = " + compra.ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    detalle = new DetalleCompra();
                    detalle.Producto = new Producto();
                    detalle.Producto = negocioP.listarProducto(accesoDatos.Lector.GetInt32(2));
                    detalle.Cantidad = accesoDatos.Lector.GetInt32(3);
                    detalle.PrecioUnitario = Math.Round(detalle.Producto.PrecioUnitario,3);
                    detalle.PrecioParcial = Math.Round((detalle.Cantidad * detalle.PrecioUnitario),3);
                    compra.Detalle.Add(detalle);
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
