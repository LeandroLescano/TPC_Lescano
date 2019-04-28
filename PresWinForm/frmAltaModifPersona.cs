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
    public partial class frmAltaModifPersona : Form
    {
        private Cliente clienteLocal = null;
        private Proveedor proveedorLocal = null;
        private char Tipo;

        public frmAltaModifPersona(char T)
        {
            InitializeComponent();
            Tipo = T;
        }

        public frmAltaModifPersona(Cliente cliente, char T)
        {
            InitializeComponent();
            clienteLocal = cliente;
            Tipo = T;
        }

        public frmAltaModifPersona(Proveedor prov, char T)
        {
            InitializeComponent();
            proveedorLocal = prov;
            Tipo = T;
        }

        private void rbtEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtEmpresa.Checked)
            {
                txtApellido.Enabled = false;
                txtNombre.Enabled = false;
                dtpFechaNac.Enabled = false;
                txtRazonSocial.Enabled = true;
            }
        }

        private void rbtParticular_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtParticular.Checked)
            {
                txtApellido.Enabled = true;
                txtNombre.Enabled = true;
                dtpFechaNac.Enabled = true;
                txtRazonSocial.Enabled = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            ProveedorNegocio provNegocio = new ProveedorNegocio();
            try
            {
                if (Tipo == 'C')
                {
                    if (clienteLocal == null)
                        clienteLocal = new Cliente();
                    if(rbtParticular.Checked)
                    {
                        clienteLocal.Apellido = txtApellido.Text;
                        clienteLocal.Nombre = txtNombre.Text;
                        clienteLocal.TipoPersona = new TipoPersona();
                        clienteLocal.TipoPersona.Fisica = true;
                    }
                    else
                    {
                        clienteLocal.RazonSocial = txtRazonSocial.Text;
                        clienteLocal.TipoPersona = new TipoPersona();
                        clienteLocal.TipoPersona.Juridica = true;
                    }
                    clienteLocal.DNI = txtDNI.Text;
                    clienteLocal.CUIT = txtCUIT.Text;
                    clienteLocal.FechaNacimiento = (DateTime)dtpFechaNac.Value;
                    //clienteLocal.Domicilio
                    //Telefono tel = new Telefono();
                    //tel.Descripcion = txtApellido.Text + ", " + txtNombre.Text;
                    //tel.Numero = txtTelCelular.Text;
                    //clienteLocal.Telefonos.Add(tel);
                    //Mail mail = new Mail();
                    //mail.Descripcion = txtApellido.Text + ", " + txtNombre.Text;
                    //mail.Direccion = txtMail.Text;
                    //clienteLocal.Mails.Add(mail);
                    //clienteLocal.Usuario.Nombre = txtNombreU.Text;
                    //clienteLocal.Usuario.Contraseña = txtContraseña.Text;

                    if(clienteLocal.Codigo != 0)
                    {
                        //clienteNegocio.modificarCliente(clienteLocal);
                    }
                    else
                    {
                        clienteNegocio.agregarCliente(clienteLocal);
                    }

                }
                else if (Tipo == 'P')
                {
                    if (proveedorLocal == null)
                        proveedorLocal = new Proveedor();

                    if (rbtParticular.Checked)
                    {
                        proveedorLocal.Apellido = txtApellido.Text;
                        proveedorLocal.Nombre = txtNombre.Text;
                        proveedorLocal.TipoPersona = new TipoPersona();
                        proveedorLocal.TipoPersona.Fisica = true;
                    }
                    else
                    {
                        proveedorLocal.RazonSocial = txtRazonSocial.Text;
                        proveedorLocal.TipoPersona = new TipoPersona();
                        proveedorLocal.TipoPersona.Juridica = true;
                    }
                    proveedorLocal.DNI = txtDNI.Text;
                    proveedorLocal.CUIT = txtCUIT.Text;
                    //proveedorLocal.Domicilio
                    //Telefono tel = new Telefono();
                    //tel.Descripcion = txtApellido.Text + ", " + txtNombre.Text;
                    //tel.Numero = txtTelCelular.Text;
                    //proveedorLocal.Telefonos.Add(tel);
                    //Mail mail = new Mail();
                    //mail.Descripcion = txtApellido.Text + ", " + txtNombre.Text;
                    //mail.Direccion = txtMail.Text;
                    //proveedorLocal.Mails.Add(mail);
                    //proveedorLocal.Usuario.Nombre = txtNombreU.Text;
                    //proveedorLocal.Usuario.Contraseña = txtContraseña.Text;

                    if (proveedorLocal.Codigo != 0)
                    {
                        //proveedorNegocio.modificarProveedor(proveedorLocal);
                    }
                    else
                    {
                        //proveedorNegocio.agregarProveedor(proveedorLocal);
                    }
                }

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaModifPersona_Load(object sender, EventArgs e)
        {
            txtRazonSocial.Enabled = false;
            try
            {
                if(Tipo == 'C')
                {
                    if(clienteLocal != null)
                    {
                        txtCodigo.Text = clienteLocal.Codigo.ToString();
                        txtNombre.Text = clienteLocal.Nombre;
                        txtApellido.Text = clienteLocal.Apellido;
                        txtRazonSocial.Text = clienteLocal.RazonSocial;
                        txtDNI.Text = clienteLocal.DNI;
                        txtCUIT.Text = clienteLocal.CUIT;
                        dtpFechaNac.Text = clienteLocal.FechaNacimiento.ToString();
                        if(clienteLocal.TipoPersona.Fisica)
                        {
                            rbtParticular.Checked = true;
                        }
                    }
                }
                else if (Tipo == 'P')
                {
                    if (proveedorLocal != null)
                    {
                        txtCodigo.Text = proveedorLocal.Codigo.ToString();
                        txtNombre.Text = proveedorLocal.Nombre;
                        txtApellido.Text = proveedorLocal.Apellido;
                        txtRazonSocial.Text = proveedorLocal.RazonSocial;
                        txtDNI.Text = proveedorLocal.DNI;
                        txtCUIT.Text = proveedorLocal.CUIT;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
