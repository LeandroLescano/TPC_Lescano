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
    public partial class frmCombos : Form
    {
        private List<Combo> listaCombo;
        private ComboNegocio negocio = new ComboNegocio();

        public frmCombos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaModifCombo combo = new frmAltaModifCombo();
            combo.ShowDialog();
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            try
            {
                listaCombo = negocio.listarCombos();
                if (chbEstado.Checked == false)
                {
                    listaCombo = listaCombo.FindAll(X => X.Estado == true);
                }
                dgvCombos.DataSource = listaCombo;
                dgvCombos.Columns["Estado"].Visible = false;
                dgvCombos.Columns["RutaImagen"].Visible = false;
                dgvCombos.ClearSelection();
                foreach (DataGridViewRow row in dgvCombos.Rows)
                {
                    Combo cmb = (Combo)row.DataBoundItem;
                    if (cmb.Estado == false)
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

        private void chbEstado_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                dgvCombos.DataSource = listaCombo;
            }
            else
            {
                if (txtBusqueda.Text.Length >= 1)
                {
                    List<Combo> lista;
                    lista = listaCombo.FindAll(X => X.Nombre.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
                    dgvCombos.DataSource = lista;
                }
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            Combo cmb = (Combo)dgvCombos.CurrentRow.DataBoundItem;
            negocio.habilitarCombo(cmb);
            cargarGrilla();
        }

        private void dgvCombos_SelectionChanged(object sender, EventArgs e)
        {
            Combo cmb = (Combo)dgvCombos.CurrentRow.DataBoundItem;
            if (cmb.Estado == false)
            {
                btnHabilitar.Enabled = true;
            }
            else
            {
                btnHabilitar.Enabled = false;
            }
        }

        private void frmCombos_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Combo cModif = (Combo)dgvCombos.CurrentRow.DataBoundItem;
            frmAltaModifCombo modif = new frmAltaModifCombo(cModif);
            modif.ShowDialog();
            cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Combo cEliminar = (Combo)dgvCombos.CurrentRow.DataBoundItem;
            if (MessageBox.Show("Está a punto de eliminar el combo: " + cEliminar.Nombre + ".\n\n¿Desea eliminarlo?", "Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                negocio.eliminarCombo(cEliminar);
                cargarGrilla();
            }
        }
    }
}
