using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Negocio;
using Dominio;

namespace PresWinForm
{
    public partial class frmAltaModifCombo : Form
    {
        Combo local = null;
        List<Producto> seleccionados = new List<Producto>();
        private List<Producto> listaProd = new List<Producto>();
        private List<Categoria> listaCat;

        public frmAltaModifCombo()
        {
            InitializeComponent();
        }

        public frmAltaModifCombo(Combo cmb, bool Ver)
        {
            InitializeComponent();
            local = cmb;
            if (Ver)
            {
                btnAgregar.Enabled = false;
                btnBuscar.Enabled = false;
                txtID.Enabled = false;
                txtRuta.Enabled = false;
                txtNombre.Enabled = false;
                txtDescripcion.Enabled = false;
                txtDiasAnticipo.Enabled = false;
                nudPrecio.Enabled = false;
                clbProductos.Enabled = false;
            }
        }

        private void frmAltaModifCombo_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            cargarComboCategorias();
            cmbCategoria.AutoCompleteMode = AutoCompleteMode.Append;
            cmbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            listaProd = negocio.listarProductos();
            listaProd = listaProd.FindAll(X => X.Estado == true);
            clbProductos.DataSource = listaProd;
            nudPrecio.Controls.RemoveAt(0);
            if (local != null)
            {
                btnAgregar.Text = "Modificar";
                txtID.Text = local.ID.ToString();
                txtRuta.Text = local.RutaImagen;
                if (local.RutaImagen != null)
                    picImagen.Image = Image.FromFile(local.RutaImagen);
                txtNombre.Text = local.Nombre;
                txtDescripcion.Text = local.Descripcion;
                txtDiasAnticipo.Text = local.DiasAnticipo.ToString();
                nudPrecio.Value = local.Precio;
                foreach (DetalleCombo prod in local.Productos)
                {
                    for (int i = 0; i <= clbProductos.Items.Count - 1; i++)
                    {
                        clbProductos.SetSelected(i, true);
                        if (clbProductos.SelectedItem.ToString() == prod.Producto.Nombre)
                        {
                            clbProductos.SetItemChecked(i, true);
                            seleccionados.Add(prod.Producto);
                        }

                    }
                }
                calcularCosto();
            }
            else
            {
                local = new Combo();
                local.Productos = new List<DetalleCombo>();
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
                if (openFileDialog.FileName != "")
                {
                    txtRuta.Text = openFileDialog.FileName;
                    picImagen.Image = Image.FromFile(txtRuta.Text);
                }
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
                if (btnAgregar.Text == "Agregar")
                {
                    local.ID = negocio.agregarCombo(local);
                    foreach (DetalleCombo item in local.Productos)
                    {
                        negocioProd.agregarProdXCombo(local, item);
                    }
                }
                else
                {
                    negocio.modificarCombo(local);
                    negocioProd.eliminarProdXCombo(local.ID);
                    foreach (DetalleCombo item in local.Productos)
                    {
                        negocioProd.agregarProdXCombo(local, item);
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
                if (txtRuta.Text != "")
                {
                    local.RutaImagen = txtRuta.Text;
                }
                local.Nombre = txtNombre.Text;
                local.Descripcion = txtDescripcion.Text;
                if (txtDiasAnticipo.Text != "")
                {
                    local.DiasAnticipo = Convert.ToInt32(txtDiasAnticipo.Text);
                }
                else
                {
                    local.DiasAnticipo = 0;
                }
                local.Precio = Decimal.Round(nudPrecio.Value, 2);
                local.Productos.Clear();
                foreach (Producto item in clbProductos.CheckedItems)
                {
                    DetalleCombo prod = new DetalleCombo();
                    prod.Producto = item;
                    prod.Unidades = 1;
                    local.Productos.Add(prod);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnAgregar.Text == "Modificar")
            {
                filtrarLista();
                foreach (DetalleCombo prod in local.Productos)
                {
                    for (int i = 0; i <= clbProductos.Items.Count - 1; i++)
                    {
                        clbProductos.SetSelected(i, true);
                        if (clbProductos.SelectedItem.ToString() == prod.Producto.Nombre)
                        {
                            clbProductos.SetItemChecked(i, true);
                        }
                    }
                }
            }
            else
            {
                filtrarLista();
                foreach (Producto prod in seleccionados)
                {
                    for (int i = 0; i <= clbProductos.Items.Count - 1; i++)
                    {
                        clbProductos.SetSelected(i, true);
                        if (clbProductos.SelectedItem.ToString() == prod.Nombre)
                        {
                            clbProductos.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != "")
            {
                List<Producto> lista;
                lista = listaProd.FindAll(X => X.Nombre.ToUpper().Contains(txtBusqueda.Text.ToUpper()));
                clbProductos.DataSource = lista;
            }
            else
            {
                clbProductos.DataSource = listaProd;
            }

            for (int i = 0; i <= clbProductos.Items.Count - 1; i++)
            {
                clbProductos.SetSelected(i, true);
                clbProductos.SetItemChecked(i, false);

            }

            foreach (Producto prod in seleccionados)
            {
                for (int i = 0; i <= clbProductos.Items.Count - 1; i++)
                {
                    clbProductos.SetSelected(i, true);
                    if (clbProductos.SelectedItem.ToString() == prod.Nombre)
                    {
                        clbProductos.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void cargarComboCategorias()
        {
            CategoriaNegocio negocioCat = new CategoriaNegocio();
            listaCat = negocioCat.listarCategorias();
            listaCat.Insert(0, new Categoria { Nombre = "Todos", ID = -1 });
            cmbCategoria.DataSource = listaCat;
        }

        private void filtrarLista()
        {
            if (cmbCategoria.SelectedIndex > 0 && cmbCategoria.SelectedItem != null)
            {
                List<Producto> lista;
                Categoria cat = (Categoria)cmbCategoria.SelectedItem;
                lista = listaProd;
                lista = listaProd.FindAll(X => X.Categoria.Nombre == cat.Nombre);
                clbProductos.DataSource = lista;
            }
            else
            {
                clbProductos.DataSource = listaProd;
            }
        }

        private void clbProductos_Click(object sender, EventArgs e)
        {
            Producto seleccionado = (Producto)clbProductos.SelectedItem;
            int index = clbProductos.SelectedIndex;
            //Van al reves ya que apenas hace click el check del item no cambia de estado.
            //clbProductos_ItemChek no me sirve en este caso ya que cuando se refresca la grilla
            //les hago check con una función y me activa ese método
            if (clbProductos.GetItemCheckState(index) == CheckState.Checked && seleccionados.Count >= 0)
            {
                foreach (var item in seleccionados)
                {
                    if(item.Nombre == seleccionado.Nombre)
                    {
                        seleccionados.RemoveAt(seleccionados.IndexOf(item));
                        return;
                    }
                }
                seleccionados.RemoveAt(seleccionados.IndexOf(seleccionado));
            }
            else
            {
                seleccionados.Add(seleccionado);
            }
        }

        private void btnCantidades_Click(object sender, EventArgs e)
        {
            if (clbProductos.CheckedItems.Count > 0)
            {
                llenarCombo();
                frmCantidadesProductos cantidades = new frmCantidadesProductos(local.Productos);
                cantidades.ShowDialog();
                calcularCosto();
            }
            else
            {
                MessageBox.Show("No hay productos seleccionados.", "Atención!");
            }
        }

        private void calcularCosto()
        {
            decimal Costo = 0;
            foreach (DetalleCombo item in local.Productos)
            {
                Costo += item.Producto.PrecioUnitario * item.Unidades;
            }
            lblCosto.Text = "Costo: $" + Math.Round(Costo, 2).ToString();
        }
    }
}
