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
            this.panelDetalle = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblServicios = new System.Windows.Forms.Label();
            this.lblCita = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.cbMetodoPago = new System.Windows.Forms.ComboBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.txtServicios = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cbCita = new System.Windows.Forms.ComboBox();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblSubtotalTexto = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.lblNotas = new System.Windows.Forms.Label();
            this.cbServicio = new System.Windows.Forms.ComboBox();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblTabla = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cbFiltroFactura = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.panelDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDetalle
            // 
            this.panelDetalle.Controls.Add(this.lblSubtotalTexto);
            this.panelDetalle.Controls.Add(this.lblSubtotal);
            this.panelDetalle.Controls.Add(this.nudCantidad);
            this.panelDetalle.Controls.Add(this.txtServicios);
            this.panelDetalle.Controls.Add(this.lblCantidad);
            this.panelDetalle.Controls.Add(this.lblFecha);
            this.panelDetalle.Controls.Add(this.lblServicios);
            this.panelDetalle.Controls.Add(this.lblEstado);
            this.panelDetalle.Controls.Add(this.txtEmpleado);
            this.panelDetalle.Controls.Add(this.dtpFecha);
            this.panelDetalle.Controls.Add(this.lblNotas);
            this.panelDetalle.Controls.Add(this.txtNotas);
            this.panelDetalle.Controls.Add(this.lblMetodoPago);
            this.panelDetalle.Controls.Add(this.btnVerDetalle);
            this.panelDetalle.Controls.Add(this.lblReferencia);
            this.panelDetalle.Controls.Add(this.lblMonto);
            this.panelDetalle.Controls.Add(this.txtMonto);
            this.panelDetalle.Controls.Add(this.txtCliente);
            this.panelDetalle.Controls.Add(this.lblCita);
            this.panelDetalle.Controls.Add(this.txtReferencia);
            this.panelDetalle.Controls.Add(this.cbEstado);
            this.panelDetalle.Controls.Add(this.lblEmpleado);
            this.panelDetalle.Controls.Add(this.cbMetodoPago);
            this.panelDetalle.Controls.Add(this.cbCita);
            this.panelDetalle.Controls.Add(this.lblCliente);
            this.panelDetalle.Controls.Add(this.btnLimpiar);
            this.panelDetalle.Controls.Add(this.btnEliminar);
            this.panelDetalle.Controls.Add(this.btnActualizar);
            this.panelDetalle.Controls.Add(this.btnGuardar);
            this.panelDetalle.Controls.Add(this.cbServicio);
            this.panelDetalle.Controls.Add(this.lblServicio);
            this.panelDetalle.Location = new System.Drawing.Point(258, 28);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Size = new System.Drawing.Size(517, 979);
            this.panelDetalle.TabIndex = 0;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(42, 425);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(58, 20);
            this.lblFecha.TabIndex = 30;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(322, 425);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(64, 20);
            this.lblEstado.TabIndex = 29;
            this.lblEstado.Text = "Estado:";
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(42, 523);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(91, 20);
            this.lblReferencia.TabIndex = 28;
            this.lblReferencia.Text = "Referencia:";
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(322, 316);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(108, 20);
            this.lblMetodoPago.TabIndex = 27;
            this.lblMetodoPago.Text = "Metodo Pago:";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(42, 316);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(58, 20);
            this.lblMonto.TabIndex = 26;
            this.lblMonto.Text = "Monto:";
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(349, 224);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(85, 20);
            this.lblEmpleado.TabIndex = 25;
            this.lblEmpleado.Text = "Empleado:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(349, 150);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(62, 20);
            this.lblCliente.TabIndex = 24;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblServicios
            // 
            this.lblServicios.AutoSize = true;
            this.lblServicios.Location = new System.Drawing.Point(271, 95);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(76, 20);
            this.lblServicios.TabIndex = 23;
            this.lblServicios.Text = "Servicios:";
            // 
            // lblCita
            // 
            this.lblCita.AutoSize = true;
            this.lblCita.Location = new System.Drawing.Point(42, 150);
            this.lblCita.Name = "lblCita";
            this.lblCita.Size = new System.Drawing.Size(49, 20);
            this.lblCita.TabIndex = 22;
            this.lblCita.Text = "Citas:";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(46, 563);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(419, 26);
            this.txtReferencia.TabIndex = 21;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(46, 459);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(242, 26);
            this.dtpFecha.TabIndex = 20;
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(317, 457);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(148, 28);
            this.cbEstado.TabIndex = 19;
            // 
            // cbMetodoPago
            // 
            this.cbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetodoPago.FormattingEnabled = true;
            this.cbMetodoPago.Location = new System.Drawing.Point(317, 348);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(148, 28);
            this.cbMetodoPago.TabIndex = 18;
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMonto.Location = new System.Drawing.Point(46, 350);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(242, 26);
            this.txtMonto.TabIndex = 17;
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmpleado.Location = new System.Drawing.Point(353, 263);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(100, 26);
            this.txtEmpleado.TabIndex = 16;
            // 
            // txtServicios
            // 
            this.txtServicios.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtServicios.Location = new System.Drawing.Point(353, 89);
            this.txtServicios.Name = "txtServicios";
            this.txtServicios.ReadOnly = true;
            this.txtServicios.Size = new System.Drawing.Size(100, 26);
            this.txtServicios.TabIndex = 15;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCliente.Location = new System.Drawing.Point(353, 175);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(100, 26);
            this.txtCliente.TabIndex = 14;
            // 
            // cbCita
            // 
            this.cbCita.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbCita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCita.FormattingEnabled = true;
            this.cbCita.Location = new System.Drawing.Point(46, 173);
            this.cbCita.Name = "cbCita";
            this.cbCita.Size = new System.Drawing.Size(266, 28);
            this.cbCita.TabIndex = 13;
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.Location = new System.Drawing.Point(326, 701);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(150, 32);
            this.btnVerDetalle.TabIndex = 7;
            this.btnVerDetalle.Text = "Detalle Factura";
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(124, 892);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(287, 42);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(266, 827);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(145, 37);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(124, 827);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(136, 37);
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(124, 765);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(287, 45);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(393, 616);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(70, 20);
            this.lblSubtotal.TabIndex = 8;
            this.lblSubtotal.Text = "cantidad";
            // 
            // lblSubtotalTexto
            // 
            this.lblSubtotalTexto.AutoSize = true;
            this.lblSubtotalTexto.Location = new System.Drawing.Point(303, 616);
            this.lblSubtotalTexto.Name = "lblSubtotalTexto";
            this.lblSubtotalTexto.Size = new System.Drawing.Size(73, 20);
            this.lblSubtotalTexto.TabIndex = 7;
            this.lblSubtotalTexto.Text = "Subtotal:";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(125, 91);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 26);
            this.nudCantidad.TabIndex = 6;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(42, 95);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(77, 20);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(46, 655);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(253, 78);
            this.txtNotas.TabIndex = 4;
            // 
            // lblNotas
            // 
            this.lblNotas.AutoSize = true;
            this.lblNotas.Location = new System.Drawing.Point(42, 616);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(96, 20);
            this.lblNotas.TabIndex = 3;
            this.lblNotas.Text = "Descripcion:";
            // 
            // cbServicio
            // 
            this.cbServicio.FormattingEnabled = true;
            this.cbServicio.Location = new System.Drawing.Point(46, 261);
            this.cbServicio.Name = "cbServicio";
            this.cbServicio.Size = new System.Drawing.Size(266, 28);
            this.cbServicio.TabIndex = 2;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Location = new System.Drawing.Point(42, 224);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(68, 20);
            this.lblServicio.TabIndex = 1;
            this.lblServicio.Text = "Servicio:";
            // 
            // lblTabla
            // 
            this.lblTabla.AutoSize = true;
            this.lblTabla.Location = new System.Drawing.Point(839, 38);
            this.lblTabla.Name = "lblTabla";
            this.lblTabla.Size = new System.Drawing.Size(144, 20);
            this.lblTabla.TabIndex = 1;
            this.lblTabla.Text = "Pagos Registrados";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(843, 120);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(303, 26);
            this.txtBuscar.TabIndex = 2;
            // 
            // cbFiltroFactura
            // 
            this.cbFiltroFactura.FormattingEnabled = true;
            this.cbFiltroFactura.Location = new System.Drawing.Point(1307, 118);
            this.cbFiltroFactura.Name = "cbFiltroFactura";
            this.cbFiltroFactura.Size = new System.Drawing.Size(121, 28);
            this.cbFiltroFactura.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1152, 113);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(92, 40);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(843, 196);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 62;
            this.dgvDetalle.RowTemplate.Height = 28;
            this.dgvDetalle.Size = new System.Drawing.Size(682, 600);
            this.dgvDetalle.TabIndex = 5;
            // 
            // panelTabla
            // 
            this.panelTabla.Location = new System.Drawing.Point(834, 185);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(709, 628);
            this.panelTabla.TabIndex = 6;
            // 
            // FrmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1651, 1014);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbFiltroFactura);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblTabla);
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.panelTabla);
            this.Name = "FrmFactura";
            this.Text = "FrmFacturaPagos";
            this.Load += new System.EventHandler(this.FrmFacturaPagos_Load);
            this.panelDetalle.ResumeLayout(false);
            this.panelDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.Label lblNotas;
        private System.Windows.Forms.ComboBox cbServicio;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblSubtotalTexto;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblTabla;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cbFiltroFactura;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.ComboBox cbCita;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.TextBox txtServicios;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.ComboBox cbMetodoPago;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblServicios;
        private System.Windows.Forms.Label lblCita;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblEstado;
    }
}