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

namespace PresWinForm
{
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                dgvProductos.DataSource = negocio.listarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal p = new frmPrincipal();
            p.WindowState = FormWindowState.Normal;
            p.Show();
        }
    }
}
