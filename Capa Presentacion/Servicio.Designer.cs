namespace Capa_Presentacion
{
    partial class Servicio
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbServicio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelServiciosRegistrados = new System.Windows.Forms.Panel();
            this.btnNuevoServicio = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvServicio = new System.Windows.Forms.DataGridView();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panelServiciosRegistrados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Location = new System.Drawing.Point(-32, -15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 1334);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(982, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "BEAUTY VENTER SPA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Administra los servicios del spa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Servicio";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cmbServicio);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(299, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1164, 129);
            this.panel3.TabIndex = 5;
            // 
            // cmbServicio
            // 
            this.cmbServicio.FormattingEnabled = true;
            this.cmbServicio.Location = new System.Drawing.Point(587, 50);
            this.cmbServicio.Name = "cmbServicio";
            this.cmbServicio.Size = new System.Drawing.Size(121, 28);
            this.cmbServicio.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1052, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Claribet Spa";
            // 
            // panelServiciosRegistrados
            // 
            this.panelServiciosRegistrados.Controls.Add(this.label7);
            this.panelServiciosRegistrados.Controls.Add(this.label6);
            this.panelServiciosRegistrados.Controls.Add(this.btnAnterior);
            this.panelServiciosRegistrados.Controls.Add(this.btnSiguiente);
            this.panelServiciosRegistrados.Controls.Add(this.dgvServicio);
            this.panelServiciosRegistrados.Controls.Add(this.label5);
            this.panelServiciosRegistrados.Controls.Add(this.txtBuscar);
            this.panelServiciosRegistrados.Controls.Add(this.btnNuevoServicio);
            this.panelServiciosRegistrados.Location = new System.Drawing.Point(299, 165);
            this.panelServiciosRegistrados.Name = "panelServiciosRegistrados";
            this.panelServiciosRegistrados.Size = new System.Drawing.Size(1164, 822);
            this.panelServiciosRegistrados.TabIndex = 6;
            // 
            // btnNuevoServicio
            // 
            this.btnNuevoServicio.BackColor = System.Drawing.Color.RosyBrown;
            this.btnNuevoServicio.Location = new System.Drawing.Point(912, 32);
            this.btnNuevoServicio.Name = "btnNuevoServicio";
            this.btnNuevoServicio.Size = new System.Drawing.Size(199, 57);
            this.btnNuevoServicio.TabIndex = 0;
            this.btnNuevoServicio.Text = "NuevoServicio";
            this.btnNuevoServicio.UseVisualStyleBackColor = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(43, 87);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(374, 26);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.Text = "Buscar Servicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Servicios";
            // 
            // dgvServicio
            // 
            this.dgvServicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicio.Location = new System.Drawing.Point(34, 148);
            this.dgvServicio.Name = "dgvServicio";
            this.dgvServicio.RowHeadersWidth = 62;
            this.dgvServicio.RowTemplate.Height = 28;
            this.dgvServicio.Size = new System.Drawing.Size(1098, 579);
            this.dgvServicio.TabIndex = 3;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.RosyBrown;
            this.btnSiguiente.Location = new System.Drawing.Point(456, 758);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = "button2";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            // 
            // btnAnterior
            // 
            this.btnAnterior.BackColor = System.Drawing.Color.RosyBrown;
            this.btnAnterior.Location = new System.Drawing.Point(587, 758);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 5;
            this.btnAnterior.Text = "button3";
            this.btnAnterior.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(538, 760);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 781);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(241, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Mostrando 1 de 6 a 6  resultados";
            // 
            // Servicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 1050);
            this.Controls.Add(this.panelServiciosRegistrados);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Servicio";
            this.Text = "Servicio";
            this.Load += new System.EventHandler(this.Servicio_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelServiciosRegistrados.ResumeLayout(false);
            this.panelServiciosRegistrados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbServicio;
        private System.Windows.Forms.Panel panelServiciosRegistrados;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnNuevoServicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.DataGridView dgvServicio;
        private System.Windows.Forms.Label label5;
    }
}