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
            this.tspEstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspMenu = new System.Windows.Forms.ToolStrip();
            this.btnCompras = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnVentas = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPedidos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnProductos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnProveedores = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClientes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEmpleados = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.tspMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspEstatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 503);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1088, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tspEstatus
            // 
            this.tspEstatus.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tspEstatus.Name = "tspEstatus";
            this.tspEstatus.Size = new System.Drawing.Size(100, 17);
            this.tspEstatus.Text = "Logueado como: ";
            // 
            // tspMenu
            // 
            this.tspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCompras,
            this.toolStripSeparator1,
            this.btnVentas,
            this.toolStripSeparator2,
            this.btnPedidos,
            this.toolStripSeparator3,
            this.btnProductos,
            this.toolStripSeparator4,
            this.btnProveedores,
            this.toolStripSeparator5,
            this.btnClientes,
            this.toolStripSeparator6,
            this.btnEmpleados});
            this.tspMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tspMenu.Location = new System.Drawing.Point(0, 0);
            this.tspMenu.Name = "tspMenu";
            this.tspMenu.Size = new System.Drawing.Size(1088, 37);
            this.tspMenu.TabIndex = 1;
            this.tspMenu.Text = "toolStrip1";
            // 
            // btnCompras
            // 
            this.btnCompras.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCompras.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnCompras.Image = ((System.Drawing.Image)(resources.GetObject("btnCompras.Image")));
            this.btnCompras.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(94, 32);
            this.btnCompras.Text = "Compras";
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.toolStripSeparator1.MergeIndex = 0;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // btnVentas
            // 
            this.btnVentas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnVentas.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas.Image")));
            this.btnVentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(73, 32);
            this.btnVentas.Text = "Ventas";
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.toolStripSeparator2.MergeIndex = 0;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // btnPedidos
            // 
            this.btnPedidos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPedidos.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnPedidos.Image = ((System.Drawing.Image)(resources.GetObject("btnPedidos.Image")));
            this.btnPedidos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(85, 32);
            this.btnPedidos.Text = "Pedidos";
            this.btnPedidos.Click += new System.EventHandler(this.btnPedidos_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.toolStripSeparator3.MergeIndex = 0;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // btnProductos
            // 
            this.btnProductos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductos.Image")));
            this.btnProductos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(105, 32);
            this.btnProductos.Text = "Productos";
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.toolStripSeparator4.MergeIndex = 0;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 35);
            // 
            // btnProveedores
            // 
            this.btnProveedores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnProveedores.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnProveedores.Image = ((System.Drawing.Image)(resources.GetObject("btnProveedores.Image")));
            this.btnProveedores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(125, 32);
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.AutoSize = false;
            this.toolStripSeparator5.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.toolStripSeparator5.MergeIndex = 0;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 35);
            // 
            // btnClientes
            // 
            this.btnClientes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(84, 32);
            this.btnClientes.Text = "Clientes";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.AutoSize = false;
            this.toolStripSeparator6.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.toolStripSeparator6.MergeIndex = 0;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 35);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEmpleados.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnEmpleados.Image = ((System.Drawing.Image)(resources.GetObject("btnEmpleados.Image")));
            this.btnEmpleados.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(112, 32);
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1088, 525);
            this.Controls.Add(this.tspMenu);
            this.Controls.Add(this.statusStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.Text = "Sistema de gestión";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tspMenu.ResumeLayout(false);
            this.tspMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tspEstatus;
        private System.Windows.Forms.ToolStrip tspMenu;
        private System.Windows.Forms.ToolStripButton btnCompras;
        private System.Windows.Forms.ToolStripButton btnVentas;
        private System.Windows.Forms.ToolStripButton btnPedidos;
        private System.Windows.Forms.ToolStripButton btnProductos;
        private System.Windows.Forms.ToolStripButton btnProveedores;
        private System.Windows.Forms.ToolStripButton btnClientes;
        private System.Windows.Forms.ToolStripButton btnEmpleados;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}

