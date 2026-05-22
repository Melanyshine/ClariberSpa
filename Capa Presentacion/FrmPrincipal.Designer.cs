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
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnDisponibilidad = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnServicios = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.lblTitulo);
            this.panelMenu.Controls.Add(this.btnCerrarSesion);
            this.panelMenu.Controls.Add(this.btnHistorial);
            this.panelMenu.Controls.Add(this.btnDisponibilidad);
            this.panelMenu.Controls.Add(this.btnCitas);
            this.panelMenu.Controls.Add(this.btnUsuarios);
            this.panelMenu.Controls.Add(this.btnServicios);
            this.panelMenu.Controls.Add(this.btnClientes);
            this.panelMenu.Location = new System.Drawing.Point(-50, -15);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(430, 1126);
            this.panelMenu.TabIndex = 0;
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
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(91, 530);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(143, 44);
            this.btnHistorial.TabIndex = 1;
            this.btnHistorial.Text = "Historial ";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
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
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(91, 368);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(149, 44);
            this.btnUsuarios.TabIndex = 2;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
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
            this.panelContenido.Location = new System.Drawing.Point(393, -12);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(1027, 976);
            this.panelContenido.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(62, 47);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(51, 20);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "label1";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnDisponibilidad;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label lblTitulo;
    }
}