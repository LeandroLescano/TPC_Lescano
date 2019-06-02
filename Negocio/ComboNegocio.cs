using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class ComboNegocio
    {
        public List<Combo> listarCombos()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<Combo> listado = new List<Combo>();
            Combo nuevo;
            try
            {
                accesoDatos.setearConsulta("SELECT * FROM COMBOS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Combo();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Nombre = accesoDatos.Lector.GetString(1);
                    nuevo.Descripcion = accesoDatos.Lector.GetString(2);
                    nuevo.DiasAnticipo = accesoDatos.Lector.GetInt32(3);
                    nuevo.Precio = accesoDatos.Lector.GetDecimal(4);
                    nuevo.Estado = accesoDatos.Lector.GetBoolean(5);
                    if(!Convert.IsDBNull(accesoDatos.Lector["RUTA"]))
                        nuevo.RutaImagen = accesoDatos.Lector.GetString(6);
                    listarProductos(nuevo);
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

        private void listarProductos(Combo cmb)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("SELECT P.* FROM PRODUCTOS AS P INNER JOIN PRODUCTOS_X_COMBO AS PC ON PC.IDPRODUCTO = P.ID WHERE PC.IDCOMBO = " + cmb.ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                cmb.Productos = new List<Producto>();
                while(accesoDatos.Lector.Read())
                {
                    Producto nuevo = new Producto();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Nombre= accesoDatos.Lector.GetString(2);
                    cmb.Productos.Add(nuevo);
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

        public int agregarCombo(Combo nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO COMBOS (NOMBRE, DESCRIPCION, DIASANTICIPO, PRECIO, ESTADO) VALUES (@Nombre, @Descripcion, @DiasAnticipo, @Precio, 1) SELECT SCOPE_IDENTITY();");
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                accesoDatos.Comando.Parameters.AddWithValue("@DiasAnticipo", nuevo.DiasAnticipo);
                accesoDatos.Comando.Parameters.AddWithValue("@Precio", nuevo.Precio.ToString().Replace('.',','));
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

        public void eliminarCombo(Combo comb)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("DELETE FROM COMBOS WHERE ID = " + comb.ID);
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

        public void habilitarCombo(Combo comb)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE COMBOS SET ESTADO = 1 WHERE ID = " + comb.ID);
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
