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
    public partial class frmModifPedidos : Form
    {
        Pedido local = new Pedido();
        public frmModifPedidos(Pedido p)
        {
            InitializeComponent();
            local = p;
        }

        private void frmModifPedidos_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocioCli = new ClienteNegocio();
            local.Cliente.Mails = negocioCli.listarMailsXCliente(local.Cliente);
            if(local.Cliente.Mails.Count > 0)
            {
                lblMail.Text += local.Cliente.Mails[0].Direccion;
            }
            else
            {
                lblMail.Text += "Este cliente no posee ningún mail registrado.";
                txtComentario.Enabled = false;
            }
            cmbEstado.Items.Add("A revisar");
            cmbEstado.Items.Add("Aceptado");
            cmbEstado.Items.Add("Rechazado");
            cmbEstado.Items.Add("En preparación");
            cmbEstado.Items.Add("Listo para retirar");
            cmbEstado.Items.Add("Entregado");
            cmbEstado.SelectedIndex = cmbEstado.FindString(local.Estado);
            txtEstado.Text = local.Estado;
            txtID.Text = local.ID.ToString();
            txtCliente.Text = local.Cliente.Apellido + ", " + local.Cliente.Nombre;
            dtpFechaSolicitud.Value = local.FechaSolicitud;
            dtpFechRetiro.Value = local.FechaEntrega;
            txtCombo.Text = local.Combo.Nombre;
            txtPrecio.Text = local.PrecioFinal.ToString();
            txtObservaciones.Text = local.Observacion;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocioP = new ProductoNegocio();
            VentaNegocio negocioV = new VentaNegocio();
            MailNegocio negocioM = new MailNegocio();
            PedidoNegocio negocioPed = new PedidoNegocio();
            local.Estado = cmbEstado.SelectedItem.ToString();
            if(local.Estado == "Entregado")
            {
                Venta ventaCombo = new Venta();
                ventaCombo.Detalle = new List<DetalleVenta>();
                ventaCombo.Cliente = local.Cliente;
                ventaCombo.Importe = local.Combo.Precio;
                ventaCombo.Descripcion = local.Combo.Nombre;
                foreach (DetalleCombo item in local.Combo.Productos)
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
            if(txtComentario.Enabled)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (negocioM.mandarMail(local.Cliente.Mails[0].Direccion, local, txtComentario.Text))
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("El mail ha sido enviado correctamente.","Confirmación");
                    negocioPed.modificarPedido(local);
                }
                else
                {
                    if(MessageBox.Show("Hubo un error al enviar el mail.\n\nDesea modificar el pedido?", "Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        negocioPed.modificarPedido(local);
                    }
                }
            }
            Cursor.Current = Cursors.Default;
            this.Close();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            frmAltaModifCombo verCombo = new frmAltaModifCombo(local.Combo, false);
            verCombo.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetallesCliente_Click(object sender, EventArgs e)
        {
            frmAltaModifPersona verCliente = new frmAltaModifPersona(local.Cliente, 'C');
            verCliente.ShowDialog();
        }

        private void llenarFactura(Venta nuevaVenta, List<DetalleVenta> Detalle)
        {
            ComercioNegocio negocioCom = new ComercioNegocio();
            FacturaNegocio negocioFact = new FacturaNegocio();
            Comercio comercio = new Comercio();
            comercio = negocioCom.listarComercio();
            nuevaVenta.Cliente = local.Cliente;
            nuevaVenta.Detalle = Detalle;
            nuevaVenta.Factura.Domicilio = comercio.Domicilio;
            nuevaVenta.Importe = local.Combo.Precio;
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
