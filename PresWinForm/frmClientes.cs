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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaModifPersona alta = new frmAltaModifPersona('C');
            alta.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Cliente cmodif = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            frmAltaModifPersona modif = new frmAltaModifPersona(cmodif, 'C');
            modif.Show();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                dgvClientes.DataSource = negocio.listarClientes();
                dgvClientes.Columns["Codigo"].DisplayIndex = 0;
                dgvClientes.Columns["Apellido"].DisplayIndex = 1;
                dgvClientes.Columns["Nombre"].DisplayIndex = 2;
                dgvClientes.Columns["RazonSocial"].DisplayIndex = 3;
                dgvClientes.Columns["DNI"].DisplayIndex = 4;
                dgvClientes.Columns["CUIT"].DisplayIndex = 5;
                dgvClientes.Columns["FechaNacimiento"].DisplayIndex = 6;
                dgvClientes.Columns["TipoPersona"].DisplayIndex = 7;
                dgvClientes.Columns["Usuario"].DisplayIndex = 8;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmClientes_Enter(object sender, EventArgs e)
        {
            cargarGrilla();
        }
    }
}
