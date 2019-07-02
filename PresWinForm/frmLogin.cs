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
    public partial class frmLogin : Form
    {
        public Usuario local = new Usuario();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text != "" && txtContraseña.Text != "")
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                local.Nombre = txtUsuario.Text;
                local.Contraseña = txtContraseña.Text;
                if(negocio.verificarUsuario(local))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos, vuelva a intentarlo.", "Cuidado!");
                }
            }
            else
            {
                MessageBox.Show("Por favor complete ambos campos.", "Cuidado!");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
