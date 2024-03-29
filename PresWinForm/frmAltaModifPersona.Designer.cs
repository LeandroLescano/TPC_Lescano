﻿namespace PresWinForm
{
    partial class frmAltaModifPersona
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblTelLinea = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCUIT = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblCUIT = new System.Windows.Forms.Label();
            this.lblFechNacimiento = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.rbtParticular = new System.Windows.Forms.RadioButton();
            this.rbtEmpresa = new System.Windows.Forms.RadioButton();
            this.pnlTipo = new System.Windows.Forms.Panel();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.gpbDireccion = new System.Windows.Forms.GroupBox();
            this.txtCPostal = new System.Windows.Forms.TextBox();
            this.lblCPostal = new System.Windows.Forms.Label();
            this.txtEntreCalle2 = new System.Windows.Forms.TextBox();
            this.txtEntreCalle1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPartido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAltura = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.gpbContacto = new System.Windows.Forms.GroupBox();
            this.btnEliminarTel = new System.Windows.Forms.Button();
            this.brnEliminarMail = new System.Windows.Forms.Button();
            this.btnAñadirTel = new System.Windows.Forms.Button();
            this.btnAñadirMail = new System.Windows.Forms.Button();
            this.listaTelefonos = new System.Windows.Forms.ListBox();
            this.cmbTel = new System.Windows.Forms.ComboBox();
            this.listaMails = new System.Windows.Forms.ListBox();
            this.pnlTipo.SuspendLayout();
            this.gpbDireccion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpbContacto.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel.Location = new System.Drawing.Point(522, 28);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(116, 23);
            this.txtTel.TabIndex = 1;
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.Location = new System.Drawing.Point(57, 30);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(195, 23);
            this.txtMail.TabIndex = 0;
            this.txtMail.TextChanged += new System.EventHandler(this.txtMail_TextChanged);
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.CustomFormat = "\'  \'dd \' de \'MMMMM\' del \' yyyy";
            this.dtpFechaNac.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaNac.Location = new System.Drawing.Point(178, 230);
            this.dtpFechaNac.MaxDate = new System.DateTime(2500, 12, 31, 0, 0, 0, 0);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(214, 23);
            this.dtpFechaNac.TabIndex = 6;
            // 
            // txtDNI
            // 
            this.txtDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNI.Location = new System.Drawing.Point(131, 167);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(261, 23);
            this.txtDNI.TabIndex = 4;
            this.txtDNI.Leave += new System.EventHandler(this.txtDNI_Leave);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(35, 42);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(56, 17);
            this.lblID.TabIndex = 30;
            this.lblID.Text = "Código:";
            // 
            // lblTelLinea
            // 
            this.lblTelLinea.AutoSize = true;
            this.lblTelLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelLinea.Location = new System.Drawing.Point(357, 31);
            this.lblTelLinea.Name = "lblTelLinea";
            this.lblTelLinea.Size = new System.Drawing.Size(68, 17);
            this.lblTelLinea.TabIndex = 52;
            this.lblTelLinea.Text = "Telefono:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(744, 356);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 30);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(742, 307);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(87, 30);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(131, 71);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(261, 23);
            this.txtApellido.TabIndex = 1;
            // 
            // txtCUIT
            // 
            this.txtCUIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCUIT.Location = new System.Drawing.Point(131, 199);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(261, 23);
            this.txtCUIT.TabIndex = 5;
            this.txtCUIT.Leave += new System.EventHandler(this.txtCUIT_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(131, 103);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(261, 23);
            this.txtNombre.TabIndex = 2;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(131, 39);
            this.txtID.Name = "txtID";
            this.txtID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtID.Size = new System.Drawing.Size(261, 23);
            this.txtID.TabIndex = 0;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.Location = new System.Drawing.Point(14, 32);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(37, 17);
            this.lblMail.TabIndex = 45;
            this.lblMail.Text = "Mail:";
            // 
            // lblCUIT
            // 
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCUIT.Location = new System.Drawing.Point(35, 202);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(43, 17);
            this.lblCUIT.TabIndex = 44;
            this.lblCUIT.Text = "CUIT:";
            // 
            // lblFechNacimiento
            // 
            this.lblFechNacimiento.AutoSize = true;
            this.lblFechNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechNacimiento.Location = new System.Drawing.Point(35, 235);
            this.lblFechNacimiento.Name = "lblFechNacimiento";
            this.lblFechNacimiento.Size = new System.Drawing.Size(145, 17);
            this.lblFechNacimiento.TabIndex = 43;
            this.lblFechNacimiento.Text = "Fecha de Nacimiento:";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNI.Location = new System.Drawing.Point(35, 170);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(35, 17);
            this.lblDNI.TabIndex = 42;
            this.lblDNI.Text = "DNI:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(35, 106);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(69, 17);
            this.lblNombre.TabIndex = 41;
            this.lblNombre.Text = "Nombres:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(35, 73);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(69, 17);
            this.lblApellido.TabIndex = 40;
            this.lblApellido.Text = "Apellidos:";
            // 
            // rbtParticular
            // 
            this.rbtParticular.AutoSize = true;
            this.rbtParticular.Checked = true;
            this.rbtParticular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtParticular.Location = new System.Drawing.Point(69, 4);
            this.rbtParticular.Name = "rbtParticular";
            this.rbtParticular.Size = new System.Drawing.Size(86, 21);
            this.rbtParticular.TabIndex = 63;
            this.rbtParticular.TabStop = true;
            this.rbtParticular.Text = "Particular";
            this.rbtParticular.UseVisualStyleBackColor = true;
            this.rbtParticular.CheckedChanged += new System.EventHandler(this.rbtParticular_CheckedChanged);
            // 
            // rbtEmpresa
            // 
            this.rbtEmpresa.AutoSize = true;
            this.rbtEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtEmpresa.Location = new System.Drawing.Point(242, 4);
            this.rbtEmpresa.Name = "rbtEmpresa";
            this.rbtEmpresa.Size = new System.Drawing.Size(82, 21);
            this.rbtEmpresa.TabIndex = 64;
            this.rbtEmpresa.TabStop = true;
            this.rbtEmpresa.Text = "Empresa";
            this.rbtEmpresa.UseVisualStyleBackColor = true;
            this.rbtEmpresa.CheckedChanged += new System.EventHandler(this.rbtEmpresa_CheckedChanged);
            // 
            // pnlTipo
            // 
            this.pnlTipo.Controls.Add(this.rbtEmpresa);
            this.pnlTipo.Controls.Add(this.rbtParticular);
            this.pnlTipo.Location = new System.Drawing.Point(12, 6);
            this.pnlTipo.Name = "pnlTipo";
            this.pnlTipo.Size = new System.Drawing.Size(393, 28);
            this.pnlTipo.TabIndex = 65;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(131, 135);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(261, 23);
            this.txtRazonSocial.TabIndex = 3;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazonSocial.Location = new System.Drawing.Point(35, 138);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(93, 17);
            this.lblRazonSocial.TabIndex = 49;
            this.lblRazonSocial.Text = "Razon social:";
            // 
            // gpbDireccion
            // 
            this.gpbDireccion.Controls.Add(this.txtCPostal);
            this.gpbDireccion.Controls.Add(this.lblCPostal);
            this.gpbDireccion.Controls.Add(this.txtEntreCalle2);
            this.gpbDireccion.Controls.Add(this.txtEntreCalle1);
            this.gpbDireccion.Controls.Add(this.label4);
            this.gpbDireccion.Controls.Add(this.txtPartido);
            this.gpbDireccion.Controls.Add(this.label1);
            this.gpbDireccion.Controls.Add(this.txtCalle);
            this.gpbDireccion.Controls.Add(this.txtLocalidad);
            this.gpbDireccion.Controls.Add(this.txtAltura);
            this.gpbDireccion.Controls.Add(this.label3);
            this.gpbDireccion.Controls.Add(this.lblAltura);
            this.gpbDireccion.Controls.Add(this.lblCalle);
            this.gpbDireccion.Controls.Add(this.groupBox1);
            this.gpbDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbDireccion.Location = new System.Drawing.Point(411, 6);
            this.gpbDireccion.Name = "gpbDireccion";
            this.gpbDireccion.Size = new System.Drawing.Size(419, 256);
            this.gpbDireccion.TabIndex = 7;
            this.gpbDireccion.TabStop = false;
            this.gpbDireccion.Text = "Dirección";
            // 
            // txtCPostal
            // 
            this.txtCPostal.Enabled = false;
            this.txtCPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPostal.Location = new System.Drawing.Point(321, 198);
            this.txtCPostal.Name = "txtCPostal";
            this.txtCPostal.Size = new System.Drawing.Size(75, 23);
            this.txtCPostal.TabIndex = 7;
            // 
            // lblCPostal
            // 
            this.lblCPostal.AutoSize = true;
            this.lblCPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPostal.Location = new System.Drawing.Point(285, 201);
            this.lblCPostal.Name = "lblCPostal";
            this.lblCPostal.Size = new System.Drawing.Size(30, 17);
            this.lblCPostal.TabIndex = 54;
            this.lblCPostal.Text = "CP:";
            // 
            // txtEntreCalle2
            // 
            this.txtEntreCalle2.Enabled = false;
            this.txtEntreCalle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntreCalle2.Location = new System.Drawing.Point(259, 64);
            this.txtEntreCalle2.Name = "txtEntreCalle2";
            this.txtEntreCalle2.Size = new System.Drawing.Size(137, 23);
            this.txtEntreCalle2.TabIndex = 3;
            // 
            // txtEntreCalle1
            // 
            this.txtEntreCalle1.Enabled = false;
            this.txtEntreCalle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntreCalle1.Location = new System.Drawing.Point(107, 64);
            this.txtEntreCalle1.Name = "txtEntreCalle1";
            this.txtEntreCalle1.Size = new System.Drawing.Size(133, 23);
            this.txtEntreCalle1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 52;
            this.label4.Text = "Entre calles:";
            // 
            // txtPartido
            // 
            this.txtPartido.Enabled = false;
            this.txtPartido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartido.Location = new System.Drawing.Point(107, 218);
            this.txtPartido.Name = "txtPartido";
            this.txtPartido.Size = new System.Drawing.Size(136, 23);
            this.txtPartido.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "Partido:";
            // 
            // txtCalle
            // 
            this.txtCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalle.Location = new System.Drawing.Point(105, 28);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(135, 23);
            this.txtCalle.TabIndex = 0;
            this.txtCalle.TextChanged += new System.EventHandler(this.txtCalle_TextChanged);
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Enabled = false;
            this.txtLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalidad.Location = new System.Drawing.Point(107, 179);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(136, 23);
            this.txtLocalidad.TabIndex = 5;
            // 
            // txtAltura
            // 
            this.txtAltura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAltura.Location = new System.Drawing.Point(325, 25);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(71, 23);
            this.txtAltura.TabIndex = 1;
            this.txtAltura.TextChanged += new System.EventHandler(this.txtAltura_TextChanged);
            this.txtAltura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAltura_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 46;
            this.label3.Text = "Localidad:";
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltura.Location = new System.Drawing.Point(256, 28);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(49, 17);
            this.lblAltura.TabIndex = 45;
            this.lblAltura.Text = "Altura:";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalle.Location = new System.Drawing.Point(17, 31);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(43, 17);
            this.lblCalle.TabIndex = 44;
            this.lblCalle.Text = "Calle:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtDepto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPiso);
            this.groupBox1.Location = new System.Drawing.Point(29, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 58);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edificio";
            // 
            // txtDepto
            // 
            this.txtDepto.Enabled = false;
            this.txtDepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepto.Location = new System.Drawing.Point(278, 22);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(64, 23);
            this.txtDepto.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 56;
            this.label2.Text = "Piso:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(167, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 57;
            this.label5.Text = "Dpto/Ofic/Local:";
            // 
            // txtPiso
            // 
            this.txtPiso.Enabled = false;
            this.txtPiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPiso.Location = new System.Drawing.Point(69, 22);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(70, 23);
            this.txtPiso.TabIndex = 0;
            // 
            // gpbContacto
            // 
            this.gpbContacto.Controls.Add(this.btnEliminarTel);
            this.gpbContacto.Controls.Add(this.brnEliminarMail);
            this.gpbContacto.Controls.Add(this.btnAñadirTel);
            this.gpbContacto.Controls.Add(this.btnAñadirMail);
            this.gpbContacto.Controls.Add(this.listaTelefonos);
            this.gpbContacto.Controls.Add(this.cmbTel);
            this.gpbContacto.Controls.Add(this.listaMails);
            this.gpbContacto.Controls.Add(this.lblMail);
            this.gpbContacto.Controls.Add(this.lblTelLinea);
            this.gpbContacto.Controls.Add(this.txtMail);
            this.gpbContacto.Controls.Add(this.txtTel);
            this.gpbContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbContacto.Location = new System.Drawing.Point(13, 265);
            this.gpbContacto.Name = "gpbContacto";
            this.gpbContacto.Size = new System.Drawing.Size(723, 140);
            this.gpbContacto.TabIndex = 8;
            this.gpbContacto.TabStop = false;
            this.gpbContacto.Text = "Contacto";
            // 
            // btnEliminarTel
            // 
            this.btnEliminarTel.AutoSize = true;
            this.btnEliminarTel.Location = new System.Drawing.Point(644, 100);
            this.btnEliminarTel.Name = "btnEliminarTel";
            this.btnEliminarTel.Size = new System.Drawing.Size(68, 27);
            this.btnEliminarTel.TabIndex = 60;
            this.btnEliminarTel.Text = "Eliminar";
            this.btnEliminarTel.UseVisualStyleBackColor = true;
            this.btnEliminarTel.Click += new System.EventHandler(this.btnEliminarTel_Click);
            // 
            // brnEliminarMail
            // 
            this.brnEliminarMail.AutoSize = true;
            this.brnEliminarMail.Location = new System.Drawing.Point(258, 100);
            this.brnEliminarMail.Name = "brnEliminarMail";
            this.brnEliminarMail.Size = new System.Drawing.Size(68, 27);
            this.brnEliminarMail.TabIndex = 59;
            this.brnEliminarMail.Text = "Eliminar";
            this.brnEliminarMail.UseVisualStyleBackColor = true;
            this.brnEliminarMail.Click += new System.EventHandler(this.brnEliminarMail_Click);
            // 
            // btnAñadirTel
            // 
            this.btnAñadirTel.Location = new System.Drawing.Point(644, 26);
            this.btnAñadirTel.Name = "btnAñadirTel";
            this.btnAñadirTel.Size = new System.Drawing.Size(59, 25);
            this.btnAñadirTel.TabIndex = 58;
            this.btnAñadirTel.Text = "Añadir";
            this.btnAñadirTel.UseVisualStyleBackColor = true;
            this.btnAñadirTel.Click += new System.EventHandler(this.btnAñadirTel_Click);
            // 
            // btnAñadirMail
            // 
            this.btnAñadirMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirMail.Location = new System.Drawing.Point(258, 29);
            this.btnAñadirMail.Name = "btnAñadirMail";
            this.btnAñadirMail.Size = new System.Drawing.Size(59, 25);
            this.btnAñadirMail.TabIndex = 57;
            this.btnAñadirMail.Text = "Añadir";
            this.btnAñadirMail.UseVisualStyleBackColor = true;
            this.btnAñadirMail.Click += new System.EventHandler(this.btnAñadirMail_Click);
            // 
            // listaTelefonos
            // 
            this.listaTelefonos.FormattingEnabled = true;
            this.listaTelefonos.ItemHeight = 16;
            this.listaTelefonos.Location = new System.Drawing.Point(360, 59);
            this.listaTelefonos.Name = "listaTelefonos";
            this.listaTelefonos.Size = new System.Drawing.Size(278, 68);
            this.listaTelefonos.TabIndex = 56;
            // 
            // cmbTel
            // 
            this.cmbTel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTel.FormattingEnabled = true;
            this.cmbTel.Location = new System.Drawing.Point(431, 27);
            this.cmbTel.Name = "cmbTel";
            this.cmbTel.Size = new System.Drawing.Size(85, 24);
            this.cmbTel.TabIndex = 55;
            // 
            // listaMails
            // 
            this.listaMails.FormattingEnabled = true;
            this.listaMails.ItemHeight = 16;
            this.listaMails.Location = new System.Drawing.Point(17, 59);
            this.listaMails.Name = "listaMails";
            this.listaMails.Size = new System.Drawing.Size(235, 68);
            this.listaMails.TabIndex = 54;
            // 
            // frmAltaModifPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 411);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.lblRazonSocial);
            this.Controls.Add(this.gpbContacto);
            this.Controls.Add(this.gpbDireccion);
            this.Controls.Add(this.pnlTipo);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.dtpFechaNac);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtCUIT);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblCUIT);
            this.Controls.Add(this.lblFechNacimiento);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblApellido);
            this.Name = "frmAltaModifPersona";
            this.Text = "Agregar/Modificar Persona";
            this.Load += new System.EventHandler(this.frmAltaModifPersona_Load);
            this.pnlTipo.ResumeLayout(false);
            this.pnlTipo.PerformLayout();
            this.gpbDireccion.ResumeLayout(false);
            this.gpbDireccion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbContacto.ResumeLayout(false);
            this.gpbContacto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblTelLinea;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCUIT;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.Label lblFechNacimiento;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.RadioButton rbtParticular;
        private System.Windows.Forms.RadioButton rbtEmpresa;
        private System.Windows.Forms.Panel pnlTipo;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.GroupBox gpbDireccion;
        private System.Windows.Forms.TextBox txtPartido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.GroupBox gpbContacto;
        private System.Windows.Forms.TextBox txtEntreCalle2;
        private System.Windows.Forms.TextBox txtEntreCalle1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.TextBox txtCPostal;
        private System.Windows.Forms.Label lblCPostal;
        private System.Windows.Forms.Button btnEliminarTel;
        private System.Windows.Forms.Button brnEliminarMail;
        private System.Windows.Forms.Button btnAñadirTel;
        private System.Windows.Forms.Button btnAñadirMail;
        private System.Windows.Forms.ListBox listaTelefonos;
        private System.Windows.Forms.ComboBox cmbTel;
        private System.Windows.Forms.ListBox listaMails;
    }
}