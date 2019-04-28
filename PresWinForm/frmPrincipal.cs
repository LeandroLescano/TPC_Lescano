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

        private void btnCompras_Click(object sender, EventArgs e)
        {
            frmCompras compras = new frmCompras();
            compras.MdiParent = this;
            compras.Dock = DockStyle.Fill;
            compras.FormBorderStyle = FormBorderStyle.None;
            compras.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmVentas ventas = new frmVentas();
            ventas.MdiParent = this;
            ventas.Dock = DockStyle.Fill;
            ventas.FormBorderStyle = FormBorderStyle.None;
            ventas.Show();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos stock = new frmProductos();
            stock.MdiParent = this;
            stock.Dock = DockStyle.Fill;
            stock.FormBorderStyle = FormBorderStyle.None;
            stock.Show();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores proveedores = new frmProveedores();
            proveedores.MdiParent = this;
            proveedores.Dock = DockStyle.Fill;
            proveedores.FormBorderStyle = FormBorderStyle.None;
            proveedores.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes clientes = new frmClientes();
            clientes.MdiParent = this;
            clientes.Dock = DockStyle.Fill;
            clientes.Show();
            clientes.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleados empleados = new frmEmpleados();
            empleados.MdiParent = this;
            empleados.Dock = DockStyle.Fill;
            empleados.FormBorderStyle = FormBorderStyle.None;
            empleados.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmCompras compras = new frmCompras();
            compras.MdiParent = this;
            compras.Dock = DockStyle.Fill;
            compras.FormBorderStyle = FormBorderStyle.None;
            compras.Show();
        }
    }
}
