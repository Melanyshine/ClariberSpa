namespace Capa_Presentacion
{
    partial class FrmFacturaReporte
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.claribetSpaDataSet2 = new Capa_Presentacion.ClaribetSpaDataSet2();
            this.claribetSpaDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.claribetSpaDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claribetSpaDataSet2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.claribetSpaDataSet2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Capa_Presentacion.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer2_Load);
            this.reportViewer1.Click += new System.EventHandler(this.FrmFacturaReporte_Load);
            // 
            // claribetSpaDataSet2
            // 
            this.claribetSpaDataSet2.DataSetName = "ClaribetSpaDataSet2";
            this.claribetSpaDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // claribetSpaDataSet2BindingSource
            // 
            this.claribetSpaDataSet2BindingSource.DataSource = this.claribetSpaDataSet2;
            this.claribetSpaDataSet2BindingSource.Position = 0;
            // 
            // FrmFacturaReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmFacturaReporte";
            this.Text = "FrmFacturaReporte";
            this.Load += new System.EventHandler(this.FrmFacturaReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.claribetSpaDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claribetSpaDataSet2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource claribetSpaDataSet2BindingSource;
        private ClaribetSpaDataSet2 claribetSpaDataSet2;
    }
}