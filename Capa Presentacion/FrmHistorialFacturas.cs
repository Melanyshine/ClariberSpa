using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmHistorialFacturas : Form
    {

        
        private readonly Color colorVino = Color.FromArgb(140, 79, 94);
        private readonly Color colorFondo = Color.FromArgb(250, 248, 246);
        private readonly Color colorBeige = Color.FromArgb(242, 235, 231);
        private readonly Color colorTexto = Color.FromArgb(70, 50, 48);

        
        FacturaBLL facturaBLL = new FacturaBLL();

        public FrmHistorialFacturas()
        {
            InitializeComponent();
           
        }

        private void FrmHistorialFacturas_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            AplicarDiseno();
            CargarFiltroEstado();
            MostrarHistorial();

            // Suscribir eventos AL FINAL
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            btnBuscar.Click += btnBuscar_Click;
            btnVerTodos.Click += btnVerTodos_Click;
            btnVerDetalle.Click += btnVerDetalle_Click;

            // Este AL ÚLTIMO para evitar que dispare al cargar
            cbFiltroEstado.SelectedIndexChanged += cbFiltroEstado_SelectedIndexChanged;
        }
        // =========================
        // CARGAR FILTRO ESTADO
        // =========================
        void CargarFiltroEstado()
        {
            cbFiltroEstado.Items.Clear();
            cbFiltroEstado.Items.AddRange(new object[]
            {
                "Todos",
                "Pagado",
                "Cancelado"
            });
            cbFiltroEstado.SelectedIndex = 0;
        }

        // =========================
        // MOSTRAR TODO
        // =========================
        void MostrarHistorial()
        {
            DataView vista = facturaBLL.Listar().DefaultView;
            vista.RowFilter = "estado_pago = 'Pagado' OR estado_pago = 'Cancelado'";
            dgvHistorial.DataSource = vista;
            EstilarGrid();
            OcultarColumnas();
        }

        // =========================
        // BUSCAR / FILTRAR
        // =========================
        void BuscarHistorial()
        {
            DataView vista = facturaBLL.Listar().DefaultView;
            string filtro = "estado_pago = 'Pagado' OR estado_pago = 'Cancelado'";

            if (cbFiltroEstado.SelectedIndex > 0)
                filtro = $"estado_pago = '{cbFiltroEstado.SelectedItem}'";

            string texto = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
                filtro += $" AND cliente LIKE '%{texto}%'";

            vista.RowFilter = filtro;
            dgvHistorial.DataSource = vista;
            EstilarGrid();
            OcultarColumnas();
        }

        // =========================
        // OCULTAR COLUMNAS
        // =========================
        void OcultarColumnas()
        {
            if (dgvHistorial.Columns.Contains("id_cliente"))
                dgvHistorial.Columns["id_cliente"].Visible = false;

            // Renombrar encabezados
            if (dgvHistorial.Columns.Contains("id_factura"))
                dgvHistorial.Columns["id_factura"].HeaderText = "Factura";

            if (dgvHistorial.Columns.Contains("cliente"))
                dgvHistorial.Columns["cliente"].HeaderText = "Cliente";

            if (dgvHistorial.Columns.Contains("fecha_factura"))
                dgvHistorial.Columns["fecha_factura"].HeaderText = "Fecha";

            if (dgvHistorial.Columns.Contains("total"))
            {
                dgvHistorial.Columns["total"].HeaderText = "Total";
                dgvHistorial.Columns["total"].DefaultCellStyle.Format = "N2";
            }

            if (dgvHistorial.Columns.Contains("metodo_pago"))
                dgvHistorial.Columns["metodo_pago"].HeaderText = "Método Pago";

            if (dgvHistorial.Columns.Contains("estado_pago"))
                dgvHistorial.Columns["estado_pago"].HeaderText = "Estado";
        }

        // =========================
        // EVENTOS
        // =========================
        private void txtBuscar_TextChanged(object sender, EventArgs e) => BuscarHistorial();
        private void btnBuscar_Click(object sender, EventArgs e) => BuscarHistorial();
        private void cbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e) => BuscarHistorial();
        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cbFiltroEstado.SelectedIndex = 0;
            MostrarHistorial();
        }

        // =========================
        // VER DETALLE
        // =========================
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una factura primero.", "Sin selección",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idFactura = Convert.ToInt32(dgvHistorial.CurrentRow.Cells["id_factura"].Value);
            FrmDetalleFactura frmDetalle = new FrmDetalleFactura(idFactura);
            frmDetalle.ShowDialog();
        }

        // =========================
        // DISEÑO GRID
        // =========================
        void EstilarGrid()
        {
            dgvHistorial.EnableHeadersVisualStyles = false;
            dgvHistorial.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = colorVino;
            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F);
            dgvHistorial.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BorderStyle = BorderStyle.None;
            dgvHistorial.BackgroundColor = Color.White;
            dgvHistorial.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvHistorial.DefaultCellStyle.ForeColor = colorTexto;
            dgvHistorial.DefaultCellStyle.SelectionBackColor = colorBeige;
            dgvHistorial.DefaultCellStyle.SelectionForeColor = colorTexto;
            dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 244, 242);
            dgvHistorial.GridColor = Color.FromArgb(235, 230, 228);
            dgvHistorial.RowTemplate.Height = 42;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.MultiSelect = false;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.ColumnHeadersHeight = 45;
        }

        // =========================
        // DISEÑO GENERAL
        // =========================
        void EstilarBoton(Button btn, Color fondo, Color texto, bool negrita = false)
        {
            btn.BackColor = fondo;
            btn.ForeColor = texto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI" + (negrita ? " Semibold" : ""), 10F);
            btn.Height = 36;
            btn.Cursor = Cursors.Hand;
        }

        void AplicarDiseno()
        {
            this.BackColor = colorFondo;
            panelTabla.BackColor = Color.White;

            // Título
            lblTitulo.ForeColor = colorVino;
            lblTitulo.Font = new Font("Georgia", 22F, FontStyle.Regular);

            lblSubtitulo.ForeColor = Color.Gray;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);

            // Buscador
            txtBuscar.BackColor = Color.White;
            txtBuscar.ForeColor = Color.Gray;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 10F);

            // Combo filtro
            cbFiltroEstado.BackColor = Color.White;
            cbFiltroEstado.ForeColor = colorTexto;
            cbFiltroEstado.FlatStyle = FlatStyle.Flat;
            cbFiltroEstado.Font = new Font("Segoe UI", 10F);

            // Botones
            EstilarBoton(btnVolver, colorBeige, colorVino);
            EstilarBoton(btnBuscar, colorVino, Color.White, negrita: true);
            EstilarBoton(btnVerTodos, colorBeige, colorVino);
            EstilarBoton(btnVerDetalle, colorVino, Color.White, negrita: true);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}