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
    public partial class frmCantidadesProductos : Form
    {
        private List<DetalleCombo> listaLocal;
        int index = 0;

        public frmCantidadesProductos(List<DetalleCombo> lista)
        {
            InitializeComponent();
            listaLocal = lista;
        }

        private void frmCantidadesProductos_Load(object sender, EventArgs e)
        {
            //txtNombre.Enabled = false;
            //llenarCampos();
            //dgvProductos.Columns["Unidades"].DisplayIndex = 1;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            //    listaLocal[index].Unidades = Convert.ToInt32(nudUnidades.Value);
            //    listaLocal[index].Kilos = nudKilos.Value;
            //    if (index+1 < listaLocal.Count)
            //    {
            //        index++;
            //    }
            //    else
            //    {
            //        index = 0;
            //    }
            //    llenarCampos();
        }

    private void llenarCampos()
        {
            //    dgvProductos.DataSource = listaLocal;
            //    dgvProductos.Refresh();
            //    txtNombre.Text = listaLocal[index].Producto.Nombre;
            //    nudUnidades.Value = listaLocal[index].Unidades;
            //    if(listaLocal[index].Producto.Fraccionable)
            //    {
            //        nudKilos.Enabled = true;
            //        nudKilos.Value = listaLocal[index].Kilos;
            //    }
            //    else
            //    {
            //        nudKilos.Enabled = false;
            //        nudKilos.Value = 0;
            //    }
            //    dgvProductos.Rows[index].Selected = true;
        }

    private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //listaLocal[index].Unidades = Convert.ToInt32(nudUnidades.Value);
            //listaLocal[index].Kilos = nudKilos.Value;
            //index = dgvProductos.CurrentRow.Index;
            //llenarCampos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
