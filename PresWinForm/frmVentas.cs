using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocioCom;
using Dominio;
namespace PresWinForm
{
    public partial class frmVentas : Form
    {
        private BindingList<DetalleVenta> Detalle = new BindingList<DetalleVenta>();
        private decimal PrecioFinal;
        private List<Venta> listado;

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
            txtPrecio.ReadOnly = true;
            txtPrecio.BackColor = Color.White;
            txtPrecio.Text = "0,00";
            btnDetalles.Visible = false;
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
            nudKilos.Value = 0;
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
            dgvVentas.Visible = false;
            btnDetalles.Visible = false;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            VentaNegocio negocio = new VentaNegocio();
            dgvVentas.BringToFront();
            dgvVentas.Visible = true;
            listado = negocio.listarVentas();
            dgvVentas.DataSource = listado;
            btnDetalles.Visible = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.Text != "Elige una opción...")
            {
                DetalleVenta nuevo = new DetalleVenta();
                nuevo.Producto = (Producto)cmbProducto.SelectedItem;
                nuevo.Cantidad = Convert.ToInt32(nudCantidad.Value);
                nuevo.Kilos = Convert.ToDecimal(nudKilos.Value);
                nuevo.PrecioUnitario = nuevo.Producto.calcularPrecio();
                nuevo.PrecioParcial = (nuevo.PrecioUnitario * nuevo.Cantidad) + (nuevo.PrecioUnitario * nuevo.Kilos);
                Detalle.Add(nuevo);
                cargarGrilla();
                PrecioFinal += Math.Round(nuevo.PrecioParcial, 2);
                lblPrecioTotal.Text = PrecioFinal.ToString();
                cmbProducto.Focus();
                cmbProducto.SelectedIndex = -1;
                cmbProducto.Text = "Elige una opción...";
            }
            else
            {
                MessageBox.Show("No hay ningún producto seleccionado", "Cuidado!");
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Producto)cmbProducto.SelectedItem != null)
            {
                Producto prod = (Producto)cmbProducto.SelectedItem;
                txtPrecio.Text = prod.calcularPrecio().ToString();
                if(prod.Fraccionable)
                {
                    nudCantidad.Value = 0;
                    nudKilos.Value = 0;
                    nudKilos.Enabled = true;
                }
                else
                {
                    nudCantidad.Value = 1;
                    nudKilos.Value = 0;
                    nudKilos.Enabled = false;
                }
            }
        }

        private void nudCantidad_Enter(object sender, EventArgs e)
        {
            nudCantidad.Select(0, nudCantidad.Text.Length);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvDetalle.CurrentRow != null)
            {
                DetalleVenta item = (DetalleVenta)dgvDetalle.CurrentRow.DataBoundItem;
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

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (cmbClientes.SelectedItem != null)
            {
                if(Detalle.Count > 0)
                {
                    VentaNegocio negocioVen = new VentaNegocio();
                    FacturaNegocio negocioFact = new FacturaNegocio();
                    ComercioNegocio negocioCom = new ComercioNegocio();
                    ProductoNegocio negocioProd = new ProductoNegocio();
                    Comercio comercio = new Comercio();
                    comercio = negocioCom.listarComercio();
                    Venta nuevaVenta = new Venta();
                    nuevaVenta.Cliente = new Cliente();
                    nuevaVenta.Detalle = new List<DetalleVenta>();
                    nuevaVenta.Factura = new Factura();

                    nuevaVenta.Cliente = (Cliente)cmbClientes.SelectedItem;
                    nuevaVenta.Detalle = Detalle.ToList();
                    nuevaVenta.Factura.Domicilio = comercio.Domicilio;
                    nuevaVenta.Importe = Convert.ToDecimal(lblPrecioTotal.Text);
                    nuevaVenta.Factura.Numero = negocioFact.NumeroNuevaFact();
                    nuevaVenta.Factura.CUIT = comercio.CUIT;
                    nuevaVenta.Factura.IngresosBrutos = comercio.IngresosBrutos;
                    nuevaVenta.Factura.FechaInicio = comercio.FechaInicio;
                    nuevaVenta.Factura.FechaActual = System.DateTime.Now;
                    nuevaVenta.Factura.ListadoProductos = nuevaVenta.Detalle;
                    nuevaVenta.Factura.ID = negocioFact.agregarFactura(nuevaVenta.Factura);
                    nuevaVenta.ID = negocioVen.agregarVenta(nuevaVenta);
                    foreach (DetalleVenta item in nuevaVenta.Detalle)
                    {
                        negocioVen.agregarProductosXVenta(nuevaVenta.ID, item.Producto.ID, item.Cantidad, item.Kilos);
                        negocioProd.descontarStock(item.Producto, item.Cantidad, item.Kilos);
                    }
                    negocioFact.FacturaWord(nuevaVenta.Factura, nuevaVenta);
                    restablecerControles();
                    Detalle.Clear();
                }
                else
                {
                    MessageBox.Show("No hay productos en la venta actual", "Cuidado!");
                }
            }
            else
            {
                MessageBox.Show("No hay cliente asignado", "Cuidado!");
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            Venta vSelect = (Venta)dgvVentas.CurrentRow.DataBoundItem;
            frmDetallesVenta detalles = new frmDetallesVenta(vSelect);
            detalles.ShowDialog();
        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Venta vSelect = (Venta)dgvVentas.CurrentRow.DataBoundItem;
            frmDetallesVenta detalles = new frmDetallesVenta(vSelect);
            detalles.ShowDialog();
        }
    }
}
