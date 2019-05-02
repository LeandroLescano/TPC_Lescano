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
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            dgvDetalle.DataSource = new List<DetalleVenta>();
            ProductoNegocio nombresProd = new ProductoNegocio();
            cmbProducto.DataSource = nombresProd.listarProductos();
            ComboStyle(cmbProducto);
            ClienteNegocio nombresClient = new ClienteNegocio();
            cmbClientes.DataSource = nombresClient.listarClientes();
            ComboStyle(cmbClientes);
        }

        private void ComboStyle (ComboBox cmb)
        {
            cmb.AutoCompleteMode = AutoCompleteMode.Append;
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb.Text = "Elige una opción...";
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            dgvCompras.Visible = false;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvCompras.BringToFront();
            dgvCompras.Visible = true;
        }
    }
}
