﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;
using System.Data.SqlClient;

namespace negocioCom
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
                    nuevo.PrecioUnitario = Math.Round(accesoDatos.Lector.GetDecimal(3),3);
                    nuevo.Cantidad = accesoDatos.Lector.GetDecimal(4);
                    nuevo.Categoria = new Categoria();
                    nuevo.Categoria.Nombre = accesoDatos.Lector["CATEGORIA"].ToString();
                    nuevo.Fraccionable = accesoDatos.Lector.GetBoolean(6);
                    nuevo.Peso = accesoDatos.Lector.GetDecimal(7);
                    nuevo.PorcentajeGanancia = Convert.ToDecimal(accesoDatos.Lector.GetString(8).Replace('.', ','));
                    nuevo.Estado = accesoDatos.Lector.GetBoolean(9);
                    agregarProveedores(nuevo);
                    if (!nuevo.Fraccionable)
                    {
                        nuevo.Cantidad = Math.Round(nuevo.Cantidad, 0);
                    }
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
                accesoDatos.setearConsulta("INSERT INTO PRODUCTOS (NOMBRE, PRECIOUNITARIO, STOCK, IDCATEGORIA, IDMARCA, FRACCIONABLE, PESO, PORCENTAJEGANANCIA) VALUES ('" + nuevo.Nombre + "'," + nuevo.PrecioUnitario + ", replace('" + nuevo.Cantidad + "',',','.'), " + IDCategoria + ", " + IDMarca + ", " + Fraccionable + ", replace('" + nuevo.Peso.ToString() + "',',','.'), replace('" + nuevo.PorcentajeGanancia.ToString() + "',',','.'))");
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
                accesoDatos.Comando.Parameters.AddWithValue("@Stock", modif.Cantidad.ToString().Replace(',','.'));
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
                accesoDatos.setearConsulta("Select P.* from PROVEEDORES as P INNER JOIN PROVEEDORES_X_PRODUCTO as PP on PP.IDPROVEEDOR = P.ID WHERE PP.IDPRODUCTO = " + nuevo.ID);
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

        public Producto listarProducto(int ID)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("Select P.ID, P.NOMBRE, M.NOMBRE as MARCA ,P.PRECIOUNITARIO ,P.STOCK, C.NOMBRE AS CATEGORIA, P.FRACCIONABLE, P.PESO, P.PORCENTAJEGANANCIA, P.ESTADO from PRODUCTOS AS P LEFT JOIN MARCAS AS M ON M.ID = P.IDMARCA LEFT JOIN CATEGORIAS AS C ON C.ID = P.IDCATEGORIA WHERE P.ID = " + ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                Producto nuevo = new Producto();
                while (accesoDatos.Lector.Read())
                {                   
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Nombre = accesoDatos.Lector.GetString(1);
                    nuevo.Marca = new Marca();
                    if (!Convert.IsDBNull(accesoDatos.Lector["MARCA"]))
                        nuevo.Marca.Nombre = accesoDatos.Lector.GetString(2);
                    nuevo.PrecioUnitario = accesoDatos.Lector.GetDecimal(3);
                    nuevo.Cantidad = (decimal)accesoDatos.Lector["STOCK"];
                    nuevo.Categoria = new Categoria();
                    nuevo.Categoria.Nombre = accesoDatos.Lector["CATEGORIA"].ToString();
                    nuevo.Fraccionable = accesoDatos.Lector.GetBoolean(6);
                    nuevo.Peso = accesoDatos.Lector.GetDecimal(7);
                    nuevo.PorcentajeGanancia = Convert.ToDecimal(accesoDatos.Lector.GetString(8).Replace('.', ','));
                    nuevo.Estado = accesoDatos.Lector.GetBoolean(9);
                    if(nuevo.Fraccionable)
                    {
                        Math.Round(nuevo.Cantidad, 0);
                    }
                    agregarProveedores(nuevo);
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

        public void aumentarStock(Producto prod, int unidades)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("UPDATE PRODUCTOS Set STOCK= STOCK + @Stock WHERE ID=" + prod.ID);
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Stock", unidades);
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

        public void descontarStock(Producto prod, int unidades, decimal kilos)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                decimal stockActual;
                if (prod.Fraccionable)
                {
                    stockActual = unidades + kilos;
                }
                else
                {
                    stockActual = unidades;
                }
                accesoDatos.setearConsulta("UPDATE PRODUCTOS Set STOCK = STOCK - @Stock WHERE ID=" + prod.ID);
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Stock", stockActual.ToString().Replace(',', '.'));
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

        //PRODUCTOS X COMBO

        public void agregarProdXCombo(Combo cmb, DetalleCombo prod)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO PRODUCTOS_X_COMBO (IDCOMBO, IDPRODUCTO, UNIDADES, KILOS) VALUES ("+cmb.ID+", "+prod.Producto.ID+", "+prod.Unidades+ ", "+prod.Kilos.ToString().Replace(',','.')+")");
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

        public void eliminarProdXCombo(int IDCombo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.abrirConexion();
                accesoDatos.setearConsulta("DELETE FROM PRODUCTOS_X_COMBO WHERE IDCOMBO = " + IDCombo);
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
