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
    public partial class frmProductos : Form
    {
        private List<Producto> listaProd;

        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaModifProducto altaProd = new frmAltaModifProducto();
            altaProd.ShowDialog();
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                listaProd = negocio.listarProductos();
                if (chbEstado.Checked == false)
                {
                    listaProd = listaProd.FindAll(X => X.Estado == true);
                }
                dgvProductos.DataSource = listaProd;
                dgvProductos.Columns["Nombre"].DisplayIndex = 1;
                dgvProductos.Columns["Estado"].Visible = false;
                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    Producto prod = (Producto)row.DataBoundItem;
                    if (prod.Estado == false)
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

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            frmMarcas marcas = new frmMarcas();
            marcas.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias categorias = new frmCategorias();
            categorias.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                Producto pmodif = (Producto)dgvProductos.CurrentRow.DataBoundItem;
                frmAltaModifProducto modif = new frmAltaModifProducto(pmodif);
                modif.ShowDialog();
                cargarGrilla();
            }
            else
            {
                MessageBox.Show("No hay ningún producto seleccionado", "Cuidado!");
            }
        }

        private void btnVerProveedores_Click(object sender, EventArgs e)
        {
            frmProveedoresXProducto provXProd = new frmProveedoresXProducto((Producto)dgvProductos.CurrentRow.DataBoundItem);
            provXProd.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                Producto peliminar = (Producto)dgvProductos.CurrentRow.DataBoundItem;
                if (MessageBox.Show("Está a punto de eliminar el producto: " + peliminar.Nombre + ".\n\n¿Desea eliminarlo?", "Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    negocio.eliminarProducto(peliminar);
                    cargarGrilla();
                }
            }
            else
            {
                MessageBox.Show("No hay ningún producto seleccionado", "Cuidado!");
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                dgvProductos.DataSource = listaProd;
            }
            else
            {
                if (txtBusqueda.Text.Length >= 1)
                {
                    List<Producto> lista;
                    lista = listaProd.FindAll(X => X.Nombre.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
                    dgvProductos.DataSource = lista;
                }
            }
        }

        private void chbEstado_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            Producto prod = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            negocio.habilitarProducto(prod);
            cargarGrilla();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            Producto prod = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            if (prod.Estado == false)
            {
                btnHabilitar.Enabled = true;
            }
            else
            {
                btnHabilitar.Enabled = false;
            }
        }

        private void dgvProductos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentRow = dgvProductos.HitTest(e.X, e.Y).RowIndex;
                int currentColumn = dgvProductos.HitTest(e.X, e.Y).ColumnIndex;

                if (currentRow >= 0)
                {
                    dgvProductos[currentColumn, currentRow].Selected = true;
                    Producto pSelect = (Producto)dgvProductos.CurrentRow.DataBoundItem;

                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("Modificar", btnModificar_Click));
                    m.MenuItems.Add(new MenuItem("Ver proveedores", btnVerProveedores_Click));
                    if (pSelect.Estado == true)
                    {
                        m.MenuItems.Add(new MenuItem("Eliminar", btnEliminar_Click));
                    }
                    else
                    {
                        m.MenuItems.Add(new MenuItem("Habilitar", btnHabilitar_Click));
                    }

                    m.Show(dgvProductos, new Point(e.X, e.Y));
                }
            }
        }
    }
}
