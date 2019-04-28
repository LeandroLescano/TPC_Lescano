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
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaModifEmpleado alta = new frmAltaModifEmpleado();
            alta.Show();
        }

        private void cargarGrilla()
        {
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            try
            {
                dgvEmpleados.DataSource = negocio.listarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
