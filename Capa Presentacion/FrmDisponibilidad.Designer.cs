namespace Capa_Presentacion
{
    partial class FrmDisponibilidad
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbListado = new System.Windows.Forms.GroupBox();
            this.dgvDisponibilidad = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.gbDisponibilidad = new System.Windows.Forms.GroupBox();
            this.txtIdDisponibilidad = new System.Windows.Forms.TextBox();
            this.dtHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.dtHoraFin = new System.Windows.Forms.DateTimePicker();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisponibilidad)).BeginInit();
            this.gbDisponibilidad.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(471, 40);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(107, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Disponibilidad";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(471, 114);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(242, 40);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Gestiona los horarios disponibles\r\n de los empleados";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(1699, 313);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(177, 53);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(1679, 254);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(213, 53);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar Disponibilidad";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gbListado
            // 
            this.gbListado.Controls.Add(this.dgvDisponibilidad);
            this.gbListado.Location = new System.Drawing.Point(475, 583);
            this.gbListado.Name = "gbListado";
            this.gbListado.Size = new System.Drawing.Size(1220, 340);
            this.gbListado.TabIndex = 6;
            this.gbListado.TabStop = false;
            this.gbListado.Text = "Disponibilidad Programada";
            // 
            // dgvDisponibilidad
            // 
            this.dgvDisponibilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisponibilidad.Location = new System.Drawing.Point(84, 40);
            this.dgvDisponibilidad.Name = "dgvDisponibilidad";
            this.dgvDisponibilidad.RowHeadersWidth = 62;
            this.dgvDisponibilidad.RowTemplate.Height = 28;
            this.dgvDisponibilidad.Size = new System.Drawing.Size(1047, 253);
            this.dgvDisponibilidad.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1733, 679);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(180, 53);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(1733, 738);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(180, 49);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // gbDisponibilidad
            // 
            this.gbDisponibilidad.Controls.Add(this.txtIdDisponibilidad);
            this.gbDisponibilidad.Controls.Add(this.dtHoraInicio);
            this.gbDisponibilidad.Controls.Add(this.dtHoraFin);
            this.gbDisponibilidad.Controls.Add(this.lblHoraFin);
            this.gbDisponibilidad.Controls.Add(this.lblHoraInicio);
            this.gbDisponibilidad.Controls.Add(this.dtFecha);
            this.gbDisponibilidad.Controls.Add(this.lblFecha);
            this.gbDisponibilidad.Controls.Add(this.cbUsuario);
            this.gbDisponibilidad.Controls.Add(this.lblUsuario);
            this.gbDisponibilidad.Location = new System.Drawing.Point(39, 72);
            this.gbDisponibilidad.Name = "gbDisponibilidad";
            this.gbDisponibilidad.Size = new System.Drawing.Size(1105, 245);
            this.gbDisponibilidad.TabIndex = 3;
            this.gbDisponibilidad.TabStop = false;
            this.gbDisponibilidad.Text = "Programar Disponibilidad";
            // 
            // txtIdDisponibilidad
            // 
            this.txtIdDisponibilidad.Location = new System.Drawing.Point(174, 38);
            this.txtIdDisponibilidad.Name = "txtIdDisponibilidad";
            this.txtIdDisponibilidad.Size = new System.Drawing.Size(100, 26);
            this.txtIdDisponibilidad.TabIndex = 7;
            // 
            // dtHoraInicio
            // 
            this.dtHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHoraInicio.Location = new System.Drawing.Point(280, 184);
            this.dtHoraInicio.Name = "dtHoraInicio";
            this.dtHoraInicio.ShowUpDown = true;
            this.dtHoraInicio.Size = new System.Drawing.Size(149, 26);
            this.dtHoraInicio.TabIndex = 9;
            // 
            // dtHoraFin
            // 
            this.dtHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHoraFin.Location = new System.Drawing.Point(821, 178);
            this.dtHoraFin.Name = "dtHoraFin";
            this.dtHoraFin.ShowUpDown = true;
            this.dtHoraFin.Size = new System.Drawing.Size(169, 26);
            this.dtHoraFin.TabIndex = 8;
            // 
            // lblHoraFin
            // 
            this.lblHoraFin.AutoSize = true;
            this.lblHoraFin.Location = new System.Drawing.Point(729, 184);
            this.lblHoraFin.Name = "lblHoraFin";
            this.lblHoraFin.Size = new System.Drawing.Size(70, 20);
            this.lblHoraFin.TabIndex = 7;
            this.lblHoraFin.Text = "Hora Fin";
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.AutoSize = true;
            this.lblHoraInicio.Location = new System.Drawing.Point(170, 190);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(85, 20);
            this.lblHoraInicio.TabIndex = 6;
            this.lblHoraInicio.Text = "Hora Inicio";
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(821, 83);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(169, 26);
            this.dtFecha.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(745, 83);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(54, 20);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Tag = "";
            this.lblFecha.Text = "Fecha";
            // 
            // cbUsuario
            // 
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(269, 88);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(141, 28);
            this.cbUsuario.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(177, 91);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 20);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbDisponibilidad);
            this.panel1.Location = new System.Drawing.Point(448, 157);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1234, 395);
            this.panel1.TabIndex = 10;
            // 
            // FrmDisponibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDisponibilidad";
            this.Text = "FrmDisponibilidad";
            this.Load += new System.EventHandler(this.FrmDisponibilidad_Load);
            this.gbListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisponibilidad)).EndInit();
            this.gbDisponibilidad.ResumeLayout(false);
            this.gbDisponibilidad.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gbListado;
        private System.Windows.Forms.DataGridView dgvDisponibilidad;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.GroupBox gbDisponibilidad;
        private System.Windows.Forms.TextBox txtIdDisponibilidad;
        private System.Windows.Forms.DateTimePicker dtHoraInicio;
        private System.Windows.Forms.DateTimePicker dtHoraFin;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel panel1;
    }
}