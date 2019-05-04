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
                dgvMarca.DataSource = negocio.listarMarcas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
