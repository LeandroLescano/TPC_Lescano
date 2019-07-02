using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocioCom;
using Dominio;

namespace PresWinForm
{
    public partial class frmProveedores : Form
    {
        private List<Proveedor> listaProv;

        public frmProveedores()
        {
            InitializeComponent();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            try
            {
                listaProv = negocio.listarProveedores();
                if (chbEstado.Checked == false)
                {
                    listaProv = listaProv.FindAll(X => X.Estado == true);
                }
                dgvProveedores.DataSource = listaProv;
                dgvProveedores.Columns["Usuario"].Visible = false;
                dgvProveedores.Columns["ID"].DisplayIndex = 0;
                dgvProveedores.Columns["Apellido"].DisplayIndex = 1;
                dgvProveedores.Columns["Nombre"].DisplayIndex = 2;
                dgvProveedores.Columns["RazonSocial"].DisplayIndex = 3;
                dgvProveedores.Columns["DNI"].DisplayIndex = 4;
                dgvProveedores.Columns["CUIT"].DisplayIndex = 5;
                dgvProveedores.Columns["FechaNacimiento"].DisplayIndex = 6;
                dgvProveedores.Columns["TipoPersona"].DisplayIndex = 7;
                dgvProveedores.Columns["Estado"].Visible = false;

                foreach (DataGridViewRow row in dgvProveedores.Rows)
                {
                    Proveedor prov = (Proveedor)row.DataBoundItem;
                    if (prov.Estado == false)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaModifPersona alta = new frmAltaModifPersona('P');
            alta.ShowDialog();
            cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow != null)
            {
                Proveedor pmodif = (Proveedor)dgvProveedores.CurrentRow.DataBoundItem;
                frmAltaModifPersona modif = new frmAltaModifPersona(pmodif, 'P');
                modif.ShowDialog();
                cargarGrilla();
            }
            else
            {
                MessageBox.Show("No hay ningún proveedor seleccionado", "Cuidado!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow != null)
            {
                Proveedor peliminar = (Proveedor)dgvProveedores.CurrentRow.DataBoundItem;
                string Nombre;
                if (peliminar.TipoPersona.Fisica)
                    Nombre = peliminar.Apellido + ", " + peliminar.Nombre;
                else
                    Nombre = peliminar.RazonSocial;
                if (MessageBox.Show("Está a punto de eliminar al proveedor: " + Nombre + ".\n\n¿Desea eliminarlo?", "Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ProveedorNegocio negocio = new ProveedorNegocio();
                    negocio.eliminarProveedor(peliminar);
                    cargarGrilla();
                }
            }
            else
            {
                MessageBox.Show("No hay ningún proveedor seleccionado", "Cuidado!");
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                dgvProveedores.DataSource = listaProv;
            }
            else
            {
                if (txtBusqueda.Text.Length >= 1)
                {
                    List<Proveedor> lista;
                    lista = listaProv.FindAll(X => X.Nombre != null && X.Nombre.ToUpper().Contains(txtBusqueda.Text.ToUpper()) || 
                                              X.Apellido != null && X.Apellido.ToUpper().Contains(txtBusqueda.Text.ToUpper())  || 
                                              X.RazonSocial != null && X.RazonSocial.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
                    dgvProveedores.DataSource = lista;
                }
            }
        }

        private void chbEstado_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            Proveedor prov = (Proveedor)dgvProveedores.CurrentRow.DataBoundItem;
            negocio.habilitarProveedor(prov);
            cargarGrilla();
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            Proveedor prov = (Proveedor)dgvProveedores.CurrentRow.DataBoundItem;
            if (prov.Estado == false)
            {
                btnHabilitar.Enabled = true;
            }
            else
            {
                btnHabilitar.Enabled = false;
            }
        }

        private void dgvProveedores_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentRow = dgvProveedores.HitTest(e.X, e.Y).RowIndex;
                int currentColumn = dgvProveedores.HitTest(e.X, e.Y).ColumnIndex;

                if (currentRow >= 0)
                {
                    dgvProveedores[currentColumn, currentRow].Selected = true;
                    Proveedor pSelect = (Proveedor)dgvProveedores.CurrentRow.DataBoundItem;

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Modificar", btnModificar_Click));
                    if (pSelect.Estado == true)
                    {
                        m.MenuItems.Add(new MenuItem("Eliminar", btnEliminar_Click));
                    }
                    else
                    {
                        m.MenuItems.Add(new MenuItem("Habilitar", btnHabilitar_Click));
                    }

                    m.Show(dgvProveedores, new Point(e.X, e.Y));
                }
            }
        }
    }
}
