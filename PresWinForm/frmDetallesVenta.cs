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
using negocioCom;

namespace PresWinForm
{
    public partial class frmDetallesVenta : Form
    {
        private Venta ventaLocal;

        public frmDetallesVenta()
        {
            InitializeComponent();
        }

        public frmDetallesVenta(Venta venta)
        {
            InitializeComponent();
            ventaLocal = venta;
        }

        private void frmDetallesVenta_Load(object sender, EventArgs e)
        {
            lblID.Text += ventaLocal.ID.ToString();
            lblCliente.Text += ventaLocal.Cliente;
            lblImporte.Text = ventaLocal.Importe.ToString();
            dgvProductos.DataSource = ventaLocal.Detalle;
        }
    }
}
