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
            dgvVentas.Visible = false;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            VentaNegocio negocio = new VentaNegocio();
            dgvVentas.BringToFront();
            dgvVentas.Visible = true;
            listado = negocio.listarVentas();
            dgvVentas.DataSource = listado;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.Text != "Elige una opción...")
            {
                DetalleVenta nuevo = new DetalleVenta();
                nuevo.Producto = (Producto)cmbProducto.SelectedItem;
                nuevo.Cantidad = Convert.ToInt32(nudCantidad.Value);
                nuevo.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
                nuevo.PrecioParcial = nuevo.PrecioUnitario * nuevo.Cantidad;
                Detalle.Add(nuevo);
                cargarGrilla();
                PrecioFinal += Math.Round(nuevo.PrecioParcial, 2);
                lblPrecioTotal.Text = PrecioFinal.ToString();
                cmbProducto.Focus();
            }
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
            nudCantidad.Select(0, nudCantidad.Text.Length);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = dgvDetalle.CurrentRow.Index;
            Detalle.RemoveAt(index);
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if(cmbClientes.SelectedItem != null)
            {
                VentaNegocio negocioVen = new VentaNegocio();
                FacturaNegocio negocioFact = new FacturaNegocio();
                Venta nuevaVenta = new Venta();
                nuevaVenta.Cliente = new Cliente();
                nuevaVenta.Detalle = new List<DetalleVenta>();
                nuevaVenta.Factura = new Factura();

                nuevaVenta.Cliente = (Cliente)cmbClientes.SelectedItem;
                nuevaVenta.Detalle = Detalle.ToList();
                nuevaVenta.Factura.Domicilio = nuevaVenta.Cliente.Domicilio; //Como prueba asigno domicilio del cliente
                nuevaVenta.Importe = Convert.ToDecimal(lblPrecioTotal.Text);
                nuevaVenta.Factura.Numero = "0001-00000001";
                nuevaVenta.Factura.CUIT = nuevaVenta.Cliente.CUIT;
                nuevaVenta.Factura.IngresosBrutos = "1234567-08"; //Falta hacer una sección para poner los datos generales de la factura junto a Domicilio, Fecha de inicio
                nuevaVenta.Factura.FechaInicio = System.DateTime.Now;
                nuevaVenta.Factura.FechaActual = System.DateTime.Now;
                nuevaVenta.Factura.ListadoProductos = nuevaVenta.Detalle;
                nuevaVenta.Factura.ID = negocioFact.agregarFactura(nuevaVenta.Factura);
                nuevaVenta.ID = negocioVen.agregarVenta(nuevaVenta);
                foreach (DetalleVenta item in nuevaVenta.Detalle)
                {
                    negocioVen.agregarProductosXVenta(nuevaVenta.ID, item.Producto.ID, item.Cantidad);
                }
            }
            else
            {
                MessageBox.Show("No hay cliente asignado", "Cuidado!");
            }
        }

    }
}
