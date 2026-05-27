namespace Capa_Presentacion
{
    partial class FrmHistorialFacturas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnVerTodos = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnMostrarTodoDetalle = new System.Windows.Forms.Button();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.txtDetalleBuscar = new System.Windows.Forms.TextBox();
            this.cbFiltroDetalle = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            this.lblFiltro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.panelTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(14, 14);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersWidth = 62;
            this.dgvHistorial.Size = new System.Drawing.Size(996, 280);
            this.dgvHistorial.TabIndex = 0;
            // 
            // panelTabla
            // 
            this.panelTabla.Controls.Add(this.dgvHistorial);
            this.panelTabla.Location = new System.Drawing.Point(590, 150);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(1030, 308);
            this.panelTabla.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(628, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(155, 20);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Historial de Facturas";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Location = new System.Drawing.Point(629, 62);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(208, 20);
            this.lblSubtitulo.TabIndex = 3;
            this.lblSubtitulo.Text = "Registro completo de pagos";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(1006, 86);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(219, 26);
            this.txtBuscar.TabIndex = 4;
            // 
            // cbFiltroEstado
            // 
            this.cbFiltroEstado.FormattingEnabled = true;
            this.cbFiltroEstado.Location = new System.Drawing.Point(1344, 86);
            this.cbFiltroEstado.Name = "cbFiltroEstado";
            this.cbFiltroEstado.Size = new System.Drawing.Size(121, 28);
            this.cbFiltroEstado.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1239, 72);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 44);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            // 
            // btnVerTodos
            // 
            this.btnVerTodos.Location = new System.Drawing.Point(1479, 72);
            this.btnVerTodos.Name = "btnVerTodos";
            this.btnVerTodos.Size = new System.Drawing.Size(110, 44);
            this.btnVerTodos.TabIndex = 7;
            this.btnVerTodos.Text = "Ver Todos";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(593, 464);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(90, 36);
            this.btnVolver.TabIndex = 9;
            this.btnVolver.Text = "← Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnMostrarTodoDetalle
            // 
            this.btnMostrarTodoDetalle.Location = new System.Drawing.Point(1315, 531);
            this.btnMostrarTodoDetalle.Name = "btnMostrarTodoDetalle";
            this.btnMostrarTodoDetalle.Size = new System.Drawing.Size(184, 36);
            this.btnMostrarTodoDetalle.TabIndex = 105;
            this.btnMostrarTodoDetalle.Text = "Mostrar Todo";
            this.btnMostrarTodoDetalle.UseVisualStyleBackColor = true;
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Location = new System.Drawing.Point(1160, 529);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(101, 38);
            this.btnVerDetalle.TabIndex = 104;
            this.btnVerDetalle.Text = "Buscar";
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            // 
            // txtDetalleBuscar
            // 
            this.txtDetalleBuscar.Location = new System.Drawing.Point(786, 535);
            this.txtDetalleBuscar.Name = "txtDetalleBuscar";
            this.txtDetalleBuscar.Size = new System.Drawing.Size(123, 26);
            this.txtDetalleBuscar.TabIndex = 103;
            // 
            // cbFiltroDetalle
            // 
            this.cbFiltroDetalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroDetalle.FormattingEnabled = true;
            this.cbFiltroDetalle.Location = new System.Drawing.Point(1016, 535);
            this.cbFiltroDetalle.Name = "cbFiltroDetalle";
            this.cbFiltroDetalle.Size = new System.Drawing.Size(121, 28);
            this.cbFiltroDetalle.TabIndex = 102;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(703, 539);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(63, 20);
            this.lblBuscar.TabIndex = 101;
            this.lblBuscar.Text = "Buscar:";
            // 
            // dgvDetalleFactura
            // 
            this.dgvDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleFactura.Location = new System.Drawing.Point(695, 595);
            this.dgvDetalleFactura.Name = "dgvDetalleFactura";
            this.dgvDetalleFactura.RowHeadersWidth = 62;
            this.dgvDetalleFactura.RowTemplate.Height = 28;
            this.dgvDetalleFactura.Size = new System.Drawing.Size(804, 213);
            this.dgvDetalleFactura.TabIndex = 100;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(962, 538);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(48, 20);
            this.lblFiltro.TabIndex = 99;
            this.lblFiltro.Text = "Filtro:";
            // 
            // FrmHistorialFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1753, 820);
            this.Controls.Add(this.btnMostrarTodoDetalle);
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.txtDetalleBuscar);
            this.Controls.Add(this.cbFiltroDetalle);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.dgvDetalleFactura);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnVerTodos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbFiltroEstado);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelTabla);
            this.Name = "FrmHistorialFacturas";
            this.Text = "Historial de Facturas";
            this.Load += new System.EventHandler(this.FrmHistorialFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.panelTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cbFiltroEstado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnVerTodos;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnMostrarTodoDetalle;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.TextBox txtDetalleBuscar;
        private System.Windows.Forms.ComboBox cbFiltroDetalle;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DataGridView dgvDetalleFactura;
        private System.Windows.Forms.Label lblFiltro;
    }
}