using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
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
    }
}
