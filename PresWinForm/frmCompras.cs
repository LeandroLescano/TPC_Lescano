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
using negocioCom;

namespace PresWinForm
{
    public partial class frmCompras : Form
    {

        private BindingList<DetalleCompra> Detalle = new BindingList<DetalleCompra>();
        private CompraNegocio negocio = new CompraNegocio();
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
            txtPrecio.ReadOnly = true;
            txtPrecio.BackColor = Color.White;
            txtPrecio.Text = "0,00";
            btnDetalles.Visible = false;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            List<Compra> listado = negocio.listarCompras();
            listado.Reverse();
            dgvCompras.DataSource = listado;
            dgvCompras.BringToFront();
            dgvCompras.Visible = true;
            btnDetalles.Visible = true;
            btnFinalizar.Visible = false;
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            dgvCompras.Visible = false;
            btnDetalles.Visible = false;
            btnFinalizar.Visible = true;
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
                nuevo.PrecioUnitario = nuevo.Producto.PrecioUnitario;
                nuevo.PrecioParcial = nuevo.PrecioUnitario * nuevo.Cantidad;
                Detalle.Add(nuevo);
                cargarGrilla();
                PrecioFinal += Math.Round(nuevo.PrecioParcial, 2);
                lblPrecioTotal.Text = PrecioFinal.ToString();
                cmbProducto.Focus();
            }
            else
            {
                MessageBox.Show("No hay ningún producto seleccionado", "Cuidado!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvDetalle.CurrentRow != null)
            {
                DetalleCompra item = (DetalleCompra)dgvDetalle.CurrentRow.DataBoundItem;
                PrecioFinal -= Math.Round(item.PrecioParcial, 2);
                lblPrecioTotal.Text = PrecioFinal.ToString();
                int index = dgvDetalle.CurrentRow.Index;
                Detalle.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("No hay ningún producto seleccionado", "Cuidado!");
            }
        }

        private void restablecerControles()
        {
            ComboStyle(cmbProducto);
            ComboStyle(cmbProveedores);
            nudCantidad.Value = 1;
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
                txtPrecio.Text = prod.PrecioUnitario.ToString();
            }
        }

        private void frmCompras_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (cmbProveedores.SelectedItem != null)
            {
                if (Detalle.Count > 0)
                {
                    CompraNegocio negocioCom = new CompraNegocio();
                    ProductoNegocio negocioProd = new ProductoNegocio();
                    Compra nuevaCompra = new Compra();
                    nuevaCompra.Proveedor = new Proveedor();
                    nuevaCompra.Detalle = new List<DetalleCompra>();
                         
                    nuevaCompra.Proveedor = (Proveedor)cmbProveedores.SelectedItem;
                    nuevaCompra.Detalle = Detalle.ToList();
                    nuevaCompra.Importe = Convert.ToDecimal(lblPrecioTotal.Text);

                    nuevaCompra.ID = negocioCom.agregarCompra(nuevaCompra);
                    foreach (DetalleCompra item in nuevaCompra.Detalle)
                    {
                        negocioCom.agregarProductosXCompra(nuevaCompra.ID, item.Producto.ID, item.Cantidad);
                        negocioProd.aumentarStock(item.Producto, item.Cantidad);
                    }
                    restablecerControles();
                    Detalle.Clear();
                }
                else
                {
                    MessageBox.Show("No hay productos en la compra actual", "Cuidado!");
                }
            }
            else
            {
                MessageBox.Show("No hay proveedor asignado", "Cuidado!");
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            Compra cSelect = (Compra)dgvCompras.CurrentRow.DataBoundItem;
            frmDetallesCompra detalles = new frmDetallesCompra(cSelect);
            detalles.ShowDialog();
        }

        private void dgvCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Compra cSelect = (Compra)dgvCompras.CurrentRow.DataBoundItem;
            frmDetallesCompra detalles = new frmDetallesCompra(cSelect);
            detalles.ShowDialog();
        }
    }
}
