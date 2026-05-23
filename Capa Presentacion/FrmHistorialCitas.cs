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

        private readonly Color colorRosado = Color.RosyBrown;
        private readonly Color fondo = Color.FromArgb(250, 248, 246);

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

     
        void BuscarHistorial()
        {
            try
            {
                DataView vista = bll.Listar().DefaultView;

                string filtro =
                    "(nombre_estado = 'Completada' OR nombre_estado = 'Cancelada')";

                // FILTRO ESTADO
                if (cbFiltroEstado.SelectedIndex > 0)
                {
                    filtro =
                        $"nombre_estado = '{cbFiltroEstado.SelectedItem}'";
                }

                // TEXTO BUSQUEDA
                string texto = txtBuscar.Text.Trim().Replace("'", "''");

                if (!string.IsNullOrEmpty(texto))
                {
                    // ✅ VALIDAR SI EXISTE COLUMNA CLIENTE
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

            // HEADERS
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

            dgvHistorial.RowTemplate.Height = 38;

            // ✅ QUITAR AZUL
            dgvHistorial.EnableHeadersVisualStyles = false;

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
                    FontStyle.Bold
                );

            dgvHistorial.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }

        // =========================
        // 🔍 EVENTOS
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

       
        void EstilarBoton(
            Button btn,
            Color fondoBtn,
            Color texto,
            bool negrita = false
        )
        {
            btn.BackColor = fondoBtn;
            btn.ForeColor = texto;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.Font = new Font(
                "Segoe UI" + (negrita ? " Semibold" : ""),
                10F
            );

            btn.Height = 28;

            btn.Cursor = Cursors.Hand;
        }

        private void AplicarDiseno()
        {
            this.BackColor = fondo;

            panelTabla.BackColor = Color.White;

            lblTitulo.ForeColor = colorRosado;

            lblTitulo.Font =
                new Font(
                    "Segoe UI Semibold",
                    28F,
                    FontStyle.Bold
                );

            // =========================
            // BUSCADOR
            // =========================
            txtBuscar.BackColor = Color.White;
            txtBuscar.ForeColor = Color.Gray;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;

            txtBuscar.Font =
                new Font("Segoe UI", 9F);

            txtBuscar.Height = 28;

            // =========================
            // FILTRO
            // =========================
            cbFiltroEstado.BackColor = Color.White;
            cbFiltroEstado.ForeColor = Color.Black;
            cbFiltroEstado.FlatStyle = FlatStyle.Flat;

            cbFiltroEstado.Font =
                new Font("Segoe UI", 9F);

            cbFiltroEstado.Height = 28;

            // =========================
            // BOTONES
            // =========================
            Color beige =
                Color.FromArgb(242, 235, 231);

            EstilarBoton(
                btnBuscar,
                colorRosado,
                Color.White,
                true
            );

            EstilarBoton(
                btnVerTodos,
                beige,
                colorRosado
            );

            EstilarBoton(
                btnVolver,
                colorRosado,
                Color.White,
                true
            );

            btnVolver.Height = 40;

            btnVolver.Font =
                new Font(
                    "Segoe UI Semibold",
                    11F,
                    FontStyle.Bold
                );

            btnVolver.Text = "← Volver";

            // =========================
            // TABLA
            // =========================
            dgvHistorial.BackgroundColor = Color.White;

            dgvHistorial.BorderStyle =
                BorderStyle.None;

            dgvHistorial.RowHeadersVisible = false;

            dgvHistorial.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvHistorial.ColumnHeadersHeight = 45;

            dgvHistorial.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

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

            dgvHistorial.MultiSelect = false;

            dgvHistorial.ReadOnly = true;

            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AllowUserToResizeRows = false;
            dgvHistorial.EnableHeadersVisualStyles = false;

            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor =
                Color.RosyBrown;

            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvHistorial.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.RosyBrown;

            dgvHistorial.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvHistorial.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvHistorial.ColumnHeadersHeight = 45;

            dgvHistorial.Refresh();
        }
    }
}