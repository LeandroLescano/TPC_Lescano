﻿using System;
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
            cargarGrilla();
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

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            frmMarcas marcas = new frmMarcas();
            marcas.Show();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias categorias = new frmCategorias();
            categorias.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Producto pmodif = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            frmAltaModifProducto modif = new frmAltaModifProducto(pmodif);
            modif.ShowDialog();
            cargarGrilla();
        }

        private void btnVerProveedores_Click(object sender, EventArgs e)
        {
            frmProveedoresXProducto provXProd = new frmProveedoresXProducto((Producto)dgvProductos.CurrentRow.DataBoundItem);
            provXProd.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto peliminar = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            if(MessageBox.Show("Está a punto de eliminar el producto: "+ peliminar.Nombre + ".\n\n¿Desea eliminarlo?", "Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                negocio.eliminarProducto(peliminar);
                cargarGrilla();
            }
        }
    }
}
