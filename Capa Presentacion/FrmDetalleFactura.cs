using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace Capa_Presentacion
{
    public partial class FrmDetalleFactura : Form
    {
        // =========================================
        // COLORES
        // =========================================
        private readonly Color colorMenuLateral =
            Color.RosyBrown;

        private readonly Color colorFondoGeneral =
            Color.FromArgb(250, 248, 246);

        private readonly Color colorVinoBotones =
            Color.RosyBrown;

        // =========================================
        // BLL
        // =========================================
        Detalle_FacturaBLL detalleBLL =
            new Detalle_FacturaBLL();

        // =========================================
        // TABLA
        // =========================================
        DataTable tablaDetalle =
            new DataTable();

        // =========================================
        // ID FACTURA
        // =========================================
        private int _idFactura;

        // =========================================
        // CONSTRUCTOR
        // =========================================
        public FrmDetalleFactura(int idFactura)
        {
            InitializeComponent();
            _idFactura = idFactura;
        }

        // =========================================
        // LOAD
        // =========================================
        private void FrmDetalleFactura_Load(
            object sender,
            EventArgs e)
        {
            this.WindowState =
                FormWindowState.Maximized;

            AplicarDiseno();

            // EVENTOS
            txtBuscar.TextChanged +=
                txtBuscar_TextChanged;

            btnBuscar.Click +=
                btnBuscar_Click;

            btnMostrar.Click +=
                btnMostrar_Click;

            btnCerrar.Click +=
                btnCerrar_Click;

            // FILTRO
            cbFiltro.Items.Clear();

            cbFiltro.Items.AddRange(new object[]
            {
                "Factura",
                "Servicio",
                "Descripcion"
            });

            cbFiltro.SelectedIndex = 0;

            // CARGAR DETALLES
            tablaDetalle =
                detalleBLL.ObtenerPorFactura(
                    _idFactura);

            dgvDetalle.DataSource =
                tablaDetalle;

            OcultarColumnas();
        }

        // =========================================
        // MOSTRAR DETALLES
        // =========================================
        void MostrarDetalle()
        {
            tablaDetalle =
                detalleBLL.ObtenerPorFactura(
                    _idFactura);

            dgvDetalle.DataSource =
                tablaDetalle;

            OcultarColumnas();
        }

        // =========================================
        // OCULTAR COLUMNAS
        // =========================================
        void OcultarColumnas()
        {
            // OCULTAR
            foreach (string col in new[]
            {
                "id_servicio"
            })
            {
                if (dgvDetalle.Columns.Contains(col))
                {
                    dgvDetalle.Columns[col]
                        .Visible = false;
                }
            }

            // HEADERS
            if (dgvDetalle.Columns.Contains("id_factura"))
                dgvDetalle.Columns["id_factura"]
                    .HeaderText = "Factura";

            if (dgvDetalle.Columns.Contains("servicio"))
                dgvDetalle.Columns["servicio"]
                    .HeaderText = "Servicio";

            if (dgvDetalle.Columns.Contains("descripcion"))
                dgvDetalle.Columns["descripcion"]
                    .HeaderText = "Descripción";

            if (dgvDetalle.Columns.Contains("cantidad"))
                dgvDetalle.Columns["cantidad"]
                    .HeaderText = "Cantidad";

            if (dgvDetalle.Columns.Contains("subtotal"))
            {
                dgvDetalle.Columns["subtotal"]
                    .HeaderText = "Subtotal";

                dgvDetalle.Columns["subtotal"]
                    .DefaultCellStyle.Format =
                    "N2";
            }

            dgvDetalle.RowTemplate.Height = 40;

            // HEADERS
            dgvDetalle.EnableHeadersVisualStyles =
                false;

            dgvDetalle.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvDetalle.ColumnHeadersDefaultCellStyle
                .BackColor = colorMenuLateral;

            dgvDetalle.ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;

            dgvDetalle.ColumnHeadersDefaultCellStyle
                .Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            dgvDetalle.ColumnHeadersDefaultCellStyle
                .Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }

        // =========================================
        // BUSCAR
        // =========================================
        void BuscarDetalle()
        {
            if (tablaDetalle.Rows.Count == 0)
                return;

            DataView dv =
                tablaDetalle.DefaultView;

            string texto =
                txtBuscar.Text.Trim()
                .Replace("'", "''");

            // SI ESTA VACIO
            if (texto == "")
            {
                dgvDetalle.DataSource =
                    tablaDetalle;

                return;
            }

            // FACTURA
            if (cbFiltro.Text == "Factura")
            {
                dv.RowFilter =
                    $"Convert(id_factura, 'System.String') " +
                    $"LIKE '%{texto}%'";
            }

            // SERVICIO
            else if (cbFiltro.Text == "Servicio")
            {
                dv.RowFilter =
                    $"servicio LIKE '%{texto}%'";
            }

            // DESCRIPCION
            else if (cbFiltro.Text == "Descripcion")
            {
                dv.RowFilter =
                    $"descripcion LIKE '%{texto}%'";
            }

            dgvDetalle.DataSource = dv;

            OcultarColumnas();
        }

        // =========================================
        // BOTON BUSCAR
        // =========================================
        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            BuscarDetalle();
        }

        // =========================================
        // BUSQUEDA AUTOMATICA
        // =========================================
        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            BuscarDetalle();
        }

        // =========================================
        // MOSTRAR TODOS
        // =========================================
        private void btnMostrar_Click(
            object sender,
            EventArgs e)
        {
            txtBuscar.Clear();

            dgvDetalle.DataSource =
                null;

            MostrarDetalle();

            if (cbFiltro.Items.Count > 0)
            {
                cbFiltro.SelectedIndex = 0;
            }
        }

        // =========================================
        // CERRAR
        // =========================================
        private void btnCerrar_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }

        // =========================================
        // ESTILAR BOTONES
        // =========================================
        void EstilarBoton(
            Button btn,
            Color fondo,
            Color texto,
            bool negrita = false)
        {
            btn.BackColor = fondo;

            btn.ForeColor = texto;

            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize =
                0;

            btn.Font =
                new Font(
                    "Segoe UI" +
                    (negrita ? " Semibold" : ""),
                    10F);

            btn.Height = 38;

            btn.Cursor =
                Cursors.Hand;
        }

        // =========================================
        // DISEÑO
        // =========================================
        void AplicarDiseno()
        {
            this.BackColor =
                colorFondoGeneral;

            // =====================================
            // TITULO
            // =====================================

            lblTitulo.ForeColor =
                colorMenuLateral;

            lblTitulo.Font =
                new Font(
                    "Georgia",
                    22F,
                    FontStyle.Regular);

            // =====================================
            // LABELS
            // =====================================

            lblBuscar.ForeColor =
                Color.FromArgb(70, 50, 48);

            lblBuscar.Font =
                new Font(
                    "Segoe UI",
                    10F);

            // =====================================
            // TEXTBOX BUSCAR
            // =====================================

            txtBuscar.BackColor =
                Color.White;

            txtBuscar.ForeColor =
                Color.FromArgb(70, 50, 48);

            txtBuscar.BorderStyle =
                BorderStyle.FixedSingle;

            txtBuscar.Font =
                new Font(
                    "Segoe UI",
                    10F);

            // =====================================
            // COMBO FILTRO
            // =====================================

            cbFiltro.BackColor =
                Color.White;

            cbFiltro.ForeColor =
                Color.FromArgb(70, 50, 48);

            cbFiltro.FlatStyle =
                FlatStyle.Flat;

            cbFiltro.Font =
                new Font(
                    "Segoe UI",
                    10F);

            // =====================================
            // BOTONES
            // =====================================

            Color beige =
                Color.FromArgb(242, 235, 231);

            EstilarBoton(
                btnBuscar,
                colorVinoBotones,
                Color.White,
                true);

            EstilarBoton(
                btnMostrar,
                beige,
                colorMenuLateral);

            EstilarBoton(
                btnCerrar,
                colorVinoBotones,
                Color.White,
                true);

            // =====================================
            // DATAGRIDVIEW
            // =====================================

            dgvDetalle.BackgroundColor =
                Color.White;

            dgvDetalle.BorderStyle =
                BorderStyle.None;

            dgvDetalle.RowHeadersVisible =
                false;

            dgvDetalle.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDetalle.ColumnHeadersHeight =
                45;

            dgvDetalle.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            dgvDetalle.DefaultCellStyle
                .SelectionBackColor =
                Color.FromArgb(
                    230,
                    210,
                    215);

            dgvDetalle.DefaultCellStyle
                .SelectionForeColor =
                Color.Black;

            dgvDetalle.DefaultCellStyle.Padding =
                new Padding(5);

            dgvDetalle.AlternatingRowsDefaultCellStyle
                .BackColor =
                Color.FromArgb(
                    248,
                    244,
                    242);

            dgvDetalle.GridColor =
                Color.FromArgb(
                    235,
                    230,
                    228);

            dgvDetalle.CellBorderStyle =
                DataGridViewCellBorderStyle
                .SingleHorizontal;

            dgvDetalle.SelectionMode =
                DataGridViewSelectionMode
                .FullRowSelect;

            dgvDetalle.MultiSelect =
                false;

            dgvDetalle.ReadOnly =
                true;

            dgvDetalle.AllowUserToAddRows =
                false;

            dgvDetalle.AllowUserToDeleteRows =
                false;

            dgvDetalle.AllowUserToResizeRows =
                false;

            dgvDetalle.EnableHeadersVisualStyles =
                false;

            dgvDetalle.ColumnHeadersDefaultCellStyle
                .BackColor =
                Color.RosyBrown;

            dgvDetalle.ColumnHeadersDefaultCellStyle
                .ForeColor =
                Color.White;

            dgvDetalle.ColumnHeadersDefaultCellStyle
                .SelectionBackColor =
                Color.RosyBrown;

            dgvDetalle.ColumnHeadersDefaultCellStyle
                .SelectionForeColor =
                Color.White;

            dgvDetalle.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvDetalle.ColumnHeadersHeight =
                45;

            dgvDetalle.Refresh();
        }
    }
}