namespace Capa_Presentacion
{
    partial class FrmReporteIngresos
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.claribetSpaDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.claribetSpaDataSet1 = new Capa_Presentacion.ClaribetSpaDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_reporte_ingresos_mensualesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spreporteingresosmensualesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_reporte_ingresos_mensualesTableAdapter = new Capa_Presentacion.ClaribetSpaDataSet1TableAdapters.sp_reporte_ingresos_mensualesTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.claribetSpaDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claribetSpaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_reporte_ingresos_mensualesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreporteingresosmensualesBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // claribetSpaDataSet1BindingSource
            // 
            this.claribetSpaDataSet1BindingSource.DataSource = this.claribetSpaDataSet1;
            this.claribetSpaDataSet1BindingSource.Position = 0;
            // 
            // claribetSpaDataSet1
            // 
            this.claribetSpaDataSet1.DataSetName = "ClaribetSpaDataSet1";
            this.claribetSpaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spreporteingresosmensualesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Capa_Presentacion.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(984, 611);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            this.reportViewer1.Click += new System.EventHandler(this.FrmReporteIngresos_Load);
            // 
            // sp_reporte_ingresos_mensualesBindingSource
            // 
            this.sp_reporte_ingresos_mensualesBindingSource.DataMember = "sp_reporte_ingresos_mensuales";
            this.sp_reporte_ingresos_mensualesBindingSource.DataSource = this.claribetSpaDataSet1;
            // 
            // spreporteingresosmensualesBindingSource
            // 
            this.spreporteingresosmensualesBindingSource.DataMember = "sp_reporte_ingresos_mensuales";
            this.spreporteingresosmensualesBindingSource.DataSource = this.claribetSpaDataSet1BindingSource;
            // 
            // sp_reporte_ingresos_mensualesTableAdapter
            // 
            this.sp_reporte_ingresos_mensualesTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 611);
            this.panel1.TabIndex = 1;
            // 
            // FrmReporteIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReporteIngresos";
            this.Text = "FrmReporteIngresos";
            this.Load += new System.EventHandler(this.FrmReporteIngresos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.claribetSpaDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claribetSpaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_reporte_ingresos_mensualesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreporteingresosmensualesBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource claribetSpaDataSet1BindingSource;
        private ClaribetSpaDataSet1 claribetSpaDataSet1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_reporte_ingresos_mensualesBindingSource;
        private System.Windows.Forms.BindingSource spreporteingresosmensualesBindingSource;
        private ClaribetSpaDataSet1TableAdapters.sp_reporte_ingresos_mensualesTableAdapter sp_reporte_ingresos_mensualesTableAdapter;
        private System.Windows.Forms.Panel panel1;
    }
}