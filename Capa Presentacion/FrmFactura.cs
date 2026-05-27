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
        private readonly Color COLOR_VINO = Color.RosyBrown;
        private readonly Color COLOR_FONDO = Color.FromArgb(250, 248, 246);
        private readonly Color COLOR_BEIGE = Color.FromArgb(242, 235, 231);

        // =========================================================
        // BLL
        // =========================================================
        private readonly FacturaBLL facturaBLL = new FacturaBLL();
        private readonly Detalle_FacturaBLL detalleBLL =
            new Detalle_FacturaBLL();

        // =========================================================
        // TABLAS
        // =========================================================
        private DataTable tablaFacturas = new DataTable();

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

            ConfigurarGridDetalle();

            ConfigurarBotones();

            SuscribirEventos();

            MostrarFacturas();

            cbEstado.Items.Clear();

            cbEstado.Items.Add("Pagado");

            cbEstado.Items.Add("Pendiente");

            cbEstado.Items.Add("Cancelado");
        }

        // =========================================================
        // DISEÑO
        // =========================================================
        // =========================================================
        // DISEÑO
        // =========================================================
        private void ConfigurarDiseno()
        {
            lblTabla.Text = "Facturas";

            lblTabla.ForeColor = COLOR_VINO;

            lblTabla.Font =
                new Font("Georgia", 20F);

            // =====================================================
            // TXT BUSCAR FACTURA
            // =====================================================
            txtBuscar.Font =
                new Font("Segoe UI", 10F);

            txtBuscar.BorderStyle =
                BorderStyle.FixedSingle;

            txtBuscar.BackColor =
                Color.White;

            txtBuscar.ForeColor =
                Color.Black;

            txtBuscar.Height = 35;

            txtBuscar.Padding =
                new Padding(8);

            // =====================================================
            // TXT BUSCAR DETALLE
            // =====================================================
            txtBuscarDetalle.Font =
                new Font("Segoe UI", 10F);

            txtBuscarDetalle.BorderStyle =
                BorderStyle.FixedSingle;

            txtBuscarDetalle.BackColor =
                Color.White;

            txtBuscarDetalle.ForeColor =
                Color.Black;

            txtBuscarDetalle.Height = 35;

            txtBuscarDetalle.Padding =
                new Padding(8);

       

            // =====================================================
            // COMBO ESTADO
            // =====================================================
            cbEstado.Font =
                new Font("Segoe UI", 10F);

            cbEstado.FlatStyle =
                FlatStyle.Flat;

            cbEstado.BackColor =
                Color.White;

            cbEstado.ForeColor =
                Color.Black;

            cbEstado.Height = 35;

            // =====================================================
            // PANEL
            // =====================================================
            panelTabla.BackColor =
                Color.White;

            // =====================================================
            // BOTÓN BUSCAR FACTURAS
            // =====================================================
            btnBuscarFactura.BackColor =
                COLOR_VINO;

            btnBuscarFactura.ForeColor =
                Color.White;

            btnBuscarFactura.FlatStyle =
                FlatStyle.Flat;

            btnBuscarFactura.FlatAppearance.BorderSize = 0;

            btnBuscarFactura.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            btnBuscarFactura.Cursor =
                Cursors.Hand;

            btnBuscarFactura.Height = 42;

            // =====================================================
            // BOTÓN BUSCAR DETALLE
            // =====================================================
            btnBuscarFactura.BackColor =
                COLOR_VINO;

            btnBuscarFactura.ForeColor =
                Color.White;

            btnBuscarFactura.FlatStyle =
                FlatStyle.Flat;

            btnBuscarFactura.FlatAppearance.BorderSize = 0;

            btnBuscarFactura.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            btnBuscarFactura.Cursor =
                Cursors.Hand;

            btnBuscarFactura.Height = 42;
        }

        // =========================================================
        // GRID FACTURAS
        // =========================================================
        private void ConfigurarGrid()
        {
            EstilarGrid(dgvDetalle);
        }

        // =========================================================
        // GRID DETALLES
        // =========================================================
        private void ConfigurarGridDetalle()
        {
            EstilarGrid(dgvDetalleFactura);
        }

        // =========================================================
        // ESTILO GRID
        // =========================================================
        private void EstilarGrid(
            DataGridView dgv)
        {
            dgv.BackgroundColor =
                Color.White;

            dgv.BorderStyle =
                BorderStyle.None;

            dgv.RowHeadersVisible = false;

            dgv.AllowUserToAddRows = false;

            dgv.AllowUserToDeleteRows = false;

            dgv.AllowUserToResizeRows = false;

            dgv.MultiSelect = false;

            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv.RowTemplate.Height = 42;

            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgv.ColumnHeadersHeight = 45;

            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                COLOR_VINO;

            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            dgv.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            dgv.DefaultCellStyle.Padding =
                new Padding(5);

            dgv.DefaultCellStyle.SelectionBackColor =
                COLOR_BEIGE;

            dgv.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgv.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(
                    248,
                    244,
                    242);

            dgv.GridColor =
                Color.FromArgb(
                    235,
                    230,
                    228);

            dgv.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.ReadOnly = true;
        }

        // =========================================================
        // BOTONES
        // =========================================================
        private void ConfigurarBotones()
        {
            // BOTONES VINO
            EstilarBotonVino(btnNuevaFactura);

            EstilarBotonVino(btnActualizarEstado);

            EstilarBotonVino(btnBuscarFactura);

            // BOTONES BLANCOS
            EstilarBotonBlanco(btnHistorial);

            EstilarBotonBlanco(btnMostrarTodoDetalle);
        }

        // =========================================================
        // BOTÓN VINO
        // =========================================================
        private void EstilarBotonVino(
            Button btn)
        {
            btn.BackColor = COLOR_VINO;

            btn.ForeColor = Color.White;

            btn.FlatStyle = FlatStyle.Flat;

            btn.FlatAppearance.BorderSize = 0;

            btn.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            btn.Cursor = Cursors.Hand;

            btn.Height = 42;
        }

        // =========================================================
        // BOTÓN BLANCO
        // =========================================================
        private void EstilarBotonBlanco(
            Button btn)
        {
            btn.BackColor = Color.White;

            btn.ForeColor = COLOR_VINO;

            btn.FlatStyle = FlatStyle.Flat;

            btn.FlatAppearance.BorderSize = 1;

            btn.FlatAppearance.BorderColor =
                COLOR_VINO;

            btn.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            btn.Cursor = Cursors.Hand;

            btn.Height = 42;
        }

        // =========================================================
        // EVENTOS
        // =========================================================
        private void SuscribirEventos()
        {
            txtBuscar.TextChanged +=
                txtBuscar_TextChanged;

            txtBuscarDetalle.TextChanged +=
                txtBuscarDetalle_TextChanged;

            dgvDetalle.SelectionChanged +=
                dgvDetalle_SelectionChanged;

            btnHistorial.Click +=
                btnHistorial_Click;

            btnNuevaFactura.Click +=
                btnNuevaFactura_Click;

            btnActualizarEstado.Click +=
                btnActualizarEstado_Click;

            btnMostrarTodoDetalle.Click +=
                btnMostrarTodoDetalle_Click;

            btnBuscarFactura.Click +=
                btnBuscarDetalle_Click;
        }


    

        // =========================================================
        // MOSTRAR FACTURAS
        // =========================================================
        private void MostrarFacturas()
        {
            tablaFacturas =
                facturaBLL.Listar();

            // =========================================
            // SOLO PENDIENTES ARRIBA
            // =========================================
            DataTable dtPendientes =
                tablaFacturas.Clone();

            foreach (DataRow fila
                in tablaFacturas.Rows)
            {
                if (fila["estado_pago"]
                    .ToString() == "Pendiente")
                {
                    dtPendientes.ImportRow(fila);
                }
            }

            dgvDetalle.DataSource =
                dtPendientes;

            OcultarColumnasFactura();

            // =========================================
            // ABAJO TODOS LOS DETALLES
            // DE LAS FACTURAS PENDIENTES
            // =========================================
            MostrarTodosLosDetallesPendientes();
        }

        // =========================================================
        // TODOS LOS DETALLES PENDIENTES
        // =========================================================
        private void MostrarTodosLosDetallesPendientes()
        {
            DataTable dtTodos =
                detalleBLL.Listar();

            DataTable dtFiltrado =
                dtTodos.Clone();

            foreach (DataRow detalle
                in dtTodos.Rows)
            {
                foreach (DataRow factura
                    in tablaFacturas.Rows)
                {
                    if (
                        factura["estado_pago"]
                        .ToString() == "Pendiente"

                        &&

                        detalle["id_factura"]
                        .ToString()

                        ==

                        factura["id_factura"]
                        .ToString()
                    )
                    {
                        dtFiltrado.ImportRow(detalle);
                    }
                }
            }

            dgvDetalleFactura.DataSource =
                dtFiltrado;

            OcultarColumnasDetalle();
        }

        // =========================================================
        // SELECCIONAR FACTURA
        // =========================================================
        private void dgvDetalle_SelectionChanged(
            object sender,
            EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 0)
                return;

            int idFactura =
                Convert.ToInt32(
                    dgvDetalle.SelectedRows[0]
                    .Cells["id_factura"].Value);

            // SOLO EL DETALLE DE ESA FACTURA
            DataTable dtDetalle =
                detalleBLL.ObtenerPorFactura(
                    idFactura);

            dgvDetalleFactura.DataSource =
                dtDetalle;

            OcultarColumnasDetalle();
        }

        // =========================================================
        // MOSTRAR TODO OTRA VEZ
        // =========================================================
        private void btnMostrarTodoDetalle_Click(
            object sender,
            EventArgs e)
        {
            MostrarTodosLosDetallesPendientes();
        }

        // =========================================================
        // BUSCAR DETALLE
        // =========================================================
        private void btnBuscarDetalle_Click(
            object sender,
            EventArgs e)
        {
            BuscarDetalle();
        }

        // =========================================================
        // BUSCAR FACTURAS
        // =========================================================
        private void BuscarFacturas()
        {
            string texto =
                txtBuscar.Text
                .Trim()
                .ToLower();

            DataTable dtPendientes =
                tablaFacturas.Clone();

            foreach (DataRow fila
                in tablaFacturas.Rows)
            {
                if (fila["estado_pago"]
                    .ToString() != "Pendiente")
                    continue;

                bool encontrado = false;

                foreach (var celda
                    in fila.ItemArray)
                {
                    if (
                        celda.ToString()
                        .ToLower()
                        .Contains(texto)
                    )
                    {
                        encontrado = true;
                        break;
                    }
                }

                if (
                    encontrado
                    ||
                    string.IsNullOrEmpty(texto)
                )
                {
                    dtPendientes.ImportRow(fila);
                }
            }

            dgvDetalle.DataSource =
                dtPendientes;

            OcultarColumnasFactura();
        }

        // =========================================================
        // BUSCAR DETALLE
        // =========================================================
        private void BuscarDetalle()
        {
            if (dgvDetalleFactura.DataSource == null)
                return;

            string texto =
                txtBuscarDetalle.Text
                .Trim()
                .ToLower();

            DataTable dtActual =
                dgvDetalleFactura.DataSource
                as DataTable;

            if (dtActual == null)
                return;

            if (string.IsNullOrEmpty(texto))
            {
                MostrarTodosLosDetallesPendientes();
                return;
            }

            DataTable dtFiltrado =
                dtActual.Clone();

            foreach (DataRow fila
                in dtActual.Rows)
            {
                foreach (var celda
                    in fila.ItemArray)
                {
                    if (
                        celda.ToString()
                        .ToLower()
                        .Contains(texto)
                    )
                    {
                        dtFiltrado.ImportRow(fila);
                        break;
                    }
                }
            }

            dgvDetalleFactura.DataSource =
                dtFiltrado;

            OcultarColumnasDetalle();
        }

        // =========================================================
        // COLUMNAS FACTURA
        // =========================================================
        private void OcultarColumnasFactura()
        {
            if (dgvDetalle.Columns.Contains("id_cliente"))
                dgvDetalle.Columns["id_cliente"].Visible = false;

            if (dgvDetalle.Columns.Contains("id_factura"))
                dgvDetalle.Columns["id_factura"].HeaderText = "Factura #";

            if (dgvDetalle.Columns.Contains("cliente"))
                dgvDetalle.Columns["cliente"].HeaderText = "Cliente";

            if (dgvDetalle.Columns.Contains("fecha_factura"))
                dgvDetalle.Columns["fecha_factura"].HeaderText = "Fecha";

            if (dgvDetalle.Columns.Contains("total"))
            {
                dgvDetalle.Columns["total"].HeaderText = "Total";

                dgvDetalle.Columns["total"]
                    .DefaultCellStyle.Format = "N2";
            }

            if (dgvDetalle.Columns.Contains("metodo_pago"))
                dgvDetalle.Columns["metodo_pago"].HeaderText =
                    "Método Pago";

            if (dgvDetalle.Columns.Contains("estado_pago"))
                dgvDetalle.Columns["estado_pago"].HeaderText =
                    "Estado";
        }

        // =========================================================
        // COLUMNAS DETALLE
        // =========================================================
        private void OcultarColumnasDetalle()
        {
            if (dgvDetalleFactura.Columns.Contains("id_servicio"))
                dgvDetalleFactura.Columns["id_servicio"].Visible = false;

            if (dgvDetalleFactura.Columns.Contains("id_factura"))
                dgvDetalleFactura.Columns["id_factura"].Visible = false;

            if (dgvDetalleFactura.Columns.Contains("id_detalle_factura"))
                dgvDetalleFactura.Columns["id_detalle_factura"].Visible = false;

            if (dgvDetalleFactura.Columns.Contains("servicio"))
                dgvDetalleFactura.Columns["servicio"].HeaderText =
                    "Servicio";

            if (dgvDetalleFactura.Columns.Contains("descripcion"))
                dgvDetalleFactura.Columns["descripcion"].HeaderText =
                    "Descripción";

            if (dgvDetalleFactura.Columns.Contains("cantidad"))
                dgvDetalleFactura.Columns["cantidad"].HeaderText =
                    "Cantidad";

            if (dgvDetalleFactura.Columns.Contains("subtotal"))
            {
                dgvDetalleFactura.Columns["subtotal"].HeaderText =
                    "Subtotal";

                dgvDetalleFactura.Columns["subtotal"]
                    .DefaultCellStyle.Format = "N2";
            }
        }

        // =========================================================
        // EVENTOS BUSCAR
        // =========================================================
        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            BuscarFacturas();
        }

        private void txtBuscarDetalle_TextChanged(
            object sender,
            EventArgs e)
        {
            BuscarDetalle();
        }

        // =========================================================
        // NUEVA FACTURA
        // =========================================================
        private void btnNuevaFactura_Click(
            object sender,
            EventArgs e)
        {
            FrmPrincipal principal =
                (FrmPrincipal)
                Application.OpenForms["FrmPrincipal"];

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
                (FrmPrincipal)
                Application.OpenForms["FrmPrincipal"];

            principal.AbrirFormulario(
                new FrmHistorialFacturas());
        }

        // =========================================================
        // ACTUALIZAR ESTADO
        // =========================================================
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

            facturaBLL.ActualizarEstado(
                idFactura,
                cbEstado.SelectedItem.ToString());

            MessageBox.Show(
                "Estado actualizado correctamente.");

            MostrarFacturas();
        }
    }
}