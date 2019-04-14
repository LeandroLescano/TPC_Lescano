namespace PresWinForm
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tspCompras = new System.Windows.Forms.ToolStripButton();
            this.tspVentas = new System.Windows.Forms.ToolStripButton();
            this.tspEstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspEstatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspCompras,
            this.toolStripSeparator1,
            this.tspVentas});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tspCompras
            // 
            this.tspCompras.Image = ((System.Drawing.Image)(resources.GetObject("tspCompras.Image")));
            this.tspCompras.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspCompras.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tspCompras.Name = "tspCompras";
            this.tspCompras.Size = new System.Drawing.Size(75, 22);
            this.tspCompras.Text = "Compras";
            this.tspCompras.Click += new System.EventHandler(this.tspCompras_Click);
            // 
            // tspVentas
            // 
            this.tspVentas.Image = ((System.Drawing.Image)(resources.GetObject("tspVentas.Image")));
            this.tspVentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspVentas.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tspVentas.Name = "tspVentas";
            this.tspVentas.Size = new System.Drawing.Size(61, 22);
            this.tspVentas.Text = "Ventas";
            // 
            // tspEstatus
            // 
            this.tspEstatus.Name = "tspEstatus";
            this.tspEstatus.Size = new System.Drawing.Size(100, 17);
            this.tspEstatus.Text = "Logueado como: ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de gestión";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tspCompras;
        private System.Windows.Forms.ToolStripButton tspVentas;
        private System.Windows.Forms.ToolStripStatusLabel tspEstatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

