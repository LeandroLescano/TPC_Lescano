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
    public partial class frmAltaModifMarcaCat : Form
    {
        private Marca marcaLocal = null;
        private Categoria categoriaLocal = null;
        private char Tipo;

        public frmAltaModifMarcaCat(char T)
        {
            InitializeComponent();
            Tipo = T;
        }

        public frmAltaModifMarcaCat(Marca M, char T)
        {
            InitializeComponent();
            marcaLocal = M;
            Tipo = T;
            btnAgregar.Text = "Modificar";
        }

        public frmAltaModifMarcaCat(Categoria C, char T)
        {
            InitializeComponent();
            categoriaLocal = C;
            Tipo = T;
            btnAgregar.Text = "Modificar";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Tipo == 'M')
            {
                MarcaNegocio negocio = new MarcaNegocio();
                if (marcaLocal != null)
                {
                    marcaLocal.Nombre = txtNombre.Text;
                    negocio.modificarMarca(marcaLocal);
                }
                else
                {
                    marcaLocal = new Marca();
                    marcaLocal.Nombre = txtNombre.Text;
                    negocio.agregarMarca(marcaLocal);
                }
            }
            else
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                if (categoriaLocal != null)
                {
                    categoriaLocal.Nombre = txtNombre.Text;
                    negocio.modificarCategoria(categoriaLocal);
                }
                else
                {
                    categoriaLocal = new Categoria();
                    categoriaLocal.Nombre = txtNombre.Text;
                    negocio.agregarCategoria(categoriaLocal);
                }
            }
                this.Close();
        }

        private void frmAltaModifMarcaCat_Load(object sender, EventArgs e)
        {
            if(categoriaLocal != null)
            {
                txtID.Text = categoriaLocal.ID.ToString();
                txtNombre.Text = categoriaLocal.Nombre;
            }
            else if(marcaLocal != null)
            {
                txtID.Text = marcaLocal.ID.ToString();
                txtNombre.Text = marcaLocal.Nombre;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
