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
        private List<Empleado> listaEmp;

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
            alta.ShowDialog();
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            try
            {
                listaEmp = negocio.listarEmpleados();
                dgvEmpleados.DataSource = listaEmp;
                dgvEmpleados.Columns["RazonSocial"].Visible = false;
                dgvEmpleados.Columns["CUIT"].Visible = false;
                dgvEmpleados.Columns["TipoPersona"].Visible = false;
                dgvEmpleados.Columns["ID"].DisplayIndex = 0;
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
            Empleado eModif = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
            frmAltaModifEmpleado modif = new frmAltaModifEmpleado(eModif);
            modif.ShowDialog();
            cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Empleado eEliminar = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
            if (MessageBox.Show("Está a punto de eliminar al empleado: " + eEliminar.Nombre + ".\n\n¿Desea eliminarlo?", "Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EmpleadoNegocio negocio = new EmpleadoNegocio();
                negocio.eliminarEmpleado(eEliminar);
                cargarGrilla();
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                dgvEmpleados.DataSource = listaEmp;
            }
            else
            {
                if (txtBusqueda.Text.Length >= 1)
                {
                    List<Empleado> lista;
                    lista = listaEmp.FindAll(X => X.Nombre.ToUpper().Contains(txtBusqueda.Text.ToUpper()) ||
                                              X.Apellido.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
                    dgvEmpleados.DataSource = lista;
                }
            }
        }
    }
}
