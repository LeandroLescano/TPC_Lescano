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
    
        public frmAltaModifPersona( char T)
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

                    if(clienteLocal.ID != 0)
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
                    ProveedorNegocio negocioProv = new ProveedorNegocio();
                    LocalidadNegocio negocioLoc = new LocalidadNegocio();
                    DomicilioNegocio negocioDoc = new DomicilioNegocio();
                    if (btnAgregar.Text == "Agregar")
                    {
                        proveedorLocal = new Proveedor();
                        if(llenarProvLocal(proveedorLocal))
                        {
                            negocioLoc.agregarLocalidad(proveedorLocal.Domicilio.Localidad);
                            negocioDoc.agregarDomicilio(proveedorLocal.Domicilio);
                            negocioProv.agregarProveedor(proveedorLocal, negocioDoc.idDomicilio(proveedorLocal.Domicilio));
                            Close();
                        }
                    }
                    else
                    {
                        if(llenarProvLocal(proveedorLocal))
                        {
                            if(proveedorLocal.Domicilio.ID < 1)
                            {
                                negocioDoc.agregarDomicilio(proveedorLocal.Domicilio);
                            }
                            else
                            {
                                negocioDoc.modificarDomicilio(proveedorLocal.Domicilio);
                            }
                            negocioProv.modificarProveedor(proveedorLocal, negocioDoc.idDomicilio(proveedorLocal.Domicilio));
                            Close();
                        }
                    }
                }
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
                        btnAgregar.Text = "Modificar";
                        if(clienteLocal.TipoPersona.Fisica)
                        {
                            rbtParticular.Checked = true;
                        }
                        else
                        {
                            rbtEmpresa.Checked = true;
                        }
                        txtID.Text = clienteLocal.ID.ToString();
                        txtNombre.Text = clienteLocal.Nombre;
                        txtApellido.Text = clienteLocal.Apellido;
                        txtRazonSocial.Text = clienteLocal.RazonSocial;
                        txtDNI.Text = clienteLocal.DNI;
                        txtCUIT.Text = clienteLocal.CUIT;
                        dtpFechaNac.Text = clienteLocal.FechaNacimiento.ToString();
                        txtCalle.Text = clienteLocal.Domicilio.Calle;
                        txtAltura.Text = clienteLocal.Domicilio.Altura.ToString();
                        txtLocalidad.Text = clienteLocal.Domicilio.Localidad.Nombre;
                    }
                }
                else if (Tipo == 'P')
                {
                    if (proveedorLocal != null)
                    {
                        btnAgregar.Text = "Modificar";
                        if (proveedorLocal.TipoPersona.Fisica)
                        {
                            rbtParticular.Checked = true;
                        }
                        else
                        {
                            rbtEmpresa.Checked = true;
                        }
                        txtID.Text = proveedorLocal.ID.ToString();
                        txtNombre.Text = proveedorLocal.Nombre;
                        txtApellido.Text = proveedorLocal.Apellido;
                        txtRazonSocial.Text = proveedorLocal.RazonSocial;
                        txtDNI.Text = proveedorLocal.DNI;
                        txtCUIT.Text = proveedorLocal.CUIT;
                        txtCalle.Text = proveedorLocal.Domicilio.Calle;
                        txtAltura.Text = proveedorLocal.Domicilio.Altura.ToString();
                        txtEntreCalle1.Text = proveedorLocal.Domicilio.EntreCalle1;
                        txtEntreCalle2.Text = proveedorLocal.Domicilio.EntreCalle2;
                        txtPiso.Text = proveedorLocal.Domicilio.Edificio.Piso.ToString();
                        txtDepto.Text = proveedorLocal.Domicilio.Edificio.Departamento;
                        txtLocalidad.Text = proveedorLocal.Domicilio.Localidad.Nombre;
                        txtPartido.Text = proveedorLocal.Domicilio.Localidad.Partido;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool llenarProvLocal(Proveedor local)
        {
            local.TipoPersona = new TipoPersona();
            if (rbtParticular.Checked)
            {
               local.Apellido = txtApellido.Text;
               local.Nombre = txtNombre.Text;
               local.TipoPersona.Fisica = true;
            }  
            else
            {  
               local.RazonSocial = txtRazonSocial.Text;
               local.TipoPersona.Juridica = true;
            }
            local.DNI = txtDNI.Text;
            local.CUIT = txtCUIT.Text;
            int idDomicilio = local.Domicilio.ID;
            if(txtCalle.Text.Trim() != "" && txtAltura.Text.Trim() != "")
            {
                local.Domicilio = new Domicilio();
                local.Domicilio.ID = idDomicilio;
                local.Domicilio.Altura = Convert.ToInt32(txtAltura.Text);
                local.Domicilio.Calle = txtCalle.Text;
                local.Domicilio.EntreCalle1 = txtEntreCalle1.Text;
                local.Domicilio.EntreCalle2 = txtEntreCalle2.Text;
            }
            else if((txtCalle.Text.Trim() == "" && txtAltura.Text.Trim() != "") || (txtCalle.Text.Trim() != "" && txtAltura.Text.Trim() == ""))
            {
                if(MessageBox.Show("Faltan datos del DOMICILIO para completar.\n\n¿Desea regresar para completarlos?\nDe lo contrario no se guardará ningún dato del domicilio.", "Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    return false;
                }
            }

            if(txtPiso.Text.Trim() !=  "" && txtDepto.Text.Trim() != "")
            {
                local.Domicilio.Edificio = new Edificio();
                local.Domicilio.Edificio.Piso = Convert.ToInt32(txtPiso.Text);
                local.Domicilio.Edificio.Departamento = txtDepto.Text;
            }
            else if ((txtPiso.Text.Trim() != "" && txtDepto.Text.Trim() == "") || (txtPiso.Text.Trim() == "" && txtDepto.Text.Trim() != ""))
            {
                if(MessageBox.Show("Faltan datos del EDIFICIO para completar.\n\n¿Desea regresar para completarlos?\nDe lo contrario no se guardará ningún dato del edificio.", "Atención!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    return false;
                }
            }

            local.Domicilio.Localidad = new Localidad();
            local.Domicilio.Localidad.Nombre = txtLocalidad.Text;
            local.Domicilio.Localidad.Partido = txtPartido.Text;
            local.Domicilio.Localidad.CPostal = txtCPostal.Text;

            //local.Telefonos = new List<Telefono>();
            //for (int i = 0; i < 2; i++)
            //{
            //    Telefono tel = new Telefono();
            //    tel.Numero = item.
            //    Telefonos.Add();
            //}
            //tel.Descripcion = txtApellido.Text + ", " + txtNombre.Text;
            //tel.Numero = txtTelCelular.Text;
            //proveedorLocal.Telefonos.Add(tel);

            local.Mails = new List<Mail>();
            Mail mail = new Mail();
            mail.Descripcion = txtApellido.Text + ", " + txtNombre.Text;
            mail.Direccion = txtMail.Text;
            local.Mails.Add(mail);
            return true;
        }
    }
}
