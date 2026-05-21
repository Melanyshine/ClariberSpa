using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmHistorialCitas : Form
    {
        Historial_CitaBLL bll = new Historial_CitaBLL();

        public FrmHistorialCitas()
        {
            InitializeComponent();
        }

        private void FrmHistorialCitas_Load(object sender, EventArgs e)
        {
            try
            {
                dgvHistorial.DataSource = bll.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar historial:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            FrmHistorialCitas frm = new FrmHistorialCitas();
            frm.Show();
        }

    }
}