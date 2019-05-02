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
            cmbCategoria.Text = "Elige una opción...";

            MarcaNegocio negocioMarcas = new MarcaNegocio();
            cmbMarca.DataSource = negocioMarcas.listarMarcas();
            cmbMarca.AutoCompleteMode = AutoCompleteMode.Append;
            cmbMarca.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbMarca.Text = "Elige una opción...";
        }

        private void btnNuevoProv_Click(object sender, EventArgs e)
        {
            frmAltaModifPersona altaProv = new frmAltaModifPersona('P');
            altaProv.Show();
        }
    }
}
