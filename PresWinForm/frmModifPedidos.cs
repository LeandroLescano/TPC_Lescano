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
            cmbEstado.Items.Add("A revisar");
            cmbEstado.Items.Add("Aceptado");
            cmbEstado.Items.Add("Rechazado");
            cmbEstado.SelectedIndex = cmbEstado.FindString(local.Estado);
            txtEstado.Text = local.Estado;
            txtID.Text = local.ID.ToString();
            txtCliente.Text = local.Cliente.Apellido + ", " + local.Cliente.Nombre;
            dtpFechRetiro.Value = local.FechaEntrega;
            txtCombo.Text = local.Combo.Nombre;
            txtPrecio.Text = local.PrecioFinal.ToString();
            txtObservaciones.Text = local.Observacion;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Enviar mail con comentarios y el estado del pedido al cliente
        }
    }
}
