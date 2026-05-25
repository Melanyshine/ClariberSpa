using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmHistorialFacturas : Form
    {
        // =========================================
        // COLORES
        // =========================================

        private readonly Color colorVino =
            Color.FromArgb(140, 79, 94);

        private readonly Color colorFondo =
            Color.FromArgb(250, 248, 246);

        private readonly Color colorBeige =
            Color.FromArgb(242, 235, 231);

        private readonly Color colorTexto =
            Color.FromArgb(70, 50, 48);

        // =========================================
        // BLL
        // =========================================

        FacturaBLL facturaBLL =
            new FacturaBLL();

        public FrmHistorialFacturas()
        {
            InitializeComponent();
        }

        private void FrmHistorialFacturas_Load(
            object sender,
            EventArgs e)
        {
            this.WindowState =
                FormWindowState.Maximized;

            AplicarDiseno();

            CargarFiltroEstado();

            MostrarHistorial();

            // EVENTOS
            txtBuscar.TextChanged +=
                txtBuscar_TextChanged;

            btnBuscar.Click +=
                btnBuscar_Click;

            btnVerTodos.Click +=
                btnVerTodos_Click;

            btnVerDetalle.Click +=
                btnVerDetalle_Click;

            cbFiltroEstado.SelectedIndexChanged +=
                cbFiltroEstado_SelectedIndexChanged;
        }

        // =========================================
        // CARGAR FILTRO
        // =========================================

        void CargarFiltroEstado()
        {
            cbFiltroEstado.Items.Clear();

            cbFiltroEstado.Items.AddRange(
                new object[]
                {
                    "Todos",
                    "Pagado",
                    "Cancelado"
                });

            cbFiltroEstado.SelectedIndex = 0;
        }

        // =========================================
        // MOSTRAR HISTORIAL
        // =========================================

        void MostrarHistorial()
        {
            DataView vista =
                facturaBLL.Listar().DefaultView;

            vista.RowFilter =
                "estado_pago = 'Pagado' " +
                "OR estado_pago = 'Cancelado'";

            dgvHistorial.DataSource =
                vista;

            OcultarColumnas();
        }

        // =========================================
        // BUSCAR
        // =========================================

        void BuscarHistorial()
        {
            DataView vista =
                facturaBLL.Listar().DefaultView;

            string filtro =
                "(estado_pago = 'Pagado' " +
                "OR estado_pago = 'Cancelado')";

            if (cbFiltroEstado.SelectedIndex > 0)
            {
                filtro +=
                    $" AND estado_pago = '{cbFiltroEstado.SelectedItem}'";
            }

            string texto =
                txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(texto))
            {
                filtro +=
                    $" AND cliente LIKE '%{texto}%'";
            }

            vista.RowFilter =
                filtro;

            dgvHistorial.DataSource =
                vista;

            OcultarColumnas();
        }

        // =========================================
        // OCULTAR COLUMNAS
        // =========================================

        void OcultarColumnas()
        {
            if (dgvHistorial.Columns.Contains("id_cliente"))
            {
                dgvHistorial.Columns["id_cliente"]
                    .Visible = false;
            }

            // ENCABEZADOS

            if (dgvHistorial.Columns.Contains("id_factura"))
            {
                dgvHistorial.Columns["id_factura"]
                    .HeaderText = "Factura";
            }

            if (dgvHistorial.Columns.Contains("cliente"))
            {
                dgvHistorial.Columns["cliente"]
                    .HeaderText = "Cliente";
            }

            if (dgvHistorial.Columns.Contains("fecha_factura"))
            {
                dgvHistorial.Columns["fecha_factura"]
                    .HeaderText = "Fecha";
            }

            if (dgvHistorial.Columns.Contains("total"))
            {
                dgvHistorial.Columns["total"]
                    .HeaderText = "Total";

                dgvHistorial.Columns["total"]
                    .DefaultCellStyle.Format = "N2";
            }

            if (dgvHistorial.Columns.Contains("metodo_pago"))
            {
                dgvHistorial.Columns["metodo_pago"]
                    .HeaderText = "Método Pago";
            }

            if (dgvHistorial.Columns.Contains("estado_pago"))
            {
                dgvHistorial.Columns["estado_pago"]
                    .HeaderText = "Estado";
            }
        }

        // =========================================
        // EVENTOS
        // =========================================

        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            BuscarHistorial();
        }

        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            BuscarHistorial();
        }

        private void cbFiltroEstado_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            BuscarHistorial();
        }

        private void btnVerTodos_Click(
            object sender,
            EventArgs e)
        {
            txtBuscar.Clear();

            cbFiltroEstado.SelectedIndex = 0;

            MostrarHistorial();
        }

        // =========================================
        // VER DETALLE
        // =========================================

        private void btnVerDetalle_Click(
            object sender,
            EventArgs e)
        {
            if (dgvHistorial.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona una factura primero.",
                    "Sin selección",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idFactura =
                Convert.ToInt32(
                    dgvHistorial.CurrentRow
                    .Cells["id_factura"].Value);

            FrmDetalleFactura frmDetalle =
                new FrmDetalleFactura(idFactura);

            frmDetalle.ShowDialog();
        }

        // =========================================
        // BOTONES
        // =========================================

        void EstilarBoton(
            Button btn,
            Color fondo,
            Color texto,
            bool negrita = false)
        {
            btn.BackColor =
                fondo;

            btn.ForeColor =
                texto;

            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize =
                0;

            btn.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    negrita
                        ? FontStyle.Bold
                        : FontStyle.Regular);

            btn.Height =
                40;

            btn.Cursor =
                Cursors.Hand;
        }

        // =========================================
        // DISEÑO
        // =========================================

        void AplicarDiseno()
        {
            // =========================================
            // FORM
            // =========================================

            this.BackColor =
                Color.FromArgb(249, 245, 242);

            // =========================================
            // PANEL
            // =========================================

            panelTabla.BackColor =
                Color.White;

            // =========================================
            // TITULO
            // =========================================

            lblTitulo.ForeColor =
                Color.FromArgb(70, 50, 48);

            lblTitulo.Font =
                new Font(
                    "Georgia",
                    22F,
                    FontStyle.Regular);

            // =========================================
            // SUBTITULO
            // =========================================

            lblSubtitulo.ForeColor =
                Color.Gray;

            lblSubtitulo.Font =
                new Font(
                    "Segoe UI",
                    9F);

            // =========================================
            // BUSCADOR
            // =========================================

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

            // =========================================
            // COMBO FILTRO
            // =========================================

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

            // =========================================
            // BOTONES PRINCIPALES
            // =========================================

            EstilarBoton(
                btnBuscar,
                Color.FromArgb(143, 94, 104),
                Color.White,
                true);

            EstilarBoton(
                btnVerDetalle,
                Color.FromArgb(143, 94, 104),
                Color.White,
                true);

            // =========================================
            // BOTONES SECUNDARIOS
            // =========================================

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

                btn.Height =
                    38;
            }

            // =========================================
            // GRID
            // =========================================

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

            // =========================================
            // CABECERA
            // =========================================

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

            // =========================================
            // FILAS
            // =========================================

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

        // =========================================
        // VOLVER
        // =========================================

        private void btnVolver_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }
    }
}