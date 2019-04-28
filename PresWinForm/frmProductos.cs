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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaModifProducto altaProd = new frmAltaModifProducto();
            altaProd.ShowDialog();
        }

        private void cargarGrilla()
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
    }
}
