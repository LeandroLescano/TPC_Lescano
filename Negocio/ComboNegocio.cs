﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace negocioCom
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
                accesoDatos.setearConsulta("SELECT ID, NOMBRE, DESCRIPCION, DIASANTICIPO, PRECIO, RUTA, ESTADO FROM COMBOS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Combo();
                    nuevo.Productos = new List<DetalleCombo>();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Nombre = accesoDatos.Lector.GetString(1);
                    nuevo.Descripcion = accesoDatos.Lector.GetString(2);
                    nuevo.DiasAnticipo = accesoDatos.Lector.GetInt32(3);
                    nuevo.Precio = accesoDatos.Lector.GetDecimal(4);
                    nuevo.Estado = accesoDatos.Lector.GetBoolean(6);
                    if(!Convert.IsDBNull(accesoDatos.Lector["RUTA"]))
                        nuevo.RutaImagen = accesoDatos.Lector.GetString(5);
                    listarProductosXCombo(nuevo);
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

        public Combo listarCombo(int ID)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Combo nuevo = new Combo();
            try
            {
                accesoDatos.setearConsulta("SELECT ID, NOMBRE, DESCRIPCION, DIASANTICIPO, PRECIO, RUTA, ESTADO FROM COMBOS WHERE ID = " + ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Combo();
                    nuevo.Productos = new List<DetalleCombo>();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Nombre = accesoDatos.Lector.GetString(1);
                    nuevo.Descripcion = accesoDatos.Lector.GetString(2);
                    nuevo.DiasAnticipo = accesoDatos.Lector.GetInt32(3);
                    nuevo.Precio = accesoDatos.Lector.GetDecimal(4);
                    nuevo.Estado = accesoDatos.Lector.GetBoolean(6);
                    if (!Convert.IsDBNull(accesoDatos.Lector["RUTA"]))
                        nuevo.RutaImagen = accesoDatos.Lector.GetString(5);
                    listarProductosXCombo(nuevo);
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

        private void listarProductosXCombo(Combo cmb)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            ProductoNegocio negocioP = new ProductoNegocio();
            try
            {
                accesoDatos.setearConsulta("SELECT PC.* FROM PRODUCTOS AS P INNER JOIN PRODUCTOS_X_COMBO AS PC ON PC.IDPRODUCTO = P.ID WHERE  PC.IDCOMBO = " + cmb.ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                DetalleCombo nuevo;
                while(accesoDatos.Lector.Read())
                {
                    nuevo = new DetalleCombo();
                    nuevo.Producto = new Producto();
                    nuevo.Producto = negocioP.listarProducto(accesoDatos.Lector.GetInt32(1));
                    if (!Convert.IsDBNull(accesoDatos.Lector["UNIDADES"]))
                        nuevo.Unidades = accesoDatos.Lector.GetInt32(2);
                    if (!Convert.IsDBNull(accesoDatos.Lector["KILOS"]))
                        nuevo.Kilos = accesoDatos.Lector.GetDecimal(3);
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
                accesoDatos.setearConsulta("INSERT INTO COMBOS (NOMBRE, DESCRIPCION, DIASANTICIPO, PRECIO, ESTADO, RUTA) VALUES (@Nombre, @Descripcion, @DiasAnticipo, @Precio, 1, @RutaImg) SELECT SCOPE_IDENTITY();");
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                accesoDatos.Comando.Parameters.AddWithValue("@DiasAnticipo", nuevo.DiasAnticipo);
                accesoDatos.Comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
                accesoDatos.Comando.Parameters.AddWithValue("@RutaImg", esNulo(nuevo.RutaImagen));
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

        public void modificarCombo(Combo cmb)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE COMBOS SET NOMBRE=@Nombre, DESCRIPCION=@Descripcion, DIASANTICIPO=@DiasAnticipo, PRECIO=@Precio, RUTA=@RutaImg WHERE ID = " + cmb.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", cmb.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", cmb.Descripcion);
                accesoDatos.Comando.Parameters.AddWithValue("@DiasAnticipo", cmb.DiasAnticipo);
                accesoDatos.Comando.Parameters.AddWithValue("@Precio", cmb.Precio);
                accesoDatos.Comando.Parameters.AddWithValue("@RutaImg", esNulo(cmb.RutaImagen));
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

        private object esNulo(object campo)
        {
            if(campo == null)
            {
                return DBNull.Value;
            }
            else
            {
                return campo;
            }
        }

    }
}
