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
            this.lblTabla = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnNuevaFactura = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.btnActualizarEstado = new System.Windows.Forms.Button();
            this.btnMostrarTodoDetalle = new System.Windows.Forms.Button();
            this.btnBuscarFactura = new System.Windows.Forms.Button();
            this.txtBuscarDetalle = new System.Windows.Forms.TextBox();
            this.lblBuscarDetalle = new System.Windows.Forms.Label();
            this.dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTabla
            // 
            this.lblTabla.AutoSize = true;
            this.lblTabla.Location = new System.Drawing.Point(862, 53);
            this.lblTabla.Name = "lblTabla";
            this.lblTabla.Size = new System.Drawing.Size(144, 20);
            this.lblTabla.TabIndex = 1;
            this.lblTabla.Text = "Pagos Registrados";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(637, 127);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(281, 26);
            this.txtBuscar.TabIndex = 2;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(612, 195);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 62;
            this.dgvDetalle.RowTemplate.Height = 28;
            this.dgvDetalle.Size = new System.Drawing.Size(1169, 313);
            this.dgvDetalle.TabIndex = 5;
            // 
            // panelTabla
            // 
            this.panelTabla.Location = new System.Drawing.Point(600, 184);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(1193, 340);
            this.panelTabla.TabIndex = 6;
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(656, 549);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(234, 55);
            this.btnHistorial.TabIndex = 7;
            this.btnHistorial.Text = "Ver Historial ";
            this.btnHistorial.UseVisualStyleBackColor = true;
            // 
            // btnNuevaFactura
            // 
            this.btnNuevaFactura.Location = new System.Drawing.Point(1390, 111);
            this.btnNuevaFactura.Name = "btnNuevaFactura";
            this.btnNuevaFactura.Size = new System.Drawing.Size(194, 55);
            this.btnNuevaFactura.TabIndex = 8;
            this.btnNuevaFactura.Text = "Nueva Factura";
            this.btnNuevaFactura.UseVisualStyleBackColor = true;
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(1437, 563);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(121, 28);
            this.cbEstado.TabIndex = 9;
            // 
            // btnActualizarEstado
            // 
            this.btnActualizarEstado.Location = new System.Drawing.Point(1592, 551);
            this.btnActualizarEstado.Name = "btnActualizarEstado";
            this.btnActualizarEstado.Size = new System.Drawing.Size(174, 50);
            this.btnActualizarEstado.TabIndex = 10;
            this.btnActualizarEstado.Text = "Actualizar Estado";
            this.btnActualizarEstado.UseVisualStyleBackColor = true;
            this.btnActualizarEstado.Click += new System.EventHandler(this.btnActualizarEstado_Click);
            // 
            // btnMostrarTodoDetalle
            // 
            this.btnMostrarTodoDetalle.Location = new System.Drawing.Point(1569, 717);
            this.btnMostrarTodoDetalle.Name = "btnMostrarTodoDetalle";
            this.btnMostrarTodoDetalle.Size = new System.Drawing.Size(184, 36);
            this.btnMostrarTodoDetalle.TabIndex = 105;
            this.btnMostrarTodoDetalle.Text = "Mostrar Todo";
            this.btnMostrarTodoDetalle.UseVisualStyleBackColor = true;
            // 
            // btnBuscarFactura
            // 
            this.btnBuscarFactura.Location = new System.Drawing.Point(945, 715);
            this.btnBuscarFactura.Name = "btnBuscarFactura";
            this.btnBuscarFactura.Size = new System.Drawing.Size(101, 38);
            this.btnBuscarFactura.TabIndex = 104;
            this.btnBuscarFactura.Text = "Buscar";
            this.btnBuscarFactura.UseVisualStyleBackColor = true;
            // 
            // txtBuscarDetalle
            // 
            this.txtBuscarDetalle.Location = new System.Drawing.Point(782, 721);
            this.txtBuscarDetalle.Name = "txtBuscarDetalle";
            this.txtBuscarDetalle.Size = new System.Drawing.Size(123, 26);
            this.txtBuscarDetalle.TabIndex = 103;
            // 
            // lblBuscarDetalle
            // 
            this.lblBuscarDetalle.AutoSize = true;
            this.lblBuscarDetalle.Location = new System.Drawing.Point(699, 725);
            this.lblBuscarDetalle.Name = "lblBuscarDetalle";
            this.lblBuscarDetalle.Size = new System.Drawing.Size(63, 20);
            this.lblBuscarDetalle.TabIndex = 101;
            this.lblBuscarDetalle.Text = "Buscar:";
            // 
            // dgvDetalleFactura
            // 
            this.dgvDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleFactura.Location = new System.Drawing.Point(640, 789);
            this.dgvDetalleFactura.Name = "dgvDetalleFactura";
            this.dgvDetalleFactura.RowHeadersWidth = 62;
            this.dgvDetalleFactura.RowTemplate.Height = 28;
            this.dgvDetalleFactura.Size = new System.Drawing.Size(1126, 213);
            this.dgvDetalleFactura.TabIndex = 100;
            // 
            // FrmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1014);
            this.Controls.Add(this.btnMostrarTodoDetalle);
            this.Controls.Add(this.btnBuscarFactura);
            this.Controls.Add(this.txtBuscarDetalle);
            this.Controls.Add(this.lblBuscarDetalle);
            this.Controls.Add(this.dgvDetalleFactura);
            this.Controls.Add(this.btnActualizarEstado);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.btnNuevaFactura);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblTabla);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.panelTabla);
            this.Name = "FrmFactura";
            this.Text = "FrmFacturaPagos";
            this.Load += new System.EventHandler(this.FrmFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTabla;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnNuevaFactura;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Button btnActualizarEstado;
        private System.Windows.Forms.Button btnMostrarTodoDetalle;
        private System.Windows.Forms.Button btnBuscarFactura;
        private System.Windows.Forms.TextBox txtBuscarDetalle;
        private System.Windows.Forms.Label lblBuscarDetalle;
        private System.Windows.Forms.DataGridView dgvDetalleFactura;
    }
}