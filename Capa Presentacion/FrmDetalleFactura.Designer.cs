namespace Capa_Presentacion
{
    partial class FrmDetalleFactura
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
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.panelDetalle = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.txtCita = new System.Windows.Forms.TextBox();
            this.lblSubtotalTexto = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblNotas = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblCita = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.cbMetodoPago = new System.Windows.Forms.ComboBox();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.lblServicio = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.panelDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(603, 683);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(63, 20);
            this.lblBuscar.TabIndex = 87;
            this.lblBuscar.Text = "Buscar:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(828, 594);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(118, 20);
            this.lblTitulo.TabIndex = 85;
            this.lblTitulo.Text = "Detalle Factura";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(446, 980);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(182, 45);
            this.btnCerrar.TabIndex = 83;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(595, 739);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.RowHeadersWidth = 62;
            this.dgvDetalle.RowTemplate.Height = 28;
            this.dgvDetalle.Size = new System.Drawing.Size(804, 213);
            this.dgvDetalle.TabIndex = 82;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(862, 682);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(48, 20);
            this.lblFiltro.TabIndex = 74;
            this.lblFiltro.Text = "Filtro:";
            // 
            // cbFiltro
            // 
            this.cbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Location = new System.Drawing.Point(916, 679);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(121, 28);
            this.cbFiltro.TabIndex = 92;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(686, 679);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(123, 26);
            this.txtBuscar.TabIndex = 94;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1060, 673);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(101, 38);
            this.btnBuscar.TabIndex = 95;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(1215, 675);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(184, 36);
            this.btnMostrar.TabIndex = 98;
            this.btnMostrar.Text = "Mostrar Todo";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // panelDetalle
            // 
            this.panelDetalle.Controls.Add(this.checkedListBox1);
            this.panelDetalle.Controls.Add(this.txtCita);
            this.panelDetalle.Controls.Add(this.lblSubtotalTexto);
            this.panelDetalle.Controls.Add(this.lblSubtotal);
            this.panelDetalle.Controls.Add(this.lblFecha);
            this.panelDetalle.Controls.Add(this.lblEstado);
            this.panelDetalle.Controls.Add(this.txtEmpleado);
            this.panelDetalle.Controls.Add(this.dtpFecha);
            this.panelDetalle.Controls.Add(this.lblNotas);
            this.panelDetalle.Controls.Add(this.txtNotas);
            this.panelDetalle.Controls.Add(this.lblMetodoPago);
            this.panelDetalle.Controls.Add(this.lblMonto);
            this.panelDetalle.Controls.Add(this.txtMonto);
            this.panelDetalle.Controls.Add(this.lblCita);
            this.panelDetalle.Controls.Add(this.cbEstado);
            this.panelDetalle.Controls.Add(this.lblEmpleado);
            this.panelDetalle.Controls.Add(this.cbMetodoPago);
            this.panelDetalle.Controls.Add(this.cbCliente);
            this.panelDetalle.Controls.Add(this.lblServicio);
            this.panelDetalle.Location = new System.Drawing.Point(583, 12);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Size = new System.Drawing.Size(834, 550);
            this.panelDetalle.TabIndex = 99;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(33, 144);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(298, 119);
            this.checkedListBox1.TabIndex = 101;
            // 
            // txtCita
            // 
            this.txtCita.Location = new System.Drawing.Point(338, 45);
            this.txtCita.Name = "txtCita";
            this.txtCita.ReadOnly = true;
            this.txtCita.Size = new System.Drawing.Size(100, 26);
            this.txtCita.TabIndex = 31;
            // 
            // lblSubtotalTexto
            // 
            this.lblSubtotalTexto.AutoSize = true;
            this.lblSubtotalTexto.Location = new System.Drawing.Point(562, 301);
            this.lblSubtotalTexto.Name = "lblSubtotalTexto";
            this.lblSubtotalTexto.Size = new System.Drawing.Size(73, 20);
            this.lblSubtotalTexto.TabIndex = 7;
            this.lblSubtotalTexto.Text = "Subtotal:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(565, 338);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(70, 20);
            this.lblSubtotal.TabIndex = 8;
            this.lblSubtotal.Text = "cantidad";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(437, 136);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(58, 20);
            this.lblFecha.TabIndex = 30;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(334, 294);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(64, 20);
            this.lblEstado.TabIndex = 29;
            this.lblEstado.Text = "Estado:";
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmpleado.Location = new System.Drawing.Point(638, 48);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(146, 26);
            this.txtEmpleado.TabIndex = 16;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(441, 167);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(152, 26);
            this.dtpFecha.TabIndex = 20;
            // 
            // lblNotas
            // 
            this.lblNotas.AutoSize = true;
            this.lblNotas.Location = new System.Drawing.Point(29, 409);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(96, 20);
            this.lblNotas.TabIndex = 3;
            this.lblNotas.Text = "Descripcion:";
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(39, 447);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(253, 78);
            this.txtNotas.TabIndex = 4;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(632, 131);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(108, 20);
            this.lblMetodoPago.TabIndex = 27;
            this.lblMetodoPago.Text = "Metodo Pago:";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(29, 296);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(58, 20);
            this.lblMonto.TabIndex = 26;
            this.lblMonto.Text = "Monto:";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMonto.Location = new System.Drawing.Point(33, 330);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(242, 26);
            this.txtMonto.TabIndex = 17;
            // 
            // lblCita
            // 
            this.lblCita.AutoSize = true;
            this.lblCita.Location = new System.Drawing.Point(29, 51);
            this.lblCita.Name = "lblCita";
            this.lblCita.Size = new System.Drawing.Size(62, 20);
            this.lblCita.TabIndex = 22;
            this.lblCita.Text = "Cliente:";
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(338, 330);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(148, 28);
            this.cbEstado.TabIndex = 19;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(534, 51);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(85, 20);
            this.lblEmpleado.TabIndex = 25;
            this.lblEmpleado.Text = "Empleado:";
            // 
            // cbMetodoPago
            // 
            this.cbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMetodoPago.FormattingEnabled = true;
            this.cbMetodoPago.Location = new System.Drawing.Point(636, 165);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(148, 28);
            this.cbMetodoPago.TabIndex = 18;
            // 
            // cbCliente
            // 
            this.cbCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(97, 46);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(195, 28);
            this.cbCliente.TabIndex = 13;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Location = new System.Drawing.Point(29, 112);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(86, 20);
            this.lblServicio.TabIndex = 1;
            this.lblServicio.Text = "Servicio(s):";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(1547, 422);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(287, 42);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1547, 366);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(147, 50);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(1547, 312);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(287, 45);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(1700, 366);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(134, 50);
            this.btnActualizar.TabIndex = 100;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // FrmDetalleFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.cbFiltro);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "FrmDetalleFactura";
            this.Text = "FrmDetalleFactura";
            this.Load += new System.EventHandler(this.FrmDetalleFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.panelDetalle.ResumeLayout(false);
            this.panelDetalle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.Label lblSubtotalTexto;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblNotas;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblCita;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cbMetodoPago;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtCita;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}