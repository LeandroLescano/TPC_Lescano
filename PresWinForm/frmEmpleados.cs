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
using negocioCom;

namespace PresWinForm
{
    public partial class frmEmpleados : Form
    {
        private List<Empleado> listaEmp;
        private Usuario uLocal = new Usuario();

        public frmEmpleados()
        {
            InitializeComponent();
        }

        public frmEmpleados(Usuario u)
        {
            InitializeComponent();
            uLocal = u;
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
                if (chbEstado.Checked == false)
                {
                    listaEmp = listaEmp.FindAll(X => X.Estado == true);
                }
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
                dgvEmpleados.Columns["Estado"].Visible = false;
                dgvEmpleados.ClearSelection();
                foreach (DataGridViewRow row in dgvEmpleados.Rows)
                {
                    Empleado emp = (Empleado)row.DataBoundItem;
                    if (emp.Estado == false)
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                Empleado eModif = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
                frmAltaModifEmpleado modif = new frmAltaModifEmpleado(eModif);
                modif.ShowDialog();
                cargarGrilla();
            }
            else
            {
                MessageBox.Show("No hay ningún empleado seleccionado", "Cuidado!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow != null)
            {
                Empleado eEliminar = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
                if (eEliminar.Usuario.Nombre != uLocal.Nombre)
                {
                    if (MessageBox.Show("Está a punto de eliminar al empleado: " + eEliminar.Nombre + ".\n\n¿Desea eliminarlo?", "Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        EmpleadoNegocio negocio = new EmpleadoNegocio();
                        negocio.eliminarEmpleado(eEliminar);
                        cargarGrilla();
                    }
                }
                else
                {
                    MessageBox.Show("No puedes eliminar el usuario actual.", "Cuidado!");
                }
            }
            else
            {
                MessageBox.Show("No hay ningún empleado seleccionado", "Cuidado!");
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

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            Empleado emp = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
            negocio.habilitarEmpleado(emp);
            cargarGrilla();
        }

        private void chbEstado_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            Empleado emp = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;
            if (emp.Estado == false)
            {
                btnHabilitar.Enabled = true;
            }
            else
            {
                btnHabilitar.Enabled = false;
            }
        }

        private void dgvEmpleados_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentRow = dgvEmpleados.HitTest(e.X, e.Y).RowIndex;
                int currentColumn = dgvEmpleados.HitTest(e.X, e.Y).ColumnIndex;

                if (currentRow >= 0)
                {
                    dgvEmpleados[currentColumn, currentRow].Selected = true;
                    Empleado eSelect = (Empleado)dgvEmpleados.CurrentRow.DataBoundItem;

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Modificar", btnModificar_Click));
                    if (eSelect.Estado == true)
                    {
                        m.MenuItems.Add(new MenuItem("Eliminar", btnEliminar_Click));
                    }
                    else
                    {
                        m.MenuItems.Add(new MenuItem("Habilitar", btnHabilitar_Click));
                    }

                    m.Show(dgvEmpleados, new Point(e.X, e.Y));
                }
            }
        }
    }
}
