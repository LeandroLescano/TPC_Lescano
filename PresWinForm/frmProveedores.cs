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
using Dominio;

namespace PresWinForm
{
    public partial class frmProveedores : Form
    {
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
                dgvProveedores.DataSource = negocio.listarProveedores();
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
            Proveedor pmodif = (Proveedor)dgvProveedores.CurrentRow.DataBoundItem;
            frmAltaModifPersona modif = new frmAltaModifPersona(pmodif, 'P');
            modif.ShowDialog();
            cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Proveedor peliminar = (Proveedor)dgvProveedores.CurrentRow.DataBoundItem;
            string Nombre;
            if(peliminar.TipoPersona.Fisica)
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
    }
}
