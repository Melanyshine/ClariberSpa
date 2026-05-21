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
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbListado = new System.Windows.Forms.GroupBox();
            this.dgvDisponibilidad = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.gbDisponibilidad.SuspendLayout();
            this.gbListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisponibilidad)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(250, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(107, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Disponibilidad";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(250, 75);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(242, 40);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Gestiona los horarios disponibles\r\n de los empleados";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Location = new System.Drawing.Point(-7, -12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 1087);
            this.panel1.TabIndex = 2;
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
            this.gbDisponibilidad.Location = new System.Drawing.Point(254, 154);
            this.gbDisponibilidad.Name = "gbDisponibilidad";
            this.gbDisponibilidad.Size = new System.Drawing.Size(741, 266);
            this.gbDisponibilidad.TabIndex = 3;
            this.gbDisponibilidad.TabStop = false;
            this.gbDisponibilidad.Text = "Programar Disponibilidad";
            // 
            // txtIdDisponibilidad
            // 
            this.txtIdDisponibilidad.Location = new System.Drawing.Point(261, 27);
            this.txtIdDisponibilidad.Name = "txtIdDisponibilidad";
            this.txtIdDisponibilidad.Size = new System.Drawing.Size(100, 26);
            this.txtIdDisponibilidad.TabIndex = 7;
            // 
            // dtHoraInicio
            // 
            this.dtHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHoraInicio.Location = new System.Drawing.Point(89, 196);
            this.dtHoraInicio.Name = "dtHoraInicio";
            this.dtHoraInicio.ShowUpDown = true;
            this.dtHoraInicio.Size = new System.Drawing.Size(149, 26);
            this.dtHoraInicio.TabIndex = 9;
            // 
            // dtHoraFin
            // 
            this.dtHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHoraFin.Location = new System.Drawing.Point(427, 196);
            this.dtHoraFin.Name = "dtHoraFin";
            this.dtHoraFin.ShowUpDown = true;
            this.dtHoraFin.Size = new System.Drawing.Size(169, 26);
            this.dtHoraFin.TabIndex = 8;
            // 
            // lblHoraFin
            // 
            this.lblHoraFin.AutoSize = true;
            this.lblHoraFin.Location = new System.Drawing.Point(423, 164);
            this.lblHoraFin.Name = "lblHoraFin";
            this.lblHoraFin.Size = new System.Drawing.Size(70, 20);
            this.lblHoraFin.TabIndex = 7;
            this.lblHoraFin.Text = "Hora Fin";
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.AutoSize = true;
            this.lblHoraInicio.Location = new System.Drawing.Point(85, 164);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(85, 20);
            this.lblHoraInicio.TabIndex = 6;
            this.lblHoraInicio.Text = "Hora Inicio";
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(427, 79);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(169, 26);
            this.dtFecha.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(423, 56);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(54, 20);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Tag = "";
            this.lblFecha.Text = "Fecha";
            // 
            // cbUsuario
            // 
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(89, 75);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(121, 28);
            this.cbUsuario.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(85, 54);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 20);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(1057, 233);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(177, 34);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(1032, 177);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(231, 34);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar Disponibilidad";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gbListado
            // 
            this.gbListado.Controls.Add(this.dgvDisponibilidad);
            this.gbListado.Location = new System.Drawing.Point(254, 446);
            this.gbListado.Name = "gbListado";
            this.gbListado.Size = new System.Drawing.Size(810, 320);
            this.gbListado.TabIndex = 6;
            this.gbListado.TabStop = false;
            this.gbListado.Text = "Disponibilidad Programada";
            // 
            // dgvDisponibilidad
            // 
            this.dgvDisponibilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisponibilidad.Location = new System.Drawing.Point(36, 45);
            this.dgvDisponibilidad.Name = "dgvDisponibilidad";
            this.dgvDisponibilidad.RowHeadersWidth = 62;
            this.dgvDisponibilidad.RowTemplate.Height = 28;
            this.dgvDisponibilidad.Size = new System.Drawing.Size(718, 253);
            this.dgvDisponibilidad.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1109, 491);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(180, 40);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(1109, 548);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(180, 40);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // FrmDisponibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 838);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.gbListado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.gbDisponibilidad);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmDisponibilidad";
            this.Text = "FrmDisponibilidad";
            this.Load += new System.EventHandler(this.FrmDisponibilidad_Load);
            this.gbDisponibilidad.ResumeLayout(false);
            this.gbDisponibilidad.PerformLayout();
            this.gbListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisponibilidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbDisponibilidad;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.DateTimePicker dtHoraInicio;
        private System.Windows.Forms.DateTimePicker dtHoraFin;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gbListado;
        private System.Windows.Forms.DataGridView dgvDisponibilidad;
        private System.Windows.Forms.TextBox txtIdDisponibilidad;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
    }
}