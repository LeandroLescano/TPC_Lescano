﻿using System;
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
            setearVentana(compras, btnCompras);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmVentas ventas = new frmVentas();
            setearVentana(ventas, btnVentas);
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            frmPedidos pedidos = new frmPedidos();
            setearVentana(pedidos, btnPedidos);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos stock = new frmProductos();
            setearVentana(stock, btnProductos);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores proveedores = new frmProveedores();
            setearVentana(proveedores, btnProveedores);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes clientes = new frmClientes();
            setearVentana(clientes, btnClientes);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleados empleados = new frmEmpleados();
            setearVentana(empleados, btnEmpleados);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmCompras compras = new frmCompras();
            setearVentana(compras, btnCompras);
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
