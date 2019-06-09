using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class PedidoNegocio
    {
        public List<Pedido> listarPedidos()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            ClienteNegocio negocioCli = new ClienteNegocio();
            ComboNegocio negocioCom = new ComboNegocio();
            List<Pedido> listado = new List<Pedido>();
            Pedido nuevo;
            try
            {
                accesoDatos.setearConsulta("SELECT ID, IDCLIENTE, IDCOMBO, OBSERVACION, FECHAENTREGA, PRECIO, ESTADO FROM PEDIDOS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    nuevo = new Pedido();
                    nuevo.ID = accesoDatos.Lector.GetInt32(0);
                    nuevo.Cliente.ID = accesoDatos.Lector.GetInt32(1);
                    nuevo.Combo.ID = accesoDatos.Lector.GetInt32(2);
                    nuevo.Observacion = accesoDatos.Lector.GetString(3);
                    nuevo.FechaEntrega = accesoDatos.Lector.GetDateTime(4);
                    nuevo.PrecioFinal = accesoDatos.Lector.GetDecimal(5);
                    nuevo.Estado = accesoDatos.Lector.GetString(6);
                    nuevo.Cliente = negocioCli.listarCliente(nuevo.Cliente.ID);
                    nuevo.Combo = negocioCom.listarCombo(nuevo.Combo.ID);
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

        public void cargarPedido(Pedido p)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("INSERT INTO PEDIDOS (IDCLIENTE, IDCOMBO, OBSERVACION, FECHAENTREGA, PRECIO, ESTADO) VALUES (@Cliente, @Combo, @Observacion, @FechaEntrega, @Precio, @Estado)");
                accesoDatos.Comando.Parameters.AddWithValue("@Cliente", p.Cliente.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@Combo", p.Combo.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@Observacion", p.Observacion);
                accesoDatos.Comando.Parameters.AddWithValue("@FechaEntrega", p.FechaEntrega);
                accesoDatos.Comando.Parameters.AddWithValue("@Precio", p.PrecioFinal);
                accesoDatos.Comando.Parameters.AddWithValue("@Estado", p.Estado);
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
