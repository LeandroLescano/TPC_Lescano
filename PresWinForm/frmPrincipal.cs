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
    public partial class frmPrincipal : Form
    {
        Usuario local = new Usuario();
        EmpleadoLite empLocal = new EmpleadoLite();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        public frmPrincipal(Usuario u)
        {
            EmpleadoNegocio negocio= new EmpleadoNegocio();
            InitializeComponent();
            local = u;
            tspEstatus.Text += u.Nombre;
            empLocal = negocio.listarEmpleadoXUsuario(u.ID);
            if (empLocal.TipoEmpleado.Vendedor)
            {
                btnClientes.Enabled = false;
                btnEmpleados.Enabled = false;
                btnProductos.Enabled = false;
                btnProveedores.Enabled = false;
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
            frmCompras compras = new frmCompras();
            setearVentana(compras, btnCompras);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
            frmVentas ventas = new frmVentas();
            setearVentana(ventas, btnVentas);
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
            frmPedidos pedidos = new frmPedidos();
            setearVentana(pedidos, btnPedidos);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
            frmProductos stock = new frmProductos();
            setearVentana(stock, btnProductos);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
            frmProveedores proveedores = new frmProveedores();
            setearVentana(proveedores, btnProveedores);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
            frmClientes clientes = new frmClientes();
            setearVentana(clientes, btnClientes);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
            frmEmpleados empleados = new frmEmpleados(local);
            setearVentana(empleados, btnEmpleados);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //if()
            frmCompras compras = new frmCompras();
            setearVentana(compras, btnCompras);
        }

        private void btnCombos_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
            frmCombos combos = new frmCombos();
            setearVentana(combos, btnCombos);
        }

        private void setearVentana(Form frm, ToolStripButton btn)
        {
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            foreach (Object b in tspMenu.Items)
            {
                if(b is ToolStripButton)
                {
                    ToolStripButton boton = (ToolStripButton)b;
                    if (boton.CheckState == CheckState.Indeterminate)
                      boton.CheckState = CheckState.Unchecked;
                }
            }
            btn.CheckState = CheckState.Indeterminate;
        }
    }
}
