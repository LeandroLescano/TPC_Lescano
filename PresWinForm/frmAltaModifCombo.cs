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
    public partial class frmAltaModifCombo : Form
    {
        Combo local = null;
        private List<Producto> listaProd = new List<Producto>();
        private List<Categoria> listaCat;
        public frmAltaModifCombo()
        {
            InitializeComponent();
        }

        public frmAltaModifCombo(Combo cmb)
        {
            InitializeComponent();
            local = cmb;
        }

        private void frmAltaModifCombo_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            cargarComboCategorias();
            cmbCategoria.AutoCompleteMode = AutoCompleteMode.Append;
            cmbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            listaProd = negocio.listarProductos();
            clbProductos.DataSource = listaProd;
            nudPrecio.Controls.RemoveAt(0);
            if(local != null)
            {
                btnAgregar.Text = "Modificar";
                txtID.Text = local.ID.ToString();
                txtRuta.Text = local.RutaImagen;
                picImagen.Image = Image.FromFile(local.RutaImagen);
                txtNombre.Text = local.Nombre;
                txtDescripcion.Text = local.Descripcion;
                txtDiasAnticipo.Text = local.DiasAnticipo.ToString();
                nudPrecio.Value = local.Precio;
                foreach (Producto prod in local.Productos)
                {
                    for (int i = 0; i <= clbProductos.Items.Count - 1; i++)
                    {
                        clbProductos.SetSelected(i, true);
                        if (clbProductos.SelectedItem.ToString() == prod.Nombre)
                            clbProductos.SetItemChecked(i, true);
                    }
                }
            }
            else
            {
                local = new Combo();
                local.Productos = new List<Producto>();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDiasAnticipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = @"C:\";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Selecciona la imagen del combo";
                openFileDialog.ShowDialog();
                txtRuta.Text = openFileDialog.FileName;
                picImagen.Image = Image.FromFile(txtRuta.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ComboNegocio negocio = new ComboNegocio();
                ProductoNegocio negocioProd = new ProductoNegocio();
                llenarCombo();
                if(btnAgregar.Text == "Agregar")
                {
                    local.ID = negocio.agregarCombo(local);
                    foreach (object item in clbProductos.CheckedItems)
                    {
                        negocioProd.agregarProdXCombo(local, (Producto)item);
                    }
                }
                else
                {
                    negocio.modificarCombo(local);
                    negocioProd.eliminarProdXCombo(local.ID);
                    foreach (object item in clbProductos.CheckedItems)
                    {
                        negocioProd.agregarProdXCombo(local, (Producto)item);
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void llenarCombo()
        {
            try
            {
                local.RutaImagen = txtRuta.Text;
                local.Nombre = txtNombre.Text;
                local.Descripcion = txtDescripcion.Text;
                local.DiasAnticipo = Convert.ToInt32(txtDiasAnticipo.Text);
                local.Precio = Decimal.Round(nudPrecio.Value,2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());     
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCategoria.SelectedIndex > 0 && cmbCategoria.SelectedItem != null)
            {
                List<Producto> lista;
                Categoria cat = (Categoria)cmbCategoria.SelectedItem;
                lista = listaProd.FindAll(X => X.Categoria.Nombre == cat.Nombre);
                clbProductos.DataSource = lista;
            }
            else
            {
                clbProductos.DataSource = listaProd;
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void cargarComboCategorias()
        {
            CategoriaNegocio negocioCat = new CategoriaNegocio();
            listaCat = negocioCat.listarCategorias();
            listaCat.Insert(0, new Categoria { Nombre = "Todos", ID = -1 });
            cmbCategoria.DataSource = listaCat;
        }
    }
}
