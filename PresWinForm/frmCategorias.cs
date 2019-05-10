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
                dgvCategoria.DataSource = negocio.listarCategorias();
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
    }
}
