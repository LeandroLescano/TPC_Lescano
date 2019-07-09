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
            cmb.Text = "Elige una opción...";
        }

        private void cmbCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combo cSelect = (Combo)cmbCombo.SelectedItem;
            dtpEntrega.MinDate = System.DateTime.Now.AddDays(cSelect.DiasAnticipo);
            dtpEntrega.Value = dtpEntrega.MinDate;
        }
    }
}
