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
    public partial class frmMarcas : Form
    {
        private List<Marca> listaMarcas;

        public frmMarcas()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaModifMarcaCat alta = new frmAltaModifMarcaCat('M');
            alta.ShowDialog();
            cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Marca mModif = (Marca)dgvMarca.CurrentRow.DataBoundItem;
            frmAltaModifMarcaCat modif = new frmAltaModifMarcaCat(mModif, 'M');
            modif.ShowDialog();
            cargarGrilla();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            try
            {
                listaMarcas = negocio.listarMarcas();
                if (chbEstado.Checked == false)
                {
                    listaMarcas = listaMarcas.FindAll(X => X.Estado == true);
                }
                dgvMarca.DataSource = listaMarcas;
                dgvMarca.Columns["Estado"].Visible = false;
                foreach (DataGridViewRow row in dgvMarca.Rows)
                {
                    Marca marca = (Marca)row.DataBoundItem;
                    if (marca.Estado == false)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Marca mEliminar = (Marca)dgvMarca.CurrentRow.DataBoundItem;
            if(MessageBox.Show("¿Desea eliminar la marca \"" +mEliminar.Nombre+ "\" ?" ,"Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MarcaNegocio negocio = new MarcaNegocio();
                negocio.eliminarMarca(mEliminar);
                cargarGrilla();
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                dgvMarca.DataSource = listaMarcas;
            }
            else
            {
                if (txtBusqueda.Text.Length >= 1)
                {
                    List<Marca> lista;
                    lista = listaMarcas.FindAll(X => X.Nombre.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
                    dgvMarca.DataSource = lista;
                }
            }
        }

        private void chbEstado_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            Marca marca = (Marca)dgvMarca.CurrentRow.DataBoundItem;
            negocio.habilitarMarca(marca);
            cargarGrilla();
        }

        private void dgvMarca_SelectionChanged(object sender, EventArgs e)
        {
            Marca marca = (Marca)dgvMarca.CurrentRow.DataBoundItem;
            if (marca.Estado == false)
            {
                btnHabilitar.Enabled = true;
            }
            else
            {
                btnHabilitar.Enabled = false;
            }
        }

        private void dgvMarca_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentRow = dgvMarca.HitTest(e.X, e.Y).RowIndex;
                int currentColumn = dgvMarca.HitTest(e.X, e.Y).ColumnIndex;

                if (currentRow >= 0)
                {
                    dgvMarca[currentColumn, currentRow].Selected = true;
                    Marca mSelect = (Marca)dgvMarca.CurrentRow.DataBoundItem;

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Modificar", btnModificar_Click));
                    if (mSelect.Estado == true)
                    {
                        m.MenuItems.Add(new MenuItem("Eliminar", btnEliminar_Click));
                    }
                    else
                    {
                        m.MenuItems.Add(new MenuItem("Habilitar", btnHabilitar_Click));
                    }

                    m.Show(dgvMarca, new Point(e.X, e.Y));
                }
            }
        }
    }
}
