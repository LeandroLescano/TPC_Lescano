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
    public partial class frmCompras : Form
    {
        public frmCompras()
        {
            InitializeComponent();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            dgvDetalle.DataSource = new List<DetalleVenta>();
            ProductoNegocio nombresProd = new ProductoNegocio();
            cmbProducto.DataSource = nombresProd.listarProductos();
            ComboStyle(cmbProducto);
            ProveedorNegocio nombresProv = new ProveedorNegocio();
            cmbProveedores.DataSource = nombresProv.listarProveedores();
            ComboStyle(cmbProveedores);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvCompras.BringToFront();
            dgvCompras.Visible = true;
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            dgvCompras.Visible = false;
        }

        private void btnNuevoProd_Click(object sender, EventArgs e)
        {
            frmAltaModifProducto altaProd = new frmAltaModifProducto();
            altaProd.Show();
        }

        private void btnNuevoProv_Click(object sender, EventArgs e)
        {
            frmAltaModifPersona altaProv = new frmAltaModifPersona('P');
            altaProv.Show();
        }

        private void ComboStyle(ComboBox cmb)
        {
            cmb.AutoCompleteMode = AutoCompleteMode.Append;
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb.Text = "Elige una opción...";
        }

        private void nudCantidad_Enter(object sender, EventArgs e)
        {
            nudCantidad.Select(0, 2);
        }

    }
}
