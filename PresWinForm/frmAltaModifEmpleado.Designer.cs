namespace PresWinForm
{
    partial class frmAltaModifEmpleado
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
            this.gpbContacto = new System.Windows.Forms.GroupBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblTelLinea = new System.Windows.Forms.Label();
            this.lblTelCelular = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtTelCelular = new System.Windows.Forms.TextBox();
            this.txtTelLinea = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtCUIL = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblCUIL = new System.Windows.Forms.Label();
            this.lblFechNacimiento = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.gpbUsuario = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.rdbAdministrador = new System.Windows.Forms.RadioButton();
            this.rdbVendedor = new System.Windows.Forms.RadioButton();
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
            this.gpbContacto.SuspendLayout();
            this.gpbUsuario.SuspendLayout();
            this.gpbDireccion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbContacto
            // 
            this.gpbContacto.Controls.Add(this.lblMail);
            this.gpbContacto.Controls.Add(this.lblTelLinea);
            this.gpbContacto.Controls.Add(this.lblTelCelular);
            this.gpbContacto.Controls.Add(this.txtMail);
            this.gpbContacto.Controls.Add(this.txtTelCelular);
            this.gpbContacto.Controls.Add(this.txtTelLinea);
            this.gpbContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbContacto.Location = new System.Drawing.Point(350, 277);
            this.gpbContacto.Name = "gpbContacto";
            this.gpbContacto.Size = new System.Drawing.Size(368, 139);
            this.gpbContacto.TabIndex = 8;
            this.gpbContacto.TabStop = false;
            this.gpbContacto.Text = "Contacto";
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
            // lblTelLinea
            // 
            this.lblTelLinea.AutoSize = true;
            this.lblTelLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelLinea.Location = new System.Drawing.Point(14, 67);
            this.lblTelLinea.Name = "lblTelLinea";
            this.lblTelLinea.Size = new System.Drawing.Size(122, 17);
            this.lblTelLinea.TabIndex = 52;
            this.lblTelLinea.Text = "Telefono de línea:";
            // 
            // lblTelCelular
            // 
            this.lblTelCelular.AutoSize = true;
            this.lblTelCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelCelular.Location = new System.Drawing.Point(14, 102);
            this.lblTelCelular.Name = "lblTelCelular";
            this.lblTelCelular.Size = new System.Drawing.Size(114, 17);
            this.lblTelCelular.TabIndex = 53;
            this.lblTelCelular.Text = "Telefono celular:";
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.Location = new System.Drawing.Point(166, 29);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(189, 23);
            this.txtMail.TabIndex = 0;
            // 
            // txtTelCelular
            // 
            this.txtTelCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelCelular.Location = new System.Drawing.Point(166, 99);
            this.txtTelCelular.Name = "txtTelCelular";
            this.txtTelCelular.Size = new System.Drawing.Size(189, 23);
            this.txtTelCelular.TabIndex = 2;
            // 
            // txtTelLinea
            // 
            this.txtTelLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelLinea.Location = new System.Drawing.Point(166, 64);
            this.txtTelLinea.Name = "txtTelLinea";
            this.txtTelLinea.Size = new System.Drawing.Size(189, 23);
            this.txtTelLinea.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(725, 360);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 30);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(725, 299);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(87, 30);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(125, 110);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(208, 23);
            this.txtNombre.TabIndex = 2;
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(125, 62);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(208, 23);
            this.txtApellido.TabIndex = 1;
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.CustomFormat = "\'  \'dd \'de\'MMM\'del\' yyyy";
            this.dtpFechaNac.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaNac.Location = new System.Drawing.Point(175, 249);
            this.dtpFechaNac.MaxDate = new System.DateTime(2500, 12, 31, 0, 0, 0, 0);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(158, 23);
            this.dtpFechaNac.TabIndex = 5;
            // 
            // txtDNI
            // 
            this.txtDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNI.Location = new System.Drawing.Point(125, 157);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(208, 23);
            this.txtDNI.TabIndex = 3;
            this.txtDNI.Leave += new System.EventHandler(this.txtDNI_Leave);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(29, 19);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(56, 17);
            this.lblID.TabIndex = 93;
            this.lblID.Text = "Código:";
            // 
            // txtCUIL
            // 
            this.txtCUIL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCUIL.Location = new System.Drawing.Point(125, 204);
            this.txtCUIL.Name = "txtCUIL";
            this.txtCUIL.Size = new System.Drawing.Size(208, 23);
            this.txtCUIL.TabIndex = 4;
            this.txtCUIL.Leave += new System.EventHandler(this.txtCUIL_Leave);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(125, 16);
            this.txtID.Name = "txtID";
            this.txtID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtID.Size = new System.Drawing.Size(208, 23);
            this.txtID.TabIndex = 0;
            this.txtID.TabStop = false;
            // 
            // lblCUIL
            // 
            this.lblCUIL.AutoSize = true;
            this.lblCUIL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCUIL.Location = new System.Drawing.Point(29, 207);
            this.lblCUIL.Name = "lblCUIL";
            this.lblCUIL.Size = new System.Drawing.Size(42, 17);
            this.lblCUIL.TabIndex = 98;
            this.lblCUIL.Text = "CUIL:";
            // 
            // lblFechNacimiento
            // 
            this.lblFechNacimiento.AutoSize = true;
            this.lblFechNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechNacimiento.Location = new System.Drawing.Point(29, 254);
            this.lblFechNacimiento.Name = "lblFechNacimiento";
            this.lblFechNacimiento.Size = new System.Drawing.Size(145, 17);
            this.lblFechNacimiento.TabIndex = 97;
            this.lblFechNacimiento.Text = "Fecha de Nacimiento:";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNI.Location = new System.Drawing.Point(29, 160);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(35, 17);
            this.lblDNI.TabIndex = 96;
            this.lblDNI.Text = "DNI:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(29, 113);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(69, 17);
            this.lblNombre.TabIndex = 95;
            this.lblNombre.Text = "Nombres:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(29, 65);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(69, 17);
            this.lblApellido.TabIndex = 94;
            this.lblApellido.Text = "Apellidos:";
            // 
            // gpbUsuario
            // 
            this.gpbUsuario.Controls.Add(this.lblUsuario);
            this.gpbUsuario.Controls.Add(this.lblContraseña);
            this.gpbUsuario.Controls.Add(this.txtUsuario);
            this.gpbUsuario.Controls.Add(this.txtContraseña);
            this.gpbUsuario.Controls.Add(this.rdbAdministrador);
            this.gpbUsuario.Controls.Add(this.rdbVendedor);
            this.gpbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbUsuario.Location = new System.Drawing.Point(23, 285);
            this.gpbUsuario.Name = "gpbUsuario";
            this.gpbUsuario.Size = new System.Drawing.Size(310, 131);
            this.gpbUsuario.TabIndex = 6;
            this.gpbUsuario.TabStop = false;
            this.gpbUsuario.Text = "Usuario";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(29, 32);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(61, 17);
            this.lblUsuario.TabIndex = 55;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.Location = new System.Drawing.Point(29, 61);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(85, 17);
            this.lblContraseña.TabIndex = 56;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(121, 29);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(165, 23);
            this.txtUsuario.TabIndex = 0;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(121, 58);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '•';
            this.txtContraseña.Size = new System.Drawing.Size(165, 23);
            this.txtContraseña.TabIndex = 1;
            // 
            // rdbAdministrador
            // 
            this.rdbAdministrador.AutoSize = true;
            this.rdbAdministrador.Location = new System.Drawing.Point(173, 97);
            this.rdbAdministrador.Name = "rdbAdministrador";
            this.rdbAdministrador.Size = new System.Drawing.Size(113, 21);
            this.rdbAdministrador.TabIndex = 3;
            this.rdbAdministrador.Text = "Administrador";
            this.rdbAdministrador.UseVisualStyleBackColor = true;
            // 
            // rdbVendedor
            // 
            this.rdbVendedor.AutoSize = true;
            this.rdbVendedor.Checked = true;
            this.rdbVendedor.Location = new System.Drawing.Point(31, 97);
            this.rdbVendedor.Name = "rdbVendedor";
            this.rdbVendedor.Size = new System.Drawing.Size(88, 21);
            this.rdbVendedor.TabIndex = 2;
            this.rdbVendedor.TabStop = true;
            this.rdbVendedor.Text = "Vendedor";
            this.rdbVendedor.UseVisualStyleBackColor = true;
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
            this.gpbDireccion.Location = new System.Drawing.Point(350, 12);
            this.gpbDireccion.Name = "gpbDireccion";
            this.gpbDireccion.Size = new System.Drawing.Size(457, 259);
            this.gpbDireccion.TabIndex = 7;
            this.gpbDireccion.TabStop = false;
            this.gpbDireccion.Text = "Dirección";
            // 
            // txtCPostal
            // 
            this.txtCPostal.Enabled = false;
            this.txtCPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPostal.Location = new System.Drawing.Point(338, 203);
            this.txtCPostal.Name = "txtCPostal";
            this.txtCPostal.Size = new System.Drawing.Size(75, 23);
            this.txtCPostal.TabIndex = 7;
            // 
            // lblCPostal
            // 
            this.lblCPostal.AutoSize = true;
            this.lblCPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPostal.Location = new System.Drawing.Point(302, 206);
            this.lblCPostal.Name = "lblCPostal";
            this.lblCPostal.Size = new System.Drawing.Size(30, 17);
            this.lblCPostal.TabIndex = 54;
            this.lblCPostal.Text = "CP:";
            // 
            // txtEntreCalle2
            // 
            this.txtEntreCalle2.Enabled = false;
            this.txtEntreCalle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntreCalle2.Location = new System.Drawing.Point(276, 69);
            this.txtEntreCalle2.Name = "txtEntreCalle2";
            this.txtEntreCalle2.Size = new System.Drawing.Size(137, 23);
            this.txtEntreCalle2.TabIndex = 3;
            // 
            // txtEntreCalle1
            // 
            this.txtEntreCalle1.Enabled = false;
            this.txtEntreCalle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntreCalle1.Location = new System.Drawing.Point(124, 69);
            this.txtEntreCalle1.Name = "txtEntreCalle1";
            this.txtEntreCalle1.Size = new System.Drawing.Size(133, 23);
            this.txtEntreCalle1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 52;
            this.label4.Text = "Entre calles:";
            // 
            // txtPartido
            // 
            this.txtPartido.Enabled = false;
            this.txtPartido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartido.Location = new System.Drawing.Point(124, 223);
            this.txtPartido.Name = "txtPartido";
            this.txtPartido.Size = new System.Drawing.Size(136, 23);
            this.txtPartido.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "Partido:";
            // 
            // txtCalle
            // 
            this.txtCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalle.Location = new System.Drawing.Point(122, 33);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(135, 23);
            this.txtCalle.TabIndex = 0;
            this.txtCalle.TextChanged += new System.EventHandler(this.txtCalle_TextChanged);
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Enabled = false;
            this.txtLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalidad.Location = new System.Drawing.Point(124, 184);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(136, 23);
            this.txtLocalidad.TabIndex = 5;
            // 
            // txtAltura
            // 
            this.txtAltura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAltura.Location = new System.Drawing.Point(342, 30);
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
            this.label3.Location = new System.Drawing.Point(43, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 46;
            this.label3.Text = "Localidad:";
            // 
            // lblAltura
            // 
            this.lblAltura.AutoSize = true;
            this.lblAltura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltura.Location = new System.Drawing.Point(273, 33);
            this.lblAltura.Name = "lblAltura";
            this.lblAltura.Size = new System.Drawing.Size(49, 17);
            this.lblAltura.TabIndex = 45;
            this.lblAltura.Text = "Altura:";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalle.Location = new System.Drawing.Point(34, 36);
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
            this.groupBox1.Location = new System.Drawing.Point(46, 110);
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
            // frmAltaModifEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 423);
            this.Controls.Add(this.gpbDireccion);
            this.Controls.Add(this.gpbUsuario);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.dtpFechaNac);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtCUIL);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblCUIL);
            this.Controls.Add(this.lblFechNacimiento);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.gpbContacto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Name = "frmAltaModifEmpleado";
            this.Text = "AgregarModifEmpleado";
            this.Load += new System.EventHandler(this.frmAltaModifEmpleado_Load);
            this.gpbContacto.ResumeLayout(false);
            this.gpbContacto.PerformLayout();
            this.gpbUsuario.ResumeLayout(false);
            this.gpbUsuario.PerformLayout();
            this.gpbDireccion.ResumeLayout(false);
            this.gpbDireccion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gpbContacto;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblTelLinea;
        private System.Windows.Forms.Label lblTelCelular;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtTelCelular;
        private System.Windows.Forms.TextBox txtTelLinea;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtCUIL;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblCUIL;
        private System.Windows.Forms.Label lblFechNacimiento;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.GroupBox gpbUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.RadioButton rdbAdministrador;
        private System.Windows.Forms.RadioButton rdbVendedor;
        private System.Windows.Forms.GroupBox gpbDireccion;
        private System.Windows.Forms.TextBox txtCPostal;
        private System.Windows.Forms.Label lblCPostal;
        private System.Windows.Forms.TextBox txtEntreCalle2;
        private System.Windows.Forms.TextBox txtEntreCalle1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPartido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAltura;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPiso;
    }
}