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
        // =========================
        // COLORES
        // =========================
        private readonly Color colorRosado = Color.RosyBrown;
        private readonly Color colorFondo = Color.FromArgb(250, 248, 246);
        private readonly Color colorVino = Color.RosyBrown;
        private readonly Color colorBeige = Color.FromArgb(242, 235, 231);

        // =========================
        // BLL
        // =========================
        Detalle_FacturaBLL detalleBLL = new Detalle_FacturaBLL();
        FacturaBLL facturaBLL = new FacturaBLL();
        ServiciosBLL servicioBLL = new ServiciosBLL();
        CitasBLL citasBLL = new CitasBLL();

        public FrmFactura() { InitializeComponent(); }

        // =========================
        // LOAD
        // =========================
        private void FrmFacturaPagos_Load(object sender, EventArgs e)
        {

            nudCantidad.ValueChanged += nudCantidad_ValueChanged;
            this.WindowState = FormWindowState.Maximized;
            AplicarDiseno();

            // Eventos buscador
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            btnBuscar.Click += btnBuscar_Click;
            cbFiltroFactura.SelectedIndexChanged += cbFiltroFactura_SelectedIndexChanged;

           

            // Evento grid
            dgvDetalle.CellClick += dgvDetalle_CellClick;

            // Evento botón ver detalle
            btnVerDetalle.Click += btnVerDetalle_Click;

            CargarCitas();
            CargarMetodosPago();
            CargarEstados();
            CargarFiltro();
            MostrarFacturas();
        }

        // =========================
        // CARGAR COMBOS
        // =========================
        void CargarCitas()
        {
            
            cbCita.SelectedIndexChanged -= cbCita_SelectedIndexChanged;

            DataTable dt = citasBLL.Listar();

            DataView vista = dt.DefaultView;
            vista.RowFilter =
                "nombre_estado = 'Completada' " +
                "OR nombre_estado = 'Confirmada'";

            cbCita.DataSource = vista.ToTable();
            cbCita.DisplayMember = "id_cita";
            cbCita.ValueMember = "id_cita";
            cbCita.SelectedIndex = -1;

           
            cbCita.SelectedIndexChanged += cbCita_SelectedIndexChanged;
        }

        void CargarMetodosPago()
        {
            cbMetodoPago.Items.Clear();
            cbMetodoPago.Items.AddRange(new object[]
            {
                "Efectivo",
                "Tarjeta",
                "Transferencia"
            });
            cbMetodoPago.SelectedIndex = -1;
        }

        void CargarEstados()
        {
            cbEstado.Items.Clear();
            cbEstado.Items.AddRange(new object[]
            {
                "Pagado",
                "Pendiente",
                "Cancelado"
            });
            cbEstado.SelectedIndex = 0;
        }

        void CargarFiltro()
        {
            cbFiltroFactura.Items.Clear();
            cbFiltroFactura.Items.Add("Todas");
            DataTable dt = facturaBLL.Listar();
            foreach (DataRow fila in dt.Rows)
                cbFiltroFactura.Items.Add(
                    fila["id_factura"].ToString());
            cbFiltroFactura.SelectedIndex = 0;
        }

        // =========================
        // KEY: SELECCIONAR CITA
        // → RELLENA CAMPOS AUTOMÁTICAMENTE
        // =========================
        private void cbCita_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (cbCita.SelectedValue == null) return;

            int idCita =
                Convert.ToInt32(cbCita.SelectedValue);

            DataTable dt =
                citasBLL.ObtenerPorId(idCita);

            if (dt.Rows.Count == 0) return;

            DataRow fila = dt.Rows[0];

            // Auto-rellenar campos de solo lectura
            txtCliente.Text =
                fila["cliente"].ToString();

            txtEmpleado.Text =
                fila["empleado"].ToString();

            txtServicios.Text =
                fila["servicios"].ToString();

            txtMonto.Text =
                Convert.ToDecimal(
                    fila["precio"]).ToString("N2");
        }

        // =========================
        // MOSTRAR FACTURAS EN GRID
        // =========================
        void MostrarFacturas()
        {
            DataTable dt = facturaBLL.Listar();
            dgvDetalle.DataSource = dt;
            dgvDetalle.Visible = true;
            dgvDetalle.BringToFront();
            OcultarColumnas();
        }

        // =========================
        // BUSCAR / FILTRAR
        // =========================
        void BuscarFacturas()
        {
            DataView vista =
                facturaBLL.Listar().DefaultView;

            string filtro = "";

            if (cbFiltroFactura.SelectedIndex > 0)
                filtro =
                    $"id_factura = {cbFiltroFactura.SelectedItem}";

            string texto = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(texto))
            {
                string tf =
                    $"estado_pago LIKE '%{texto}%'";

                filtro = string.IsNullOrEmpty(filtro)
                    ? tf
                    : filtro + " AND " + tf;
            }

            vista.RowFilter = filtro;
            dgvDetalle.DataSource = vista;
            OcultarColumnas();
        }

        void OcultarColumnas()
        {
            if (dgvDetalle.Columns.Contains("id_cliente"))
                dgvDetalle.Columns["id_cliente"].Visible = false;

            if (dgvDetalle.Columns.Contains("referencia"))
                dgvDetalle.Columns["referencia"].Visible = false;

            if (dgvDetalle.Columns.Contains("notas"))
                dgvDetalle.Columns["notas"].Visible = false;

            dgvDetalle.EnableHeadersVisualStyles = false;
            dgvDetalle.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;
            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = colorVino;
            dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetalle.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI Semibold", 9F);
            dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }

        // =========================
        // EVENTOS BUSCADOR
        // =========================
        private void btnBuscar_Click(
            object sender, EventArgs e) =>
            BuscarFacturas();

        private void txtBuscar_TextChanged(
            object sender, EventArgs e) =>
            BuscarFacturas();

        private void cbFiltroFactura_SelectedIndexChanged(
            object sender, EventArgs e) =>
            BuscarFacturas();

        // =========================
        // CLICK EN GRID
        // → CARGA DATOS PARA EDITAR
        // =========================
        private void dgvDetalle_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila =
                dgvDetalle.Rows[e.RowIndex];

            if (dgvDetalle.Columns.Contains("metodo_pago") &&
                fila.Cells["metodo_pago"].Value != DBNull.Value)
                cbMetodoPago.SelectedItem =
                    fila.Cells["metodo_pago"].Value.ToString();

            if (dgvDetalle.Columns.Contains("estado_pago") &&
                fila.Cells["estado_pago"].Value != DBNull.Value)
                cbEstado.SelectedItem =
                    fila.Cells["estado_pago"].Value.ToString();

            if (dgvDetalle.Columns.Contains("total") &&
                fila.Cells["total"].Value != DBNull.Value)
                txtMonto.Text =
                    Convert.ToDecimal(
                        fila.Cells["total"].Value
                    ).ToString("N2");

            if (dgvDetalle.Columns.Contains("fecha_factura") &&
                fila.Cells["fecha_factura"].Value != DBNull.Value)
                dtpFecha.Value =
                    Convert.ToDateTime(
                        fila.Cells["fecha_factura"].Value);
        }

        // =========================
        // ABRIR DETALLE FACTURA
        // =========================
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una factura primero.");
                return;
            }

            // Toma el ID de la fila seleccionada (ajusta el nombre de la columna)
            int idFactura = Convert.ToInt32(dgvDetalle.SelectedRows[0].Cells["id_factura"].Value);

            FrmDetalleFactura frm = new FrmDetalleFactura();
            frm.ShowDialog();
        }

        // =========================
        // VALIDAR CAMPOS
        // =========================
        bool ValidarCampos()
        {
            if (cbCita.SelectedValue == null)
            {
                MessageBox.Show(
                    "⚠️ Selecciona una cita.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cbCita.Focus();
                return false;
            }

            if (cbMetodoPago.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "⚠️ Selecciona el método de pago.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cbMetodoPago.Focus();
                return false;
            }

            if (cbEstado.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "⚠️ Selecciona el estado.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cbEstado.Focus();
                return false;
            }

            return true;
        }

        // =========================
        // CONSTRUIR OBJETO FACTURA
        // =========================
        Factura ObtenerFacturaDesdeCampos()
        {
            // El id_cliente viene de la cita seleccionada
            int idCita =
                Convert.ToInt32(cbCita.SelectedValue);

            DataTable dt =
                citasBLL.ObtenerPorId(idCita);

            int idCliente =
                Convert.ToInt32(dt.Rows[0]["id_cliente"]);

            decimal total = decimal.TryParse(
                txtMonto.Text,
                out decimal t) ? t : 0;

            return new Factura
            {
                id_cliente = idCliente,
                fecha_factura = dtpFecha.Value,
                total = total,
                metodo_pago =
                    cbMetodoPago.SelectedItem.ToString(),
                estado_pago =
                    cbEstado.SelectedItem.ToString()
            };
        }

        // =========================
        // GUARDAR
        // =========================
        private void btnGuardar_Click(
            object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                Factura f = ObtenerFacturaDesdeCampos();
                facturaBLL.Guardar(f);

                MessageBox.Show(
                    "✅ Pago registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarFiltro();
                MostrarFacturas();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // ACTUALIZAR
        // =========================
        private void btnActualizar_Click(
            object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null)
            {
                MessageBox.Show(
                    "⚠️ Selecciona una factura de la tabla.",
                    "Sin selección",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            try
            {
                Factura f = ObtenerFacturaDesdeCampos();

                f.id_factura = Convert.ToInt32(
                    dgvDetalle.CurrentRow
                               .Cells["id_factura"].Value);

                facturaBLL.Actualizar(f);

                MessageBox.Show(
                    "✅ Factura actualizada.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MostrarFacturas();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // ELIMINAR
        // =========================
        private void btnEliminar_Click(
            object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null) return;

            if (MessageBox.Show(
                "¿Eliminar esta factura?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int id = Convert.ToInt32(
                    dgvDetalle.CurrentRow
                               .Cells["id_factura"].Value);

                facturaBLL.Eliminar(id);

                MessageBox.Show(
                    "🗑 Factura eliminada.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarFiltro();
                MostrarFacturas();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // LIMPIAR
        // =========================
        private void btnLimpiar_Click(
            object sender, EventArgs e) =>
            LimpiarCampos();

        void LimpiarCampos()
        {
            cbCita.SelectedIndex = -1;
            txtCliente.Text = "";
            txtEmpleado.Text = "";
            txtServicios.Text = "";
            txtMonto.Text = "0.00";
            cbMetodoPago.SelectedIndex = -1;
            cbEstado.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Today;
            txtReferencia.Clear();
            txtNotas.Clear();
            dgvDetalle.ClearSelection();
        }

        // =========================
        // DISEÑO
        // =========================
        void EstilarBoton(
            Button btn,
            Color fondo,
            Color texto,
            bool negrita = false)
        {
            btn.BackColor = fondo;
            btn.ForeColor = texto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font(
                "Segoe UI" + (negrita ? " Semibold" : ""),
                10F);
            btn.Height = 40;
            btn.Cursor = Cursors.Hand;
        }

        private void AplicarDiseno()
        {
            this.BackColor = colorFondo;
            panelDetalle.BackColor = Color.White;
            panelTabla.BackColor = Color.White;

            // Título tabla
            lblTabla.ForeColor = colorRosado;
            lblTabla.Font =
                new Font("Segoe UI Semibold", 20F, FontStyle.Bold);

            // Labels del formulario
            foreach (Label lbl in new[]
            {
                lblCita, lblCliente, lblServicios,
                lblEmpleado, lblMonto, lblMetodoPago,
                lblFecha, lblEstado, lblReferencia, lblNotas
            })
            {
                lbl.ForeColor = Color.Black;
                lbl.Font = new Font("Segoe UI", 9F);
            }

            // Combos editables
            foreach (ComboBox cb in new[]
            { cbCita, cbMetodoPago, cbEstado })
            {
                cb.BackColor = Color.White;
                cb.ForeColor = Color.Black;
                cb.FlatStyle = FlatStyle.Flat;
                cb.Font = new Font("Segoe UI", 9F);
            }

            // Campos readonly (fondo gris claro)
            foreach (TextBox txt in new[]
            { txtCliente, txtEmpleado, txtServicios, txtMonto })
            {
                txt.BackColor =
                    Color.FromArgb(245, 245, 245);
                txt.ForeColor = Color.DimGray;
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 9F);
            }

            // Campos editables
            foreach (TextBox txt in new[]
            { txtReferencia, txtNotas })
            {
                txt.BackColor = Color.White;
                txt.ForeColor = Color.Black;
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 9F);
            }

            // DateTimePicker
            dtpFecha.Font = new Font("Segoe UI", 9F);

            // Buscador
            txtBuscar.BackColor = Color.White;
            txtBuscar.ForeColor = Color.Gray;
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.Font = new Font("Segoe UI", 9F);

            cbFiltroFactura.BackColor = Color.White;
            cbFiltroFactura.ForeColor = Color.Black;
            cbFiltroFactura.FlatStyle = FlatStyle.Flat;
            cbFiltroFactura.Font = new Font("Segoe UI", 9F);

            // Botones
            EstilarBoton(btnGuardar, colorVino, Color.White, negrita: true);
            EstilarBoton(btnActualizar, colorVino, Color.White, negrita: true);
            EstilarBoton(btnEliminar, colorBeige, colorRosado);
            EstilarBoton(btnLimpiar, colorBeige, colorRosado);
            EstilarBoton(btnBuscar, colorVino, Color.White, negrita: true);
            EstilarBoton(btnVerDetalle, colorBeige, colorRosado, negrita: true);
            btnBuscar.Height = 28;
            btnVerDetalle.Height = 28;

            // Grid
            dgvDetalle.BackgroundColor = Color.White;
            dgvDetalle.BorderStyle = BorderStyle.None;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ColumnHeadersHeight = 38;
            dgvDetalle.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);
            dgvDetalle.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(230, 210, 215);
            dgvDetalle.DefaultCellStyle.SelectionForeColor =
                Color.Black;
            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 244, 242);
            dgvDetalle.GridColor =
                Color.FromArgb(235, 230, 228);
            dgvDetalle.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.MultiSelect = false;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;

            dgvDetalle.DataBindingComplete += (s, ev) =>
            {
                dgvDetalle.EnableHeadersVisualStyles = false;
                dgvDetalle.ColumnHeadersBorderStyle =
                    DataGridViewHeaderBorderStyle.None;
                dgvDetalle.ColumnHeadersDefaultCellStyle
                    .BackColor = colorVino;
                dgvDetalle.ColumnHeadersDefaultCellStyle
                    .ForeColor = Color.White;
                dgvDetalle.ColumnHeadersDefaultCellStyle
                    .Font =
                    new Font("Segoe UI Semibold", 9F);
                dgvDetalle.ColumnHeadersDefaultCellStyle
                    .Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            };
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            decimal monto = 0;
            decimal.TryParse(txtMonto.Text, out monto);
            lblSubtotal.Text = "RD$ " + (nudCantidad.Value * monto).ToString("N2");
        }
    }
}