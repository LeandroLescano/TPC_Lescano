using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace PresWinForm
{
    public partial class frmModifPedidos : Form
    {
        Pedido local = new Pedido();
        public frmModifPedidos(Pedido p)
        {
            InitializeComponent();
            local = p;
        }

        private void frmModifPedidos_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocioCli = new ClienteNegocio();
            local.Cliente.Mails = negocioCli.listarMailsXCliente(local.Cliente);
            lblMail.Text += local.Cliente.Mails[0].Direccion;
            cmbEstado.Items.Add("A revisar");
            cmbEstado.Items.Add("Aceptado");
            cmbEstado.Items.Add("Rechazado");
            cmbEstado.Items.Add("En preparación");
            cmbEstado.Items.Add("Listo para retirar");
            cmbEstado.Items.Add("Entregado");
            cmbEstado.SelectedIndex = cmbEstado.FindString(local.Estado);
            txtEstado.Text = local.Estado;
            txtID.Text = local.ID.ToString();
            txtCliente.Text = local.Cliente.Apellido + ", " + local.Cliente.Nombre;
            dtpFechaSolicitud.Value = local.FechaSolicitud;
            dtpFechRetiro.Value = local.FechaEntrega;
            txtCombo.Text = local.Combo.Nombre;
            txtPrecio.Text = local.PrecioFinal.ToString();
            txtObservaciones.Text = local.Observacion;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocioP = new ProductoNegocio();
            MailNegocio negocioM = new MailNegocio();
            PedidoNegocio negocioPed = new PedidoNegocio();
            local.Estado = cmbEstado.SelectedItem.ToString();
            if(local.Estado == "Entregado")
            {
                foreach (DetalleCombo item in local.Combo.Productos)
                {
                    negocioP.descontarStock(item.Producto, item.Unidades, item.Kilos);
                }
            }
            Cursor.Current = Cursors.WaitCursor;
            if (negocioM.mandarMail(local.Cliente.Mails[0].Direccion, local, txtComentario.Text))
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("El mail ha sido enviado correctamente.","Confirmación");
            }
            negocioPed.modificarPedido(local);
            this.Close();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            frmAltaModifCombo verCombo = new frmAltaModifCombo(local.Combo, true);
            verCombo.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
