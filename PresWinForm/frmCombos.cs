﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresWinForm
{
    public partial class frmCombos : Form
    {
        public frmCombos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaModifCombo combo = new frmAltaModifCombo();
            combo.ShowDialog();
            //cargarGrilla();
        }
    }
}