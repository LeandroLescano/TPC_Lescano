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
    public partial class frmCategorias : Form
    {
        private List<Categoria> listaCat;

        public frmCategorias()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaModifMarcaCat alta = new frmAltaModifMarcaCat('C');
            alta.ShowDialog();
            cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Categoria cModif = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
            frmAltaModifMarcaCat modif = new frmAltaModifMarcaCat(cModif, 'C');
            modif.ShowDialog();
            cargarGrilla();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                listaCat = negocio.listarCategorias();
                if (chbEstado.Checked == false)
                {
                    listaCat = listaCat.FindAll(X => X.Estado == true);
                }
                dgvCategoria.DataSource = listaCat;
                dgvCategoria.Columns[2].Visible = false;
                dgvCategoria.ClearSelection();
                foreach (DataGridViewRow row in dgvCategoria.Rows)
                {
                    Categoria cat = (Categoria)row.DataBoundItem;
                    if(cat.Estado == false)
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
            Categoria cEliminar = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
            if (MessageBox.Show("¿Desea eliminar la categoria \"" + cEliminar.Nombre + "\" ?", "Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.eliminarCategoria(cEliminar);
                cargarGrilla();
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                dgvCategoria.DataSource = listaCat;
            }
            else
            {
                if (txtBusqueda.Text.Length >= 1)
                {
                    List<Categoria> lista;
                    lista = listaCat.FindAll(X => X.Nombre.ToUpper().Contains(txtBusqueda.Text.ToUpper()) && X.Estado == true);
                    dgvCategoria.DataSource = lista;
                }
            }
        }

        private void chbEstado_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void dgvCategoria_SelectionChanged(object sender, EventArgs e)
        {
            Categoria cat = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
            if (cat.Estado == false)
            {
                btnHabilitar.Enabled = true;
            }
            else
            {
                btnHabilitar.Enabled = false;
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Categoria cat = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
            negocio.habilitarCategoria(cat);
            cargarGrilla();
        }

        private void dgvCategoria_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentRow = dgvCategoria.HitTest(e.X, e.Y).RowIndex;
                int currentColumn = dgvCategoria.HitTest(e.X, e.Y).ColumnIndex;

                if (currentRow >= 0)
                {
                    dgvCategoria[currentColumn, currentRow].Selected = true;
                    Categoria cSelect = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Modificar", btnModificar_Click));
                    if (cSelect.Estado == true)
                    {
                        m.MenuItems.Add(new MenuItem("Deshabilitar", btnEliminar_Click));
                    }
                    else
                    {
                        m.MenuItems.Add(new MenuItem("Habilitar", btnHabilitar_Click));
                    }

                    m.Show(dgvCategoria, new Point(e.X, e.Y));
                }
            }
        }
    }
}
