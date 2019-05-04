namespace PresWinForm
{
    partial class frmProveedoresXProducto
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
            this.dgvProvXProd = new System.Windows.Forms.DataGridView();
            this.lblProducto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvXProd)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProvXProd
            // 
            this.dgvProvXProd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProvXProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProvXProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProvXProd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProvXProd.Location = new System.Drawing.Point(12, 32);
            this.dgvProvXProd.MultiSelect = false;
            this.dgvProvXProd.Name = "dgvProvXProd";
            this.dgvProvXProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProvXProd.Size = new System.Drawing.Size(544, 406);
            this.dgvProvXProd.TabIndex = 0;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(12, 9);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(128, 20);
            this.lblProducto.TabIndex = 1;
            this.lblProducto.Text = "Proveedores de: ";
            // 
            // frmProveedoresXProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 450);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.dgvProvXProd);
            this.Name = "frmProveedoresXProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProveedoresXProducto";
            this.Load += new System.EventHandler(this.frmProveedoresXProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvXProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProvXProd;
        private System.Windows.Forms.Label lblProducto;
    }
}