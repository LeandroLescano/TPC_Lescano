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
    public partial class frmConfiguracion : Form
    {
        private Comercio local = new Comercio();
        private ComercioNegocio negocio = new ComercioNegocio();
        private LocalidadNegocio negocioLoc = new LocalidadNegocio();
        private DomicilioNegocio negocioDom = new DomicilioNegocio();

        public frmConfiguracion()
        {
            InitializeComponent();
            local = negocio.listarComercio();
            if(local.ID == 0)
            {
                btnActualizar.Text = "Agregar";
            }
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

        private void alturaCalle()
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

        private void txtCalle_TextChanged(object sender, EventArgs e)
        {
            alturaCalle(); 
        }

        private void txtAltura_TextChanged(object sender, EventArgs e)
        {
            alturaCalle();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (btnActualizar.Text == "Agregar")
            {
                if (llenarLocal())
                {
                    //Domicilio
                    int idLocalidad = negocioLoc.buscarLocalidad(local.Domicilio.Localidad);
                    if (txtCalle.Text.Trim() != "" && txtAltura.Text.Trim() != "")
                    {
                        if (idLocalidad == -1 && txtLocalidad.Text != "")
                            local.Domicilio.Localidad.ID = negocioLoc.agregarLocalidad(local.Domicilio.Localidad);
                        else
                            local.Domicilio.Localidad.ID = idLocalidad;
                        local.Domicilio.ID = negocioDom.agregarDomicilio(local.Domicilio);
                    }

                    negocio.agregarComercio(local);
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Comercio agregado con éxito.");
                }
            }
            else
            {
                if (llenarLocal())
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
                            local.Domicilio.ID = negocioDom.agregarDomicilio(local.Domicilio);
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
                            negocioDom.modificarDomicilio(local.Domicilio);
                        }
                    }
                    else if (local.Domicilio.Calle == "" || local.Domicilio.Altura == 0)
                    {
                        negocioDom.eliminarDomicilio(local.Domicilio);
                    }

                    negocio.modificarComercio(local);
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Comercio modificado con éxito.");
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            if(local.ID != 0)
            {
                txtNombreJ.Text = local.NombreJuridico;
                txtNombreF.Text = local.NombreFantasia;
                txtIngresosB.Text = local.IngresosBrutos;
                dtpFechInicio.Value = local.FechaInicio;
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
            else
            {
                local.Domicilio = new Domicilio();
                local.Domicilio.Coordenadas = new Coordenada();
                local.Domicilio.Localidad = new Localidad();
                local.Domicilio.Edificio = new Edificio();
            }
        }

        private bool llenarLocal()
        {
            if(txtNombreJ.Text != "")
            {
                local.NombreJuridico = txtNombreJ.Text;
            }
            else
            {
                MessageBox.Show("El comercio debe tener un nombre jurídico.", "Cuidado!");
                return false;
            }

            if(txtNombreF.Text != "")
            {
                local.NombreFantasia = txtNombreF.Text;
            }
            else
            {
                local.NombreFantasia = txtNombreJ.Text;
            }

            if (txtCUIT.Text.Trim() != "")
            {
                local.CUIT = txtCUIT.Text;
            }
            else
            {
                MessageBox.Show("El comercio debe tener un CUIT.", "Cuidado!");
                return false;
            }

            if(txtIngresosB.Text != "")
            {
                local.IngresosBrutos = txtIngresosB.Text;
            }
            else
            {
                MessageBox.Show("El comercio debe tener un número de ingresos brutos.", "Cuidado!");
                return false;
            }

            local.FechaInicio = dtpFechInicio.Value;
            if (!llenarDomicilio())
            {
                return false;
            }
            if (!llenarEdificio())
            {
                return false;
            }
            llenarLocalidad();

            return true;
        }

        private bool llenarDomicilio()
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
                else if (txtCalle.Text.Trim() == "" || txtAltura.Text.Trim() == "")
                {
                    MessageBox.Show("Faltan datos de la dirección para completar.", "Atención!");
                    return false;
                }
            }
            else
            {
                if (txtCalle.Text.Trim() == "" || txtAltura.Text.Trim() == "")
                {
                    MessageBox.Show("Faltan datos de la dirección para completar.", "Atención!");
                    return false;
                }
                else
                {
                    local.Domicilio.Altura = Convert.ToInt32(txtAltura.Text);
                    local.Domicilio.Calle = txtCalle.Text;
                    local.Domicilio.EntreCalle1 = txtEntreCalle1.Text;
                    local.Domicilio.EntreCalle2 = txtEntreCalle2.Text;
                }
            }
            return true;
        }

        private bool llenarEdificio()
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

        private bool llenarLocalidad()
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
    }
}
