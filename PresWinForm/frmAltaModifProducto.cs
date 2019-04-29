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
    public partial class frmAltaModifProducto : Form
    {
        public frmAltaModifProducto()
        {
            InitializeComponent();
        }

        private void frmAltaModifProducto_Load(object sender, EventArgs e)
        {
            ProveedorNegocio negocioProv = new ProveedorNegocio();
            clbProveedores.DataSource = negocioProv.listarNombresProv();

            CategoriaNegocio negocioCat = new CategoriaNegocio();
            cmbCategoria.DataSource = negocioCat.listarNombresCategorias();
            cmbCategoria.AutoCompleteMode = AutoCompleteMode.Append;
            cmbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCategoria.Text = "Elige una opción...";

            MarcaNegocio negocioMarcas = new MarcaNegocio();
            cmbMarca.DataSource = negocioMarcas.listarNombresMarcas();
            cmbMarca.AutoCompleteMode = AutoCompleteMode.Append;
            cmbMarca.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbMarca.Text = "Elige una opción...";
        }

        private void btnNuevoProv_Click(object sender, EventArgs e)
        {
            frmAltaModifPersona altaProv = new frmAltaModifPersona('P');
            altaProv.Show();
        }
    }
}
