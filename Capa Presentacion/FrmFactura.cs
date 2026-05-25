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

     
        private void FrmFacturaPagos_Load(object sender, EventArgs e)
        {


            nudCantidad.ValueChanged += nudCantidad_ValueChanged;
            this.WindowState = FormWindowState.Maximized;
            AplicarDiseno();

            // Eventos buscador
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            btnHistorial.Click += btnHistorial_Click;
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
            {
                if (fila["estado_pago"].ToString() == "Pendiente")
                    cbFiltroFactura.Items.Add(fila["id_factura"].ToString());
            }
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
            DataView vista = facturaBLL.Listar().DefaultView;
            vista.RowFilter = "estado_pago = 'Pendiente'";
            dgvDetalle.DataSource = vista;
            dgvDetalle.Visible = true;
            dgvDetalle.BringToFront();
            OcultarColumnas();
        }

        // =========================
        // BUSCAR / FILTRAR
        // =========================
        void BuscarFacturas()
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
            FrmDetalleFactura frm = new FrmDetalleFactura(idFactura);
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

        bool ValidarCamposActualizar()
        {
            if (cbMetodoPago.SelectedIndex < 0)
            {
                MessageBox.Show("⚠️ Selecciona el método de pago.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMetodoPago.Focus(); return false;
            }
            if (cbEstado.SelectedIndex < 0)
            {
                MessageBox.Show("⚠️ Selecciona el estado.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbEstado.Focus(); return false;
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                Factura f = ObtenerFacturaDesdeCampos();
                int idNuevaFactura = facturaBLL.Guardar(f);

                // Obtener id_servicio desde Detalle_Cita
                int idCita = Convert.ToInt32(cbCita.SelectedValue);
                DataTable dtDetalleCita = new DetalleCitas_BLL().ObtenerPorCita(idCita);

                decimal monto = Convert.ToDecimal(txtMonto.Text);
                int cantidad = Convert.ToInt32(nudCantidad.Value);

                foreach (DataRow fila in dtDetalleCita.Rows)
                {
                    Detalle_Factura detalle = new Detalle_Factura
                    {
                        id_factura = idNuevaFactura,
                        id_servicio = Convert.ToInt32(fila["id_servicio"]),
                        descripcion = txtServicios.Text,
                        cantidad = cantidad,
                        subtotal = monto * cantidad
                    };
                    detalleBLL.Guardar(detalle);
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
        // =========================
        // ACTUALIZAR
        // =========================
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null)
            {
                MessageBox.Show("⚠️ Selecciona una factura de la tabla.", "Sin selección",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarCamposActualizar()) return;  // ← cambio aquí

            try
            {
                Factura f = new Factura
                {
                    id_factura = Convert.ToInt32(dgvDetalle.CurrentRow.Cells["id_factura"].Value),
                    id_cliente = Convert.ToInt32(dgvDetalle.CurrentRow.Cells["id_cliente"].Value),
                    fecha_factura = dtpFecha.Value,
                    total = Convert.ToDecimal(txtMonto.Text),
                    metodo_pago = cbMetodoPago.SelectedItem.ToString(),
                    estado_pago = cbEstado.SelectedItem.ToString()
                };
                facturaBLL.Actualizar(f);

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
        // =========================
        // ELIMINAR
        // =========================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null) return;

            if (MessageBox.Show("¿Eliminar esta factura?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int id = Convert.ToInt32(dgvDetalle.CurrentRow.Cells["id_factura"].Value);

                // Primero eliminar los detalles
                DataTable detalles = detalleBLL.ObtenerPorFactura(id);
                foreach (DataRow fila in detalles.Rows)
                {
                    detalleBLL.Eliminar(Convert.ToInt32(fila["id_detalle_factura"]));
                }

                // Luego eliminar la factura
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

            panelDetalle.BackColor =
                Color.White;

            panelTabla.BackColor =
                Color.White;

            // =========================================
            // TITULO
            // =========================================

            lblTabla.ForeColor =
                colorRosado;

            lblTabla.Font =
                new Font(
                    "Georgia",
                    22,
                    FontStyle.Regular);

            // =========================================
            // LABELS
            // =========================================

            foreach (Label lbl in new[]
            {
        lblCita,
        lblCliente,
        lblServicio,
        lblEmpleado,
        lblMonto,
        lblMetodoPago,
        lblFecha,
        lblEstado,
        lblNotas
    })
            {
                lbl.ForeColor =
                    Color.FromArgb(70, 50, 48);

                lbl.Font =
                    new Font(
                        "Segoe UI",
                        10F,
                        FontStyle.Regular);
            }

            // =========================================
            // COMBOBOX
            // =========================================

            foreach (ComboBox cb in new[]
            {
        cbCita,
        cbMetodoPago,
        cbEstado,
        cbFiltroFactura
    })
            {
                cb.BackColor =
                    Color.White;

                cb.ForeColor =
                    Color.FromArgb(70, 50, 48);

                cb.FlatStyle =
                    FlatStyle.Flat;

                cb.Font =
                    new Font(
                        "Segoe UI",
                        10F,
                        FontStyle.Regular);
            }

            // =========================================
            // TEXTBOXES
            // =========================================

            foreach (TextBox txt in new[]
            {
        txtCliente,
        txtEmpleado,
        txtServicios,
        txtMonto,
        txtNotas,
        txtBuscar
    })
            {
                txt.BackColor =
                    Color.White;

                txt.ForeColor =
                    Color.FromArgb(70, 50, 48);

                txt.BorderStyle =
                    BorderStyle.FixedSingle;

                txt.Font =
                    new Font(
                        "Segoe UI",
                        10F,
                        FontStyle.Regular);
            }

            // =========================================
            // SOLO LECTURA
            // =========================================

            foreach (TextBox txt in new[]
            {
        txtCliente,
        txtEmpleado,
        txtServicios,
        txtMonto
    })
            {
                txt.BackColor =
                    Color.FromArgb(245, 245, 245);

                txt.ForeColor =
                    Color.DimGray;
            }

            // =========================================
            // DATETIMEPICKER
            // =========================================

            dtpFecha.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular);

            // =========================================
            // NUMERICUPDOWN
            // =========================================

            nudCantidad.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular);

            nudCantidad.BackColor =
                Color.White;

            nudCantidad.ForeColor =
                Color.FromArgb(70, 50, 48);

            // =========================================
            // SUBTOTAL
            // =========================================

            lblSubtotal.ForeColor =
                colorRosado;

            lblSubtotal.Font =
                new Font(
                    "Georgia",
                    15F,
                    FontStyle.Bold);

            // =========================================
            // BOTONES
            // =========================================

            Color beige =
                Color.FromArgb(242, 235, 231);

            EstilarBoton(
                btnGuardar,
                colorVino,
                Color.White,
                true);

            EstilarBoton(
                btnActualizar,
                colorVino,
                Color.White,
                true);

            EstilarBoton(
                btnBuscar,
                colorVino,
                Color.White,
                true);

            EstilarBoton(
                btnVerDetalle,
                beige,
                colorRosado,
                true);

            EstilarBoton(
                btnEliminar,
                beige,
                colorRosado);

            EstilarBoton(
                btnLimpiar,
                beige,
                colorRosado);

            EstilarBoton(
                btnHistorial,
                beige,
                colorRosado,
                true);

            btnBuscar.Height = 28;
            btnVerDetalle.Height = 28;

            // =========================================
            // DATAGRIDVIEW
            // =========================================

            dgvDetalle.BackgroundColor =
                Color.White;

            dgvDetalle.BorderStyle =
                BorderStyle.None;

            dgvDetalle.RowHeadersVisible =
                false;

            dgvDetalle.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDetalle.EnableHeadersVisualStyles =
                false;

            dgvDetalle.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(245, 238, 234);

            dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(70, 50, 48);

            dgvDetalle.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            dgvDetalle.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(245, 238, 234);

            dgvDetalle.ColumnHeadersHeight =
                45;

            dgvDetalle.DefaultCellStyle.BackColor =
                Color.White;

            dgvDetalle.DefaultCellStyle.ForeColor =
                Color.FromArgb(70, 50, 48);

            dgvDetalle.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Regular);

            dgvDetalle.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(250, 245, 242);

            dgvDetalle.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(70, 50, 48);

            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 244, 242);

            dgvDetalle.GridColor =
                Color.FromArgb(235, 230, 228);

            dgvDetalle.RowTemplate.Height =
                42;

            dgvDetalle.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDetalle.MultiSelect =
                false;

            dgvDetalle.AllowUserToAddRows =
                false;

            dgvDetalle.AllowUserToDeleteRows =
                false;

            dgvDetalle.AllowUserToResizeRows =
                false;
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            decimal monto = 0;
            decimal.TryParse(txtMonto.Text, out monto);
            lblSubtotal.Text = "RD$ " + (nudCantidad.Value * monto).ToString("N2");
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FrmHistorialFacturas frm = new FrmHistorialFacturas();
            frm.ShowDialog();
        }
    }
}