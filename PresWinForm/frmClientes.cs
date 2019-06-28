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
        private List<Cliente> listaCli;

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        { 
            frmAltaModifPersona alta = new frmAltaModifPersona('C');
            alta.ShowDialog();
            cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Cliente cmodif = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            frmAltaModifPersona modif = new frmAltaModifPersona(cmodif, 'C');
            modif.ShowDialog();
            cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                Cliente cmodif = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
                if (MessageBox.Show("Seguro que desea eliminar el cliente " + cmodif.Apellido + ", " + cmodif.Nombre + " con ID: " + cmodif.ID + "?", "Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    negocio.eliminarCliente(cmodif);
                    cargarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarGrilla()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                listaCli = negocio.listarClientes();
                if (chbEstado.Checked == false)
                {
                    listaCli = listaCli.FindAll(X => X.Estado == true);
                }
                dgvClientes.DataSource = listaCli;
                dgvClientes.Columns["Usuario"].Visible = false;
                dgvClientes.Columns["ID"].DisplayIndex = 0;
                dgvClientes.Columns["Apellido"].DisplayIndex = 1;
                dgvClientes.Columns["Nombre"].DisplayIndex = 2;
                dgvClientes.Columns["RazonSocial"].DisplayIndex = 3;
                dgvClientes.Columns["DNI"].DisplayIndex = 4;
                dgvClientes.Columns["CUIT"].DisplayIndex = 5;
                dgvClientes.Columns["FechaNacimiento"].DisplayIndex = 6;
                dgvClientes.Columns["TipoPersona"].DisplayIndex = 7;
                dgvClientes.Columns["Estado"].Visible = false;
                dgvClientes.ClearSelection();

                foreach (DataGridViewRow row in dgvClientes.Rows)
                {
                    Cliente cli = (Cliente)row.DataBoundItem;
                    if (cli.Estado == false)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                dgvClientes.DataSource = listaCli;
            }
            else
            {
                if (txtBusqueda.Text.Length >= 1)
                {
                    List<Cliente> lista;
                    lista = listaCli.FindAll(X => X.Nombre != null && X.Nombre.ToUpper().Contains(txtBusqueda.Text.ToUpper()) ||
                                              X.Apellido != null && X.Apellido.ToUpper().Contains(txtBusqueda.Text.ToUpper()) ||
                                              X.RazonSocial != null && X.RazonSocial.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
                    dgvClientes.DataSource = lista;
                }
            }
        }

        private void chbEstado_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cli = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            negocio.habilitarCliente(cli);
            cargarGrilla();
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            Cliente cli = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            if (cli.Estado == false)
            {
                btnHabilitar.Enabled = true;
            }
            else
            {
                btnHabilitar.Enabled = false;
            }
        }

        private void dgvClientes_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentRow = dgvClientes.HitTest(e.X, e.Y).RowIndex;
                int currentColumn = dgvClientes.HitTest(e.X, e.Y).ColumnIndex;

                if (currentRow >= 0)
                {
                    dgvClientes[currentColumn, currentRow].Selected = true;
                    Cliente cSelect = (Cliente)dgvClientes.CurrentRow.DataBoundItem;

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Modificar", btnModificar_Click));
                    if (cSelect.Estado == true)
                    {
                        m.MenuItems.Add(new MenuItem("Eliminar", btnEliminar_Click));
                    }
                    else
                    {
                        m.MenuItems.Add(new MenuItem("Habilitar", btnHabilitar_Click));
                    }

                    m.Show(dgvClientes, new Point(e.X, e.Y));
                }
            }
        }
    }
}
