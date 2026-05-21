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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.clbServicios = new System.Windows.Forms.CheckedListBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.panelCitas.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCitas
            // 
            this.dgvCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Location = new System.Drawing.Point(357, 138);
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.RowHeadersWidth = 62;
            this.dgvCitas.RowTemplate.Height = 28;
            this.dgvCitas.Size = new System.Drawing.Size(801, 573);
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
            this.panelCitas.Location = new System.Drawing.Point(1274, 118);
            this.panelCitas.Name = "panelCitas";
            this.panelCitas.Size = new System.Drawing.Size(416, 704);
            this.panelCitas.TabIndex = 3;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(49, 622);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(128, 44);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(197, 547);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(124, 47);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar cita";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(49, 547);
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
            this.lblPrecio.Location = new System.Drawing.Point(248, 503);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(49, 20);
            this.lblPrecio.TabIndex = 16;
            this.lblPrecio.Text = "$0.00";
            // 
            // lblPrecioTitulo
            // 
            this.lblPrecioTitulo.AutoSize = true;
            this.lblPrecioTitulo.Location = new System.Drawing.Point(27, 503);
            this.lblPrecioTitulo.Name = "lblPrecioTitulo";
            this.lblPrecioTitulo.Size = new System.Drawing.Size(113, 20);
            this.lblPrecioTitulo.TabIndex = 15;
            this.lblPrecioTitulo.Text = "Total estimado";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(34, 373);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(236, 81);
            this.txtDescripcion.TabIndex = 14;
            // 
            // txtNotas
            // 
            this.txtNotas.AutoSize = true;
            this.txtNotas.Location = new System.Drawing.Point(30, 329);
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(134, 20);
            this.txtNotas.TabIndex = 13;
            this.txtNotas.Text = "Notas adicionales";
            // 
            // dtHora
            // 
            this.dtHora.CustomFormat = "HH : mm";
            this.dtHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHora.Location = new System.Drawing.Point(198, 274);
            this.dtHora.Name = "dtHora";
            this.dtHora.ShowUpDown = true;
            this.dtHora.Size = new System.Drawing.Size(109, 26);
            this.dtHora.TabIndex = 12;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(226, 248);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(44, 20);
            this.lblHora.TabIndex = 11;
            this.lblHora.Text = "Hora";
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(24, 274);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(136, 26);
            this.dtFecha.TabIndex = 10;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(27, 239);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(54, 20);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Fecha";
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Location = new System.Drawing.Point(20, 91);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(64, 20);
            this.lblServicio.TabIndex = 7;
            this.lblServicio.Text = "Servicio";
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(21, 46);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(175, 28);
            this.cbCliente.TabIndex = 6;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(17, 23);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(58, 20);
            this.lblCliente.TabIndex = 5;
            this.lblCliente.Text = "Cliente";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(1280, 74);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(151, 20);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Agendar Nueva Cita";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-33, -67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 5;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.RosyBrown;
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(289, 849);
            this.panelMenu.TabIndex = 6;
            // 
            // panelTabla
            // 
            this.panelTabla.Location = new System.Drawing.Point(345, 126);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(831, 598);
            this.panelTabla.TabIndex = 7;
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(357, 746);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(194, 49);
            this.btnHistorial.TabIndex = 9;
            this.btnHistorial.Text = "Ver Historial de citas";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // clbServicios
            // 
            this.clbServicios.FormattingEnabled = true;
            this.clbServicios.Location = new System.Drawing.Point(31, 125);
            this.clbServicios.Name = "clbServicios";
            this.clbServicios.Size = new System.Drawing.Size(239, 96);
            this.clbServicios.TabIndex = 10;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(198, 622);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(124, 46);
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(216, 46);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(121, 28);
            this.cbEstado.TabIndex = 20;
            // 
            // FrmCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1725, 849);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelCitas);
            this.Controls.Add(this.dgvCitas);
            this.Controls.Add(this.panelTabla);
            this.Name = "FrmCitas";
            this.Text = "FrmCitas";
            this.Load += new System.EventHandler(this.FrmCitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.panelCitas.ResumeLayout(false);
            this.panelCitas.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.CheckedListBox clbServicios;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ComboBox cbEstado;
    }
}