using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
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
            this.WindowState = FormWindowState.Maximized;

            AplicarDiseno();

            txtBuscar.TextChanged += txtBuscar_TextChanged;
            btnBuscar.Click += btnBuscar_Click;
            btnVerTodos.Click += btnVerTodos_Click;
            cbFiltroEstado.SelectedIndexChanged += cbFiltroEstado_SelectedIndexChanged;

            CargarFiltroEstado();
            CargarHistorial();
        }

        // =========================
        // FILTRO ESTADO
        // =========================
        void CargarFiltroEstado()
        {
            cbFiltroEstado.Items.Clear();

            cbFiltroEstado.Items.AddRange(new object[]
            {
                "Todos",
                "Completada",
                "Cancelada"
            });

            cbFiltroEstado.SelectedIndex = 0;
        }

        // =========================
        // CARGAR HISTORIAL
        // =========================
        private void CargarHistorial()
        {
            try
            {
                DataView vista = bll.Listar().DefaultView;

                vista.RowFilter =
                    "nombre_estado = 'Completada' OR nombre_estado = 'Cancelada'";

                dgvHistorial.DataSource = vista;

                OcultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar historial:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================
        // BUSCAR
        // =========================
        void BuscarHistorial()
        {
            try
            {
                DataView vista = bll.Listar().DefaultView;

                string filtro =
                    "(nombre_estado = 'Completada' OR nombre_estado = 'Cancelada')";

                if (cbFiltroEstado.SelectedIndex > 0)
                {
                    filtro +=
                        $" AND nombre_estado = '{cbFiltroEstado.SelectedItem}'";
                }

                string texto =
                    txtBuscar.Text.Trim().Replace("'", "''");

                if (!string.IsNullOrEmpty(texto))
                {
                    bool tieneCliente =
                        vista.Table.Columns.Contains("cliente");

                    bool tieneAccion =
                        vista.Table.Columns.Contains("accion");

                    if (tieneCliente && tieneAccion)
                    {
                        filtro +=
                            $" AND (cliente LIKE '%{texto}%' OR accion LIKE '%{texto}%')";
                    }
                    else if (tieneAccion)
                    {
                        filtro +=
                            $" AND accion LIKE '%{texto}%'";
                    }
                }

                vista.RowFilter = filtro;

                dgvHistorial.DataSource = vista;

                OcultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al buscar:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================
        // CONFIG GRID
        // =========================
        void OcultarColumnas()
        {
            foreach (string col in new[]
            {
                "id_historial",
                "id_cita",
                "id_cliente",
                "id_servicio",
                "id_usuario"
            })
            {
                if (dgvHistorial.Columns.Contains(col))
                    dgvHistorial.Columns[col].Visible = false;
            }

            if (dgvHistorial.Columns.Contains("cliente"))
                dgvHistorial.Columns["cliente"].HeaderText = "Cliente";

            if (dgvHistorial.Columns.Contains("nombre_estado"))
                dgvHistorial.Columns["nombre_estado"].HeaderText = "Estado";

            if (dgvHistorial.Columns.Contains("fecha"))
                dgvHistorial.Columns["fecha"].HeaderText = "Fecha";

            if (dgvHistorial.Columns.Contains("hora_inicio"))
            {
                dgvHistorial.Columns["hora_inicio"].HeaderText = "Hora";

                dgvHistorial.Columns["hora_inicio"]
                    .DefaultCellStyle.Format = "hh\\:mm";
            }

            if (dgvHistorial.Columns.Contains("descripcion"))
                dgvHistorial.Columns["descripcion"].HeaderText = "Descripción";

            if (dgvHistorial.Columns.Contains("precio"))
                dgvHistorial.Columns["precio"].HeaderText = "Precio";

            if (dgvHistorial.Columns.Contains("accion"))
                dgvHistorial.Columns["accion"].HeaderText = "Acción";
        }

        // =========================
        // EVENTOS
        // =========================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarHistorial();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarHistorial();
        }

        private void cbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarHistorial();
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();

            cbFiltroEstado.SelectedIndex = 0;

            CargarHistorial();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =========================
        // DISEÑO
        // =========================
        private void AplicarDiseno()
        {
            // FORM
            this.BackColor =
                Color.FromArgb(249, 245, 242);

            // PANEL
            panelTabla.BackColor =
                Color.White;

            // TITULO
            lblTitulo.ForeColor =
                Color.FromArgb(70, 50, 48);

            lblTitulo.Font =
                new Font(
                    "Georgia",
                    22F,
                    FontStyle.Regular);

            // BUSCADOR
            txtBuscar.BackColor =
                Color.White;

            txtBuscar.ForeColor =
                Color.FromArgb(70, 50, 48);

            txtBuscar.BorderStyle =
                BorderStyle.FixedSingle;

            txtBuscar.Font =
                new Font(
                    "Segoe UI",
                    9F);

            // COMBO FILTRO
            cbFiltroEstado.BackColor =
                Color.White;

            cbFiltroEstado.ForeColor =
                Color.FromArgb(70, 50, 48);

            cbFiltroEstado.FlatStyle =
                FlatStyle.Flat;

            cbFiltroEstado.Font =
                new Font(
                    "Segoe UI",
                    9F);

            // BOTON PRINCIPAL
            btnBuscar.BackColor =
                Color.FromArgb(143, 94, 104);

            btnBuscar.ForeColor =
                Color.White;

            btnBuscar.FlatStyle =
                FlatStyle.Flat;

            btnBuscar.FlatAppearance.BorderSize =
                0;

            btnBuscar.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular);

            btnBuscar.Height = 40;

            // BOTONES SECUNDARIOS
            Button[] botones =
            {
                btnVerTodos,
                btnVolver
            };

            foreach (Button btn in botones)
            {
                btn.BackColor =
                    Color.FromArgb(245, 240, 235);

                btn.ForeColor =
                    Color.FromArgb(100, 80, 80);

                btn.FlatStyle =
                    FlatStyle.Flat;

                btn.FlatAppearance.BorderColor =
                    Color.FromArgb(220, 210, 205);

                btn.FlatAppearance.BorderSize =
                    1;

                btn.Font =
                    new Font(
                        "Segoe UI",
                        9F);

                btn.Height = 38;
            }

            // GRID
            dgvHistorial.BackgroundColor =
                Color.White;

            dgvHistorial.BorderStyle =
                BorderStyle.None;

            dgvHistorial.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvHistorial.GridColor =
                Color.FromArgb(245, 240, 238);

            dgvHistorial.RowHeadersVisible =
                false;

            dgvHistorial.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

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

            dgvHistorial.EnableHeadersVisualStyles =
                false;

            dgvHistorial.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            // CABECERA
            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(245, 238, 234);

            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(70, 50, 48);

            dgvHistorial.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            dgvHistorial.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(245, 238, 234);

            dgvHistorial.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Color.FromArgb(70, 50, 48);

            dgvHistorial.ColumnHeadersHeight =
                45;

            // FILAS
            dgvHistorial.DefaultCellStyle.BackColor =
                Color.White;

            dgvHistorial.DefaultCellStyle.ForeColor =
                Color.FromArgb(70, 50, 48);

            dgvHistorial.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Regular);

            dgvHistorial.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(250, 245, 242);

            dgvHistorial.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(70, 50, 48);

            dgvHistorial.RowTemplate.Height =
                45;

            dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor =
                Color.White;
        }
    }
}