﻿using System;
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
                txtRazonSocial.Focus();
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
                txtApellido.Focus();
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
                    //if (clienteLocal == null)
                    //    clienteLocal = new Cliente();
                    //if(rbtParticular.Checked)
                    //{
                    //    clienteLocal.Apellido = txtApellido.Text;
                    //    clienteLocal.Nombre = txtNombre.Text;
                    //    clienteLocal.TipoPersona = new TipoPersona();
                    //    clienteLocal.TipoPersona.Fisica = true;
                    //}
                    //else
                    //{
                    //    clienteLocal.RazonSocial = txtRazonSocial.Text;
                    //    clienteLocal.TipoPersona = new TipoPersona();
                    //    clienteLocal.TipoPersona.Juridica = true;
                    //}
                    //clienteLocal.DNI = txtDNI.Text;
                    //clienteLocal.CUIT = txtCUIT.Text;
                    //clienteLocal.FechaNacimiento = (DateTime)dtpFechaNac.Value;
                    ////clienteLocal.Domicilio
                    ////Telefono tel = new Telefono();
                    ////tel.Descripcion = txtApellido.Text + ", " + txtNombre.Text;
                    ////tel.Numero = txtTelCelular.Text;
                    ////clienteLocal.Telefonos.Add(tel);
                    ////Mail mail = new Mail();
                    ////mail.Descripcion = txtApellido.Text + ", " + txtNombre.Text;
                    ////mail.Direccion = txtMail.Text;
                    ////clienteLocal.Mails.Add(mail);

                    //if(clienteLocal.ID != 0)
                    //{
                    //    //clienteNegocio.modificarCliente(clienteLocal);
                    //}
                    //else
                    //{
                    //    clienteNegocio.agregarCliente(clienteLocal);
                    //}
                    AddModif(clienteLocal, 'C');

                }
                else if (Tipo == 'P')
                {
                    ProveedorNegocio negocioProv = new ProveedorNegocio();
                    LocalidadNegocio negocioLoc = new LocalidadNegocio();
                    DomicilioNegocio negocioDoc = new DomicilioNegocio();
                    if (btnAgregar.Text == "Agregar")
                    {
                        proveedorLocal = new Proveedor();
                        if(llenarLocal(proveedorLocal))
                        {
                            if(proveedorLocal.Domicilio != null)
                            {
                                proveedorLocal.Domicilio.Localidad.ID = negocioLoc.agregarLocalidad(proveedorLocal.Domicilio.Localidad);
                                proveedorLocal.Domicilio.ID = negocioDoc.agregarDomicilio(proveedorLocal.Domicilio);
                            }
                            negocioProv.agregarProveedor(proveedorLocal);
                            Close();
                        }
                    }
                    else
                    {
                        if(llenarLocal(proveedorLocal))
                        {
                            int idLocalidad = negocioLoc.buscarLocalidad(proveedorLocal.Domicilio.Localidad);
                            if (proveedorLocal.Domicilio.ID < 1)
                            {
                                if(proveedorLocal.Domicilio.Localidad.ID == 0)
                                {
                                    if (idLocalidad == -1)
                                        proveedorLocal.Domicilio.Localidad.ID = negocioLoc.agregarLocalidad(proveedorLocal.Domicilio.Localidad);
                                    else
                                        proveedorLocal.Domicilio.Localidad.ID = idLocalidad;
                                }
                                proveedorLocal.Domicilio.ID = negocioDoc.agregarDomicilio(proveedorLocal.Domicilio);
                            }
                            else if (proveedorLocal.Domicilio.Calle == "" || proveedorLocal.Domicilio.Altura == 0)
                            {
                                negocioDoc.eliminarDomicilio(proveedorLocal.Domicilio);
                            }
                            else
                            {
                                if(proveedorLocal.Domicilio.Localidad.ID < 1)
                                {
                                    proveedorLocal.Domicilio.Localidad.ID = negocioLoc.agregarLocalidad(proveedorLocal.Domicilio.Localidad);
                                }
                                else
                                {
                                    if (idLocalidad == -1)
                                        proveedorLocal.Domicilio.Localidad.ID = negocioLoc.agregarLocalidad(proveedorLocal.Domicilio.Localidad);
                                    else
                                        proveedorLocal.Domicilio.Localidad.ID = idLocalidad;
                                    //negocioLoc.modificarLocalidad(proveedorLocal.Domicilio);
                                }
                                negocioDoc.modificarDomicilio(proveedorLocal.Domicilio);
                            }

                            negocioProv.modificarProveedor(proveedorLocal);
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
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool llenarLocal(Persona local)
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
            if(!llenarDomicilio(local))
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
                if (txtCalle.Text.Trim() != "" && txtAltura.Text.Trim() != "")
                {
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
            return true;
        }

        private bool llenarEdificio(Persona local)
        {
            if(local.Domicilio == null)
            {
                if (txtPiso.Text.Trim() != "" && txtDepto.Text.Trim() != "")
                {
                    local.Domicilio.Edificio = new Edificio();
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
            }
            else
            {
                if (txtPiso.Text.Trim() != "" && txtDepto.Text.Trim() != "")
                {
                    local.Domicilio.Edificio.Piso = Convert.ToInt32(txtPiso.Text);
                    local.Domicilio.Edificio.Departamento = txtDepto.Text;
                }
                else if (txtPiso.Text.Trim() == "" && txtDepto.Text.Trim() == "")
                {
                    local.Domicilio.Edificio.Piso = 0;
                    local.Domicilio.Edificio.Departamento = null;
                }
                else if ((txtPiso.Text.Trim() != "" && txtDepto.Text.Trim() == "") || (txtPiso.Text.Trim() == "" && txtDepto.Text.Trim() != ""))
                {
                    if (MessageBox.Show("Faltan datos del EDIFICIO para completar.\n\n¿Desea continuar? No se guardará ningún dato del edificio.", "Atención!", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return false;
                    }
                }
                
            }
            return true;
        }

        private bool llenarLocalidad(Persona local)
        {
            if(local.Domicilio == null)
            {
                if(txtLocalidad.Text.Trim() != "")
                {
                    local.Domicilio.Localidad = new Localidad();
                    local.Domicilio.Localidad.Nombre = txtLocalidad.Text;
                    local.Domicilio.Localidad.Partido = txtPartido.Text;
                    local.Domicilio.Localidad.CPostal = txtCPostal.Text;
                }
            }
            else
            {
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
                local = new Proveedor();
                if (llenarLocal(local))
                {
                    int idLocalidad = negocioLoc.buscarLocalidad(local.Domicilio.Localidad);
                    if (local.Domicilio != null)
                    {
                        if (idLocalidad == -1)
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
                    int idLocalidad = negocioLoc.buscarLocalidad(local.Domicilio.Localidad);
                    if (local.Domicilio.ID < 1)
                    {
                        if (idLocalidad == -1)
                            local.Domicilio.Localidad.ID = negocioLoc.agregarLocalidad(local.Domicilio.Localidad);
                        else
                            local.Domicilio.Localidad.ID = idLocalidad;
                        local.Domicilio.ID = negocioDoc.agregarDomicilio(local.Domicilio);
                    }
                    else if (local.Domicilio.Calle == "" || local.Domicilio.Altura == 0)
                    {
                        negocioDoc.eliminarDomicilio(local.Domicilio);
                    }
                    else
                    {
                        if (local.Domicilio.Localidad.ID < 1)
                        {
                            local.Domicilio.Localidad.ID = negocioLoc.agregarLocalidad(local.Domicilio.Localidad);
                        }
                        else
                        {
                            if (idLocalidad == -1)
                                local.Domicilio.Localidad.ID = negocioLoc.agregarLocalidad(local.Domicilio.Localidad);
                            else
                                local.Domicilio.Localidad.ID = idLocalidad;
                        }
                        negocioDoc.modificarDomicilio(local.Domicilio);
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
    }
}
