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
                dgvMarca.DataSource = listaMarcas;
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
    }
}
