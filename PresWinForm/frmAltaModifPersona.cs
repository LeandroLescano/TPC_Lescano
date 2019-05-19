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
        private MailNegocio negocioMail = new MailNegocio();
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
            cmbTel.Items.Add("Particular");
            cmbTel.Items.Add("Laboral");
            cmbTel.Items.Add("Celular");
            cmbTel.SelectedIndex = 0;
            btnAñadirMail.Enabled = false;
            try
            {
                if(Tipo == 'C')
                {
                    if(clienteLocal != null)
                    {
                        btnAgregar.Text = "Modificar";
                        txtID.Text = clienteLocal.ID.ToString();
                        ClienteNegocio negocioCli = new ClienteNegocio();
                        foreach (var item in negocioCli.listarMailsXCliente(clienteLocal))
                        {
                            listaMails.Items.Add(item.Direccion);
                        }
                        foreach (var item in negocioCli.listarTelefonosXCliente(clienteLocal))
                        {
                            listaTelefonos.Items.Add(item.Descripcion +" - "+item.Numero);
                        }
                        if (clienteLocal.TipoPersona.Fisica)
                        {
                            rbtParticular.Checked = true;
                            dtpFechaNac.Text = clienteLocal.FechaNacimiento.ToString();
                        }
                        else
                        {
                            rbtEmpresa.Checked = true;
                        }
                        cargarFormulario(clienteLocal);
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
                        ProveedorNegocio negocioProv = new ProveedorNegocio();
                        btnAgregar.Text = "Modificar";
                        txtID.Text = proveedorLocal.ID.ToString();
                        foreach (var item in negocioProv.listarMailsXProveedor(proveedorLocal))
                        {
                            listaMails.Items.Add(item.Direccion);
                        }
                        foreach (var item in negocioProv.listarTelefonosXProveedor(proveedorLocal))
                        {
                            listaTelefonos.Items.Add(item.Descripcion + " - " + item.Numero);
                        }
                        if (proveedorLocal.TipoPersona.Fisica)
                        {
                            rbtParticular.Checked = true;
                        }
                        else
                        {
                            rbtEmpresa.Checked = true;
                        }
                        cargarFormulario(proveedorLocal);
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

        private void cargarFormulario(Persona local)
        {
            txtNombre.Text = local.Nombre;
            txtApellido.Text = local.Apellido;
            txtRazonSocial.Text = local.RazonSocial;
            txtDNI.Text = local.DNI;
            txtCUIT.Text = local.CUIT;
            txtCalle.Text = local.Domicilio.Calle;
            if (local.Domicilio.Altura != 0)
                txtAltura.Text = local.Domicilio.Altura.ToString();
            txtEntreCalle1.Text = local.Domicilio.EntreCalle1;
            txtEntreCalle2.Text = local.Domicilio.EntreCalle2;
            if (local.Domicilio.Edificio.Piso != 0)
                txtPiso.Text = local.Domicilio.Edificio.Piso.ToString();
            txtDepto.Text = local.Domicilio.Edificio.Departamento;
            txtLocalidad.Text = local.Domicilio.Localidad.Nombre;
            txtPartido.Text = local.Domicilio.Localidad.Partido;
            txtCPostal.Text = local.Domicilio.Localidad.CPostal;
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

            local.Telefonos = new List<Telefono>();
            foreach (var item in listaTelefonos.Items)
            {
                Telefono tel = new Telefono();
                string telefono = item.ToString();
                tel.Descripcion = telefono.Substring(0,telefono.IndexOf(' '));
                tel.Numero = telefono.Substring(telefono.IndexOf('-')+2);
                local.Telefonos.Add(tel);

            }

            local.Mails = new List<Mail>();
            foreach (var item in listaMails.Items)
            {
                Mail mail = new Mail();
                mail.Direccion = item.ToString();
                if(local.TipoPersona.Fisica)
                    mail.Descripcion = txtApellido.Text + ", " + txtNombre.Text;
                else
                    mail.Descripcion = txtRazonSocial.Text;
                local.Mails.Add(mail);
            }
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
            TelefonoNegocio negocioTel = new TelefonoNegocio();
            MailNegocio negocioMail = new MailNegocio();
            if (btnAgregar.Text == "Agregar")
            {
                if (llenarLocal(local))
                {
                    //Domicilio
                    int idLocalidad = negocioLoc.buscarLocalidad(local.Domicilio.Localidad);
                    if(txtCalle.Text.Trim() != "" && txtAltura.Text.Trim() != "")
                    {
                        if (idLocalidad == -1 && txtLocalidad.Text != "")
                            local.Domicilio.Localidad.ID = negocioLoc.agregarLocalidad(local.Domicilio.Localidad);
                        else
                            local.Domicilio.Localidad.ID = idLocalidad;
                        local.Domicilio.ID = negocioDoc.agregarDomicilio(local.Domicilio);
                    }

                    //Mail
                    for (int i = 0; i < local.Mails.Count; i++)
                    {
                        int idMail = negocioMail.agregarMail(local.Mails[i]);
                        if (Tipo == 'P')
                            negocioProv.agregarMailXProveedor((Proveedor)local, idMail);
                        else
                            negocioCli.agregarMailXCliente((Cliente)local, idMail);
                    }

                    //Telefono
                    for (int i = 0; i < local.Telefonos.Count; i++)
                    {
                        int idMail = negocioTel.agregarTelefono(local.Telefonos[i]);
                        if (Tipo == 'P')
                            negocioProv.agregarTelefonoXProveedor((Proveedor)local, idMail);
                        else
                            negocioCli.agregarTelefonoXCliente((Cliente)local, idMail);
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

                    //Mail
                    if (Tipo == 'P')
                        negocioProv.eliminarMailXProveedor((Proveedor)local);
                    else
                        negocioCli.eliminarMailXCliente((Cliente)local);

                    for (int i = 0; i < local.Mails.Count; i++)
                    {
                        int idMail = negocioMail.agregarMail(local.Mails[i]);
                        if (Tipo == 'P')
                            negocioProv.agregarMailXProveedor((Proveedor)local, idMail);
                        else
                            negocioCli.agregarMailXCliente((Cliente)local, idMail);
                    }

                    //Telefono
                    if (Tipo == 'P')
                        negocioProv.eliminarTelefonoXProveedor((Proveedor)local);
                    else
                        negocioCli.eliminarTelefonoXCliente((Cliente)local);

                    for (int i = 0; i < local.Telefonos.Count; i++)
                    {
                        int idMail = negocioTel.agregarTelefono(local.Telefonos[i]);
                        if (Tipo == 'P')
                            negocioProv.agregarTelefonoXProveedor((Proveedor)local, idMail);
                        else
                            negocioCli.agregarTelefonoXCliente((Cliente)local, idMail);
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

        private void btnAñadirTel_Click(object sender, EventArgs e)
        {
            if(txtTel.Text.Trim() != "")
                listaTelefonos.Items.Add(cmbTel.SelectedItem.ToString() + " - " + txtTel.Text);
            txtTel.ResetText();
            txtTel.Focus();
        }

        private void btnEliminarTel_Click(object sender, EventArgs e)
        {
            if(listaTelefonos.SelectedItem == null)
            {
                MessageBox.Show("No hay ningún telefono seleccionado.", "Atención");
            }
            else
            {
                listaTelefonos.Items.Remove(listaTelefonos.SelectedItem);
            }
        }

        private void btnAñadirMail_Click(object sender, EventArgs e)
        {
            if(txtMail.Text.Trim() != "")
                listaMails.Items.Add(txtMail.Text);
            txtMail.ResetText();
            txtMail.Focus();
        }

        private void brnEliminarMail_Click(object sender, EventArgs e)
        {
            if (listaMails.SelectedItem == null)
            {
                MessageBox.Show("No hay ningún mail seleccionado.", "Atención");
            }
            else
            {
                listaMails.Items.Remove(listaMails.SelectedItem);
            }
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            if(negocioMail.IsValidEmail(txtMail.Text))
            {
                btnAñadirMail.Enabled = true;
            }
            else
            {
                btnAñadirMail.Enabled = false;
            }
        }
    }
}
