using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace PresWebForm
{
    public partial class MisPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClienteID"] != null)
            {
                ClienteID.Value = Session["ClienteID"].ToString();
            }
            cargarGrilla();
        }

        [System.Web.Services.WebMethod]
        public static DataGrid actualizarGrilla(DataGrid dgv, int ID)
        {
            PedidoNegocio negocio = new PedidoNegocio();
            dgv.DataSource = negocio.listarPedidosCliente(ID);
            dgv.DataBind();

            return dgv;
        }

        protected void cargarGrilla()
        {
            if (ClienteID.Value != "")
            {
                PedidoNegocio negocio = new PedidoNegocio();
                List<Pedido> lista = new List<Pedido>();   
                lista = negocio.listarPedidosCliente(Convert.ToInt32(ClienteID.Value));
                dgvPedidos.DataSource = lista;
                dgvPedidos.DataBind();
            }
            else
            {
                List<Pedido> listaVacia = new List<Pedido>();
                Pedido vacio = new Pedido();
                dgvPedidos.DataSource = listaVacia;
                dgvPedidos.DataBind();
            }
        }

        protected void dgvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "N° de pedido";
                e.Row.Cells[2].Text = "Fecha de entrega";
                e.Row.Cells[3].Text = "Fecha de solicitud";
                e.Row.Cells[4].Text = "Precio";
            }
        }
    }
}