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
        private Producto productoLocal = null;

        public frmAltaModifProducto()
        {
            InitializeComponent();
        }

        public frmAltaModifProducto(Producto P)
        {
            InitializeComponent();
            productoLocal = P;
        }

        private void frmAltaModifProducto_Load(object sender, EventArgs e)
        {
            if(productoLocal != null)
            {
                btnAgregar.Text = "Modificar";
                txtID.Text = productoLocal.ID.ToString();
                txtNombre.Text = productoLocal.Nombre;
                cmbCategoria.Text = productoLocal.Categoria.Nombre;
                cmbMarca.Text = productoLocal.Marca.Nombre;
                nudPrecioUnit.Text = productoLocal.PrecioUnitario.ToString();
                nudStock.Text = productoLocal.Cantidad.ToString();
            }

            ProveedorNegocio negocioProv = new ProveedorNegocio();
            clbProveedores.DataSource = negocioProv.listarProveedores();

            CategoriaNegocio negocioCat = new CategoriaNegocio();
            cmbCategoria.DataSource = negocioCat.listarCategorias();
            cmbCategoria.AutoCompleteMode = AutoCompleteMode.Append;
            cmbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCategoria.SelectedIndex = -1;
            cmbCategoria.Text = "Elige una opción...";

            MarcaNegocio negocioMarcas = new MarcaNegocio();
            cmbMarca.DataSource = negocioMarcas.listarMarcas();
            cmbMarca.AutoCompleteMode = AutoCompleteMode.Append;
            cmbMarca.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbMarca.SelectedIndex = -1;
            cmbMarca.Text = "Elige una opción...";
        }

        private void btnNuevoProv_Click(object sender, EventArgs e)
        {
            frmAltaModifPersona altaProv = new frmAltaModifPersona('P');
            altaProv.ShowDialog();
        }

        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            frmAltaModifMarcaCat altaMarca = new frmAltaModifMarcaCat('M');
            altaMarca.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria catSelec = (Categoria)cmbCategoria.SelectedItem;
            Marca marcaSelec = (Marca)cmbMarca.SelectedItem;
            if (validaciónCampos(catSelec, marcaSelec))
            {
                ProductoNegocio negocio = new ProductoNegocio();
                if(productoLocal == null)
                {
                    productoLocal = new Producto();
                    productoLocal.Nombre = txtNombre.Text;
                    productoLocal.PrecioUnitario = nudPrecioUnit.Value;
                    productoLocal.Cantidad = (int)nudStock.Value;
                    negocio.agregarProducto(productoLocal, catSelec.ID, marcaSelec.ID);
                }
            }

        }

        private bool validaciónCampos(Categoria catSelec, Marca marcaSelec)
        {
            string Mensaje = "El producto que desea agregar no posee:\n";
            if(txtNombre.Text == "")
            {
                MessageBox.Show("El producto que desea agregar no posee nombre.","Atención!", MessageBoxButtons.OK);
                return false;
            }
            if (catSelec == null)
                Mensaje += "\n-Categoria.";
            if (marcaSelec == null)
                Mensaje += "\n-Marca.";
            if(nudPrecioUnit.Value == 0)
                Mensaje += "\n-Precio unitario.";
            if(nudStock.Value == 0)
                Mensaje += "\n-Stock.";

            bool sinProveedores = true;
            foreach (object item in clbProveedores.CheckedItems)
            {
                sinProveedores = false;
            }
            if (sinProveedores)
                Mensaje += "\n-Proveedor/es.";

            if(MessageBox.Show(Mensaje + "\n\n¿Desea agregarlo de todas formas?", "Atención!",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
