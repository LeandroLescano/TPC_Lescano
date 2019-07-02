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
    public partial class frmDetallesCompra : Form
    {
        private Compra compraLocal;
        public frmDetallesCompra()
        {
            InitializeComponent();
        }

        public frmDetallesCompra(Compra compra)
        {
            InitializeComponent();
            compraLocal = compra;
        }

        private void frmDetallesCompra_Load(object sender, EventArgs e)
        {
            lblID.Text += compraLocal.ID.ToString();
            lblProveedor.Text += compraLocal.Proveedor;
            lblImporte.Text = compraLocal.Importe.ToString();
            dgvProductos.DataSource = compraLocal.Detalle;
        }
    }
}
