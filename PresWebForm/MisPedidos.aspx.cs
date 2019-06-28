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
        public List<Pedido> lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClienteID"] != null)
            {
                if (Session["ClienteID"].ToString() != "")
                    ClienteID.Value = Session["ClienteID"].ToString();
            }
        }

        [System.Web.Services.WebMethod]
        public static string actualizarGrilla(int ID, string Tabla)
        {
            PedidoNegocio negocio = new PedidoNegocio();
            List<Pedido> listado = new List<Pedido>();
            listado =  negocio.listarPedidosCliente(ID);

            for (int i = 0; i < listado.Count; i++)
            {
                Tabla += "<tr>" +
                    "<th class='thID' scope='row'>" + (i + 1) + "</th>" +
                        "<td>" + listado[i].Combo.Nombre + "</td>" + 
                        "<td class='tdObservacion'>" + listado[i].Observacion + "</td>" +
                        "<td>" + listado[i].FechaEntrega.ToShortDateString() + "</td>" +
                        "<td>" + listado[i].FechaSolicitud.ToShortDateString() + "</td>" +
                        "<td>" + "$" + listado[i].PrecioFinal + "</td>" +
                        "<td>" + listado[i].Estado + "</td>" +
                    "</tr>";

            }

            return Tabla;
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