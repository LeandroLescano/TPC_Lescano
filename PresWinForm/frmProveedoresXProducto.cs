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
    public partial class frmProveedoresXProducto : Form
    {
        private Producto prodLocal;
        public frmProveedoresXProducto(Producto prod)
        {
            InitializeComponent();
            prodLocal = prod;
            lblProducto.Text += prodLocal.Nombre;
        }

        private void frmProveedoresXProducto_Load(object sender, EventArgs e)
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            dgvProvXProd.DataSource = negocio.listarProveedoresXProducto(prodLocal.ID);
        }
    }
}
