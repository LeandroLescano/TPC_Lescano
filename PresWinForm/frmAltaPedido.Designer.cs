namespace PresWinForm
{
    partial class frmAltaPedido
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
            this.lblCombo = new System.Windows.Forms.Label();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCombo = new System.Windows.Forms.ComboBox();
            this.dtpEntrega = new System.Windows.Forms.DateTimePicker();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dtpSolicitud = new System.Windows.Forms.DateTimePicker();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.btnNuevoCombo = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblSigno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCombo
            // 
            this.lblCombo.AutoSize = true;
            this.lblCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCombo.Location = new System.Drawing.Point(12, 9);
            this.lblCombo.Name = "lblCombo";
            this.lblCombo.Size = new System.Drawing.Size(64, 20);
            this.lblCombo.TabIndex = 0;
            this.lblCombo.Text = "Combo:";
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacion.Location = new System.Drawing.Point(10, 234);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(101, 20);
            this.lblObservacion.TabIndex = 1;
            this.lblObservacion.Text = "Observación:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha de entrega:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha de solicitud:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Precio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Estado:";
            // 
            // cmbCombo
            // 
            this.cmbCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCombo.FormattingEnabled = true;
            this.cmbCombo.Location = new System.Drawing.Point(153, 8);
            this.cmbCombo.Name = "cmbCombo";
            this.cmbCombo.Size = new System.Drawing.Size(210, 28);
            this.cmbCombo.TabIndex = 7;
            this.cmbCombo.SelectedIndexChanged += new System.EventHandler(this.cmbCombo_SelectedIndexChanged);
            // 
            // dtpEntrega
            // 
            this.dtpEntrega.CustomFormat = "d \'de\' MMMM \'del\' yyyy";
            this.dtpEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEntrega.Location = new System.Drawing.Point(153, 88);
            this.dtpEntrega.Name = "dtpEntrega";
            this.dtpEntrega.Size = new System.Drawing.Size(210, 24);
            this.dtpEntrega.TabIndex = 8;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(153, 160);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrecio.Size = new System.Drawing.Size(105, 26);
            this.txtPrecio.TabIndex = 9;
            // 
            // cmbClientes
            // 
            this.cmbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(153, 48);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(210, 28);
            this.cmbClientes.TabIndex = 10;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(153, 198);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbEstado.Size = new System.Drawing.Size(210, 28);
            this.cmbEstado.TabIndex = 11;
            // 
            // dtpSolicitud
            // 
            this.dtpSolicitud.CustomFormat = "d \'de\' MMMM \'del\' yyyy";
            this.dtpSolicitud.Enabled = false;
            this.dtpSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSolicitud.Location = new System.Drawing.Point(153, 124);
            this.dtpSolicitud.Name = "dtpSolicitud";
            this.dtpSolicitud.Size = new System.Drawing.Size(210, 24);
            this.dtpSolicitud.TabIndex = 12;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacion.Location = new System.Drawing.Point(14, 257);
            this.txtObservacion.MaxLength = 1024;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(430, 77);
            this.txtObservacion.TabIndex = 13;
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.AutoSize = true;
            this.btnNuevoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoCliente.Location = new System.Drawing.Point(369, 46);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(75, 30);
            this.btnNuevoCliente.TabIndex = 14;
            this.btnNuevoCliente.Text = "Nuevo";
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // btnNuevoCombo
            // 
            this.btnNuevoCombo.AutoSize = true;
            this.btnNuevoCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoCombo.Location = new System.Drawing.Point(369, 6);
            this.btnNuevoCombo.Name = "btnNuevoCombo";
            this.btnNuevoCombo.Size = new System.Drawing.Size(75, 30);
            this.btnNuevoCombo.TabIndex = 15;
            this.btnNuevoCombo.Text = "Nuevo";
            this.btnNuevoCombo.UseVisualStyleBackColor = true;
            this.btnNuevoCombo.Click += new System.EventHandler(this.btnNuevoCombo_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(131, 350);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 30);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(271, 350);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(82, 30);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblSigno
            // 
            this.lblSigno.AutoSize = true;
            this.lblSigno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSigno.Location = new System.Drawing.Point(135, 163);
            this.lblSigno.Name = "lblSigno";
            this.lblSigno.Size = new System.Drawing.Size(18, 20);
            this.lblSigno.TabIndex = 18;
            this.lblSigno.Text = "$";
            // 
            // frmAltaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 395);
            this.Controls.Add(this.lblSigno);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnNuevoCombo);
            this.Controls.Add(this.btnNuevoCliente);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.dtpSolicitud);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.dtpEntrega);
            this.Controls.Add(this.cmbCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblObservacion);
            this.Controls.Add(this.lblCombo);
            this.Name = "frmAltaPedido";
            this.Text = "Nuevo pedido";
            this.Load += new System.EventHandler(this.frmAltaPedido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCombo;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCombo;
        private System.Windows.Forms.DateTimePicker dtpEntrega;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DateTimePicker dtpSolicitud;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Button btnNuevoCombo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblSigno;
    }
}