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

        private BindingList<DetalleCompra> Detalle = new BindingList<DetalleCompra>();
        private decimal PrecioFinal;

        public frmCompras()
        {
            InitializeComponent();
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            dgvDetalle.DataSource = new List<DetalleVenta>();
            ProductoNegocio nombresProd = new ProductoNegocio();
            List<Producto> listaProd = new List<Producto>();
            listaProd = nombresProd.listarProductos();
            listaProd = listaProd.FindAll(X => X.Estado == true);
            cmbProducto.DataSource = listaProd;
            ComboStyle(cmbProducto);
            ProveedorNegocio nombresProv = new ProveedorNegocio();
            List<Proveedor> listaProv = new List<Proveedor>();
            listaProv = nombresProv.listarProveedores();
            listaProv = listaProv.FindAll(X => X.Estado == true);
            cmbProveedores.DataSource = listaProv;
            ComboStyle(cmbProveedores);
            txtPrecio.BackColor = Color.White;
            txtPrecio.Text = "0,00";
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

        private void cargarGrilla()
        {
            dgvDetalle.DataSource = Detalle;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cmbProducto.Text != "Elige una opción...")
            {
                DetalleCompra nuevo = new DetalleCompra();
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
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvDetalle.CurrentRow != null)
            {
                int index = dgvDetalle.CurrentRow.Index;
                Detalle.RemoveAt(index);
            }
        }

        private void nudCantidad_Enter_1(object sender, EventArgs e)
        {
            nudCantidad.Select(0, nudCantidad.Text.Length);
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Producto)cmbProducto.SelectedItem != null)
            {
                Producto prod = (Producto)cmbProducto.SelectedItem;
                txtPrecio.Text = prod.calcularPrecio().ToString();
            }
        }

        private void frmCompras_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
