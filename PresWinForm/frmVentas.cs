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
        private BindingList<DetalleVenta> Detalle = new BindingList<DetalleVenta>();
        private decimal PrecioFinal;
        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            dgvDetalle.DataSource = new List<DetalleVenta>();
            ProductoNegocio nombresProd = new ProductoNegocio();
            cmbProducto.DataSource = nombresProd.listarProductos();
            ClienteNegocio nombresClient = new ClienteNegocio();
            cmbClientes.DataSource = nombresClient.listarClientes();
            restablecerControles();
            nudPrecio.Controls.RemoveAt(0);
            nudPrecio.ReadOnly = true;
            nudPrecio.BackColor = Color.White;
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
            nuevo.PrecioUnitario = nudPrecio.Value;
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
                nudPrecio.Value = prod.calcularPrecio();
            }
        }

        private void nudCantidad_Enter(object sender, EventArgs e)
        {
            nudCantidad.Select(0,nudCantidad.Text.Length);
        }
    }
}
