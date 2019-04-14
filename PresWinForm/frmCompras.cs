using System;
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
    public partial class frmCompras : Form
    {
        public frmCompras()
        {
            InitializeComponent();
        }

        private void frmCompras_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmPrincipal p = new frmPrincipal();
            p.WindowState = FormWindowState.Normal;
            p.Show();
        }
    }
}
