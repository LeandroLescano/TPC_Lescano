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
            cargarListas();
            if (productoLocal != null)
            {
                btnAgregar.Text = "Modificar";
                txtID.Text = productoLocal.ID.ToString();
                txtNombre.Text = productoLocal.Nombre;
                cmbCategoria.Text = productoLocal.Categoria.Nombre;
                cmbMarca.Text = productoLocal.Marca.Nombre;
                nudPeso.Value = productoLocal.Peso;
                nudPorcentajeGanancia.Value = productoLocal.PorcentajeGanancia;
                nudPrecioUnit.Value = productoLocal.PrecioUnitario;
                nudStock.Value = productoLocal.Cantidad;
                if (productoLocal.Fraccionable)
                {
                    chbFraccionable.Checked = true;
                }
                else
                {
                    chbFraccionable.Checked = false;
                }
                foreach (Proveedor prov in productoLocal.Proveedor)
                {
                    for (int i = 0; i <= clbProveedores.Items.Count - 1; i++)
                    {
                        clbProveedores.SetSelected(i, true);
                        if (clbProveedores.SelectedItem.ToString() == prov.RazonSocial)
                            clbProveedores.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void btnNuevoProv_Click(object sender, EventArgs e)
        {
            frmAltaModifPersona altaProv = new frmAltaModifPersona('P');
            altaProv.ShowDialog();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria catSelec = (Categoria)cmbCategoria.SelectedItem;
            Marca marcaSelec = (Marca)cmbMarca.SelectedItem;
            if (validaciónCampos(catSelec, marcaSelec))
            {
                ProductoNegocio negocio = new ProductoNegocio();
                if (productoLocal == null)
                {
                    productoLocal = new Producto();
                    llenarLocal(productoLocal);
                    negocio.agregarProducto(productoLocal, catSelec.ID, marcaSelec.ID);
                    int idProd = negocio.idProducto(productoLocal.Nombre);
                    foreach (object item in clbProveedores.CheckedItems)
                    {
                        ProveedorNegocio negocioProv = new ProveedorNegocio();
                        negocioProv.agregarProvXProductos(idProd, (Proveedor)item);
                    }
                }
                else
                {
                    llenarLocal(productoLocal);
                    negocio.modificarProducto(productoLocal, catSelec.ID, marcaSelec.ID);
                    int idProd = negocio.idProducto(productoLocal.Nombre);
                    ProveedorNegocio negocioEliminar = new ProveedorNegocio();
                    negocioEliminar.eliminarProvXProductos(idProd);
                    foreach (object item in clbProveedores.CheckedItems)
                    {
                        ProveedorNegocio negocioProv = new ProveedorNegocio();
                        negocioProv.agregarProvXProductos(idProd, (Proveedor)item);
                    }
                }
                this.Close();
            }
        }

        private void llenarLocal(Producto productoLocal)
        {
            productoLocal.Nombre = txtNombre.Text;
            productoLocal.PrecioUnitario = nudPrecioUnit.Value;
            productoLocal.Cantidad = (int)nudStock.Value;
            if (chbFraccionable.Checked == true)
            {
                productoLocal.Fraccionable = true;
            }
            else
            {
                productoLocal.Fraccionable = false;
            }
            productoLocal.Peso = nudPeso.Value;
            productoLocal.PorcentajeGanancia = nudPorcentajeGanancia.Value;
        }

        private bool validaciónCampos(Categoria catSelec, Marca marcaSelec)
        {
            bool faltanDatos = false;
            string Mensaje = "El producto que desea agregar no posee:\n";
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El producto que desea agregar no posee nombre.", "Atención!", MessageBoxButtons.OK);
                return false;
            }
            if (catSelec == null)
            {
                Mensaje += "\n-Categoria.";
                faltanDatos = true;
            }
            if (marcaSelec == null)
            {
                Mensaje += "\n-Marca.";
                faltanDatos = true;
            }
            if (nudPrecioUnit.Value == 0)
            {
                Mensaje += "\n-Precio unitario.";
                faltanDatos = true;
            }
            if (nudStock.Value == 0)
            {
                Mensaje += "\n-Stock.";
                faltanDatos = true;
            }

            bool sinProveedores = true;
            foreach (object item in clbProveedores.CheckedItems)
            {
                sinProveedores = false;
            }
            if (sinProveedores)
            {
                Mensaje += "\n-Proveedor/es.";
                faltanDatos = true;
            }

            if (faltanDatos)
            {
                if (MessageBox.Show(Mensaje + "\n\n¿Desea agregarlo de todas formas?", "Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarListas()
        {
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

        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            frmAltaModifMarcaCat altaCategoria = new frmAltaModifMarcaCat('C');
            altaCategoria.ShowDialog();
            CategoriaNegocio negocioCat = new CategoriaNegocio();
            cmbCategoria.DataSource = negocioCat.listarCategorias();
            cmbCategoria.SelectedIndex = cmbCategoria.Items.Count - 1;
        }

        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            frmAltaModifMarcaCat altaMarca = new frmAltaModifMarcaCat('M');
            altaMarca.ShowDialog();
            MarcaNegocio negocioMarcas = new MarcaNegocio();
            cmbMarca.DataSource = negocioMarcas.listarMarcas();
            cmbMarca.SelectedIndex = cmbCategoria.Items.Count - 1;
        }
    }
}
