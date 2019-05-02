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

namespace PresWinForm
{
    public partial class frmAltaModifMarcaCat : Form
    {
        private Marca marcaLocal = null;
        private Categoria categoriaLocal = null;

        public frmAltaModifMarcaCat()
        {
            InitializeComponent();
        }

        public frmAltaModifMarcaCat(Marca M)
        {
            InitializeComponent();
            marcaLocal = M;
        }

        public frmAltaModifMarcaCat(Categoria C)
        {
            InitializeComponent();
            categoriaLocal = C;
        }
    }
}
