namespace Capa_Presentacion
{
    partial class FrmPrincipal
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnFactura = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnDisponibilidad = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnServicios = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.btnSeleccionarCarpt = new System.Windows.Forms.Button();
            this.btnRestoreBackup = new System.Windows.Forms.Button();
            this.btnBackupFull = new System.Windows.Forms.Button();
            this.btnBackupDifferential = new System.Windows.Forms.Button();
            this.btnBackupLog = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnInicio);
            this.panelMenu.Controls.Add(this.btnFactura);
            this.panelMenu.Controls.Add(this.btnUsuario);
            this.panelMenu.Controls.Add(this.lblTitulo);
            this.panelMenu.Controls.Add(this.btnCerrarSesion);
            this.panelMenu.Controls.Add(this.btnDisponibilidad);
            this.panelMenu.Controls.Add(this.btnCitas);
            this.panelMenu.Controls.Add(this.btnServicios);
            this.panelMenu.Controls.Add(this.btnClientes);
            this.panelMenu.Location = new System.Drawing.Point(-50, -15);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(430, 1126);
            this.panelMenu.TabIndex = 0;
            // 
            // btnFactura
            // 
            this.btnFactura.Location = new System.Drawing.Point(97, 525);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(143, 44);
            this.btnFactura.TabIndex = 0;
            this.btnFactura.Text = "Factura";
            this.btnFactura.UseVisualStyleBackColor = true;
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(91, 369);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(149, 44);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.Text = "Usuarios";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(62, 48);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(51, 20);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "label1";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(91, 733);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(143, 44);
            this.btnCerrarSesion.TabIndex = 1;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnDisponibilidad
            // 
            this.btnDisponibilidad.Location = new System.Drawing.Point(91, 118);
            this.btnDisponibilidad.Name = "btnDisponibilidad";
            this.btnDisponibilidad.Size = new System.Drawing.Size(149, 44);
            this.btnDisponibilidad.TabIndex = 3;
            this.btnDisponibilidad.Text = "Disponibilidad";
            this.btnDisponibilidad.UseVisualStyleBackColor = true;
            this.btnDisponibilidad.Click += new System.EventHandler(this.btnDisponibilidad_Click);
            // 
            // btnCitas
            // 
            this.btnCitas.Location = new System.Drawing.Point(91, 448);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(149, 44);
            this.btnCitas.TabIndex = 2;
            this.btnCitas.Text = "Citas";
            this.btnCitas.UseVisualStyleBackColor = true;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // btnServicios
            // 
            this.btnServicios.Location = new System.Drawing.Point(91, 284);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Size = new System.Drawing.Size(149, 44);
            this.btnServicios.TabIndex = 1;
            this.btnServicios.Text = "Servicios";
            this.btnServicios.UseVisualStyleBackColor = true;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(91, 195);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(149, 44);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.btnSeleccionarCarpt);
            this.panelContenido.Controls.Add(this.btnRestoreBackup);
            this.panelContenido.Controls.Add(this.btnBackupFull);
            this.panelContenido.Controls.Add(this.btnBackupDifferential);
            this.panelContenido.Controls.Add(this.btnBackupLog);
            this.panelContenido.Location = new System.Drawing.Point(393, -12);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(1027, 976);
            this.panelContenido.TabIndex = 1;
            // 
            // btnSeleccionarCarpt
            // 
            this.btnSeleccionarCarpt.Location = new System.Drawing.Point(912, 153);
            this.btnSeleccionarCarpt.Name = "btnSeleccionarCarpt";
            this.btnSeleccionarCarpt.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionarCarpt.TabIndex = 4;
            this.btnSeleccionarCarpt.Text = "Carpeta";
            this.btnSeleccionarCarpt.UseVisualStyleBackColor = true;
            this.btnSeleccionarCarpt.Click += new System.EventHandler(this.btnSeleccionarCarpt_Click);
            // 
            // btnRestoreBackup
            // 
            this.btnRestoreBackup.Location = new System.Drawing.Point(912, 115);
            this.btnRestoreBackup.Name = "btnRestoreBackup";
            this.btnRestoreBackup.Size = new System.Drawing.Size(75, 23);
            this.btnRestoreBackup.TabIndex = 3;
            this.btnRestoreBackup.Text = "Restaurar";
            this.btnRestoreBackup.UseVisualStyleBackColor = true;
            this.btnRestoreBackup.Click += new System.EventHandler(this.btnRestoreBackup_Click_1);
            // 
            // btnBackupFull
            // 
            this.btnBackupFull.Location = new System.Drawing.Point(912, 24);
            this.btnBackupFull.Name = "btnBackupFull";
            this.btnBackupFull.Size = new System.Drawing.Size(75, 23);
            this.btnBackupFull.TabIndex = 2;
            this.btnBackupFull.Text = "Full";
            this.btnBackupFull.UseVisualStyleBackColor = true;
            this.btnBackupFull.Click += new System.EventHandler(this.btnBackupFull_Click_1);
            // 
            // btnBackupDifferential
            // 
            this.btnBackupDifferential.Location = new System.Drawing.Point(912, 53);
            this.btnBackupDifferential.Name = "btnBackupDifferential";
            this.btnBackupDifferential.Size = new System.Drawing.Size(75, 23);
            this.btnBackupDifferential.TabIndex = 1;
            this.btnBackupDifferential.Text = "Diferencial";
            this.btnBackupDifferential.UseVisualStyleBackColor = true;
            this.btnBackupDifferential.Click += new System.EventHandler(this.btnBackupDifferential_Click_1);
            // 
            // btnBackupLog
            // 
            this.btnBackupLog.Location = new System.Drawing.Point(912, 82);
            this.btnBackupLog.Name = "btnBackupLog";
            this.btnBackupLog.Size = new System.Drawing.Size(75, 23);
            this.btnBackupLog.TabIndex = 0;
            this.btnBackupLog.Text = "incremental";
            this.btnBackupLog.UseVisualStyleBackColor = true;
            this.btnBackupLog.Click += new System.EventHandler(this.btnBackupLog_Click_1);
            // 
            // btnInicio
            // 
            this.btnInicio.Location = new System.Drawing.Point(261, 195);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(98, 73);
            this.btnInicio.TabIndex = 5;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 935);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelContenido);
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnDisponibilidad;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.Button btnBackupFull;
        private System.Windows.Forms.Button btnBackupDifferential;
        private System.Windows.Forms.Button btnBackupLog;
        private System.Windows.Forms.Button btnSeleccionarCarpt;
        private System.Windows.Forms.Button btnRestoreBackup;
        private System.Windows.Forms.Button btnInicio;
    }
}