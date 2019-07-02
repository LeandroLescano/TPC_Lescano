using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocioCom;
using Dominio;

namespace PresWinForm
{
    public partial class frmPedidos : Form
    {
        public frmPedidos()
        {
            InitializeComponent();
        }

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            PedidoNegocio negocio = new PedidoNegocio();
            try
            {
                dgvPedidos.DataSource = negocio.listarPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.RowCount > 0)
            {
                Pedido pModif = (Pedido)dgvPedidos.CurrentRow.DataBoundItem;
                frmModifPedidos modif = new frmModifPedidos(pModif);
                modif.ShowDialog();
                cargarGrilla();
            }
        }

        private void dgvPedidos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentRow = dgvPedidos.HitTest(e.X, e.Y).RowIndex;
                int currentColumn = dgvPedidos.HitTest(e.X, e.Y).ColumnIndex;

                if (currentRow >= 0)
                {
                    dgvPedidos[currentColumn, currentRow].Selected = true;
                    Pedido pSelect = (Pedido)dgvPedidos.CurrentRow.DataBoundItem;

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Detalles", btnDetalles_Click));
                    m.Show(dgvPedidos, new Point(e.X, e.Y));
                }
            }
        }
    }
}
