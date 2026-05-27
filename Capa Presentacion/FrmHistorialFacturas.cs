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

        Detalle_FacturaBLL detalleBLL =
            new Detalle_FacturaBLL();

        // =========================================
        // TABLAS
        // =========================================

        DataTable tablaFacturas =
            new DataTable();

        public FrmHistorialFacturas()
        {
            InitializeComponent();
        }

        // =========================================
        // LOAD
        // =========================================

        private void FrmHistorialFacturas_Load(
            object sender,
            EventArgs e)
        {
            this.WindowState =
                FormWindowState.Maximized;

            AplicarDiseno();

            CargarFiltroEstado();

            CargarFiltroDetalle();

            MostrarHistorial();

            MostrarTodosLosDetalles();

            // =====================================
            // EVENTOS
            // =====================================

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

            dgvHistorial.SelectionChanged +=
                dgvHistorial_SelectionChanged;

            btnMostrarTodoDetalle.Click +=
                btnBuscarDetalle_Click;

            btnMostrarTodoDetalle.Click +=
                btnMostrarTodoDetalle_Click;

            txtDetalleBuscar.TextChanged +=
                txtBuscarDetalle_TextChanged;
        }

        // =========================================
        // FILTRO ESTADO
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
        // FILTRO DETALLE
        // =========================================

        void CargarFiltroDetalle()
        {
            cbFiltroDetalle.Items.Clear();

            cbFiltroDetalle.Items.AddRange(
                new object[]
                {
                    "Todos",
                    "Servicio",
                    "Descripción"
                });

            cbFiltroDetalle.SelectedIndex = 0;
        }

        // =========================================
        // MOSTRAR HISTORIAL
        // =========================================

        void MostrarHistorial()
        {
            tablaFacturas =
                facturaBLL.Listar();

            DataView vista =
                tablaFacturas.DefaultView;

            vista.RowFilter =
                "estado_pago = 'Pagado' " +
                "OR estado_pago = 'Cancelado'";

            dgvHistorial.DataSource =
                vista;

            OcultarColumnas();

            if (dgvHistorial.Rows.Count > 0)
            {
                dgvHistorial.Rows[0].Selected = true;
            }
        }

        // =========================================
        // MOSTRAR TODOS LOS DETALLES
        // =========================================

        void MostrarTodosLosDetalles()
        {
            DataTable dt =
                detalleBLL.Listar();

            dgvDetalleFactura.DataSource =
                dt;

            OcultarColumnasDetalle();
        }

        // =========================================
        // MOSTRAR DETALLE ESPECIFICO
        // =========================================

        void MostrarDetalleFactura(
            int idFactura)
        {
            DataTable dt =
                detalleBLL.ObtenerPorFactura(
                    idFactura);

            dgvDetalleFactura.DataSource =
                dt;

            OcultarColumnasDetalle();
        }

        // =========================================
        // BUSCAR HISTORIAL
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
        // BUSCAR DETALLE
        // =========================================

        void BuscarDetalle()
        {
            if (dgvDetalleFactura.DataSource == null)
                return;

            string texto =
                txtDetalleBuscar.Text
                .Trim()
                .ToLower();

            if (string.IsNullOrEmpty(texto))
            {
                MostrarTodosLosDetalles();
                return;
            }

            DataTable dtActual =
                dgvDetalleFactura.DataSource
                as DataTable;

            if (dtActual == null)
                return;

            DataTable dtFiltrado =
                dtActual.Clone();

            foreach (DataRow fila
                in dtActual.Rows)
            {
                bool agregar = false;

                // =============================
                // TODOS
                // =============================

                if (cbFiltroDetalle.Text == "Todos")
                {
                    foreach (var celda
                        in fila.ItemArray)
                    {
                        if (celda.ToString()
                            .ToLower()
                            .Contains(texto))
                        {
                            agregar = true;
                            break;
                        }
                    }
                }

                // =============================
                // SERVICIO
                // =============================

                else if (
                    cbFiltroDetalle.Text ==
                    "Servicio")
                {
                    if (
                        fila["servicio"]
                        .ToString()
                        .ToLower()
                        .Contains(texto))
                    {
                        agregar = true;
                    }
                }

                // =============================
                // DESCRIPCION
                // =============================

                else if (
                    cbFiltroDetalle.Text ==
                    "Descripción")
                {
                    if (
                        fila["descripcion"]
                        .ToString()
                        .ToLower()
                        .Contains(texto))
                    {
                        agregar = true;
                    }
                }

                if (agregar)
                {
                    dtFiltrado.ImportRow(fila);
                }
            }

            dgvDetalleFactura.DataSource =
                dtFiltrado;

            OcultarColumnasDetalle();
        }

        // =========================================
        // OCULTAR COLUMNAS FACTURA
        // =========================================

        void OcultarColumnas()
        {
            if (dgvHistorial.Columns.Contains("id_cliente"))
            {
                dgvHistorial.Columns["id_cliente"]
                    .Visible = false;
            }

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
        // OCULTAR COLUMNAS DETALLE
        // =========================================

        void OcultarColumnasDetalle()
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

        // =========================================
        // EVENTOS HISTORIAL
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
        // SELECCIONAR FACTURA
        // =========================================

        private void dgvHistorial_SelectionChanged(
            object sender,
            EventArgs e)
        {
            if (dgvHistorial.SelectedRows.Count == 0)
                return;

            int idFactura =
                Convert.ToInt32(
                    dgvHistorial.SelectedRows[0]
                    .Cells["id_factura"].Value);

            MostrarDetalleFactura(idFactura);
        }

        // =========================================
        // EVENTOS DETALLE
        // =========================================

        private void btnBuscarDetalle_Click(
            object sender,
            EventArgs e)
        {
            BuscarDetalle();
        }

        private void txtBuscarDetalle_TextChanged(
            object sender,
            EventArgs e)
        {
            BuscarDetalle();
        }

        private void btnMostrarTodoDetalle_Click(
            object sender,
            EventArgs e)
        {
            txtDetalleBuscar.Clear();

            cbFiltroDetalle.SelectedIndex = 0;

            MostrarTodosLosDetalles();
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
        // VOLVER
        // =========================================

        private void btnVolver_Click(
            object sender,
            EventArgs e)
        {
            FrmPrincipal principal =
                (FrmPrincipal)
                Application.OpenForms["FrmPrincipal"];

            principal.AbrirFormulario(
                new FrmFactura());
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
            this.BackColor =
                Color.FromArgb(249, 245, 242);

            panelTabla.BackColor =
                Color.White;

            lblTitulo.ForeColor =
                Color.FromArgb(70, 50, 48);

            lblTitulo.Font =
                new Font(
                    "Georgia",
                    22F,
                    FontStyle.Regular);

            lblSubtitulo.ForeColor =
                Color.Gray;

            lblSubtitulo.Font =
                new Font(
                    "Segoe UI",
                    9F);

            // =====================================
            // BUSCADORES
            // =====================================

            TextBox[] buscadores =
            {
                txtBuscar,
                txtDetalleBuscar
            };

            foreach (TextBox txt in buscadores)
            {
                txt.BackColor =
                    Color.White;

                txt.ForeColor =
                    colorTexto;

                txt.BorderStyle =
                    BorderStyle.FixedSingle;

                txt.Font =
                    new Font(
                        "Segoe UI",
                        10F);
            }

            // =====================================
            // COMBOS
            // =====================================

            ComboBox[] combos =
            {
                cbFiltroEstado,
                cbFiltroDetalle
            };

            foreach (ComboBox cb in combos)
            {
                cb.BackColor =
                    Color.White;

                cb.ForeColor =
                    colorTexto;

                cb.FlatStyle =
                    FlatStyle.Flat;

                cb.Font =
                    new Font(
                        "Segoe UI",
                        10F);
            }

            // =====================================
            // BOTONES VINO
            // =====================================

            Button[] botonesVino =
            {
                btnBuscar,
                btnVerDetalle,
                btnMostrarTodoDetalle
            };

            foreach (Button btn in botonesVino)
            {
                EstilarBoton(
                    btn,
                    colorVino,
                    Color.White,
                    true);
            }

            // =====================================
            // BOTONES BLANCOS
            // =====================================

            Button[] botonesBlancos =
            {
                btnVerTodos,
                btnVolver,
                btnMostrarTodoDetalle
            };

            foreach (Button btn in botonesBlancos)
            {
                btn.BackColor =
                    Color.White;

                btn.ForeColor =
                    colorVino;

                btn.FlatStyle =
                    FlatStyle.Flat;

                btn.FlatAppearance.BorderColor =
                    colorVino;

                btn.FlatAppearance.BorderSize =
                    1;

                btn.Font =
                    new Font(
                        "Segoe UI",
                        10F,
                        FontStyle.Bold);

                btn.Height =
                    40;

                btn.Cursor =
                    Cursors.Hand;
            }

            // =====================================
            // GRID PRINCIPAL
            // =====================================

            EstilarGrid(dgvHistorial);

            // =====================================
            // GRID DETALLE
            // =====================================

            EstilarGrid(dgvDetalleFactura);
        }

        // =========================================
        // ESTILO GRID
        // =========================================

        void EstilarGrid(
            DataGridView dgv)
        {
            dgv.BackgroundColor =
                Color.White;

            dgv.BorderStyle =
                BorderStyle.None;

            dgv.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.GridColor =
                Color.FromArgb(245, 240, 238);

            dgv.RowHeadersVisible =
                false;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv.MultiSelect =
                false;

            dgv.ReadOnly =
                true;

            dgv.AllowUserToAddRows =
                false;

            dgv.AllowUserToDeleteRows =
                false;

            dgv.AllowUserToResizeRows =
                false;

            dgv.EnableHeadersVisualStyles =
                false;

            dgv.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                colorVino;

            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            dgv.ColumnHeadersHeight =
                45;

            dgv.DefaultCellStyle.BackColor =
                Color.White;

            dgv.DefaultCellStyle.ForeColor =
                colorTexto;

            dgv.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            dgv.DefaultCellStyle.SelectionBackColor =
                colorBeige;

            dgv.DefaultCellStyle.SelectionForeColor =
                colorTexto;

            dgv.RowTemplate.Height =
                42;

            dgv.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 244, 242);
        }
    }
}