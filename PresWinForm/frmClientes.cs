﻿using System;
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
    public partial class frmClientes : Form
    {
        private List<Cliente> listaCli;

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        { 
            frmAltaModifPersona alta = new frmAltaModifPersona('C');
            alta.ShowDialog();
            cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Cliente cmodif = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            frmAltaModifPersona modif = new frmAltaModifPersona(cmodif, 'C');
            modif.ShowDialog();
            cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                Cliente cmodif = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
                if (MessageBox.Show("Seguro que desea eliminar el cliente " + cmodif.Apellido + ", " + cmodif.Nombre + " con ID: " + cmodif.ID + "?", "Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    negocio.eliminarCliente(cmodif);
                    cargarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarGrilla()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                listaCli = negocio.listarClientes();
                dgvClientes.DataSource = listaCli;
                dgvClientes.Columns["Usuario"].Visible = false;
                dgvClientes.Columns["ID"].DisplayIndex = 0;
                dgvClientes.Columns["Apellido"].DisplayIndex = 1;
                dgvClientes.Columns["Nombre"].DisplayIndex = 2;
                dgvClientes.Columns["RazonSocial"].DisplayIndex = 3;
                dgvClientes.Columns["DNI"].DisplayIndex = 4;
                dgvClientes.Columns["CUIT"].DisplayIndex = 5;
                dgvClientes.Columns["FechaNacimiento"].DisplayIndex = 6;
                dgvClientes.Columns["TipoPersona"].DisplayIndex = 7;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                dgvClientes.DataSource = listaCli;
            }
            else
            {
                if (txtBusqueda.Text.Length >= 1)
                {
                    List<Cliente> lista;
                    lista = listaCli.FindAll(X => X.Nombre != null && X.Nombre.ToUpper().Contains(txtBusqueda.Text.ToUpper()) ||
                                              X.Apellido != null && X.Apellido.ToUpper().Contains(txtBusqueda.Text.ToUpper()) ||
                                              X.RazonSocial != null && X.RazonSocial.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
                    dgvClientes.DataSource = lista;
                }
            }
        }
    }
}
