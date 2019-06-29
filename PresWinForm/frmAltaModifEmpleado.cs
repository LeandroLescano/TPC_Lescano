using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Dominio;
using Negocio;

namespace PresWinForm
{
    public partial class frmAltaModifEmpleado : Form
    {
        private Empleado empleadoLocal = null;
        private EmpleadoNegocio negocio = new EmpleadoNegocio();

        public frmAltaModifEmpleado()
        {
            InitializeComponent();
        }

        public frmAltaModifEmpleado(Empleado emp)
        {
            InitializeComponent();
            empleadoLocal = emp;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                AddModif(empleadoLocal);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaModifEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                if (empleadoLocal != null)
                {
                    btnAgregar.Text = "Modificar";
                    txtID.Text = empleadoLocal.ID.ToString(); ;
                    txtApellido.Text = empleadoLocal.Apellido;
                    txtNombre.Text = empleadoLocal.Nombre;
                    txtDNI.Text = empleadoLocal.DNI;
                    txtCUIL.Text = empleadoLocal.CUIL;
                    txtUsuario.Text = empleadoLocal.Usuario.Nombre;
                    if(empleadoLocal.Domicilio.Altura != 0)
                        txtAltura.Text = empleadoLocal.Domicilio.Altura.ToString(); ;
                    txtCalle.Text = empleadoLocal.Domicilio.Calle;
                    txtEntreCalle1.Text = empleadoLocal.Domicilio.EntreCalle1;
                    txtEntreCalle2.Text = empleadoLocal.Domicilio.EntreCalle2;
                    txtLocalidad.Text = empleadoLocal.Domicilio.Localidad.Nombre;
                    txtPartido.Text = empleadoLocal.Domicilio.Localidad.Partido;
                    dtpFechaNac.Text = empleadoLocal.FechaNacimiento.ToShortDateString();
                    if (empleadoLocal.Domicilio.Edificio.Piso != 0)
                        txtPiso.Text = empleadoLocal.Domicilio.Edificio.Piso.ToString();
                    txtDepto.Text = empleadoLocal.Domicilio.Edificio.Departamento;
                    if(empleadoLocal.Usuario != null)
                    {
                        txtUsuario.Text = empleadoLocal.Usuario.Nombre;
                        txtContraseña.Text = empleadoLocal.Usuario.Contraseña;
                    }
                    if (empleadoLocal.TipoEmpleado.Administrador)
                    {
                        rdbAdministrador.Checked = true;
                    }
                    else
                    {
                        rdbVendedor.Checked = true;
                    }

                }
                else
                {
                    empleadoLocal = new Empleado();
                    empleadoLocal.Usuario = new Usuario();
                    empleadoLocal.TipoEmpleado = new TipoEmpleado();
                    empleadoLocal.Domicilio = new Domicilio();
                    empleadoLocal.Domicilio.Localidad = new Localidad();
                    empleadoLocal.Domicilio.Edificio = new Edificio();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool llenarLocal(Empleado local)
        {
            if(rdbAdministrador.Checked)
            {
                local.TipoEmpleado.Administrador = true;
            }
            else
            {
                local.TipoEmpleado.Vendedor = true;
            }
            if(txtApellido.Text != "" && txtNombre.Text != "")
            {
                local.Apellido = txtApellido.Text;
                local.Nombre = txtNombre.Text;
            }
            else
            {
                MessageBox.Show("No puedes agregar un empleado sin nombre y/o apellido.", "Cuidado!");
                return false;
            }
            if(txtDNI.Text !=  "" || txtCUIL.Text != "")
            {
                local.DNI = txtDNI.Text;
                local.CUIL = txtCUIL.Text;
            }
            else
            {
                MessageBox.Show("No puedes agregar un empleado sin DNI y/o CUIT.", "Cuidado!");
                return false;
            }
            local.FechaNacimiento = (DateTime)dtpFechaNac.Value;
            local.Usuario.Nombre = txtUsuario.Text;
            local.Usuario.Contraseña = txtContraseña.Text;
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

        private void AddModif(Empleado local)
        {
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            LocalidadNegocio negocioLoc = new LocalidadNegocio();
            DomicilioNegocio negocioDoc = new DomicilioNegocio();
            UsuarioNegocio negocioUser = new UsuarioNegocio();
            if (btnAgregar.Text == "Agregar")
            {
                if (llenarLocal(local))
                {           
                    int idLocalidad = negocioLoc.buscarLocalidad(local.Domicilio.Localidad);
                    if (txtCalle.Text.Trim() != "" && txtAltura.Text.Trim() != "")
                    {
                        if (idLocalidad == -1 && txtLocalidad.Text != "")
                            local.Domicilio.Localidad.ID = negocioLoc.agregarLocalidad(local.Domicilio.Localidad);
                        else
                            local.Domicilio.Localidad.ID = idLocalidad;
                        local.Domicilio.ID = negocioDoc.agregarDomicilio(local.Domicilio);
                    }
                    local.Usuario.ID = negocioUser.agregarUsuario(local.Usuario);
                    negocio.agregarEmpleado(local);
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
                        else if (local.Domicilio.Calle == "" || local.Domicilio.Altura == 0)
                        {
                            negocioDoc.eliminarDomicilio(local.Domicilio);
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
                    if(local.Usuario.ID == 0)
                    {
                        local.Usuario.ID = negocioUser.agregarUsuario(local.Usuario);
                    }
                    else
                    {
                        negocioUser.modificarUsuario(local.Usuario);
                    }
                    negocio.modificarEmpleado(local);
                    Close();
                }
            }
        }

        private bool llenarDomicilio(Persona local)
        {
            if (local.Domicilio == null)
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
                    if (txtAltura.Text != "")
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
            if (txtLocalidad.Text.Trim() != "")
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if(negocio.dniCuilDuplicado(txtDNI.Text, 'D') && txtDNI.Text != "")
            {
                MessageBox.Show("El DNI pertenece a otro empleado", "Cuidado!");
                txtDNI.Focus();
                txtDNI.SelectAll();
            }
        }

        private void txtCUIL_Leave(object sender, EventArgs e)
        {
            if (negocio.dniCuilDuplicado(txtCUIL.Text, 'C') && txtCUIL.Text != "")
            {
                MessageBox.Show("El CUIL pertenece a otro empleado", "Cuidado!");
                txtCUIL.Focus();
                txtCUIL.SelectAll();
            }
        }
    }
}
