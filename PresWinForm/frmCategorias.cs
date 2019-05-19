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
                dgvCategoria.DataSource = listaCat;
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
                    lista = listaCat.FindAll(X => X.Nombre.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
                    dgvCategoria.DataSource = lista;
                }
            }
        }
    }
}
