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

namespace PresWinForm
{
    public partial class frmAltaModifCombo : Form
    {
        public frmAltaModifCombo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDiasAnticipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void frmAltaModifCombo_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            clbProductos.DataSource = negocio.listarProductos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Selecciona la imagen del combo";
            openFileDialog.ShowDialog();
            txtRuta.Text = openFileDialog.FileName;
            picImagen.Image = Image.FromFile(txtRuta.Text);
        }
    }
}
