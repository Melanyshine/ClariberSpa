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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnFactura = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnDisponibilidad = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnServicios = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.btnVerTodasCitas = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chartResumen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblClientesTitulo = new System.Windows.Forms.Label();
            this.lblClientesCantidad = new System.Windows.Forms.Label();
            this.btnVerClientes = new System.Windows.Forms.Button();
            this.lblServiciosTitulo = new System.Windows.Forms.Label();
            this.lblServiciosCantidad = new System.Windows.Forms.Label();
            this.btnVerServicios = new System.Windows.Forms.Button();
            this.btnVerCitas = new System.Windows.Forms.Button();
            this.lblCitasTitulo = new System.Windows.Forms.Label();
            this.lblCitasCantidad = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResumen)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnConfiguracion);
            this.panelMenu.Controls.Add(this.btnReportes);
            this.panelMenu.Controls.Add(this.btnInicio);
            this.panelMenu.Controls.Add(this.btnFactura);
            this.panelMenu.Controls.Add(this.btnUsuario);
            this.panelMenu.Controls.Add(this.lblTitulo);
            this.panelMenu.Controls.Add(this.btnCerrarSesion);
            this.panelMenu.Controls.Add(this.btnDisponibilidad);
            this.panelMenu.Controls.Add(this.btnCitas);
            this.panelMenu.Controls.Add(this.btnServicios);
            this.panelMenu.Controls.Add(this.btnClientes);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(353, 858);
            this.panelMenu.TabIndex = 0;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Location = new System.Drawing.Point(55, 810);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(160, 45);
            this.btnConfiguracion.TabIndex = 0;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(55, 725);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(160, 45);
            this.btnReportes.TabIndex = 0;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Location = new System.Drawing.Point(55, 115);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(160, 44);
            this.btnInicio.TabIndex = 5;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnFactura
            // 
            this.btnFactura.Location = new System.Drawing.Point(55, 543);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(160, 44);
            this.btnFactura.TabIndex = 0;
            this.btnFactura.Text = "Factura";
            this.btnFactura.UseVisualStyleBackColor = true;
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(55, 370);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(160, 44);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.Text = "Usuarios";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(27, 55);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(51, 20);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "label1";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(55, 926);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(160, 44);
            this.btnCerrarSesion.TabIndex = 1;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnDisponibilidad
            // 
            this.btnDisponibilidad.Location = new System.Drawing.Point(55, 635);
            this.btnDisponibilidad.Name = "btnDisponibilidad";
            this.btnDisponibilidad.Size = new System.Drawing.Size(160, 44);
            this.btnDisponibilidad.TabIndex = 3;
            this.btnDisponibilidad.Text = "Disponibilidad";
            this.btnDisponibilidad.UseVisualStyleBackColor = true;
            this.btnDisponibilidad.Click += new System.EventHandler(this.btnDisponibilidad_Click);
            // 
            // btnCitas
            // 
            this.btnCitas.Location = new System.Drawing.Point(55, 452);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(160, 44);
            this.btnCitas.TabIndex = 2;
            this.btnCitas.Text = "Citas";
            this.btnCitas.UseVisualStyleBackColor = true;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // btnServicios
            // 
            this.btnServicios.Location = new System.Drawing.Point(55, 283);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Size = new System.Drawing.Size(160, 44);
            this.btnServicios.TabIndex = 1;
            this.btnServicios.Text = "Servicios";
            this.btnServicios.UseVisualStyleBackColor = true;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(55, 203);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(160, 44);
            this.btnClientes.TabIndex = 1;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.lblCitasCantidad);
            this.panelContenido.Controls.Add(this.lblCitasTitulo);
            this.panelContenido.Controls.Add(this.btnVerCitas);
            this.panelContenido.Controls.Add(this.btnVerServicios);
            this.panelContenido.Controls.Add(this.lblServiciosCantidad);
            this.panelContenido.Controls.Add(this.lblServiciosTitulo);
            this.panelContenido.Controls.Add(this.btnVerClientes);
            this.panelContenido.Controls.Add(this.lblClientesCantidad);
            this.panelContenido.Controls.Add(this.lblClientesTitulo);
            this.panelContenido.Controls.Add(this.btnVerTodasCitas);
            this.panelContenido.Controls.Add(this.dataGridView1);
            this.panelContenido.Controls.Add(this.chartResumen);
            this.panelContenido.Controls.Add(this.lblSubtitulo);
            this.panelContenido.Controls.Add(this.lblBienvenida);
            this.panelContenido.Location = new System.Drawing.Point(300, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(1524, 935);
            this.panelContenido.TabIndex = 1;
            this.panelContenido.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenido_Paint);
            // 
            // btnVerTodasCitas
            // 
            this.btnVerTodasCitas.Location = new System.Drawing.Point(589, 727);
            this.btnVerTodasCitas.Name = "btnVerTodasCitas";
            this.btnVerTodasCitas.Size = new System.Drawing.Size(177, 39);
            this.btnVerTodasCitas.TabIndex = 4;
            this.btnVerTodasCitas.Text = "Ver todas las citas";
            this.btnVerTodasCitas.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(476, 426);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(413, 295);
            this.dataGridView1.TabIndex = 3;
            // 
            // chartResumen
            // 
            chartArea4.Name = "ChartArea1";
            this.chartResumen.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartResumen.Legends.Add(legend4);
            this.chartResumen.Location = new System.Drawing.Point(1008, 426);
            this.chartResumen.Name = "chartResumen";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartResumen.Series.Add(series4);
            this.chartResumen.Size = new System.Drawing.Size(418, 304);
            this.chartResumen.TabIndex = 2;
            this.chartResumen.Text = "chart1";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Location = new System.Drawing.Point(472, 101);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(343, 20);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Panel principal del Sistema Clariber Spa Beauty";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(472, 66);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(184, 20);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Binvenido, Administrador";
            // 
            // lblClientesTitulo
            // 
            this.lblClientesTitulo.AutoSize = true;
            this.lblClientesTitulo.Location = new System.Drawing.Point(472, 227);
            this.lblClientesTitulo.Name = "lblClientesTitulo";
            this.lblClientesTitulo.Size = new System.Drawing.Size(156, 20);
            this.lblClientesTitulo.TabIndex = 5;
            this.lblClientesTitulo.Text = "Clientes Registrados";
            // 
            // lblClientesCantidad
            // 
            this.lblClientesCantidad.AutoSize = true;
            this.lblClientesCantidad.Location = new System.Drawing.Point(472, 264);
            this.lblClientesCantidad.Name = "lblClientesCantidad";
            this.lblClientesCantidad.Size = new System.Drawing.Size(51, 20);
            this.lblClientesCantidad.TabIndex = 6;
            this.lblClientesCantidad.Text = "label1";
            // 
            // btnVerClientes
            // 
            this.btnVerClientes.Location = new System.Drawing.Point(502, 314);
            this.btnVerClientes.Name = "btnVerClientes";
            this.btnVerClientes.Size = new System.Drawing.Size(117, 35);
            this.btnVerClientes.TabIndex = 7;
            this.btnVerClientes.Text = "Ver Clientes";
            this.btnVerClientes.UseVisualStyleBackColor = true;
            // 
            // lblServiciosTitulo
            // 
            this.lblServiciosTitulo.AutoSize = true;
            this.lblServiciosTitulo.Location = new System.Drawing.Point(848, 227);
            this.lblServiciosTitulo.Name = "lblServiciosTitulo";
            this.lblServiciosTitulo.Size = new System.Drawing.Size(127, 20);
            this.lblServiciosTitulo.TabIndex = 8;
            this.lblServiciosTitulo.Text = "Servicios Activos";
            // 
            // lblServiciosCantidad
            // 
            this.lblServiciosCantidad.AutoSize = true;
            this.lblServiciosCantidad.Location = new System.Drawing.Point(848, 264);
            this.lblServiciosCantidad.Name = "lblServiciosCantidad";
            this.lblServiciosCantidad.Size = new System.Drawing.Size(51, 20);
            this.lblServiciosCantidad.TabIndex = 9;
            this.lblServiciosCantidad.Text = "label1";
            // 
            // btnVerServicios
            // 
            this.btnVerServicios.Location = new System.Drawing.Point(852, 315);
            this.btnVerServicios.Name = "btnVerServicios";
            this.btnVerServicios.Size = new System.Drawing.Size(123, 34);
            this.btnVerServicios.TabIndex = 10;
            this.btnVerServicios.Text = "Ver Servicios";
            this.btnVerServicios.UseVisualStyleBackColor = true;
            // 
            // btnVerCitas
            // 
            this.btnVerCitas.Location = new System.Drawing.Point(1202, 315);
            this.btnVerCitas.Name = "btnVerCitas";
            this.btnVerCitas.Size = new System.Drawing.Size(110, 35);
            this.btnVerCitas.TabIndex = 11;
            this.btnVerCitas.Text = "Ver Citas";
            this.btnVerCitas.UseVisualStyleBackColor = true;
            // 
            // lblCitasTitulo
            // 
            this.lblCitasTitulo.AutoSize = true;
            this.lblCitasTitulo.Location = new System.Drawing.Point(1198, 227);
            this.lblCitasTitulo.Name = "lblCitasTitulo";
            this.lblCitasTitulo.Size = new System.Drawing.Size(99, 20);
            this.lblCitasTitulo.TabIndex = 12;
            this.lblCitasTitulo.Text = "Citas de Hoy";
            // 
            // lblCitasCantidad
            // 
            this.lblCitasCantidad.AutoSize = true;
            this.lblCitasCantidad.Location = new System.Drawing.Point(1198, 264);
            this.lblCitasCantidad.Name = "lblCitasCantidad";
            this.lblCitasCantidad.Size = new System.Drawing.Size(51, 20);
            this.lblCitasCantidad.TabIndex = 13;
            this.lblCitasCantidad.Text = "label1";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1821, 858);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelContenido);
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResumen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;

        public System.Windows.Forms.Button btnCitas;

        private System.Windows.Forms.Button btnServicios;

        private System.Windows.Forms.Button btnClientes;

        public System.Windows.Forms.Button btnDisponibilidad;

        private System.Windows.Forms.Button btnCerrarSesion;

        private System.Windows.Forms.Panel panelContenido;

        private System.Windows.Forms.Label lblTitulo;

        public System.Windows.Forms.Button btnUsuario;

        public System.Windows.Forms.Button btnFactura;

        private System.Windows.Forms.Button btnInicio;

        public System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResumen;
        private System.Windows.Forms.Button btnVerTodasCitas;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblClientesTitulo;
        private System.Windows.Forms.Label lblServiciosTitulo;
        private System.Windows.Forms.Button btnVerClientes;
        private System.Windows.Forms.Label lblClientesCantidad;
        private System.Windows.Forms.Button btnVerServicios;
        private System.Windows.Forms.Label lblServiciosCantidad;
        private System.Windows.Forms.Label lblCitasCantidad;
        private System.Windows.Forms.Label lblCitasTitulo;
        private System.Windows.Forms.Button btnVerCitas;
    }
}