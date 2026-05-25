using CapaEntidades;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmFactura : Form
    {
        // =========================================================
        // COLORES
        // =========================================================
        private readonly Color COLOR_VINO =
            Color.RosyBrown;

        private readonly Color COLOR_FONDO =
            Color.FromArgb(250, 248, 246);

        private readonly Color COLOR_BEIGE =
            Color.FromArgb(242, 235, 231);

        // =========================================================
        // BLL
        // =========================================================
        private readonly FacturaBLL facturaBLL =
            new FacturaBLL();

        // =========================================================
        // CONSTRUCTOR
        // =========================================================
        public FrmFactura()
        {
            InitializeComponent();
        }

        // =========================================================
        // LOAD
        // =========================================================
        private void FrmFactura_Load(
            object sender,
            EventArgs e)
        {
            this.BackColor = COLOR_FONDO;

            ConfigurarDiseno();
            ConfigurarGrid();
            ConfigurarBotones();
            SuscribirEventos();

            CargarFiltro();
            MostrarFacturas();
            cbEstado.Items.Add("Pagado");
            cbEstado.Items.Add("Pendiente");
            cbEstado.Items.Add("Cancelado");

        }

        // =========================================================
        // DISEÑO
        // =========================================================
        private void ConfigurarDiseno()
        {
            // TITULO
            lblTabla.Text = "Pagos Pendientes";

            lblTabla.ForeColor =
                COLOR_VINO;

            lblTabla.Font =
                new Font("Georgia", 20F);

            // BUSCADOR
            txtBuscar.Font =
                new Font("Segoe UI", 10F);

            txtBuscar.BorderStyle =
                BorderStyle.FixedSingle;

            // COMBO
            cbFiltroFactura.Font =
                new Font("Segoe UI", 10F);

            cbFiltroFactura.FlatStyle =
                FlatStyle.Flat;

            // PANEL
            panelTabla.BackColor =
                Color.White;
        }

      

        // =========================================================
        // GRID
        // =========================================================
        private void ConfigurarGrid()
        {
            dgvDetalle.BackgroundColor =
                Color.White;

            dgvDetalle.BorderStyle =
                BorderStyle.None;

            dgvDetalle.RowHeadersVisible =
                false;

            dgvDetalle.AllowUserToAddRows =
                false;

            dgvDetalle.AllowUserToDeleteRows =
                false;

            dgvDetalle.AllowUserToResizeRows =
                false;

            dgvDetalle.MultiSelect =
                false;

            dgvDetalle.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDetalle.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDetalle.RowTemplate.Height =
                42;

            dgvDetalle.EnableHeadersVisualStyles =
                false;

            dgvDetalle.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvDetalle.ColumnHeadersHeight =
                45;

            // HEADER
            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor =
                COLOR_VINO;

            dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvDetalle.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDetalle.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                COLOR_VINO;

            // FILAS
            dgvDetalle.DefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F);

            dgvDetalle.DefaultCellStyle.Padding =
                new Padding(5);

            dgvDetalle.DefaultCellStyle.SelectionBackColor =
                COLOR_BEIGE;

            dgvDetalle.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 244, 242);

            dgvDetalle.GridColor =
                Color.FromArgb(235, 230, 228);

            dgvDetalle.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;
        }

        // =========================================================
        // BOTONES
        // =========================================================
        private void ConfigurarBotones()
        {
      

            EstilarBoton(
                btnNuevaFactura,
                COLOR_VINO,
                Color.White);

            EstilarBoton(
                btnVerDetalle,
                COLOR_BEIGE,
                COLOR_VINO);

            EstilarBoton(
                btnHistorial,
                COLOR_BEIGE,
                COLOR_VINO);
        }

        // =========================================================
        // ESTILO BOTÓN
        // =========================================================
        private void EstilarBoton(
            Button btn,
            Color fondo,
            Color texto)
        {
            btn.BackColor =
                fondo;

            btn.ForeColor =
                texto;

            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize =
                1;

            btn.FlatAppearance.BorderColor =
                ControlPaint.Dark(fondo);

            btn.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold);

            btn.Cursor =
                Cursors.Hand;
        }

        // =========================================================
        // EVENTOS
        // =========================================================
        private void SuscribirEventos()
        {
            txtBuscar.TextChanged +=
                txtBuscar_TextChanged;

            cbFiltroFactura.SelectedIndexChanged +=
                cbFiltroFactura_SelectedIndexChanged;

            btnHistorial.Click +=
                btnHistorial_Click;

            btnVerDetalle.Click +=
                btnVerDetalle_Click;

            btnNuevaFactura.Click +=
                btnNuevaFactura_Click;
        }

        // =========================================================
        // CARGAR FILTRO
        // =========================================================
        private void CargarFiltro()
        {
            cbFiltroFactura.Items.Clear();

            cbFiltroFactura.Items.Add("Todas");

            DataTable dt =
                facturaBLL.Listar();

            foreach (DataRow fila in dt.Rows)
            {
                if (fila["estado_pago"].ToString()
                    == "Pendiente")
                {
                    cbFiltroFactura.Items.Add(
                        fila["id_factura"].ToString());
                }
            }

            cbFiltroFactura.SelectedIndex = 0;
        }

        // =========================================================
        // MOSTRAR FACTURAS
        // =========================================================
        private void MostrarFacturas()
        {
            DataView vista =
                facturaBLL.Listar().DefaultView;

            vista.RowFilter =
                "estado_pago = 'Pendiente'";

            dgvDetalle.DataSource =
                vista;

            OcultarColumnas();
        }

        // =========================================================
        // BUSCAR FACTURAS
        // =========================================================
        private void BuscarFacturas()
        {
            DataView vista =
                facturaBLL.Listar().DefaultView;

            string filtro =
                "estado_pago = 'Pendiente'";

            if (cbFiltroFactura.SelectedIndex > 0)
            {
                filtro +=
                    $" AND id_factura = {cbFiltroFactura.SelectedItem}";
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

            dgvDetalle.DataSource =
                vista;

            OcultarColumnas();
        }

        // =========================================================
        // OCULTAR COLUMNAS
        // =========================================================
        private void OcultarColumnas()
        {
            if (dgvDetalle.Columns.Contains("id_cliente"))
            {
                dgvDetalle.Columns["id_cliente"].Visible =
                    false;
            }

            if (dgvDetalle.Columns.Contains("referencia"))
            {
                dgvDetalle.Columns["referencia"].Visible =
                    false;
            }

            if (dgvDetalle.Columns.Contains("notas"))
            {
                dgvDetalle.Columns["notas"].Visible =
                    false;
            }
        }

        // =========================================================
        // EVENTOS BÚSQUEDA
        // =========================================================
        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            BuscarFacturas();
        }

        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            BuscarFacturas();
        }

        private void cbFiltroFactura_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            BuscarFacturas();
        }

        // =========================================================
        // VER DETALLE
        // =========================================================
        private void btnVerDetalle_Click(
            object sender,
            EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Selecciona una factura.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idFactura =
                Convert.ToInt32(
                    dgvDetalle.SelectedRows[0]
                    .Cells["id_factura"].Value);

            FrmPrincipal principal =
                (FrmPrincipal)Application.OpenForms["FrmPrincipal"];

            principal.AbrirFormulario(
                new FrmDetalleFactura(idFactura));
        }

        // =========================================================
        // NUEVA FACTURA
        // =========================================================
        private void btnNuevaFactura_Click(
            object sender,
            EventArgs e)
        {
            FrmPrincipal principal =
                (FrmPrincipal)Application.OpenForms["FrmPrincipal"];

            principal.AbrirFormulario(
                new FrmDetalleFactura());
        }

        // =========================================================
        // HISTORIAL
        // =========================================================
        private void btnHistorial_Click(
            object sender,
            EventArgs e)
        {
            FrmPrincipal principal =
                (FrmPrincipal)Application.OpenForms["FrmPrincipal"];

            principal.AbrirFormulario(
                new FrmHistorialFacturas());
        }

        private void btnActualizarEstado_Click(
     object sender,
     EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Selecciona una factura.");

                return;
            }

            if (cbEstado.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Selecciona un estado.");

                return;
            }

            int idFactura =
                Convert.ToInt32(
                    dgvDetalle.SelectedRows[0]
                    .Cells["id_factura"].Value);

            string estado =
                cbEstado.SelectedItem
                .ToString();

            facturaBLL.ActualizarEstado(
                idFactura,
                estado);

            MessageBox.Show(
                "Estado actualizado correctamente.");

            MostrarFacturas();
        }

    }
}