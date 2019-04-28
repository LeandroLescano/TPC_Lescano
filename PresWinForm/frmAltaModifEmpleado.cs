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
    public partial class frmAltaModifEmpleado : Form
    {
        private Empleado empleadoLocal = null;

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
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            try
            {
                if (empleadoLocal == null)
                    empleadoLocal = new Empleado();

                empleadoLocal.Apellido = txtApellido.Text;
                empleadoLocal.Nombre = txtNombre.Text;
                empleadoLocal.DNI = txtDNI.Text;
                empleadoLocal.CUIL = txtCUIL.Text;
                empleadoLocal.TipoEmpleado = new TipoEmpleado();
                if(rdbAdministrador.Checked)
                {
                    empleadoLocal.TipoEmpleado.Administrador = true;
                }
                else
                {
                    empleadoLocal.TipoEmpleado.Vendedor = true;
                }

                if(empleadoLocal.Codigo != 0)
                {
                    //negocio.modificarEmpleado(empleadoLocal);
                }
                else
                {
                    //negocio.agregarEmpleado(empleadoLocal);
                }

                Close();

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
                if(empleadoLocal != null)
                {
                    txtCodigo.Text = empleadoLocal.Codigo.ToString(); ;
                    txtApellido.Text = empleadoLocal.Apellido;
                    txtNombre.Text = empleadoLocal.Nombre;
                    txtDNI.Text = empleadoLocal.DNI;
                    txtCUIL.Text = empleadoLocal.CUIL;
                    txtUsuario.Text = empleadoLocal.Usuario.Nombre;
                    txtAltura.Text = empleadoLocal.Domicilio.Altura.ToString(); ;
                    txtCalle.Text = empleadoLocal.Domicilio.Calle;
                    txtEntreCalle1.Text = empleadoLocal.Domicilio.EntreCalle1;
                    txtEntreCalle2.Text = empleadoLocal.Domicilio.EntreCalle2;
                    txtLocalidad.Text = empleadoLocal.Domicilio.Localidad.Nombre;
                    txtPartido.Text = empleadoLocal.Domicilio.Localidad.Partido;
                    txtPiso.Text = empleadoLocal.Domicilio.Edificio.Piso.ToString();
                    txtDepto.Text = empleadoLocal.Domicilio.Edificio.Departamento;
                    if (empleadoLocal.TipoEmpleado.Administrador)
                    {
                        rdbAdministrador.Checked = true;
                    }
                    else
                    {
                        rdbVendedor.Checked = true;
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
