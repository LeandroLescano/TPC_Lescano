﻿namespace PresWinForm
{
    partial class frmModifPedidos
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
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblFechRetiro = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCombo = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.dtpFechRetiro = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.dtpFechaSolicitud = new System.Windows.Forms.DateTimePicker();
            this.lblFechaSolicitud = new System.Windows.Forms.Label();
            this.btnDetallesCliente = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblSeparador = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCombo
            // 
            this.lblCombo.AutoSize = true;
            this.lblCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCombo.Location = new System.Drawing.Point(12, 58);
            this.lblCombo.Name = "lblCombo";
            this.lblCombo.Size = new System.Drawing.Size(56, 17);
            this.lblCombo.TabIndex = 0;
            this.lblCombo.Text = "Combo:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(12, 134);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(55, 17);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(12, 96);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(52, 17);
            this.lblPrecio.TabIndex = 2;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblFechRetiro
            // 
            this.lblFechRetiro.AutoSize = true;
            this.lblFechRetiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechRetiro.Location = new System.Drawing.Point(339, 78);
            this.lblFechRetiro.Name = "lblFechRetiro";
            this.lblFechRetiro.Size = new System.Drawing.Size(124, 17);
            this.lblFechRetiro.TabIndex = 3;
            this.lblFechRetiro.Text = "Fecha de entrega:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(339, 137);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(56, 17);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(12, 20);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(25, 17);
            this.lblID.TabIndex = 6;
            this.lblID.Text = "ID:";
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = true;
            this.lblObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacion.Location = new System.Drawing.Point(12, 166);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(92, 17);
            this.lblObservacion.TabIndex = 7;
            this.lblObservacion.Text = "Observación:";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(83, 17);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtID.Size = new System.Drawing.Size(157, 23);
            this.txtID.TabIndex = 8;
            // 
            // txtCombo
            // 
            this.txtCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCombo.Location = new System.Drawing.Point(83, 55);
            this.txtCombo.Name = "txtCombo";
            this.txtCombo.ReadOnly = true;
            this.txtCombo.Size = new System.Drawing.Size(157, 23);
            this.txtCombo.TabIndex = 9;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(83, 93);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(157, 23);
            this.txtPrecio.TabIndex = 10;
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(83, 131);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(157, 23);
            this.txtCliente.TabIndex = 11;
            // 
            // dtpFechRetiro
            // 
            this.dtpFechRetiro.CustomFormat = "\'  \'dd \'de\'MMM\'del\' yyyy";
            this.dtpFechRetiro.Enabled = false;
            this.dtpFechRetiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechRetiro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechRetiro.Location = new System.Drawing.Point(474, 78);
            this.dtpFechRetiro.MaxDate = new System.DateTime(2500, 12, 31, 0, 0, 0, 0);
            this.dtpFechRetiro.Name = "dtpFechRetiro";
            this.dtpFechRetiro.Size = new System.Drawing.Size(158, 23);
            this.dtpFechRetiro.TabIndex = 15;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(538, 367);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 27);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.AutoSize = true;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(364, 367);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(143, 27);
            this.btnModificar.TabIndex = 16;
            this.btnModificar.Text = "Modificar e informar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtEstado
            // 
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(475, 136);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(157, 23);
            this.txtEstado.TabIndex = 18;
            // 
            // btnDetalles
            // 
            this.btnDetalles.AutoSize = true;
            this.btnDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalles.Location = new System.Drawing.Point(246, 53);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(69, 27);
            this.btnDetalles.TabIndex = 23;
            this.btnDetalles.Text = "Detalles";
            this.btnDetalles.UseVisualStyleBackColor = true;
            this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
            // 
            // dtpFechaSolicitud
            // 
            this.dtpFechaSolicitud.CustomFormat = "\'  \'dd \'de\'MMM\'del\' yyyy";
            this.dtpFechaSolicitud.Enabled = false;
            this.dtpFechaSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaSolicitud.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaSolicitud.Location = new System.Drawing.Point(475, 20);
            this.dtpFechaSolicitud.MaxDate = new System.DateTime(2500, 12, 31, 0, 0, 0, 0);
            this.dtpFechaSolicitud.Name = "dtpFechaSolicitud";
            this.dtpFechaSolicitud.Size = new System.Drawing.Size(158, 23);
            this.dtpFechaSolicitud.TabIndex = 25;
            // 
            // lblFechaSolicitud
            // 
            this.lblFechaSolicitud.AutoSize = true;
            this.lblFechaSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaSolicitud.Location = new System.Drawing.Point(339, 20);
            this.lblFechaSolicitud.Name = "lblFechaSolicitud";
            this.lblFechaSolicitud.Size = new System.Drawing.Size(106, 17);
            this.lblFechaSolicitud.TabIndex = 24;
            this.lblFechaSolicitud.Text = "Fecha solicitud:";
            // 
            // btnDetallesCliente
            // 
            this.btnDetallesCliente.AutoSize = true;
            this.btnDetallesCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetallesCliente.Location = new System.Drawing.Point(246, 129);
            this.btnDetallesCliente.Name = "btnDetallesCliente";
            this.btnDetallesCliente.Size = new System.Drawing.Size(69, 27);
            this.btnDetallesCliente.TabIndex = 26;
            this.btnDetallesCliente.Text = "Detalles";
            this.btnDetallesCliente.UseVisualStyleBackColor = true;
            this.btnDetallesCliente.Click += new System.EventHandler(this.btnDetallesCliente_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(12, 186);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ReadOnly = true;
            this.txtObservaciones.Size = new System.Drawing.Size(620, 79);
            this.txtObservaciones.TabIndex = 13;
            // 
            // txtComentario
            // 
            this.txtComentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(8, 302);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(324, 92);
            this.txtComentario.TabIndex = 19;
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComentario.Location = new System.Drawing.Point(5, 282);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(80, 17);
            this.lblComentario.TabIndex = 20;
            this.lblComentario.Text = "Comentario";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(355, 327);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(277, 24);
            this.cmbEstado.TabIndex = 21;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(352, 302);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(83, 13);
            this.lblMail.TabIndex = 22;
            this.lblMail.Text = "Mail del cliente: ";
            // 
            // lblSeparador
            // 
            this.lblSeparador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparador.Location = new System.Drawing.Point(8, 274);
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(630, 2);
            this.lblSeparador.TabIndex = 27;
            // 
            // frmModifPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 406);
            this.Controls.Add(this.lblSeparador);
            this.Controls.Add(this.btnDetallesCliente);
            this.Controls.Add(this.dtpFechaSolicitud);
            this.Controls.Add(this.lblFechaSolicitud);
            this.Controls.Add(this.btnDetalles);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dtpFechRetiro);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtCombo);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblObservacion);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblFechRetiro);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblCombo);
            this.Name = "frmModifPedidos";
            this.Text = "frmModifPedidos";
            this.Load += new System.EventHandler(this.frmModifPedidos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCombo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblFechRetiro;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtCombo;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.DateTimePicker dtpFechRetiro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.DateTimePicker dtpFechaSolicitud;
        private System.Windows.Forms.Label lblFechaSolicitud;
        private System.Windows.Forms.Button btnDetallesCliente;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblSeparador;
    }
}