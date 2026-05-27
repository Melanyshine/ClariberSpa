using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmReporteIngresos : Form
    {
        public FrmReporteIngresos()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmReporteIngresos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'claribetSpaDataSet1.sp_reporte_ingresos_mensuales' Puede moverla o quitarla según sea necesario.
            this.sp_reporte_ingresos_mensualesTableAdapter.Fill(this.claribetSpaDataSet1.sp_reporte_ingresos_mensuales);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
