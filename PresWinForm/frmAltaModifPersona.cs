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
                lblFechNacimiento.Text = "Fecha de creación:";
                txtRazonSocial.Enabled = true;
                txtRazonSocial.Focus();
            }
        }

        private void rbtParticular_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtParticular.Checked)
            {
                txtApellido.Enabled = true;
                txtNombre.Enabled = true;
                lblFechNacimiento.Text = "Fecha de nacimiento:";
                txtRazonSocial.Enabled = false;
                txtApellido.Focus();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tipo == 'C')
                {
                    AddModif(clienteLocal, Tipo);
                }
                else if (Tipo == 'P')
                {
                    AddModif(proveedorLocal, Tipo);
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
                            dtpFechaNac.Text = clienteLocal.FechaNacimiento.ToString();
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
                        txtCalle.Text = clienteLocal.Domicilio.Calle;
                        if (clienteLocal.Domicilio.Altura != 0)
                            txtAltura.Text = clienteLocal.Domicilio.Altura.ToString();
                        txtEntreCalle1.Text = clienteLocal.Domicilio.EntreCalle1;
                        txtEntreCalle2.Text = clienteLocal.Domicilio.EntreCalle2;
                        if (clienteLocal.Domicilio.Edificio.Piso != 0)
                            txtPiso.Text = clienteLocal.Domicilio.Edificio.Piso.ToString();
                        txtDepto.Text = clienteLocal.Domicilio.Edificio.Departamento;
                        txtLocalidad.Text = clienteLocal.Domicilio.Localidad.Nombre;
                        txtPartido.Text = clienteLocal.Domicilio.Localidad.Partido;
                        txtCPostal.Text = clienteLocal.Domicilio.Localidad.CPostal;
                    }
                    else
                    {
                        clienteLocal = new Cliente();
                        clienteLocal.Usuario = new Usuario();
                        clienteLocal.TipoPersona = new TipoPersona();
                        clienteLocal.Domicilio = new Domicilio();
                        clienteLocal.Domicilio.Localidad = new Localidad();
                        clienteLocal.Domicilio.Edificio = new Edificio();
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
                        if(proveedorLocal.Domicilio.Altura != 0)
                            txtAltura.Text = proveedorLocal.Domicilio.Altura.ToString();
                        txtEntreCalle1.Text = proveedorLocal.Domicilio.EntreCalle1;
                        txtEntreCalle2.Text = proveedorLocal.Domicilio.EntreCalle2;
                        if(proveedorLocal.Domicilio.Edificio.Piso != 0)
                            txtPiso.Text = proveedorLocal.Domicilio.Edificio.Piso.ToString();
                        txtDepto.Text = proveedorLocal.Domicilio.Edificio.Departamento;
                        txtLocalidad.Text = proveedorLocal.Domicilio.Localidad.Nombre;
                        txtPartido.Text = proveedorLocal.Domicilio.Localidad.Partido;
                        txtCPostal.Text = proveedorLocal.Domicilio.Localidad.CPostal;
                    }
                    else
                    {
                        proveedorLocal = new Proveedor();
                        proveedorLocal.TipoPersona = new TipoPersona();
                        proveedorLocal.Domicilio = new Domicilio();
                        proveedorLocal.Domicilio.Localidad = new Localidad();
                        proveedorLocal.Domicilio.Edificio = new Edificio();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool llenarLocal(Persona local)
        {
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
            local.FechaNacimiento = (DateTime)dtpFechaNac.Value;
            if (!llenarDomicilio(local))
            {
                return false;
            }
            if (!llenarEdificio(local))
            {
                return false;
            }
            llenarLocalidad(local);

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

        private bool llenarDomicilio(Persona local)
        {
            if(local.Domicilio == null)
            {
                if (txtCalle.Text.Trim() != "" && txtAltura.Text.Trim() != "")
                {
                    local.Domicilio = new Domicilio();
                    local.Domicilio.Altura = Convert.ToInt32(txtAltura.Text);
                    local.Domicilio.Calle = txtCalle.Text;
                    local.Domicilio.EntreCalle1 = txtEntreCalle1.Text;
                    local.Domicilio.EntreCalle2 = txtEntreCalle2.Text;
                }
                else if ((txtCalle.Text.Trim() == "" && txtAltura.Text.Trim() != "") || (txtCalle.Text.Trim() != "" && txtAltura.Text.Trim() == ""))
                {
                    if (MessageBox.Show("Faltan datos del DOMICILIO para completar.\n\n¿Desea continuar? No se guardará ningún dato del domicilio.", "Atención!", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                    return false;
                    }
                }
            }
            else
            {
                if ((txtCalle.Text.Trim() == "" && txtAltura.Text.Trim() != "") || (txtCalle.Text.Trim() != "" && txtAltura.Text.Trim() == ""))
                {
                    if (MessageBox.Show("Faltan datos del DOMICILIO para completar.\n\n¿Desea continuar? No se guardará ningún dato del domicilio.", "Atención!", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return false;
                    }
                }
                else
                {
                    if(txtAltura.Text != "")
                        local.Domicilio.Altura = Convert.ToInt32(txtAltura.Text);
                    else
                        local.Domicilio.Altura = 0;
                    local.Domicilio.Calle = txtCalle.Text;
                    local.Domicilio.EntreCalle1 = txtEntreCalle1.Text;
                    local.Domicilio.EntreCalle2 = txtEntreCalle2.Text;
                }
            }
            return true;
        }

        private bool llenarEdificio(Persona local)
        {
            if (txtPiso.Text.Trim() != "" && txtDepto.Text.Trim() != "")
            {
                local.Domicilio.Edificio.Piso = Convert.ToInt32(txtPiso.Text);
                local.Domicilio.Edificio.Departamento = txtDepto.Text;
            }
            else if ((txtPiso.Text.Trim() != "" && txtDepto.Text.Trim() == "") || (txtPiso.Text.Trim() == "" && txtDepto.Text.Trim() != ""))
            {
                if (MessageBox.Show("Faltan datos del EDIFICIO para completar.\n\n¿Desea continuar? No se guardará ningún dato del edificio.", "Atención!", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        private bool llenarLocalidad(Persona local)
        {
            if(txtLocalidad.Text.Trim() != "")
            {
                local.Domicilio.Localidad.Nombre = txtLocalidad.Text;
                local.Domicilio.Localidad.Partido = txtPartido.Text;
                local.Domicilio.Localidad.CPostal = txtCPostal.Text;
            }
            else
            {
                local.Domicilio.Localidad.ID = 0;
                local.Domicilio.Localidad.Nombre = txtLocalidad.Text;
                local.Domicilio.Localidad.Partido = txtPartido.Text;
                local.Domicilio.Localidad.CPostal = txtCPostal.Text;
            }
            return true;
        }

        private void AddModif(Persona local, char Tipo)
        {
            ClienteNegocio negocioCli = new ClienteNegocio();
            ProveedorNegocio negocioProv = new ProveedorNegocio();
            LocalidadNegocio negocioLoc = new LocalidadNegocio();
            DomicilioNegocio negocioDoc = new DomicilioNegocio();
            if (btnAgregar.Text == "Agregar")
            {
                if (llenarLocal(local))
                {
                    int idLocalidad = negocioLoc.buscarLocalidad(local.Domicilio.Localidad);
                    if(txtCalle.Text.Trim() != "" && txtAltura.Text.Trim() != "")
                    {
                        if (idLocalidad == -1 && txtLocalidad.Text != "")
                            local.Domicilio.Localidad.ID = negocioLoc.agregarLocalidad(local.Domicilio.Localidad);
                        else
                            local.Domicilio.Localidad.ID = idLocalidad;
                        local.Domicilio.ID = negocioDoc.agregarDomicilio(local.Domicilio);
                    }
                    if (Tipo == 'P')
                        negocioProv.agregarProveedor((Proveedor)local);
                    else
                        negocioCli.agregarCliente((Cliente)local);
                    Close();
                }
            }
            else
            {
                if (llenarLocal(local))
                {
                    if (txtCalle.Text.Trim() != "" && txtAltura.Text.Trim() != "")
                    {
                        int idLocalidad = negocioLoc.buscarLocalidad(local.Domicilio.Localidad);
                        if (local.Domicilio.ID < 1)
                        {
                            if (local.Domicilio.Localidad.ID == 0)
                            {
                                if (idLocalidad == -1 && txtLocalidad.Text != "")
                                    local.Domicilio.Localidad.ID = negocioLoc.agregarLocalidad(local.Domicilio.Localidad);
                                else
                                    local.Domicilio.Localidad.ID = idLocalidad;
                            }
                            local.Domicilio.ID = negocioDoc.agregarDomicilio(local.Domicilio);
                        }
                        else
                        {
                            if (local.Domicilio.Localidad.ID == 0)
                            {
                                if (idLocalidad == -1 && txtLocalidad.Text != "")
                                    local.Domicilio.Localidad.ID = negocioLoc.agregarLocalidad(local.Domicilio.Localidad);
                                else
                                    local.Domicilio.Localidad.ID = idLocalidad;
                            }
                            negocioDoc.modificarDomicilio(local.Domicilio);
                        }
                    }
                    else if (local.Domicilio.Calle == "" || local.Domicilio.Altura == 0)
                    {
                        negocioDoc.eliminarDomicilio(local.Domicilio);
                    }
                    if (Tipo == 'P')
                        negocioProv.modificarProveedor((Proveedor)local);
                    else
                        negocioCli.modificarCliente((Cliente)local);
                    Close();
                }
            }
        }

        private void txtCalle_TextChanged(object sender, EventArgs e)
        {
            if(txtCalle.Text != "" && txtAltura.Text != "")
            {
                txtEntreCalle1.Enabled = true;
                txtEntreCalle2.Enabled = true;
                txtPiso.Enabled = true;
                txtDepto.Enabled = true;
                txtLocalidad.Enabled = true;
                txtPartido.Enabled = true;
                txtCPostal.Enabled = true;
            }
            else
            {
                txtEntreCalle1.Enabled = false;
                txtEntreCalle2.Enabled = false;
                txtPiso.Enabled = false;
                txtDepto.Enabled = false;
                txtLocalidad.Enabled = false;
                txtPartido.Enabled = false;
                txtCPostal.Enabled = false;
            }
        }

        private void txtAltura_TextChanged(object sender, EventArgs e)
        {
            if (txtCalle.Text != "" && txtAltura.Text != "")
            {
                txtEntreCalle1.Enabled = true;
                txtEntreCalle2.Enabled = true;
                txtPiso.Enabled = true;
                txtDepto.Enabled = true;
                txtLocalidad.Enabled = true;
                txtPartido.Enabled = true;
                txtCPostal.Enabled = true;
            }
            else
            {
                txtEntreCalle1.Enabled = false;
                txtEntreCalle2.Enabled = false;
                txtPiso.Enabled = false;
                txtDepto.Enabled = false;
                txtLocalidad.Enabled = false;
                txtPartido.Enabled = false;
                txtCPostal.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
