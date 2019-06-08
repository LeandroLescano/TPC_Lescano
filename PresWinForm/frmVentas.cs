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
    public partial class frmVentas : Form
    {
        private BindingList<DetalleVenta> Detalle = new BindingList<DetalleVenta>();
        private decimal PrecioFinal;

        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            ProductoNegocio nombresProd = new ProductoNegocio();
            ClienteNegocio nombresClient = new ClienteNegocio();
            dgvDetalle.DataSource = new List<DetalleVenta>();
            List<Cliente> listaClientes = new List<Cliente>();
            List<Producto> listaProd = new List<Producto>();
            listaProd = nombresProd.listarProductos();
            listaProd = listaProd.FindAll(X => X.Estado == true);
            cmbProducto.DataSource = listaProd;
            listaClientes = nombresClient.listarClientes();
            listaClientes = listaClientes.FindAll(X => X.Estado == true);
            cmbClientes.DataSource = listaClientes;
            restablecerControles();
            txtPrecio.BackColor = Color.White;
            txtPrecio.Text = "0,00";
        }

        private void cargarGrilla()
        {
            dgvDetalle.DataSource = Detalle;
        }

        private void restablecerControles()
        {
            ComboStyle(cmbProducto);
            ComboStyle(cmbClientes);
            nudCantidad.Value = 1;
        }

        private void ComboStyle(ComboBox cmb)
        {
            cmb.AutoCompleteMode = AutoCompleteMode.Append;
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb.SelectedIndex = -1;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DetalleVenta nuevo = new DetalleVenta();
            nuevo.Producto = (Producto)cmbProducto.SelectedItem;
            nuevo.Cantidad = Convert.ToInt32(nudCantidad.Value);
            nuevo.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
            nuevo.PrecioParcial = nuevo.PrecioUnitario * nuevo.Cantidad;
            Detalle.Add(nuevo);
            cargarGrilla();
            PrecioFinal += Math.Round(nuevo.PrecioParcial, 2);
            lblTotal.Text = "Total: " + PrecioFinal;
            cmbProducto.Focus();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Producto)cmbProducto.SelectedItem != null)
            {
                Producto prod = (Producto)cmbProducto.SelectedItem;
                txtPrecio.Text = prod.calcularPrecio().ToString();
            }
        }

        private void nudCantidad_Enter(object sender, EventArgs e)
        {
            nudCantidad.Select(0,nudCantidad.Text.Length);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = dgvDetalle.CurrentRow.Index;
            Detalle.RemoveAt(index);
        }
    }
}
