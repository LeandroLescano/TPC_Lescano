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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void tspCompras_Click(object sender, EventArgs e)
        {
            frmCompras Compras = new frmCompras();
            Compras.Show();
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
