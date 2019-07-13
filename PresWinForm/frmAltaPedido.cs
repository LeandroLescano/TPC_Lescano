using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using Dominio;
using negocioCom;

namespace PresWinForm
{
    public partial class frmAltaPedido : Form
    {
        private Combo comboLocal;
        public frmAltaPedido()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAltaPedido_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocioCli = new ClienteNegocio();
            ComboNegocio negocioCom = new ComboNegocio();

            cmbCombo.DataSource = negocioCom.listarCombos();
            ComboStyle(cmbCombo);
            cmbClientes.DataSource = negocioCli.listarClientes();
            ComboStyle(cmbClientes);

            dtpEntrega.MinDate = DateTime.Now;
            txtPrecio.Text = "0,00";

            cmbEstado.Items.Add("A revisar");
            cmbEstado.Items.Add("Aceptado");
            cmbEstado.Items.Add("Rechazado");
            cmbEstado.Items.Add("En preparación");
            cmbEstado.Items.Add("Listo para retirar");
            cmbEstado.Items.Add("Entregado");
            cmbEstado.SelectedIndex = 0;
        }

        private void ComboStyle(ComboBox cmb)
        {
            cmb.AutoCompleteMode = AutoCompleteMode.Append;
            cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmb.SelectedIndex = -1;
            cmb.Text = "Elige una opción...";
        }

        private void cmbCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCombo.SelectedItem != null)
            {
                Combo cSelect = (Combo)cmbCombo.SelectedItem;
                dtpEntrega.MinDate = DateTime.Now.AddDays(cSelect.DiasAnticipo);
                dtpEntrega.Value = dtpEntrega.MinDate;
                txtPrecio.Text = cSelect.Precio.ToString();
            }
        }

        private void btnNuevoCombo_Click(object sender, EventArgs e)
        {
            frmAltaModifCombo nuevoCombo = new frmAltaModifCombo();
            nuevoCombo.ShowDialog();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmAltaModifPersona nuevoCliente = new frmAltaModifPersona('C');
            nuevoCliente.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            comboLocal = (Combo)cmbCombo.SelectedItem;
            if(comboLocal != null)
            {
                if(cmbClientes.SelectedItem != null)
                {
                    PedidoNegocio negocio = new PedidoNegocio();
                    Pedido nuevo = new Pedido();
                    nuevo.Cliente = (Cliente)cmbClientes.SelectedItem;
                    nuevo.Combo = comboLocal;
                    nuevo.FechaSolicitud = dtpSolicitud.Value;
                    nuevo.FechaEntrega = dtpEntrega.Value;
                    nuevo.Estado = cmbEstado.SelectedItem.ToString();
                    nuevo.PrecioFinal = comboLocal.Precio;
                    nuevo.Observacion = txtObservacion.Text;
                    negocio.cargarPedido(nuevo);
                    if(nuevo.Estado == "Entregado")
                    {
                        VentaNegocio negocioV = new VentaNegocio();
                        ProductoNegocio negocioP = new ProductoNegocio();
                        Venta ventaCombo = new Venta();
                        ventaCombo.Detalle = new List<DetalleVenta>();
                        ventaCombo.Cliente = nuevo.Cliente;
                        ventaCombo.Importe = nuevo.Combo.Precio;
                        ventaCombo.Descripcion = nuevo.Combo.Nombre;
                        foreach (DetalleCombo item in nuevo.Combo.Productos)
                        {
                            DetalleVenta detalle = new DetalleVenta();
                            detalle.Cantidad = item.Unidades;
                            detalle.Kilos = item.Kilos;
                            detalle.Producto = item.Producto;
                            detalle.PrecioUnitario = item.Producto.calcularPrecio();
                            detalle.PrecioParcial = (detalle.PrecioUnitario * item.Unidades) + (detalle.PrecioUnitario * item.Kilos);
                            ventaCombo.Detalle.Add(detalle);
                            negocioP.descontarStock(item.Producto, item.Unidades, item.Kilos);
                        }
                        ventaCombo.Factura = new Factura();
                        llenarFactura(ventaCombo, ventaCombo.Detalle);
                        ventaCombo.ID = negocioV.agregarVenta(ventaCombo);
                        foreach (DetalleVenta item in ventaCombo.Detalle)
                        {
                            negocioV.agregarProductosXVenta(ventaCombo.ID, item.Producto.ID, item.Cantidad, item.Kilos);
                        }
                    }
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("No hay ningún cliente seleccionado", "Atención!");
                }
            }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("No hay ningún combo seleccionado", "Atención!");
            }
            Cursor.Current = Cursors.Default;
        }

        private void llenarFactura(Venta nuevaVenta, List<DetalleVenta> Detalle)
        {
            ComercioNegocio negocioCom = new ComercioNegocio();
            FacturaNegocio negocioFact = new FacturaNegocio();
            Comercio comercio = new Comercio();
            comercio = negocioCom.listarComercio();
            nuevaVenta.Cliente = (Cliente)cmbClientes.SelectedItem;
            nuevaVenta.Detalle = Detalle;
            nuevaVenta.Factura.Domicilio = comercio.Domicilio;
            nuevaVenta.Importe = comboLocal.Precio;
            nuevaVenta.Factura.Numero = negocioFact.NumeroNuevaFact();
            nuevaVenta.Factura.CUIT = comercio.CUIT;
            nuevaVenta.Factura.IngresosBrutos = comercio.IngresosBrutos;
            nuevaVenta.Factura.FechaInicio = comercio.FechaInicio;
            nuevaVenta.Factura.FechaActual = System.DateTime.Now;
            nuevaVenta.Factura.ListadoProductos = nuevaVenta.Detalle;
            nuevaVenta.Factura.ID = negocioFact.agregarFactura(nuevaVenta.Factura);
        }
    }
}
