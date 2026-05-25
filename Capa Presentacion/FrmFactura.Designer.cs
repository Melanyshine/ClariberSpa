namespace Capa_Presentacion
{
    partial class FrmFactura
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
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.lblTabla = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cbFiltroFactura = new System.Windows.Forms.ComboBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnNuevaFactura = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.btnActualizarEstado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Location = new System.Drawing.Point(637, 832);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(242, 55);
            this.btnVerDetalle.TabIndex = 7;
            this.btnVerDetalle.Text = "Detalle Factura";
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            // 
            // lblTabla
            // 
            this.lblTabla.AutoSize = true;
            this.lblTabla.Location = new System.Drawing.Point(860, 90);
            this.lblTabla.Name = "lblTabla";
            this.lblTabla.Size = new System.Drawing.Size(144, 20);
            this.lblTabla.TabIndex = 1;
            this.lblTabla.Text = "Pagos Registrados";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(634, 206);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(281, 26);
            this.txtBuscar.TabIndex = 2;
            // 
            // cbFiltroFactura
            // 
            this.cbFiltroFactura.FormattingEnabled = true;
            this.cbFiltroFactura.Location = new System.Drawing.Point(942, 206);
            this.cbFiltroFactura.Name = "cbFiltroFactura";
            this.cbFiltroFactura.Size = new System.Drawing.Size(142, 28);
            this.cbFiltroFactura.TabIndex = 3;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(637, 274);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 62;
            this.dgvDetalle.RowTemplate.Height = 28;
            this.dgvDetalle.Size = new System.Drawing.Size(932, 521);
            this.dgvDetalle.TabIndex = 5;
            // 
            // panelTabla
            // 
            this.panelTabla.Location = new System.Drawing.Point(625, 263);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(956, 548);
            this.panelTabla.TabIndex = 6;
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(906, 832);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(234, 55);
            this.btnHistorial.TabIndex = 7;
            this.btnHistorial.Text = "Ver Historial ";
            this.btnHistorial.UseVisualStyleBackColor = true;
            // 
            // btnNuevaFactura
            // 
            this.btnNuevaFactura.Location = new System.Drawing.Point(1387, 190);
            this.btnNuevaFactura.Name = "btnNuevaFactura";
            this.btnNuevaFactura.Size = new System.Drawing.Size(194, 55);
            this.btnNuevaFactura.TabIndex = 8;
            this.btnNuevaFactura.Text = "Nueva Factura";
            this.btnNuevaFactura.UseVisualStyleBackColor = true;
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(1308, 846);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(121, 28);
            this.cbEstado.TabIndex = 9;
            // 
            // btnActualizarEstado
            // 
            this.btnActualizarEstado.Location = new System.Drawing.Point(1463, 834);
            this.btnActualizarEstado.Name = "btnActualizarEstado";
            this.btnActualizarEstado.Size = new System.Drawing.Size(174, 50);
            this.btnActualizarEstado.TabIndex = 10;
            this.btnActualizarEstado.Text = "Actualizar Estado";
            this.btnActualizarEstado.UseVisualStyleBackColor = true;
            this.btnActualizarEstado.Click += new System.EventHandler(this.btnActualizarEstado_Click);
            // 
            // FrmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1014);
            this.Controls.Add(this.btnActualizarEstado);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.btnNuevaFactura);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.cbFiltroFactura);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblTabla);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.panelTabla);
            this.Controls.Add(this.btnVerDetalle);
            this.Name = "FrmFactura";
            this.Text = "FrmFacturaPagos";
            this.Load += new System.EventHandler(this.FrmFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTabla;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cbFiltroFactura;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnNuevaFactura;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Button btnActualizarEstado;
    }
}