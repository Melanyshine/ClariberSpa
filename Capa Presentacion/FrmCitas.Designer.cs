namespace Capa_Presentacion
{
    partial class FrmCitas
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
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.panelCitas = new System.Windows.Forms.Panel();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.clbServicios = new System.Windows.Forms.CheckedListBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblPrecioTitulo = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNotas = new System.Windows.Forms.Label();
            this.dtHora = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnVerTodos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.panelCitas.SuspendLayout();
            this.panelTabla.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCitas
            // 
            this.dgvCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Location = new System.Drawing.Point(12, 14);
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.RowHeadersWidth = 62;
            this.dgvCitas.RowTemplate.Height = 28;
            this.dgvCitas.Size = new System.Drawing.Size(922, 573);
            this.dgvCitas.TabIndex = 2;
            // 
            // panelCitas
            // 
            this.panelCitas.Controls.Add(this.cbEstado);
            this.panelCitas.Controls.Add(this.btnActualizar);
            this.panelCitas.Controls.Add(this.clbServicios);
            this.panelCitas.Controls.Add(this.btnLimpiar);
            this.panelCitas.Controls.Add(this.btnEliminar);
            this.panelCitas.Controls.Add(this.btnGuardar);
            this.panelCitas.Controls.Add(this.lblPrecio);
            this.panelCitas.Controls.Add(this.lblPrecioTitulo);
            this.panelCitas.Controls.Add(this.txtDescripcion);
            this.panelCitas.Controls.Add(this.txtNotas);
            this.panelCitas.Controls.Add(this.dtHora);
            this.panelCitas.Controls.Add(this.lblHora);
            this.panelCitas.Controls.Add(this.dtFecha);
            this.panelCitas.Controls.Add(this.lblFecha);
            this.panelCitas.Controls.Add(this.lblServicio);
            this.panelCitas.Controls.Add(this.cbCliente);
            this.panelCitas.Controls.Add(this.lblCliente);
            this.panelCitas.Location = new System.Drawing.Point(1435, 202);
            this.panelCitas.Name = "panelCitas";
            this.panelCitas.Size = new System.Drawing.Size(441, 784);
            this.panelCitas.TabIndex = 3;
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(253, 43);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(159, 28);
            this.cbEstado.TabIndex = 20;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(234, 681);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(124, 46);
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // clbServicios
            // 
            this.clbServicios.FormattingEnabled = true;
            this.clbServicios.Location = new System.Drawing.Point(68, 122);
            this.clbServicios.Name = "clbServicios";
            this.clbServicios.Size = new System.Drawing.Size(239, 96);
            this.clbServicios.TabIndex = 10;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(85, 681);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(128, 44);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(233, 606);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(124, 47);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar cita";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(85, 606);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(124, 47);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar cita";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(188, 505);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(49, 20);
            this.lblPrecio.TabIndex = 16;
            this.lblPrecio.Text = "$0.00";
            // 
            // lblPrecioTitulo
            // 
            this.lblPrecioTitulo.AutoSize = true;
            this.lblPrecioTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTitulo.Location = new System.Drawing.Point(36, 515);
            this.lblPrecioTitulo.Name = "lblPrecioTitulo";
            this.lblPrecioTitulo.Size = new System.Drawing.Size(146, 25);
            this.lblPrecioTitulo.TabIndex = 15;
            this.lblPrecioTitulo.Text = "Total estimado:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(85, 379);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(236, 81);
            this.txtDescripcion.TabIndex = 14;
            // 
            // txtNotas
            // 
            this.txtNotas.AutoSize = true;
            this.txtNotas.Location = new System.Drawing.Point(81, 335);
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(134, 20);
            this.txtNotas.TabIndex = 13;
            this.txtNotas.Text = "Notas adicionales";
            // 
            // dtHora
            // 
            this.dtHora.CustomFormat = "HH : mm";
            this.dtHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHora.Location = new System.Drawing.Point(249, 280);
            this.dtHora.Name = "dtHora";
            this.dtHora.ShowUpDown = true;
            this.dtHora.Size = new System.Drawing.Size(109, 26);
            this.dtHora.TabIndex = 12;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(259, 254);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(48, 20);
            this.lblHora.TabIndex = 11;
            this.lblHora.Text = "Hora:";
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(75, 280);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(136, 26);
            this.dtFecha.TabIndex = 10;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(81, 254);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(58, 20);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Location = new System.Drawing.Point(57, 88);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(68, 20);
            this.lblServicio.TabIndex = 7;
            this.lblServicio.Text = "Servicio:";
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(58, 43);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(175, 28);
            this.cbCliente.TabIndex = 6;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(54, 20);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(62, 20);
            this.lblCliente.TabIndex = 5;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(1431, 145);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(151, 20);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Agendar Nueva Cita";
            // 
            // panelTabla
            // 
            this.panelTabla.Controls.Add(this.dgvCitas);
            this.panelTabla.Location = new System.Drawing.Point(432, 222);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(945, 605);
            this.panelTabla.TabIndex = 7;
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(432, 863);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(305, 49);
            this.btnHistorial.TabIndex = 9;
            this.btnHistorial.Text = "Ver Historial de citas";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(542, 137);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(277, 26);
            this.txtBuscar.TabIndex = 10;
            // 
            // cbFiltroEstado
            // 
            this.cbFiltroEstado.FormattingEnabled = true;
            this.cbFiltroEstado.Location = new System.Drawing.Point(1063, 137);
            this.cbFiltroEstado.Name = "cbFiltroEstado";
            this.cbFiltroEstado.Size = new System.Drawing.Size(121, 28);
            this.cbFiltroEstado.TabIndex = 11;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(842, 123);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(56, 10);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "🔍 ";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnVerTodos
            // 
            this.btnVerTodos.Location = new System.Drawing.Point(1205, 137);
            this.btnVerTodos.Name = "btnVerTodos";
            this.btnVerTodos.Size = new System.Drawing.Size(96, 12);
            this.btnVerTodos.TabIndex = 13;
            this.btnVerTodos.Text = "Ver todos";
            this.btnVerTodos.UseVisualStyleBackColor = true;
            this.btnVerTodos.Click += new System.EventHandler(this.btnVerTodos_Click);
            // 
            // FrmCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 907);
            this.Controls.Add(this.btnVerTodos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbFiltroEstado);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelCitas);
            this.Controls.Add(this.panelTabla);
            this.Name = "FrmCitas";
            this.Text = "FrmCitas";
            this.Load += new System.EventHandler(this.FrmCitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.panelCitas.ResumeLayout(false);
            this.panelCitas.PerformLayout();
            this.panelTabla.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Panel panelCitas;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtHora;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label txtNotas;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblPrecioTitulo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.CheckedListBox clbServicios;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cbFiltroEstado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnVerTodos;
    }
}