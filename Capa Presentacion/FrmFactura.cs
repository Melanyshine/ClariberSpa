using CapaEntidades;
using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    public partial class FrmFactura : Form
    {
        // =====================================================================
        // CONSTANTES DE COLOR
        // =====================================================================

        private readonly Color COLOR_VINO = Color.RosyBrown;
        private readonly Color COLOR_ROSADO = Color.RosyBrown;
        private readonly Color COLOR_FONDO = Color.FromArgb(250, 248, 246);
        private readonly Color COLOR_BEIGE = Color.FromArgb(242, 235, 231);
        private readonly Color COLOR_BORDE_SECUNDARIO = Color.FromArgb(217, 200, 195);

        // =====================================================================
        // CAPA DE NEGOCIO
        // =====================================================================

        private readonly Detalle_FacturaBLL detalleBLL = new Detalle_FacturaBLL();
        private readonly FacturaBLL facturaBLL = new FacturaBLL();
        private readonly ServiciosBLL servicioBLL = new ServiciosBLL();
        private readonly CitasBLL citasBLL = new CitasBLL();

        // =====================================================================
        // CONSTRUCTOR
        // =====================================================================

        public FrmFactura()
        {
            InitializeComponent();
        }

        // =====================================================================
        // CARGA DEL FORMULARIO
        // =====================================================================

        private void FrmFacturaPagos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            AplicarDiseno();
            SuscribirEventos();

            CargarCitas();
            CargarMetodosPago();
            CargarEstados();
            CargarFiltro();
            MostrarFacturas();
        }

        private void SuscribirEventos()
        {
            nudCantidad.ValueChanged += nudCantidad_ValueChanged;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            cbFiltroFactura.SelectedIndexChanged += cbFiltroFactura_SelectedIndexChanged;
            dgvDetalle.CellClick += dgvDetalle_CellClick;
            btnBuscar.Click += btnBuscar_Click;
            btnHistorial.Click += btnHistorial_Click;
            btnVerDetalle.Click += btnVerDetalle_Click;
        }

        // =====================================================================
        // CARGA DE COMBOS
        // =====================================================================

        private void CargarCitas()
        {
            cbCita.SelectedIndexChanged -= cbCita_SelectedIndexChanged;

            DataTable dt = citasBLL.Listar();
            DataView vista = dt.DefaultView;
            vista.RowFilter = "nombre_estado = 'Completada' OR nombre_estado = 'Confirmada'";

            cbCita.DataSource = vista.ToTable();
            cbCita.DisplayMember = "id_cita";
            cbCita.ValueMember = "id_cita";
            cbCita.SelectedIndex = -1;

            cbCita.SelectedIndexChanged += cbCita_SelectedIndexChanged;
        }

        private void CargarMetodosPago()
        {
            cbMetodoPago.Items.Clear();
            cbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cbMetodoPago.SelectedIndex = -1;
        }

        private void CargarEstados()
        {
            cbEstado.Items.Clear();
            cbEstado.Items.AddRange(new object[] { "Pagado", "Pendiente", "Cancelado" });
            cbEstado.SelectedIndex = 0;
        }

        private void CargarFiltro()
        {
            cbFiltroFactura.Items.Clear();
            cbFiltroFactura.Items.Add("Todas");

            DataTable dt = facturaBLL.Listar();
            foreach (DataRow fila in dt.Rows)
                if (fila["estado_pago"].ToString() == "Pendiente")
                    cbFiltroFactura.Items.Add(fila["id_factura"].ToString());

            cbFiltroFactura.SelectedIndex = 0;
        }

        // =====================================================================
        // EVENTO: SELECCIONAR CITA → AUTO-RELLENA CAMPOS
        // =====================================================================

        private void cbCita_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCita.SelectedValue == null) return;

            int idCita = Convert.ToInt32(cbCita.SelectedValue);
            DataTable dt = citasBLL.ObtenerPorId(idCita);

            if (dt.Rows.Count == 0) return;

            DataRow fila = dt.Rows[0];

            txtCliente.Text = fila["cliente"].ToString();
            txtEmpleado.Text = fila["empleado"].ToString();
            txtServicios.Text = fila["servicios"].ToString();
            txtMonto.Text = Convert.ToDecimal(fila["precio"]).ToString("N2");
        }

        // =====================================================================
        // MOSTRAR / BUSCAR FACTURAS
        // =====================================================================

        private void MostrarFacturas()
        {
            DataView vista = facturaBLL.Listar().DefaultView;
            vista.RowFilter = "estado_pago = 'Pendiente'";
            dgvDetalle.DataSource = vista;
            dgvDetalle.Visible = true;
            dgvDetalle.BringToFront();
            OcultarColumnas();
        }

        private void BuscarFacturas()
        {
            DataView vista = facturaBLL.Listar().DefaultView;
            string filtro = "estado_pago = 'Pendiente'";

            if (cbFiltroFactura.SelectedIndex > 0)
                filtro += $" AND id_factura = {cbFiltroFactura.SelectedItem}";

            string texto = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
                filtro += $" AND cliente LIKE '%{texto}%'";

            vista.RowFilter = filtro;
            dgvDetalle.DataSource = vista;
            OcultarColumnas();
        }

        private void OcultarColumnas()
        {
            if (dgvDetalle.Columns.Contains("id_cliente"))
                dgvDetalle.Columns["id_cliente"].Visible = false;
            if (dgvDetalle.Columns.Contains("referencia"))
                dgvDetalle.Columns["referencia"].Visible = false;
            if (dgvDetalle.Columns.Contains("notas"))
                dgvDetalle.Columns["notas"].Visible = false;

            dgvDetalle.EnableHeadersVisualStyles = false;
            dgvDetalle.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = COLOR_VINO;
            dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F);
            dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // =====================================================================
        // EVENTOS DE BÚSQUEDA
        // =====================================================================

        private void btnBuscar_Click(object sender, EventArgs e) => BuscarFacturas();
        private void txtBuscar_TextChanged(object sender, EventArgs e) => BuscarFacturas();
        private void cbFiltroFactura_SelectedIndexChanged(object sender, EventArgs e) => BuscarFacturas();

        // =====================================================================
        // EVENTO: CLICK EN GRID → CARGA DATOS PARA EDITAR
        // =====================================================================

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvDetalle.Rows[e.RowIndex];

            if (dgvDetalle.Columns.Contains("metodo_pago") && fila.Cells["metodo_pago"].Value != DBNull.Value)
                cbMetodoPago.SelectedItem = fila.Cells["metodo_pago"].Value.ToString();

            if (dgvDetalle.Columns.Contains("estado_pago") && fila.Cells["estado_pago"].Value != DBNull.Value)
                cbEstado.SelectedItem = fila.Cells["estado_pago"].Value.ToString();

            if (dgvDetalle.Columns.Contains("total") && fila.Cells["total"].Value != DBNull.Value)
                txtMonto.Text = Convert.ToDecimal(fila.Cells["total"].Value).ToString("N2");

            if (dgvDetalle.Columns.Contains("fecha_factura") && fila.Cells["fecha_factura"].Value != DBNull.Value)
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["fecha_factura"].Value);
        }

        // =====================================================================
        // ABRIR DETALLE DE FACTURA
        // =====================================================================

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una factura primero.");
                return;
            }

            int idFactura = Convert.ToInt32(dgvDetalle.SelectedRows[0].Cells["id_factura"].Value);
            new FrmDetalleFactura(idFactura).ShowDialog();
        }

        // =====================================================================
        // VALIDACIONES
        // =====================================================================

        private bool ValidarCampos()
        {
            if (cbCita.SelectedValue == null)
            {
                MessageBox.Show("⚠️ Selecciona una cita.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCita.Focus();
                return false;
            }
            if (cbMetodoPago.SelectedIndex < 0)
            {
                MessageBox.Show("⚠️ Selecciona el método de pago.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMetodoPago.Focus();
                return false;
            }
            if (cbEstado.SelectedIndex < 0)
            {
                MessageBox.Show("⚠️ Selecciona el estado.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbEstado.Focus();
                return false;
            }
            return true;
        }

        private bool ValidarCamposActualizar()
        {
            if (cbMetodoPago.SelectedIndex < 0)
            {
                MessageBox.Show("⚠️ Selecciona el método de pago.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMetodoPago.Focus();
                return false;
            }
            if (cbEstado.SelectedIndex < 0)
            {
                MessageBox.Show("⚠️ Selecciona el estado.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbEstado.Focus();
                return false;
            }
            return true;
        }

        // =====================================================================
        // CONSTRUIR OBJETO FACTURA DESDE CAMPOS
        // =====================================================================

        private Factura ObtenerFacturaDesdeCampos()
        {
            int idCita = Convert.ToInt32(cbCita.SelectedValue);
            DataTable dt = citasBLL.ObtenerPorId(idCita);
            int idCliente = Convert.ToInt32(dt.Rows[0]["id_cliente"]);
            decimal total = decimal.TryParse(txtMonto.Text, out decimal t) ? t : 0;

            return new Factura
            {
                id_cliente = idCliente,
                fecha_factura = dtpFecha.Value,
                total = total,
                metodo_pago = cbMetodoPago.SelectedItem.ToString(),
                estado_pago = cbEstado.SelectedItem.ToString()
            };
        }

        // =====================================================================
        // CRUD: GUARDAR
        // =====================================================================

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                Factura f = ObtenerFacturaDesdeCampos();
                int idNuevaFactura = facturaBLL.Guardar(f);

                int idCita = Convert.ToInt32(cbCita.SelectedValue);
                DataTable dtDetalleCita = new DetalleCitas_BLL().ObtenerPorCita(idCita);
                decimal monto = Convert.ToDecimal(txtMonto.Text);
                int cantidad = Convert.ToInt32(nudCantidad.Value);

                foreach (DataRow fila in dtDetalleCita.Rows)
                {
                    detalleBLL.Guardar(new Detalle_Factura
                    {
                        id_factura = idNuevaFactura,
                        id_servicio = Convert.ToInt32(fila["id_servicio"]),
                        descripcion = txtServicios.Text,
                        cantidad = cantidad,
                        subtotal = monto * cantidad
                    });
                }

                MessageBox.Show("✅ Pago registrado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarFiltro();
                MostrarFacturas();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // CRUD: ACTUALIZAR
        // =====================================================================

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null)
            {
                MessageBox.Show("⚠️ Selecciona una factura de la tabla.", "Sin selección",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarCamposActualizar()) return;

            try
            {
                facturaBLL.Actualizar(new Factura
                {
                    id_factura = Convert.ToInt32(dgvDetalle.CurrentRow.Cells["id_factura"].Value),
                    id_cliente = Convert.ToInt32(dgvDetalle.CurrentRow.Cells["id_cliente"].Value),
                    fecha_factura = dtpFecha.Value,
                    total = Convert.ToDecimal(txtMonto.Text),
                    metodo_pago = cbMetodoPago.SelectedItem.ToString(),
                    estado_pago = cbEstado.SelectedItem.ToString()
                });

                MessageBox.Show("✅ Factura actualizada.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarFacturas();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // CRUD: ELIMINAR
        // =====================================================================

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null) return;

            if (MessageBox.Show("¿Eliminar esta factura?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int id = Convert.ToInt32(dgvDetalle.CurrentRow.Cells["id_factura"].Value);

                DataTable detalles = detalleBLL.ObtenerPorFactura(id);
                foreach (DataRow fila in detalles.Rows)
                    detalleBLL.Eliminar(Convert.ToInt32(fila["id_detalle_factura"]));

                facturaBLL.Eliminar(id);

                MessageBox.Show("🗑 Factura eliminada.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarFiltro();
                MostrarFacturas();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // LIMPIAR CAMPOS
        // =====================================================================

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();

        private void LimpiarCampos()
        {
            cbCita.SelectedIndex = -1;
            txtCliente.Text = "";
            txtEmpleado.Text = "";
            txtServicios.Text = "";
            txtMonto.Text = "0.00";
            cbMetodoPago.SelectedIndex = -1;
            cbEstado.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Today;
            txtNotas.Clear();
            dgvDetalle.ClearSelection();
        }

        // =====================================================================
        // HISTORIAL
        // =====================================================================

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            new FrmHistorialFacturas().ShowDialog();
        }

        // =====================================================================
        // SUBTOTAL EN TIEMPO REAL
        // =====================================================================

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            decimal.TryParse(txtMonto.Text, out decimal monto);
            lblSubtotal.Text = "RD$ " + (nudCantidad.Value * monto).ToString("N2");
        }

        // =====================================================================
        // DISEÑO VISUAL
        // =====================================================================

        private void AplicarDiseno()
        {
            this.BackColor = COLOR_FONDO;

            panelDetalle.BackColor = Color.White;
            panelTabla.BackColor = Color.White;

            AgregarSombraPanel(panelDetalle);
            AgregarSombraPanel(panelTabla);

            AplicarEstiloTitulo();
            AplicarEstiloLabels();
            AplicarEstiloCombos();
            AplicarEstiloTextBoxes();
            AplicarEstiloControlesExtra();
            AplicarEstiloBotones();
            AplicarEstiloDataGrid();
        }

        // --- Título -----------------------------------------------------------

        private void AplicarEstiloTitulo()
        {
            lblTabla.ForeColor = COLOR_ROSADO;
            lblTabla.Font = new Font("Georgia", 22, FontStyle.Regular);
        }

        // --- Labels -----------------------------------------------------------

        private void AplicarEstiloLabels()
        {
            var labels = new[] { lblCita, lblCliente, lblServicio, lblEmpleado,
                                 lblMonto, lblMetodoPago, lblFecha, lblEstado, lblNotas };
            foreach (Label lbl in labels)
            {
                lbl.ForeColor = Color.FromArgb(70, 50, 48);
                lbl.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }
        }

        // --- ComboBoxes -------------------------------------------------------

        private void AplicarEstiloCombos()
        {
            var combos = new[] { cbCita, cbMetodoPago, cbEstado, cbFiltroFactura };
            foreach (ComboBox cb in combos)
            {
                cb.BackColor = Color.White;
                cb.ForeColor = Color.FromArgb(70, 50, 48);
                cb.FlatStyle = FlatStyle.Flat;
                cb.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }
        }

        // --- TextBoxes --------------------------------------------------------

        private void AplicarEstiloTextBoxes()
        {
            var todos = new[] { txtCliente, txtEmpleado, txtServicios, txtMonto, txtNotas, txtBuscar };
            foreach (TextBox txt in todos)
            {
                txt.BackColor = Color.White;
                txt.ForeColor = Color.FromArgb(70, 50, 48);
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }

            // Solo lectura → fondo gris claro
            var soloLectura = new[] { txtCliente, txtEmpleado, txtServicios, txtMonto };
            foreach (TextBox txt in soloLectura)
            {
                txt.BackColor = Color.FromArgb(245, 245, 245);
                txt.ForeColor = Color.DimGray;
            }
        }

        // --- Controles extra --------------------------------------------------

        private void AplicarEstiloControlesExtra()
        {
            dtpFecha.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            nudCantidad.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            nudCantidad.BackColor = Color.White;
            nudCantidad.ForeColor = Color.FromArgb(70, 50, 48);

            lblSubtotal.ForeColor = COLOR_ROSADO;
            lblSubtotal.Font = new Font("Georgia", 12F, FontStyle.Bold);
        }

        // --- Botones ----------------------------------------------------------

        private void AplicarEstiloBotones()
        {
            // Primarios (vino sólido, sin borde externo)
            EstilarBoton(btnGuardar, COLOR_VINO, Color.White, negrita: true, primario: true);
            EstilarBoton(btnActualizar, COLOR_VINO, Color.White, negrita: true, primario: true);
            EstilarBoton(btnBuscar, COLOR_VINO, Color.White, negrita: true, primario: true);

            // Secundarios (beige con borde visible)
            EstilarBoton(btnVerDetalle, COLOR_BEIGE, COLOR_ROSADO, negrita: true, primario: false);
            EstilarBoton(btnEliminar, COLOR_BEIGE, COLOR_ROSADO, negrita: false, primario: false);
            EstilarBoton(btnLimpiar, COLOR_BEIGE, COLOR_ROSADO, negrita: false, primario: false);
            EstilarBoton(btnHistorial, COLOR_BEIGE, COLOR_ROSADO, negrita: true, primario: false);

            // Tamaños especiales
            btnBuscar.Height = 28;
            btnVerDetalle.Height = 28;

            // Padding horizontal
            foreach (Button b in new[] { btnGuardar, btnActualizar, btnEliminar, btnLimpiar, btnHistorial })
                b.Padding = new Padding(8, 0, 8, 0);
        }

        private void EstilarBoton(Button btn, Color fondo, Color texto,
                                   bool negrita = false, bool primario = false)
        {
            btn.BackColor = fondo;
            btn.ForeColor = texto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 9F, negrita ? FontStyle.Bold : FontStyle.Regular);
            btn.Height = 34;
            btn.Cursor = Cursors.Hand;

            if (primario)
            {
                btn.FlatAppearance.BorderColor = ControlPaint.Dark(fondo, 0.15f);
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseOverBackColor = ControlPaint.Dark(fondo, 0.08f);
                btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(fondo, 0.18f);
            }
            else
            {
                btn.FlatAppearance.BorderColor = COLOR_BORDE_SECUNDARIO;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 220, 216);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(215, 205, 200);
            }
        }

        // --- DataGridView -----------------------------------------------------

        private void AplicarEstiloDataGrid()
        {
            dgvDetalle.BackgroundColor = Color.White;
            dgvDetalle.BorderStyle = BorderStyle.None;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.GridColor = Color.FromArgb(235, 230, 228);
            dgvDetalle.RowTemplate.Height = 42;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.MultiSelect = false;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AllowUserToResizeRows = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cabecera
            dgvDetalle.EnableHeadersVisualStyles = false;
            dgvDetalle.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDetalle.ColumnHeadersHeight = 45;
            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 238, 234);
            dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 50, 48);
            dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDetalle.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 238, 234);
            dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Celdas normales
            dgvDetalle.DefaultCellStyle.BackColor = Color.White;
            dgvDetalle.DefaultCellStyle.ForeColor = Color.FromArgb(70, 50, 48);
            dgvDetalle.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvDetalle.DefaultCellStyle.SelectionBackColor = Color.FromArgb(250, 245, 242);
            dgvDetalle.DefaultCellStyle.SelectionForeColor = Color.FromArgb(70, 50, 48);

            // Filas alternas
            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 244, 242);
        }

        // --- Sombra en paneles ------------------------------------------------

        private void AgregarSombraPanel(Panel panel)
        {
            panel.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                var rc = panel.ClientRectangle;

                for (int i = 4; i >= 1; i--)
                {
                    var rcSombra = new Rectangle(
                        rc.X + i, rc.Y + i,
                        rc.Width - i * 2,
                        rc.Height - i * 2);

                    using (var pen = new Pen(Color.FromArgb(12 * i, 0, 0, 0), 1))
                        g.DrawRectangle(pen, rcSombra);
                }
            };
        }
    }
}