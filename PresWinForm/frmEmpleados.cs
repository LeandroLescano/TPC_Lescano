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
                dgvEmpleados.Columns["RazonSocial"].Visible = false;
                dgvEmpleados.Columns["CUIT"].Visible = false;
                dgvEmpleados.Columns["TipoPersona"].Visible = false;
                dgvEmpleados.Columns["Codigo"].DisplayIndex = 0;
                dgvEmpleados.Columns["Apellido"].DisplayIndex = 1;
                dgvEmpleados.Columns["Nombre"].DisplayIndex = 2;
                dgvEmpleados.Columns["DNI"].DisplayIndex = 3;
                dgvEmpleados.Columns["CUIL"].DisplayIndex = 4;
                dgvEmpleados.Columns["TipoEmpleado"].DisplayIndex = 5;
                dgvEmpleados.Columns["Usuario"].DisplayIndex = 6;
                dgvEmpleados.Columns["Domicilio"].DisplayIndex = 7;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmAltaModifEmpleado modif = new frmAltaModifEmpleado();
            modif.Show();
        }
    }
}
