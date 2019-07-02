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
using negocioCom;

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
                cmbCategoria.SelectedIndex = cmbCategoria.FindString(productoLocal.Categoria.Nombre);
                cmbMarca.SelectedIndex = cmbMarca.FindString(productoLocal.Marca.Nombre);
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
            else
            {
                productoLocal = new Producto();
                productoLocal.Categoria = new Categoria();
                productoLocal.Marca = new Marca();
                productoLocal.Proveedor = new List<Proveedor>();
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
                ProveedorNegocio negocioProv = new ProveedorNegocio();
                if (btnAgregar.Text == "Agregar")
                {
                    llenarLocal(productoLocal);
                    negocio.agregarProducto(productoLocal, catSelec.ID, marcaSelec.ID);
                    int idProd = negocio.idProducto(productoLocal.Nombre);
                    foreach (object item in clbProveedores.CheckedItems)
                    {
                        negocioProv.agregarProvXProductos(idProd, (Proveedor)item);
                    }
                }
                else
                {
                    llenarLocal(productoLocal);
                    negocio.modificarProducto(productoLocal, catSelec.ID, marcaSelec.ID);
                    int idProd = negocio.idProducto(productoLocal.Nombre);
                    negocioProv.eliminarProvXProductos(idProd);
                    foreach (object item in clbProveedores.CheckedItems)
                    {
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
                MessageBox.Show("El producto que desea agregar no posee categoría.", "Atención!", MessageBoxButtons.OK);
                return false;
            }
            if (marcaSelec == null)
            {
                MessageBox.Show("El producto que desea agregar no posee marca.", "Atención!", MessageBoxButtons.OK);
                return false;
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
            List<Proveedor> listadoProv = new List<Proveedor>();
            listadoProv = negocioProv.listarProveedores();
            listadoProv = listadoProv.FindAll(X => X.Estado == true);
            clbProveedores.DataSource = listadoProv;

            CategoriaNegocio negocioCat = new CategoriaNegocio();
            List<Categoria> listadoCat = negocioCat.listarCategorias();
            listadoCat = listadoCat.FindAll(X => X.Estado == true);
            cmbCategoria.DataSource = listadoCat;
            cmbCategoria.AutoCompleteMode = AutoCompleteMode.Append;
            cmbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCategoria.SelectedIndex = -1;
            cmbCategoria.Text = "Elige una opción...";

            MarcaNegocio negocioMarcas = new MarcaNegocio();
            List<Marca> listadoMarcas = negocioMarcas.listarMarcas();
            listadoMarcas = listadoMarcas.FindAll(X => X.Estado == true);
            cmbMarca.DataSource = listadoMarcas;
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
