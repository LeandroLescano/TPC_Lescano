using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listarProductos()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<Producto> listado = new List<Producto>();
            Producto nuevo = new Producto();
            try
            {
                accesoDatos.setearConsulta("Select P.ID, P.NOMBRE, M.NOMBRE as MARCA ,P.PRECIOUNITARIO ,P.STOCK, C.NOMBRE AS CATEGORIA, P.FRACCIONABLE, P.PESO, P.PORCENTAJEGANANCIA, P.ESTADO from PRODUCTOS AS P LEFT JOIN MARCAS AS M ON M.ID = P.IDMARCA LEFT JOIN CATEGORIAS AS C ON C.ID = P.IDCATEGORIA");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Producto();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Nombre = accesoDatos.Lector.GetString(1);
                    nuevo.Marca = new Marca();
                    if (!Convert.IsDBNull(accesoDatos.Lector["MARCA"]))
                        nuevo.Marca.Nombre = accesoDatos.Lector.GetString(2);

                    //nuevo.Marca.Nombre = accesoDatos.Lector["MARCA"].ToString();
                    nuevo.PrecioUnitario = accesoDatos.Lector.GetDecimal(3);
                    nuevo.Categoria = new Categoria();
                    nuevo.Categoria.Nombre = accesoDatos.Lector["CATEGORIA"].ToString();
                    nuevo.Fraccionable = accesoDatos.Lector.GetBoolean(6);
                    nuevo.Peso = Convert.ToDecimal(accesoDatos.Lector.GetString(7).Replace('.', ','));
                    nuevo.PorcentajeGanancia = Convert.ToDecimal(accesoDatos.Lector.GetString(8).Replace('.', ','));
                    nuevo.Estado = accesoDatos.Lector.GetBoolean(9);
                    agregarProveedores(nuevo);
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

        public void agregarProducto(Producto nuevo, int IDCategoria, int IDMarca)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int Fraccionable = 0;
                if (nuevo.Fraccionable)
                    Fraccionable = 1;
                accesoDatos.setearConsulta("INSERT INTO PRODUCTOS (NOMBRE, PRECIOUNITARIO, STOCK, IDCATEGORIA, IDMARCA, FRACCIONABLE, PESO, PORCENTAJEGANANCIA) VALUES ('" + nuevo.Nombre + "'," + nuevo.PrecioUnitario + ", " + nuevo.Cantidad + ", " + IDCategoria + ", " + IDMarca + ", " + Fraccionable + ", replace('" + nuevo.Peso.ToString() + "',',','.'), replace('" + nuevo.PorcentajeGanancia.ToString() + "',',','.'))");
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

        public void modificarProducto(Producto modif, int IDCategoria, int IDMarca)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int Fraccionable = 0;
                if (modif.Fraccionable)
                {
                    Fraccionable = 1;
                }
                else
                {
                    Fraccionable = 0;
                }
                accesoDatos.setearConsulta("UPDATE PRODUCTOS Set NOMBRE=@Nombre, PRECIOUNITARIO=@PrecioUnit, STOCK=@Stock, IDCATEGORIA=@IDCat, IDMARCA=@IDMarca, FRACCIONABLE=@Fraccionable, PESO=@Peso, PORCENTAJEGANANCIA=@Porcentaje WHERE ID=" + modif.ID.ToString());
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modif.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@PrecioUnit", modif.PrecioUnitario);
                accesoDatos.Comando.Parameters.AddWithValue("@Stock", modif.Cantidad);
                accesoDatos.Comando.Parameters.AddWithValue("@IDCat", IDCategoria);
                accesoDatos.Comando.Parameters.AddWithValue("@IDMarca", IDMarca);
                accesoDatos.Comando.Parameters.AddWithValue("@Fraccionable", Fraccionable);
                accesoDatos.Comando.Parameters.AddWithValue("@Peso", modif.Peso.ToString().Replace(',', '.'));
                accesoDatos.Comando.Parameters.AddWithValue("@Porcentaje", modif.PorcentajeGanancia.ToString().Replace(',', '.'));
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

        public void eliminarProducto(Producto prod)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("DELETE FROM PROVEEDORES_X_PRODUCTO WHERE IDPRODUCTO = " + prod.ID + " DELETE FROM PRODUCTOS WHERE ID = " + prod.ID);
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

        public void habilitarProducto(Producto prod)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE PRODUCTOS SET ESTADO = 1 WHERE ID = " + prod.ID);
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

        public int idProducto(string Nombre)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                int idProd = -1;
                accesoDatos.setearConsulta("Select ID FROM PRODUCTOS where NOMBRE LIKE '" + Nombre + "'");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    idProd = accesoDatos.Lector.GetInt32(0);
                }

                return idProd;
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

        private void agregarProveedores(Producto nuevo)
        {
            Proveedor prov = new Proveedor();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                nuevo.Proveedor = new List<Proveedor>();
                accesoDatos.setearConsulta("Select P.* from PROVEEDORES as P INNER JOIN PROVEEDORES_X_PRODUCTO as PP on PP.IDPROVEEDOR = P.ID INNER JOIN PRODUCTOS as PROD ON PROD.ID = PP.IDPRODUCTO WHERE PROD.ID = " + nuevo.ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    prov = new Proveedor();
                    if (!Convert.IsDBNull(accesoDatos.Lector["ID"]))
                        prov.ID = accesoDatos.Lector.GetInt32(0);
                    if (!Convert.IsDBNull(accesoDatos.Lector["RAZONSOCIAL"]))
                        prov.RazonSocial = accesoDatos.Lector.GetString(3);

                    nuevo.Proveedor.Add(prov);
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
