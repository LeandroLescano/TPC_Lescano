using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresWinForm
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void tspCompras_Click(object sender, EventArgs e)
        {
            frmCompras Compras = new frmCompras();
            Compras.Show();
        }

        private void tspStock_Click(object sender, EventArgs e)
        {
            frmStock Stock = new frmStock();
            Stock.Show();
        }

        private void tspProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores Proveedores = new frmProveedores();
            Proveedores.Show();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            frmCompras Compras = new frmCompras();
            Compras.Show();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            frmStock Stock = new frmStock();
            Stock.Show();

        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores Proveedores = new frmProveedores();
            Proveedores.Show();
        }
    }
}
