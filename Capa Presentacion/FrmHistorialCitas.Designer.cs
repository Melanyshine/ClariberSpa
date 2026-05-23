namespace CapaPresentacion
{
    partial class FrmHistorialCitas
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
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelTabla = new System.Windows.Forms.Panel();
            this.btnVerTodos = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.panelTabla.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(491, 240);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 62;
            this.dgvHistorial.RowTemplate.Height = 28;
            this.dgvHistorial.Size = new System.Drawing.Size(1031, 526);
            this.dgvHistorial.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(768, 48);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(128, 20);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Historial de Citas";
            // 
            // panelTabla
            // 
            this.panelTabla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTabla.Controls.Add(this.btnVerTodos);
            this.panelTabla.Controls.Add(this.btnBuscar);
            this.panelTabla.Controls.Add(this.cbFiltroEstado);
            this.panelTabla.Controls.Add(this.txtBuscar);
            this.panelTabla.Controls.Add(this.btnVolver);
            this.panelTabla.Controls.Add(this.dgvHistorial);
            this.panelTabla.Controls.Add(this.lblTitulo);
            this.panelTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabla.Location = new System.Drawing.Point(0, 0);
            this.panelTabla.Name = "panelTabla";
            this.panelTabla.Size = new System.Drawing.Size(1712, 959);
            this.panelTabla.TabIndex = 2;
            // 
            // btnVerTodos
            // 
            this.btnVerTodos.Location = new System.Drawing.Point(1258, 155);
            this.btnVerTodos.Name = "btnVerTodos";
            this.btnVerTodos.Size = new System.Drawing.Size(117, 30);
            this.btnVerTodos.TabIndex = 6;
            this.btnVerTodos.Text = "Ver Todos";
            this.btnVerTodos.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(851, 159);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 28);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // cbFiltroEstado
            // 
            this.cbFiltroEstado.FormattingEnabled = true;
            this.cbFiltroEstado.Location = new System.Drawing.Point(1095, 157);
            this.cbFiltroEstado.Name = "cbFiltroEstado";
            this.cbFiltroEstado.Size = new System.Drawing.Size(140, 28);
            this.cbFiltroEstado.TabIndex = 4;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(555, 161);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(275, 26);
            this.txtBuscar.TabIndex = 3;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(664, 824);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(103, 44);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FrmHistorialCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1712, 959);
            this.Controls.Add(this.panelTabla);
            this.Name = "FrmHistorialCitas";
            this.Text = "FrmHistorialCitas";
            this.Load += new System.EventHandler(this.FrmHistorialCitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.panelTabla.ResumeLayout(false);
            this.panelTabla.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelTabla;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnVerTodos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbFiltroEstado;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}