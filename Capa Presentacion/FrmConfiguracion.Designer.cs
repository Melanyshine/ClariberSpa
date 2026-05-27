namespace Capa_Presentacion
{
    partial class FrmConfiguracion
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
            this.lblConfiguracion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picBackupCompleto = new System.Windows.Forms.PictureBox();
            this.lblBackupCompleto = new System.Windows.Forms.Label();
            this.lblDescCompleto = new System.Windows.Forms.Label();
            this.btnBackupCompleto = new System.Windows.Forms.Button();
            this.picBackupDiferencial = new System.Windows.Forms.PictureBox();
            this.lblBackupLog = new System.Windows.Forms.Label();
            this.lblBackupDiferencial = new System.Windows.Forms.Label();
            this.lblDescDiferencial = new System.Windows.Forms.Label();
            this.btnBackupDiferencial = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDescLog = new System.Windows.Forms.Label();
            this.btnBackupLog = new System.Windows.Forms.Button();
            this.picRestaurarBackup = new System.Windows.Forms.PictureBox();
            this.lblRestaurarBackup = new System.Windows.Forms.Label();
            this.lblDescRestaurar = new System.Windows.Forms.Label();
            this.btnRestaurarBackup = new System.Windows.Forms.Button();
            this.gbInformacion = new System.Windows.Forms.GroupBox();
            this.btnAbrirCarpeta = new System.Windows.Forms.Button();
            this.lblFechaBackup = new System.Windows.Forms.Label();
            this.lblUltimoBackup = new System.Windows.Forms.Label();
            this.lblEstadoBackup = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnCambiarRuta = new System.Windows.Forms.Button();
            this.txtRutaBackup = new System.Windows.Forms.TextBox();
            this.lblRutaBackup = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBackupCompleto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackupDiferencial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRestaurarBackup)).BeginInit();
            this.gbInformacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConfiguracion
            // 
            this.lblConfiguracion.AutoSize = true;
            this.lblConfiguracion.Location = new System.Drawing.Point(288, 70);
            this.lblConfiguracion.Name = "lblConfiguracion";
            this.lblConfiguracion.Size = new System.Drawing.Size(198, 20);
            this.lblConfiguracion.TabIndex = 0;
            this.lblConfiguracion.Text = "Configuración y Respaldos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Administra los respaldos y Configuración del sistema.";
            // 
            // picBackupCompleto
            // 
            this.picBackupCompleto.Location = new System.Drawing.Point(292, 218);
            this.picBackupCompleto.Name = "picBackupCompleto";
            this.picBackupCompleto.Size = new System.Drawing.Size(163, 136);
            this.picBackupCompleto.TabIndex = 2;
            this.picBackupCompleto.TabStop = false;
            // 
            // lblBackupCompleto
            // 
            this.lblBackupCompleto.AutoSize = true;
            this.lblBackupCompleto.Location = new System.Drawing.Point(308, 369);
            this.lblBackupCompleto.Name = "lblBackupCompleto";
            this.lblBackupCompleto.Size = new System.Drawing.Size(135, 20);
            this.lblBackupCompleto.TabIndex = 3;
            this.lblBackupCompleto.Text = "Backup Completo";
            // 
            // lblDescCompleto
            // 
            this.lblDescCompleto.AutoSize = true;
            this.lblDescCompleto.Location = new System.Drawing.Point(203, 400);
            this.lblDescCompleto.Name = "lblDescCompleto";
            this.lblDescCompleto.Size = new System.Drawing.Size(352, 20);
            this.lblDescCompleto.TabIndex = 4;
            this.lblDescCompleto.Text = "Genera una copia completa de la base de datos.";
            // 
            // btnBackupCompleto
            // 
            this.btnBackupCompleto.Location = new System.Drawing.Point(292, 445);
            this.btnBackupCompleto.Name = "btnBackupCompleto";
            this.btnBackupCompleto.Size = new System.Drawing.Size(143, 37);
            this.btnBackupCompleto.TabIndex = 5;
            this.btnBackupCompleto.Text = "Generar Backup";
            this.btnBackupCompleto.UseVisualStyleBackColor = true;
            this.btnBackupCompleto.Click += new System.EventHandler(this.btnBackupCompleto_Click);
            // 
            // picBackupDiferencial
            // 
            this.picBackupDiferencial.Location = new System.Drawing.Point(656, 218);
            this.picBackupDiferencial.Name = "picBackupDiferencial";
            this.picBackupDiferencial.Size = new System.Drawing.Size(178, 136);
            this.picBackupDiferencial.TabIndex = 6;
            this.picBackupDiferencial.TabStop = false;
            // 
            // lblBackupLog
            // 
            this.lblBackupLog.AutoSize = true;
            this.lblBackupLog.Location = new System.Drawing.Point(1020, 369);
            this.lblBackupLog.Name = "lblBackupLog";
            this.lblBackupLog.Size = new System.Drawing.Size(151, 20);
            this.lblBackupLog.TabIndex = 7;
            this.lblBackupLog.Text = "Backup Incremental";
            // 
            // lblBackupDiferencial
            // 
            this.lblBackupDiferencial.AutoSize = true;
            this.lblBackupDiferencial.Location = new System.Drawing.Point(676, 369);
            this.lblBackupDiferencial.Name = "lblBackupDiferencial";
            this.lblBackupDiferencial.Size = new System.Drawing.Size(142, 20);
            this.lblBackupDiferencial.TabIndex = 8;
            this.lblBackupDiferencial.Text = "Backup Diferencial";
            // 
            // lblDescDiferencial
            // 
            this.lblDescDiferencial.AutoSize = true;
            this.lblDescDiferencial.Location = new System.Drawing.Point(618, 400);
            this.lblDescDiferencial.Name = "lblDescDiferencial";
            this.lblDescDiferencial.Size = new System.Drawing.Size(264, 40);
            this.lblDescDiferencial.TabIndex = 9;
            this.lblDescDiferencial.Text = "Guarda los cambios desde el último \r\nbackup completo.";
            this.lblDescDiferencial.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBackupDiferencial
            // 
            this.btnBackupDiferencial.Location = new System.Drawing.Point(680, 445);
            this.btnBackupDiferencial.Name = "btnBackupDiferencial";
            this.btnBackupDiferencial.Size = new System.Drawing.Size(140, 37);
            this.btnBackupDiferencial.TabIndex = 10;
            this.btnBackupDiferencial.Text = "Generar Backup";
            this.btnBackupDiferencial.UseVisualStyleBackColor = true;
            this.btnBackupDiferencial.Click += new System.EventHandler(this.btnBackupDiferencial_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1010, 218);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 136);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblDescLog
            // 
            this.lblDescLog.AutoSize = true;
            this.lblDescLog.Location = new System.Drawing.Point(944, 400);
            this.lblDescLog.Name = "lblDescLog";
            this.lblDescLog.Size = new System.Drawing.Size(338, 20);
            this.lblDescLog.TabIndex = 12;
            this.lblDescLog.Text = "Respalda las últimas transacciones realizadas.";
            // 
            // btnBackupLog
            // 
            this.btnBackupLog.Location = new System.Drawing.Point(1024, 445);
            this.btnBackupLog.Name = "btnBackupLog";
            this.btnBackupLog.Size = new System.Drawing.Size(168, 37);
            this.btnBackupLog.TabIndex = 13;
            this.btnBackupLog.Text = "Generar Backup";
            this.btnBackupLog.UseVisualStyleBackColor = true;
            this.btnBackupLog.Click += new System.EventHandler(this.btnBackupLog_Click);
            // 
            // picRestaurarBackup
            // 
            this.picRestaurarBackup.Location = new System.Drawing.Point(1371, 218);
            this.picRestaurarBackup.Name = "picRestaurarBackup";
            this.picRestaurarBackup.Size = new System.Drawing.Size(195, 136);
            this.picRestaurarBackup.TabIndex = 14;
            this.picRestaurarBackup.TabStop = false;
            // 
            // lblRestaurarBackup
            // 
            this.lblRestaurarBackup.AutoSize = true;
            this.lblRestaurarBackup.Location = new System.Drawing.Point(1404, 369);
            this.lblRestaurarBackup.Name = "lblRestaurarBackup";
            this.lblRestaurarBackup.Size = new System.Drawing.Size(138, 20);
            this.lblRestaurarBackup.TabIndex = 15;
            this.lblRestaurarBackup.Text = "Restaurar Backup";
            // 
            // lblDescRestaurar
            // 
            this.lblDescRestaurar.AutoSize = true;
            this.lblDescRestaurar.Location = new System.Drawing.Point(1346, 400);
            this.lblDescRestaurar.Name = "lblDescRestaurar";
            this.lblDescRestaurar.Size = new System.Drawing.Size(248, 40);
            this.lblDescRestaurar.TabIndex = 16;
            this.lblDescRestaurar.Text = "Restaura la base de datos desde \r\nun archivo backup.";
            this.lblDescRestaurar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRestaurarBackup
            // 
            this.btnRestaurarBackup.Location = new System.Drawing.Point(1388, 446);
            this.btnRestaurarBackup.Name = "btnRestaurarBackup";
            this.btnRestaurarBackup.Size = new System.Drawing.Size(178, 36);
            this.btnRestaurarBackup.TabIndex = 17;
            this.btnRestaurarBackup.Text = "Restaurar Backup";
            this.btnRestaurarBackup.UseVisualStyleBackColor = true;
            this.btnRestaurarBackup.Click += new System.EventHandler(this.btnRestaurarBackup_Click);
            // 
            // gbInformacion
            // 
            this.gbInformacion.Controls.Add(this.btnAbrirCarpeta);
            this.gbInformacion.Controls.Add(this.lblFechaBackup);
            this.gbInformacion.Controls.Add(this.lblUltimoBackup);
            this.gbInformacion.Controls.Add(this.lblEstadoBackup);
            this.gbInformacion.Controls.Add(this.lblEstado);
            this.gbInformacion.Controls.Add(this.btnCambiarRuta);
            this.gbInformacion.Controls.Add(this.txtRutaBackup);
            this.gbInformacion.Controls.Add(this.lblRutaBackup);
            this.gbInformacion.Location = new System.Drawing.Point(292, 513);
            this.gbInformacion.Name = "gbInformacion";
            this.gbInformacion.Size = new System.Drawing.Size(1216, 263);
            this.gbInformacion.TabIndex = 18;
            this.gbInformacion.TabStop = false;
            this.gbInformacion.Text = "Información del Respaldo";
            // 
            // btnAbrirCarpeta
            // 
            this.btnAbrirCarpeta.Location = new System.Drawing.Point(631, 137);
            this.btnAbrirCarpeta.Name = "btnAbrirCarpeta";
            this.btnAbrirCarpeta.Size = new System.Drawing.Size(141, 34);
            this.btnAbrirCarpeta.TabIndex = 7;
            this.btnAbrirCarpeta.Text = "Abrir Carpeta";
            this.btnAbrirCarpeta.UseVisualStyleBackColor = true;
            this.btnAbrirCarpeta.Click += new System.EventHandler(this.btnAbrirCarpeta_Click);
            // 
            // lblFechaBackup
            // 
            this.lblFechaBackup.AutoSize = true;
            this.lblFechaBackup.Location = new System.Drawing.Point(747, 77);
            this.lblFechaBackup.Name = "lblFechaBackup";
            this.lblFechaBackup.Size = new System.Drawing.Size(51, 20);
            this.lblFechaBackup.TabIndex = 6;
            this.lblFechaBackup.Text = "label2";
            // 
            // lblUltimoBackup
            // 
            this.lblUltimoBackup.AutoSize = true;
            this.lblUltimoBackup.Location = new System.Drawing.Point(627, 77);
            this.lblUltimoBackup.Name = "lblUltimoBackup";
            this.lblUltimoBackup.Size = new System.Drawing.Size(114, 20);
            this.lblUltimoBackup.TabIndex = 5;
            this.lblUltimoBackup.Text = "Último backup:";
            // 
            // lblEstadoBackup
            // 
            this.lblEstadoBackup.AutoSize = true;
            this.lblEstadoBackup.Location = new System.Drawing.Point(91, 144);
            this.lblEstadoBackup.Name = "lblEstadoBackup";
            this.lblEstadoBackup.Size = new System.Drawing.Size(262, 20);
            this.lblEstadoBackup.TabIndex = 4;
            this.lblEstadoBackup.Text = "Sistema listo para generar backups.";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(31, 144);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(64, 20);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado:";
            // 
            // btnCambiarRuta
            // 
            this.btnCambiarRuta.Location = new System.Drawing.Point(424, 66);
            this.btnCambiarRuta.Name = "btnCambiarRuta";
            this.btnCambiarRuta.Size = new System.Drawing.Size(135, 36);
            this.btnCambiarRuta.TabIndex = 2;
            this.btnCambiarRuta.Text = "Cambiar Ruta";
            this.btnCambiarRuta.UseVisualStyleBackColor = true;
            // 
            // txtRutaBackup
            // 
            this.txtRutaBackup.Location = new System.Drawing.Point(228, 71);
            this.txtRutaBackup.Name = "txtRutaBackup";
            this.txtRutaBackup.Size = new System.Drawing.Size(178, 26);
            this.txtRutaBackup.TabIndex = 1;
            // 
            // lblRutaBackup
            // 
            this.lblRutaBackup.AutoSize = true;
            this.lblRutaBackup.Location = new System.Drawing.Point(31, 74);
            this.lblRutaBackup.Name = "lblRutaBackup";
            this.lblRutaBackup.Size = new System.Drawing.Size(191, 20);
            this.lblRutaBackup.TabIndex = 0;
            this.lblRutaBackup.Text = "Ruta de almacenamiento:";
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1680, 788);
            this.Controls.Add(this.gbInformacion);
            this.Controls.Add(this.btnRestaurarBackup);
            this.Controls.Add(this.lblDescRestaurar);
            this.Controls.Add(this.lblRestaurarBackup);
            this.Controls.Add(this.picRestaurarBackup);
            this.Controls.Add(this.btnBackupLog);
            this.Controls.Add(this.lblDescLog);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBackupDiferencial);
            this.Controls.Add(this.lblDescDiferencial);
            this.Controls.Add(this.lblBackupDiferencial);
            this.Controls.Add(this.lblBackupLog);
            this.Controls.Add(this.picBackupDiferencial);
            this.Controls.Add(this.btnBackupCompleto);
            this.Controls.Add(this.lblDescCompleto);
            this.Controls.Add(this.lblBackupCompleto);
            this.Controls.Add(this.picBackupCompleto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblConfiguracion);
            this.Name = "FrmConfiguracion";
            this.Text = "FrmConfiguracion";
            ((System.ComponentModel.ISupportInitialize)(this.picBackupCompleto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackupDiferencial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRestaurarBackup)).EndInit();
            this.gbInformacion.ResumeLayout(false);
            this.gbInformacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConfiguracion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBackupCompleto;
        private System.Windows.Forms.Label lblBackupCompleto;
        private System.Windows.Forms.Label lblDescCompleto;
        private System.Windows.Forms.Button btnBackupCompleto;
        private System.Windows.Forms.PictureBox picBackupDiferencial;
        private System.Windows.Forms.Label lblBackupLog;
        private System.Windows.Forms.Label lblBackupDiferencial;
        private System.Windows.Forms.Label lblDescDiferencial;
        private System.Windows.Forms.Button btnBackupDiferencial;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDescLog;
        private System.Windows.Forms.Button btnBackupLog;
        private System.Windows.Forms.PictureBox picRestaurarBackup;
        private System.Windows.Forms.Label lblRestaurarBackup;
        private System.Windows.Forms.Label lblDescRestaurar;
        private System.Windows.Forms.Button btnRestaurarBackup;
        private System.Windows.Forms.GroupBox gbInformacion;
        private System.Windows.Forms.Label lblRutaBackup;
        private System.Windows.Forms.TextBox txtRutaBackup;
        private System.Windows.Forms.Label lblEstadoBackup;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnCambiarRuta;
        private System.Windows.Forms.Label lblFechaBackup;
        private System.Windows.Forms.Label lblUltimoBackup;
        private System.Windows.Forms.Button btnAbrirCarpeta;
    }
}