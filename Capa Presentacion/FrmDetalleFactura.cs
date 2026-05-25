using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace Capa_Presentacion
{
    public partial class FrmDetalleFactura : Form
    {
        // =========================
        // COLORES
        // =========================
        private readonly Color colorVino =
            Color.RosyBrown;

        private readonly Color colorFondo =
            Color.FromArgb(250, 248, 246);

        private readonly Color colorBeige =
            Color.FromArgb(242, 235, 231);

        // =========================
        // BLL
        // =========================
        Detalle_FacturaBLL detalleBLL =
            new Detalle_FacturaBLL();

        // =========================
        // TABLA
        // =========================
        DataTable tablaDetalle =
            new DataTable();

        // =========================
        // CONSTRUCTOR
        // =========================
        private int _idFactura;

        public FrmDetalleFactura(int idFactura)
        {
            InitializeComponent();
            _idFactura = idFactura;
        }

        private void FrmDetalleFactura_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            AplicarDiseno();

            cbFiltro.Items.Clear();
            cbFiltro.Items.Add("Factura");
            cbFiltro.Items.Add("Servicio");
            cbFiltro.Items.Add("Descripcion");
            cbFiltro.SelectedIndex = 0;

            // Cargar solo los detalles de esa factura
            tablaDetalle = detalleBLL.ObtenerPorFactura(_idFactura);
            dgvDetalle.DataSource = tablaDetalle;
            OcultarColumnas();
        }

        // =========================
        // MOSTRAR DATOS
        // =========================
        void MostrarDetalle()
        {
            tablaDetalle =
                detalleBLL.Listar();

            DataView dv =
                new DataView(tablaDetalle);

            dgvDetalle.DataSource =
                dv;

            OcultarColumnas();
        }

        // =========================
        // OCULTAR COLUMNAS
        // =========================
        void OcultarColumnas()
        {
            if (dgvDetalle.Columns.Contains("id_servicio"))
            {
                dgvDetalle.Columns["id_servicio"]
                    .Visible = false;
            }
        }

        // =========================
        // BUSCAR
        // =========================
        void BuscarDetalle()
        {
            if (tablaDetalle.Rows.Count == 0)
                return;

            DataView dv =
                tablaDetalle.DefaultView;

            string texto =
                txtBuscar.Text.Trim();

            // =====================
            // SI ESTA VACIO
            // =====================

            if (texto == "")
            {
                dgvDetalle.DataSource =
                    tablaDetalle;

                return;
            }

            // =====================
            // FACTURA
            // =====================

            if (cbFiltro.Text == "Factura")
            {
                dv.RowFilter =
                    $"Convert(id_factura, 'System.String') " +
                    $"LIKE '%{texto}%'";
            }

            // =====================
            // SERVICIO
            // =====================

            else if (cbFiltro.Text == "Servicio")
            {
                dv.RowFilter =
                    $"servicio LIKE '%{texto}%'";
            }

            // =====================
            // DESCRIPCION
            // =====================

            else if (cbFiltro.Text == "Descripcion")
            {
                dv.RowFilter =
                    $"descripcion LIKE '%{texto}%'";
            }

            dgvDetalle.DataSource = dv;
        }

        // =========================
        // BOTON BUSCAR
        // =========================
        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            BuscarDetalle();
        }

        // =========================
        // BUSQUEDA AUTOMATICA
        // =========================
        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            BuscarDetalle();
        }

        // =========================
        // MOSTRAR TODO
        // =========================
        private void btnMostrar_Click(
    object sender,
    EventArgs e)
        {
            txtBuscar.Clear();

            dgvDetalle.DataSource = null;

            MostrarDetalle();

            // SOLO SI TIENE ITEMS
            if (cbFiltro.Items.Count > 0)
            {
                cbFiltro.SelectedIndex = 0;
            }
        }

        // =========================
        // CERRAR
        // =========================
        private void btnCerrar_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }

        // =========================
        // DISEÑO
        // =========================
        void AplicarDiseno()
        {
            this.BackColor = colorFondo;

            // =====================
            // TXT BUSCAR
            // =====================

            txtBuscar.BorderStyle =
                BorderStyle.FixedSingle;

            txtBuscar.Font =
                new Font("Segoe UI", 10);

            // =====================
            // COMBO FILTRO
            // =====================

            cbFiltro.Font =
                new Font("Segoe UI", 10);

            // =====================
            // BOTONES
            // =====================

            foreach (Button btn in new[]
            {
                btnBuscar,
                btnMostrar,
                btnCerrar
            })
            {
                btn.BackColor = colorBeige;

                btn.ForeColor = colorVino;

                btn.FlatStyle =
                    FlatStyle.Flat;

                btn.FlatAppearance
                    .BorderSize = 0;

                btn.Font =
                    new Font(
                        "Segoe UI Semibold",
                        10F);

                btn.Cursor =
                    Cursors.Hand;
            }

            // =====================
            // DATAGRIDVIEW
            // =====================

            dgvDetalle.BackgroundColor =
                Color.White;

            dgvDetalle.BorderStyle =
                BorderStyle.None;

            dgvDetalle.RowHeadersVisible =
                false;

            dgvDetalle.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDetalle.ColumnHeadersHeight =
                38;

            dgvDetalle.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            dgvDetalle.DefaultCellStyle
                .SelectionBackColor =
                Color.FromArgb(230, 210, 215);

            dgvDetalle.DefaultCellStyle
                .SelectionForeColor =
                Color.Black;

            dgvDetalle.AlternatingRowsDefaultCellStyle
                .BackColor =
                Color.FromArgb(248, 244, 242);

            dgvDetalle.GridColor =
                Color.FromArgb(235, 230, 228);

            dgvDetalle.SelectionMode =
                DataGridViewSelectionMode
                .FullRowSelect;

            dgvDetalle.MultiSelect =
                false;

            dgvDetalle.AllowUserToAddRows =
                false;

            dgvDetalle.AllowUserToDeleteRows =
                false;

            dgvDetalle.EnableHeadersVisualStyles =
                false;

            dgvDetalle.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvDetalle.ColumnHeadersDefaultCellStyle
                .BackColor = colorVino;

            dgvDetalle.ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;

            dgvDetalle.ColumnHeadersDefaultCellStyle
                .Font =
                new Font(
                    "Segoe UI Semibold",
                    9F);
        }
    }
}