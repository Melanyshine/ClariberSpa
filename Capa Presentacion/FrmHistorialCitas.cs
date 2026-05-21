using CapaNegocio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmHistorialCitas : Form
    {
        Historial_CitaBLL bll =
            new Historial_CitaBLL();

        // 🎨 COLORES
        Color colorRosado =
            Color.RosyBrown;

        Color fondo =
            Color.FromArgb(250, 248, 246);

        public FrmHistorialCitas()
        {
            InitializeComponent();
        }

        private void FrmHistorialCitas_Load(
            object sender,
            EventArgs e)
        {
            // 🔥 ABRIR GRANDE
            this.WindowState =
                FormWindowState.Maximized;

            AplicarDiseno();

            try
            {
                dgvHistorial.DataSource =
                    bll.Listar();

                // 🔥 OCULTAR IDS
                if (dgvHistorial.Columns.Contains("id_historial"))
                    dgvHistorial.Columns["id_historial"].Visible = false;

                if (dgvHistorial.Columns.Contains("id_cita"))
                    dgvHistorial.Columns["id_cita"].Visible = false;

                // 🔥 CAMBIAR TITULOS
                if (dgvHistorial.Columns.Contains("nombre_estado"))
                    dgvHistorial.Columns["nombre_estado"].HeaderText =
                        "Estado";

                if (dgvHistorial.Columns.Contains("fecha"))
                    dgvHistorial.Columns["fecha"].HeaderText =
                        "Fecha";

                if (dgvHistorial.Columns.Contains("accion"))
                    dgvHistorial.Columns["accion"].HeaderText =
                        "Acción";

                // 🔥 CENTRAR HEADERS
                dgvHistorial.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                // 🔥 ALTURA FILAS
                dgvHistorial.RowTemplate.Height =
                    38;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar historial:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // 🔥 BOTON VOLVER
        private void btnVolver_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }

        // 🎨 DISEÑO
        private void AplicarDiseno()
        {
            // FORM
            this.BackColor =
                fondo;

            // TITULO
            lblTitulo.ForeColor =
                colorRosado;

            lblTitulo.Font =
                new Font(
                    "Segoe UI Semibold",
                    28F,
                    FontStyle.Bold);

            // PANEL TABLA
            panelTabla.BackColor =
                Color.White;

            // TABLA
            dgvHistorial.BackgroundColor =
                Color.White;

            dgvHistorial.BorderStyle =
                BorderStyle.None;

            dgvHistorial.RowHeadersVisible =
                false;

            dgvHistorial.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvHistorial.EnableHeadersVisualStyles =
                false;

            dgvHistorial.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor =
                colorRosado;

            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvHistorial.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI Semibold",
                    11F,
                    FontStyle.Bold);

            dgvHistorial.ColumnHeadersHeight =
                45;

            dgvHistorial.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            dgvHistorial.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(230, 210, 215);

            dgvHistorial.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgvHistorial.DefaultCellStyle.Padding =
                new Padding(5);

            dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 244, 242);

            dgvHistorial.GridColor =
                Color.FromArgb(235, 230, 228);

            dgvHistorial.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvHistorial.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHistorial.MultiSelect =
                false;

            dgvHistorial.ReadOnly =
                true;

            dgvHistorial.AllowUserToAddRows =
                false;

            dgvHistorial.AllowUserToDeleteRows =
                false;

            dgvHistorial.AllowUserToResizeRows =
                false;

            // 🔥 BOTON VOLVER
            btnVolver.BackColor =
                colorRosado;

            btnVolver.ForeColor =
                Color.White;

            btnVolver.FlatStyle =
                FlatStyle.Flat;

            btnVolver.FlatAppearance.BorderSize =
                0;

            btnVolver.Font =
                new Font(
                    "Segoe UI Semibold",
                    11F,
                    FontStyle.Bold);

            btnVolver.Cursor =
                Cursors.Hand;

            btnVolver.Text =
                "← Volver";
        }

        private void BtnHistorial_Click(
            object sender,
            EventArgs e)
        {
            FrmHistorialCitas frm =
                new FrmHistorialCitas();

            frm.ShowDialog();
        }
    }
}