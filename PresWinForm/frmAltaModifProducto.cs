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
    public partial class frmAltaModifProducto : Form
    {
        public frmAltaModifProducto()
        {
            InitializeComponent();
            ProveedorNegocio nombresProv = new ProveedorNegocio();
            clbProveedores.DataSource = nombresProv.listarNombresProv();
            MarcaNegocio nombresMarcas = new MarcaNegocio();
            cmbMarca.DataSource = nombresMarcas.listarNombresMarcas();
        }
    }
}
